using HMS.Database;
using HMS.Models;

namespace HMS.Forms
{//CHECK IN/CHECK OUT OPERATIONS_MANAGE RESERVED OR CHECKED IN GUESTS
    public partial class CheckInOutForm : Form
    {
        private readonly User _user;
        private readonly BookingRepository _bookRepo = new();
        private readonly RoomRepository _roomRepo = new();
        private Booking? _selected;

        public CheckInOutForm(User user)
        {
            _user = user;
            InitializeComponent();
            LoadTab();
        }

        private void LoadTab()
        {
            if (tabControl.SelectedIndex == 0) LoadReserved();
            else LoadCheckedIn();
        }
//LOAD RESERVED BOOKINGS
        private void LoadReserved()
        {
            try
            {
                var list = _bookRepo.GetAll().Where(b => b.Status == "Reserved").ToList();
                dgvReserved.Rows.Clear();
                foreach (var b in list)
                    dgvReserved.Rows.Add(b.BookingId, b.CustomerName, b.RoomNumber, b.RoomType,
                        b.CheckInDate.ToString("dd/MM/yyyy"), b.CheckOutDate.ToString("dd/MM/yyyy"),
                        b.Nights, $"Rs. {b.TotalAmount:N0}", $"Rs. {b.PaidAmount:N0}", b.Status);
                lblReservedCount.Text = $"Reserved Bookings: {list.Count}";
            }
            catch { }
        }
//LOAD CHECKED IN GUESTS FOR CHECK OUT
        private void LoadCheckedIn()
        {
            try
            {
                var list = _bookRepo.GetCheckedIn();
                dgvCheckedIn.Rows.Clear();
                foreach (var b in list)
                    dgvCheckedIn.Rows.Add(b.BookingId, b.CustomerName, b.RoomNumber, b.RoomType,
                        b.CheckInDate.ToString("dd/MM/yyyy"), b.CheckOutDate.ToString("dd/MM/yyyy"),
                        b.ActualCheckIn?.ToString("dd/MM/yyyy HH:mm") ?? "",
                        b.Nights, $"Rs. {b.TotalAmount:N0}", $"Rs. {b.Balance:N0}");
                lblCheckedInCount.Text = $"Currently Checked-In: {list.Count}";
            }
            catch { }
        }

        private void dgvReserved_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReserved.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvReserved.CurrentRow.Cells[0].Value);
            _selected = _bookRepo.GetById(id);
            UpdateDetails(_selected);
        }

        private void dgvCheckedIn_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCheckedIn.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvCheckedIn.CurrentRow.Cells[0].Value);
            _selected = _bookRepo.GetById(id);
            UpdateDetails(_selected);
        }
//UPDATE DETAILS OF SELECTED BOOKING
        private void UpdateDetails(Booking? b)
        {
            if (b == null) { pnlDetails.Visible = false; return; }
            pnlDetails.Visible = true;
            lblDetBookingId.Text = $"Booking #: {b.BookingId}";
            lblDetCustomer.Text = $"Customer: {b.CustomerName}";
            lblDetRoom.Text = $"Room: {b.RoomNumber} ({b.RoomType})";
            lblDetCheckIn.Text = $"Check-In: {b.CheckInDate:dd/MM/yyyy}";
            lblDetCheckOut.Text = $"Check-Out: {b.CheckOutDate:dd/MM/yyyy}";
            lblDetNights.Text = $"Nights: {b.Nights}";
            lblDetTotal.Text = $"Total: Rs. {b.TotalAmount:N0}";
            lblDetPaid.Text = $"Paid: Rs. {b.PaidAmount:N0}";
            lblDetBalance.Text = $"Balance: Rs. {b.Balance:N0}";
            lblDetStatus.Text = $"Status: {b.Status}";

            btnCheckIn.Enabled = b.Status == "Reserved";
            btnCheckOut.Enabled = b.Status == "Checked-In";
        }
//ROOM STATUS OCCUPIED WHEN CUSTOMER CHECKED IN
        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (_selected == null || _selected.Status != "Reserved") return;
            if (MessageBox.Show($"Confirm Check-In for {_selected.CustomerName} - Room {_selected.RoomNumber}?",
                "Confirm Check-In", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _bookRepo.CheckIn(_selected.BookingId);
                _roomRepo.UpdateStatus(_selected.RoomId, "Occupied");
                MessageBox.Show("Check-In successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _selected = null; pnlDetails.Visible = false;
                LoadReserved(); LoadCheckedIn();
            }
        }
//Room AVAILABLE WHEN CUSTOMER CHECKED OUT
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (_selected == null || _selected.Status != "Checked-In") return;
            if (MessageBox.Show($"Confirm Check-Out for {_selected.CustomerName} - Room {_selected.RoomNumber}?",
                "Confirm Check-Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _bookRepo.CheckOut(_selected.BookingId);
                _roomRepo.UpdateStatus(_selected.RoomId, "Available");
                MessageBox.Show("Check-Out successful! Please generate a bill.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _selected = null; pnlDetails.Visible = false;
                LoadReserved(); LoadCheckedIn();
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e) => LoadTab();
        private void btnRefresh_Click(object sender, EventArgs e) => LoadTab();
    }
}
