using HMS.Database;
using HMS.Models;

namespace HMS.Forms
{//MAIN DASHBOARD
    public partial class MainForm : Form
    {
        private readonly User               _currentUser;
        private readonly BookingRepository  _bookings  = new();
        private readonly RoomRepository     _rooms     = new();
        private readonly CustomerRepository _customers = new();
        private readonly BillRepository     _bills     = new();
        private System.Windows.Forms.Timer  _clock     = new();

        public MainForm(User user)
        {
            _currentUser = user;
            InitializeComponent();
            lblUserName.Text =
                $"  Welcome,  {_currentUser.FullName}     Role: {_currentUser.Role.ToUpper()}";
            SetupClock();
            LoadDashboard();
        }
//SETUP REAL TIME CLOCK_UPDATE EVERY SECOND
        private void SetupClock()
        {
            _clock.Interval = 1000;
            _clock.Tick += (s, e) =>
                lblClock.Text = DateTime.Now.ToString("dd MMM yyyy   hh:mm:ss tt");
            _clock.Start();
            lblClock.Text = DateTime.Now.ToString("dd MMM yyyy   hh:mm:ss tt");
        }
//LOAD DASHBOARD AND ALSO REFRESH ALL STAT CARDS
        public void LoadDashboard()
        {
            try
            {
                int total     = _rooms.GetAll().Count;
                int avail     = _rooms.GetAvailable().Count;
                int occupied  = total - avail;
                int checkedIn = _bookings.GetCheckedIn().Count;
                int todayIn   = _bookings.GetTodayCheckIns();
                int todayOut  = _bookings.GetTodayCheckOuts();
                int customers = _customers.GetTotalCount();

                // Use GetTotalRevenue (no date filter) — most reliable
                decimal revenue = _bills.GetTotalRevenue();

                lblStatAvailable.Text = avail.ToString();
                lblStatOccupied.Text  = occupied.ToString();
                lblStatCheckedIn.Text = checkedIn.ToString();
                lblStatTotal.Text     = total.ToString();
                lblStatTodayIn.Text   = todayIn.ToString();
                lblStatTodayOut.Text  = todayOut.ToString();
                lblStatCustomers.Text = customers.ToString();
                lblStatRevenue.Text   = $"Rs. {revenue:N0}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dashboard error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
//OPEN CHILD FORM_DASHBOARD GET REFRESHED ON CLOSING
        private void OpenChild(Form frm)
        {
            frm.FormClosed += (s, e) => LoadDashboard();
            frm.Show();
        }
        //BY CLICKING ON SPECIFIC BUTTON SPECIFIC FORM IS OPENED 
        private void btnRooms_Click(object sender, EventArgs e)
            => OpenChild(new RoomManagementForm(_currentUser));
        private void btnCustomers_Click(object sender, EventArgs e)
            => OpenChild(new CustomerForm(_currentUser));
        private void btnBookings_Click(object sender, EventArgs e)
            => OpenChild(new BookingForm(_currentUser));
        private void btnCheckInOut_Click(object sender, EventArgs e)
            => OpenChild(new CheckInOutForm(_currentUser));
        private void btnBilling_Click(object sender, EventArgs e)
            => OpenChild(new BillingForm(_currentUser));
        private void btnRefresh_Click(object sender, EventArgs e)
            => LoadDashboard();
//LOGOUT THE FORM AFTER CONFIRMATION
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Logout?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _clock.Stop();
                new LoginForm().Show();
                this.Close();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Exit?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                { e.Cancel = true; return; }
                _clock.Stop();
                Application.Exit();
            }
        }
    }
}
