using HMS.Database;
using HMS.Models;

namespace HMS.Forms
{
    public partial class BillingForm : Form
    {
        private readonly User              _user;
        private readonly BillRepository    _billRepo  = new();
        private readonly BookingRepository _bookRepo  = new();
        private readonly MainForm?         _mainForm;        // reference to refresh dashboard
        private Bill?    _selectedBill;
        private Booking? _selectedBooking;
        private bool     _loading = false;

        // Constructor receives MainForm reference
        public BillingForm(User user, MainForm? mainForm = null)
        {
            _user     = user;
            _mainForm = mainForm;
            InitializeComponent();
            LoadBookingsCombo();
            LoadBills();
        }

        // ── Load Bookings Dropdown ───────────────────────────────────────────
        private void LoadBookingsCombo()
        {
            _loading = true;
            try
            {
                cmbBooking.Items.Clear();
                _selectedBooking = null;

                foreach (var b in _bookRepo.GetCheckedOut())
                {
                    try
                    {
                        if (_billRepo.GetByBookingId(b.BookingId) == null)
                            cmbBooking.Items.Add(new BillingItem(b,
                                $"#{b.BookingId}  |  {b.CustomerName}  |  Room {b.RoomNumber}" +
                                $"  |  {b.CheckInDate:dd/MM/yy}–{b.CheckOutDate:dd/MM/yy}" +
                                $"  |  {Math.Max(1,b.Nights)} nights  [Checked-Out]"));
                    }
                    catch { }
                }

                foreach (var b in _bookRepo.GetCheckedIn())
                {
                    try
                    {
                        if (_billRepo.GetByBookingId(b.BookingId) == null)
                            cmbBooking.Items.Add(new BillingItem(b,
                                $"#{b.BookingId}  |  {b.CustomerName}  |  Room {b.RoomNumber}" +
                                $"  |  {b.CheckInDate:dd/MM/yy}  [Active]"));
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bookings:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { _loading = false; }

            if (cmbBooking.Items.Count > 0)
            {
                cmbBooking.SelectedIndex = 0;
                FillFromSelected();
            }
            else
            {
                ClearFields();
                lblCalc.Text = "No bookings available. Do Check-Out first.";
            }
        }

        // ── Load Bills Grid ──────────────────────────────────────────────────
        private void LoadBills()
        {
            try
            {
                var bills = _billRepo.GetAll();
                dgvBills.Rows.Clear();
                foreach (var b in bills)
                    dgvBills.Rows.Add(
                        b.BillId, b.BookingId, b.CustomerName, b.RoomNumber,
                        $"Rs. {b.TotalAmount:N0}", $"Rs. {b.PaidAmount:N0}",
                        $"Rs. {b.Balance:N0}", b.PaymentMethod,
                        b.BillDate.ToString("dd/MM/yyyy"));

                decimal total = _billRepo.GetTotalRevenue();
                lblBillCount.Text    = $"Total Bills: {bills.Count}";
                lblTotalRevenue.Text = $"Total Revenue: Rs. {total:N0}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bills:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Combo Changed ────────────────────────────────────────────────────
        private void cmbBooking_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loading) return;
            FillFromSelected();
        }

        private void FillFromSelected()
        {
            if (cmbBooking.SelectedItem is not BillingItem item) return;
            _selectedBooking = item.Booking;
            if (_selectedBooking == null) return;

            int nights = Math.Max(1, _selectedBooking.Nights);
            decimal roomCharges = _selectedBooking.PricePerNight * nights;

            _loading = true;
            txtRoomCharges.Text  = roomCharges.ToString("N0");
            txtExtraCharges.Text = "0";
            txtDiscount.Text     = "0";
            txtPaidAmount.Text   = _selectedBooking.PaidAmount > 0
                                    ? _selectedBooking.PaidAmount.ToString("N0") : "0";
            _loading = false;

            RecalcTotal();
        }

        // ── Recalc ───────────────────────────────────────────────────────────
        private void RecalcTotal()
        {
            if (_loading) return;
            try
            {
                decimal room  = ParseAmt(txtRoomCharges.Text);
                decimal extra = ParseAmt(txtExtraCharges.Text);
                decimal disc  = ParseAmt(txtDiscount.Text);
                decimal tax   = Math.Round((room + extra) * 0.10m, 0);
                decimal total = Math.Max(0, room + extra + tax - disc);

                _loading = true;
                txtTotal.Text = total.ToString("N0");
                _loading = false;

                lblCalc.Text =
                    $"Room Rs.{room:N0}  +  Extra Rs.{extra:N0}  +  Tax Rs.{tax:N0}  –  Disc Rs.{disc:N0}  =  Rs.{total:N0}";
            }
            catch { _loading = false; }
        }

        private static decimal ParseAmt(string s)
        {
            s = (s ?? "0").Replace(",", "").Replace("Rs.", "").Replace(" ", "").Trim();
            return decimal.TryParse(s, out var v) ? Math.Max(0, v) : 0m;
        }

        // ── Generate Bill ────────────────────────────────────────────────────
        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            if (_selectedBooking == null)
            {
                MessageBox.Show("Select a booking first.",
                    "No Booking", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = ParseAmt(txtTotal.Text);
            decimal paid  = ParseAmt(txtPaidAmount.Text);

            if (total <= 0)
            {
                MessageBox.Show("Total is 0. Check room charges.",
                    "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (paid > total)
            {
                MessageBox.Show("Paid cannot exceed total.",
                    "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var bill = new Bill
                {
                    BookingId     = _selectedBooking.BookingId,
                    RoomCharges   = ParseAmt(txtRoomCharges.Text),
                    ExtraCharges  = ParseAmt(txtExtraCharges.Text),
                    TaxPercent    = 10,
                    Discount      = ParseAmt(txtDiscount.Text),
                    TotalAmount   = total,
                    PaidAmount    = paid,
                    PaymentMethod = cmbPayment.SelectedItem?.ToString() ?? "Cash"
                };

                int billId = _billRepo.Add(bill);
                if (billId <= 0)
                {
                    MessageBox.Show("Bill save failed. Try again.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update booking
                try
                {
                    _selectedBooking.PaidAmount  = paid;
                    _selectedBooking.TotalAmount = total;
                    _bookRepo.Update(_selectedBooking);
                }
                catch { }

                // ★ Immediately refresh dashboard revenue
                _mainForm?.LoadDashboard();

                MessageBox.Show(
                    $"Bill #{billId} generated!\n\n" +
                    $"Customer : {_selectedBooking.CustomerName}\n" +
                    $"Room     : {_selectedBooking.RoomNumber}\n" +
                    $"Total    : Rs. {total:N0}\n" +
                    $"Paid     : Rs. {paid:N0}\n" +
                    $"Balance  : Rs. {(total-paid):N0}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadBills();
                LoadBookingsCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Grid Selection ───────────────────────────────────────────────────
        private void dgvBills_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                _selectedBill = null;
                if (dgvBills.CurrentRow == null) return;
                var cell = dgvBills.CurrentRow.Cells[0].Value;
                if (cell == null || cell == DBNull.Value) return;
                _selectedBill = _billRepo.GetById(Convert.ToInt32(cell));
            }
            catch { _selectedBill = null; }
        }

        // ── View Receipt ─────────────────────────────────────────────────────
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            if (_selectedBill == null)
            {
                MessageBox.Show("Select a bill from the list.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ShowReceipt(_selectedBill);
        }

        private void ShowReceipt(Bill b)
        {
            Booking? booking = null;
            try { booking = _bookRepo.GetById(b.BookingId); } catch { }
            decimal taxAmt = Math.Round((b.RoomCharges + b.ExtraCharges) * 0.10m, 0);

            string text =
$@"========================================
         GRAND HOTEL
      Hotel Management System
========================================
Bill #    : {b.BillId}
Date      : {b.BillDate:dd/MM/yyyy  hh:mm tt}
Booking # : {b.BookingId}
Customer  : {b.CustomerName}
Room      : {b.RoomNumber}
Check-In  : {booking?.CheckInDate:dd/MM/yyyy}
Check-Out : {booking?.CheckOutDate:dd/MM/yyyy}
Nights    : {booking?.Nights ?? 0}
----------------------------------------
Room Charges  : Rs. {b.RoomCharges,10:N0}
Extra Charges : Rs. {b.ExtraCharges,10:N0}
Tax (10%)     : Rs. {taxAmt,10:N0}
Discount      : Rs. {b.Discount,10:N0}
----------------------------------------
TOTAL         : Rs. {b.TotalAmount,10:N0}
PAID          : Rs. {b.PaidAmount,10:N0}
BALANCE       : Rs. {b.Balance,10:N0}
Payment       : {b.PaymentMethod}
========================================
  Thank you for staying with us!
========================================";

            var frm = new Form
            {
                Text = $"Bill #{b.BillId}", Size = new Size(450, 560),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog, MaximizeBox = false
            };
            var rtb = new RichTextBox
            {
                Dock = DockStyle.Fill, ReadOnly = true,
                Font = new Font("Courier New", 9.5F),
                Text = text, BackColor = Color.White, BorderStyle = BorderStyle.None
            };
            var pnl = new Panel { Dock = DockStyle.Bottom, Height = 48, BackColor = Color.WhiteSmoke };
            var btnCopy = new Button
            {
                Text = "Copy to Clipboard", BackColor = Color.FromArgb(15,76,129),
                ForeColor = Color.White, FlatStyle = FlatStyle.Flat,
                Size = new Size(180,32), Location = new Point(12,8), Cursor = Cursors.Hand
            };
            btnCopy.FlatAppearance.BorderSize = 0;
            btnCopy.Click += (s, ev) =>
            {
                Clipboard.SetText(text);
                MessageBox.Show("Copied! Open Notepad → Paste → Print.",
                    "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            var btnClose = new Button
            {
                Text = "Close", BackColor = Color.FromArgb(127,140,141),
                ForeColor = Color.White, FlatStyle = FlatStyle.Flat,
                Size = new Size(100,32), Location = new Point(200,8), Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, ev) => frm.Close();
            pnl.Controls.Add(btnCopy); pnl.Controls.Add(btnClose);
            frm.Controls.Add(rtb); frm.Controls.Add(pnl);
            frm.ShowDialog();
        }

        // ── Delete ───────────────────────────────────────────────────────────
        private void btnDeleteBill_Click(object sender, EventArgs e)
        {
            if (_selectedBill == null)
            {
                MessageBox.Show("Select a bill first.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show($"Delete Bill #{_selectedBill.BillId}?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _billRepo.Delete(_selectedBill.BillId);
                _selectedBill = null;
                _mainForm?.LoadDashboard();   // ★ refresh dashboard
                LoadBills();
                LoadBookingsCombo();
            }
        }

        // ── Clear / Refresh ──────────────────────────────────────────────────
        private void ClearFields()
        {
            _loading = true;
            txtRoomCharges.Text = "0"; txtExtraCharges.Text = "0";
            txtDiscount.Text = "0";   txtPaidAmount.Text = "0";
            txtTotal.Text = "0";
            _loading = false;
            try { cmbPayment.SelectedIndex = 0; } catch { }
            lblCalc.Text = "Select a booking above";
            _selectedBooking = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            if (cmbBooking.Items.Count > 0)
            { cmbBooking.SelectedIndex = 0; FillFromSelected(); }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBills();
            LoadBookingsCombo();
        }

        private void txtCharges_TextChanged(object sender, EventArgs e)
        {
            if (!_loading) RecalcTotal();
        }
    }

    class BillingItem
    {
        public int     Id      { get; }
        public Booking Booking { get; }
        private string Label  { get; }
        public BillingItem(Booking b, string label) { Id = b.BookingId; Booking = b; Label = label; }
        public override string ToString() => Label;
    }
}
