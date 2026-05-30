using HMS.Database;
using HMS.Models;

namespace HMS.Forms
{
    public partial class BookingForm : Form
    {
        private readonly User _user;
        private readonly BookingRepository _bookRepo = new();
        private readonly CustomerRepository _custRepo = new();
        private readonly RoomRepository _roomRepo = new();
        private Booking? _selected;

        public BookingForm(User user)
        {
            _user = user;
            InitializeComponent();
            LoadCombos();
            LoadBookings();
        }

        private void LoadCombos()
        {
            cmbCustomer.Items.Clear();
            foreach (var c in _custRepo.GetAll())
                cmbCustomer.Items.Add(new ComboItem(c.CustomerId, $"{c.FullName} ({c.Phone})"));
            if (cmbCustomer.Items.Count > 0) cmbCustomer.SelectedIndex = 0;

            cmbRoom.Items.Clear();
            foreach (var r in _roomRepo.GetAvailable())
                cmbRoom.Items.Add(new ComboItem(r.RoomId, $"Room {r.RoomNumber} - {r.RoomType} - Rs.{r.PricePerNight:N0}/night"));
            if (cmbRoom.Items.Count > 0) { cmbRoom.SelectedIndex = 0; CalculateTotal(); }

            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(Booking.Statuses);
            cmbStatus.SelectedIndex = 0;
        }

        private void LoadBookings()
        {
            try
            {
                string filter = cmbFilter.SelectedItem?.ToString() ?? "All";
                var list = _bookRepo.GetAll();
                if (filter != "All") list = list.Where(b => b.Status == filter).ToList();
                dgvBookings.Rows.Clear();
                foreach (var b in list)
                    dgvBookings.Rows.Add(b.BookingId, b.CustomerName, b.RoomNumber, b.RoomType,
                        b.CheckInDate.ToString("dd/MM/yyyy"), b.CheckOutDate.ToString("dd/MM/yyyy"),
                        b.Nights, b.Adults, b.Status,
                        $"Rs. {b.TotalAmount:N0}", $"Rs. {b.PaidAmount:N0}", $"Rs. {b.Balance:N0}");
                lblCount.Text = $"Bookings: {list.Count}";
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void CalculateTotal()
        {
            if (cmbRoom.SelectedItem is not ComboItem ci) return;
            var room = _roomRepo.GetById(ci.Id);
            if (room == null) return;
            int nights = Math.Max(1, (int)(dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).TotalDays);
            decimal total = room.PricePerNight * nights;
            lblTotal.Text = $"Total: Rs. {total:N0}  ({nights} nights × Rs. {room.PricePerNight:N0})";
            txtTotalAmount.Text = total.ToString("N0");
        }

        private void ClearForm()
        {
            if (cmbCustomer.Items.Count > 0) cmbCustomer.SelectedIndex = 0;
            dtpCheckIn.Value  = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);
            nudAdults.Value   = 1;
            cmbStatus.SelectedIndex = 0;
            txtTotalAmount.Text = "0";
            txtPaidAmount.Text  = "0";
            txtNotes.Clear();
            _selected = null;
            btnSave.Text = "Add Booking";
            lblTotal.Text = "Select room and dates above";
            LoadCombos();
        }

        private void dgvBookings_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBookings.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvBookings.CurrentRow.Cells[0].Value);
            _selected = _bookRepo.GetById(id);
            if (_selected == null) return;

            SelectCombo(cmbCustomer, _selected.CustomerId);

            // Reload room combo including current room
            cmbRoom.Items.Clear();
            var currentRoom = _roomRepo.GetById(_selected.RoomId);
            if (currentRoom != null)
                cmbRoom.Items.Add(new ComboItem(currentRoom.RoomId,
                    $"Room {currentRoom.RoomNumber} - {currentRoom.RoomType} - Rs.{currentRoom.PricePerNight:N0}/night"));
            foreach (var r in _roomRepo.GetAvailable())
                if (!cmbRoom.Items.Cast<ComboItem>().Any(ci => ci.Id == r.RoomId))
                    cmbRoom.Items.Add(new ComboItem(r.RoomId,
                        $"Room {r.RoomNumber} - {r.RoomType} - Rs.{r.PricePerNight:N0}/night"));
            SelectCombo(cmbRoom, _selected.RoomId);

            dtpCheckIn.Value  = _selected.CheckInDate;
            dtpCheckOut.Value = _selected.CheckOutDate;
            nudAdults.Value   = _selected.Adults;
            cmbStatus.SelectedItem = _selected.Status;
            txtTotalAmount.Text = _selected.TotalAmount.ToString("N0");
            txtPaidAmount.Text  = _selected.PaidAmount.ToString("N0");
            txtNotes.Text       = _selected.Notes ?? "";
            btnSave.Text        = "Update Booking";
            lblTotal.Text       = $"Total: Rs. {_selected.TotalAmount:N0}  ({_selected.Nights} nights)";
        }

        private void SelectCombo(ComboBox cmb, int id)
        {
            for (int i = 0; i < cmb.Items.Count; i++)
                if (cmb.Items[i] is ComboItem ci && ci.Id == id) { cmb.SelectedIndex = i; return; }
        }

        private decimal ParseAmount(TextBox tb)
        {
            string clean = tb.Text.Replace(",", "").Replace("Rs.", "").Trim();
            return decimal.TryParse(clean, out var v) ? v : 0m;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedItem is not ComboItem cust)
            { MessageBox.Show("Please select a customer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (cmbRoom.SelectedItem is not ComboItem room)
            { MessageBox.Show("Please select a room.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (dtpCheckOut.Value.Date <= dtpCheckIn.Value.Date)
            { MessageBox.Show("Check-out date must be after check-in date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            decimal total = ParseAmount(txtTotalAmount);
            decimal paid  = ParseAmount(txtPaidAmount);
            if (paid > total) { MessageBox.Show("Paid amount cannot exceed total amount.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var b = new Booking
            {
                CustomerId   = cust.Id,
                RoomId       = room.Id,
                CheckInDate  = dtpCheckIn.Value.Date,
                CheckOutDate = dtpCheckOut.Value.Date,
                Adults       = (int)nudAdults.Value,
                Children     = 0,
                Status       = cmbStatus.SelectedItem?.ToString() ?? "Reserved",
                TotalAmount  = total,
                PaidAmount   = paid,
                Notes        = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim(),
                CreatedBy    = _user.UserId
            };

            bool ok;
            if (_selected == null)
            {
                int newId = _bookRepo.Add(b);
                ok = newId > 0;
                if (ok)
                {
                    if (b.Status == "Checked-In")  _roomRepo.UpdateStatus(b.RoomId, "Occupied");
                    else if (b.Status == "Reserved") _roomRepo.UpdateStatus(b.RoomId, "Reserved");
                }
            }
            else
            {
                b.BookingId = _selected.BookingId;
                ok = _bookRepo.Update(b);
            }

            MessageBox.Show(ok ? "Booking saved successfully!" : "Operation failed.",
                ok ? "Success" : "Error", MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            ClearForm();
            LoadBookings();
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            { MessageBox.Show("Select a booking from the list first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (_selected.Status == "Checked-Out")
            { MessageBox.Show("This booking is already checked out.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (MessageBox.Show($"Cancel booking #{_selected.BookingId} for {_selected.CustomerName}?",
                "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _bookRepo.Cancel(_selected.BookingId);
                _roomRepo.UpdateStatus(_selected.RoomId, "Available");
                ClearForm();
                LoadBookings();
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();
        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e) => CalculateTotal();
        private void dtpCheckIn_ValueChanged(object sender, EventArgs e) => CalculateTotal();
        private void dtpCheckOut_ValueChanged(object sender, EventArgs e) => CalculateTotal();
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e) => LoadBookings();
    }

    // Shared helper class used by BookingForm and BillingForm
    class ComboItem
    {
        public int Id { get; }
        private string Label { get; }
        public ComboItem(int id, string label) { Id = id; Label = label; }
        public override string ToString() => Label;
    }
}
