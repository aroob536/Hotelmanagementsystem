namespace HMS.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel  pnlTopBar;
        private Label  lblAppTitle;
        private Label  lblClock;
        private Label  lblUserName;
        private Button btnLogout;
        private Panel  pnlNav;
        private Label  lblNavTitle;
        private Button btnRooms;
        private Button btnCustomers;
        private Button btnBookings;
        private Button btnCheckInOut;
        private Button btnBilling;
        private Button btnRefresh;
        private Panel  pnlContent;
        private Label  lblDashTitle;
        private Label  lblDashSub;
        private Panel  card1, card2, card3, card4;
        private Panel  card5, card6, card7, card8;
        private Label  lblStatAvailable;
        private Label  lblStatOccupied;
        private Label  lblStatCheckedIn;
        private Label  lblStatTotal;
        private Label  lblStatTodayIn;
        private Label  lblStatTodayOut;
        private Label  lblStatCustomers;
        private Label  lblStatRevenue;
        private Label  lblQuick;
        private Button qa1, qa2, qa3, qa4, qa5;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            // ── TOP BAR ──────────────────────────────────────────────────────
            pnlTopBar           = new Panel();
            pnlTopBar.BackColor = Color.FromArgb(15, 76, 129);
            pnlTopBar.Dock      = DockStyle.Top;
            pnlTopBar.Height    = 55;

            lblAppTitle           = new Label();
            lblAppTitle.Text      = "GRAND HOTEL MANAGEMENT SYSTEM";
            lblAppTitle.ForeColor = Color.White;
            lblAppTitle.Font      = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblAppTitle.Location  = new Point(12, 12);
            lblAppTitle.Size      = new Size(520, 30);
            lblAppTitle.AutoSize  = false;

            lblClock           = new Label();
            lblClock.Text      = "";
            lblClock.ForeColor = Color.FromArgb(200, 230, 255);
            lblClock.Font      = new Font("Segoe UI", 9F);
            lblClock.TextAlign = ContentAlignment.MiddleRight;
            lblClock.Anchor    = AnchorStyles.Top | AnchorStyles.Right;
            lblClock.Location  = new Point(720, 8);
            lblClock.Size      = new Size(260, 20);
            lblClock.AutoSize  = false;

            lblUserName           = new Label();
            lblUserName.Text      = "";
            lblUserName.ForeColor = Color.FromArgb(180, 215, 255);
            lblUserName.Font      = new Font("Segoe UI", 8.5F);
            lblUserName.TextAlign = ContentAlignment.MiddleRight;
            lblUserName.Anchor    = AnchorStyles.Top | AnchorStyles.Right;
            lblUserName.Location  = new Point(560, 30);
            lblUserName.Size      = new Size(420, 18);
            lblUserName.AutoSize  = false;

            btnLogout                           = new Button();
            btnLogout.Text                      = "Logout";
            btnLogout.ForeColor                 = Color.White;
            btnLogout.BackColor                 = Color.FromArgb(180, 40, 40);
            btnLogout.FlatStyle                 = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Font                      = new Font("Segoe UI", 9F);
            btnLogout.Anchor                    = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.Location                  = new Point(1070, 13);
            btnLogout.Size                      = new Size(80, 28);
            btnLogout.Cursor                    = Cursors.Hand;
            btnLogout.Click                    += btnLogout_Click;

            pnlTopBar.Controls.Add(lblAppTitle);
            pnlTopBar.Controls.Add(lblClock);
            pnlTopBar.Controls.Add(lblUserName);
            pnlTopBar.Controls.Add(btnLogout);

            // ── NAV ──────────────────────────────────────────────────────────
            pnlNav           = new Panel();
            pnlNav.BackColor = Color.FromArgb(24, 50, 82);
            pnlNav.Dock      = DockStyle.Left;
            pnlNav.Width     = 192;

            lblNavTitle           = new Label();
            lblNavTitle.Text      = "NAVIGATION";
            lblNavTitle.ForeColor = Color.FromArgb(120, 160, 200);
            lblNavTitle.Font      = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblNavTitle.Location  = new Point(12, 16);
            lblNavTitle.Size      = new Size(168, 20);
            lblNavTitle.AutoSize  = false;

            btnRooms      = NavBtn("  Room Management",       48);
            btnCustomers  = NavBtn("  Customer Details",      96);
            btnBookings   = NavBtn("  Bookings",             144);
            btnCheckInOut = NavBtn("  Check In / Check Out", 192);
            btnBilling    = NavBtn("  Billing",              240);

            btnRooms.Click      += btnRooms_Click;
            btnCustomers.Click  += btnCustomers_Click;
            btnBookings.Click   += btnBookings_Click;
            btnCheckInOut.Click += btnCheckInOut_Click;
            btnBilling.Click    += btnBilling_Click;

            btnRefresh           = new Button();
            btnRefresh.Text      = "  Refresh";
            btnRefresh.ForeColor = Color.FromArgb(100, 180, 255);
            btnRefresh.BackColor = Color.Transparent;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(60, 100, 150);
            btnRefresh.FlatAppearance.BorderSize  = 1;
            btnRefresh.Font      = new Font("Segoe UI", 9F);
            btnRefresh.Location  = new Point(10, 300);
            btnRefresh.Size      = new Size(172, 36);
            btnRefresh.Cursor    = Cursors.Hand;
            btnRefresh.Click    += btnRefresh_Click;

            pnlNav.Controls.Add(lblNavTitle);
            pnlNav.Controls.Add(btnRooms);
            pnlNav.Controls.Add(btnCustomers);
            pnlNav.Controls.Add(btnBookings);
            pnlNav.Controls.Add(btnCheckInOut);
            pnlNav.Controls.Add(btnBilling);
            pnlNav.Controls.Add(btnRefresh);

            // ── CONTENT ──────────────────────────────────────────────────────
            pnlContent           = new Panel();
            pnlContent.BackColor = Color.FromArgb(240, 245, 250);
            pnlContent.Dock      = DockStyle.Fill;
            pnlContent.AutoScroll= true;

            lblDashTitle           = new Label();
            lblDashTitle.Text      = "Dashboard Overview";
            lblDashTitle.ForeColor = Color.FromArgb(15, 76, 129);
            lblDashTitle.Font      = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblDashTitle.Location  = new Point(22, 20);
            lblDashTitle.Size      = new Size(420, 36);
            lblDashTitle.AutoSize  = false;

            lblDashSub           = new Label();
            lblDashSub.Text      = "Real-time hotel statistics";
            lblDashSub.ForeColor = Color.FromArgb(130, 130, 130);
            lblDashSub.Font      = new Font("Segoe UI", 9F);
            lblDashSub.Location  = new Point(22, 58);
            lblDashSub.Size      = new Size(350, 20);
            lblDashSub.AutoSize  = false;

            // Cards row1 y=90  row2 y=220  w=198 h=112 gap=18
            int cw=198, ch=112, gap=18, sx=22, row1=90, row2=220;

            card1 = MakeCard("Available Rooms",  Color.FromArgb(39,174,96),   sx,              row1, cw, ch, out lblStatAvailable);
            card2 = MakeCard("Occupied Rooms",   Color.FromArgb(231,76,60),   sx+cw+gap,       row1, cw, ch, out lblStatOccupied);
            card3 = MakeCard("Checked-In Now",   Color.FromArgb(52,152,219),  sx+2*(cw+gap),   row1, cw, ch, out lblStatCheckedIn);
            card4 = MakeCard("Total Rooms",      Color.FromArgb(142,68,173),  sx+3*(cw+gap),   row1, cw, ch, out lblStatTotal);
            card5 = MakeCard("Today Check-Ins",  Color.FromArgb(22,160,133),  sx,              row2, cw, ch, out lblStatTodayIn);
            card6 = MakeCard("Today Check-Outs", Color.FromArgb(230,126,34),  sx+cw+gap,       row2, cw, ch, out lblStatTodayOut);
            card7 = MakeCard("Total Customers",  Color.FromArgb(41,128,185),  sx+2*(cw+gap),   row2, cw, ch, out lblStatCustomers);
            card8 = MakeCard("Today Revenue",    Color.FromArgb(192,57,43),   sx+3*(cw+gap),   row2, cw, ch, out lblStatRevenue);

            lblQuick           = new Label();
            lblQuick.Text      = "Quick Actions";
            lblQuick.ForeColor = Color.FromArgb(15, 76, 129);
            lblQuick.Font      = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblQuick.Location  = new Point(22, 352);
            lblQuick.Size      = new Size(300, 28);
            lblQuick.AutoSize  = false;

            qa1 = QuickBtn("Room Management",  Color.FromArgb(39,174,96),   sx,          390, btnRooms_Click);
            qa2 = QuickBtn("Customer Details", Color.FromArgb(22,160,133),  sx+174,      390, btnCustomers_Click);
            qa3 = QuickBtn("New Booking",      Color.FromArgb(52,152,219),  sx+2*174,    390, btnBookings_Click);
            qa4 = QuickBtn("Check In/Out",     Color.FromArgb(230,126,34),  sx+3*174,    390, btnCheckInOut_Click);
            qa5 = QuickBtn("Billing",          Color.FromArgb(142,68,173),  sx+4*174,    390, btnBilling_Click);

            pnlContent.Controls.Add(lblDashTitle);
            pnlContent.Controls.Add(lblDashSub);
            pnlContent.Controls.Add(card1);  pnlContent.Controls.Add(card2);
            pnlContent.Controls.Add(card3);  pnlContent.Controls.Add(card4);
            pnlContent.Controls.Add(card5);  pnlContent.Controls.Add(card6);
            pnlContent.Controls.Add(card7);  pnlContent.Controls.Add(card8);
            pnlContent.Controls.Add(lblQuick);
            pnlContent.Controls.Add(qa1);    pnlContent.Controls.Add(qa2);
            pnlContent.Controls.Add(qa3);    pnlContent.Controls.Add(qa4);
            pnlContent.Controls.Add(qa5);

            // ── FORM ────────────────────────────────────────────────────────
            ClientSize    = new Size(1180, 660);
            MinimumSize   = new Size(1024, 600);
            Name          = "MainForm";
            Text          = "Hotel Management System – Grand Hotel";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState   = FormWindowState.Maximized;
            FormClosing  += MainForm_FormClosing;

            Controls.Add(pnlContent);
            Controls.Add(pnlNav);
            Controls.Add(pnlTopBar);

            ResumeLayout(false);
        }

        private Button NavBtn(string text, int y)
        {
            var b = new Button();
            b.Text      = text;
            b.ForeColor = Color.FromArgb(200, 220, 240);
            b.BackColor = Color.Transparent;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.Font      = new Font("Segoe UI", 9.5F);
            b.TextAlign = ContentAlignment.MiddleLeft;
            b.Location  = new Point(0, y);
            b.Size      = new Size(192, 40);
            b.Cursor    = Cursors.Hand;
            b.MouseEnter += (s, e) => ((Button)s!).BackColor = Color.FromArgb(40,70,110);
            b.MouseLeave += (s, e) => ((Button)s!).BackColor = Color.Transparent;
            return b;
        }

        private Panel MakeCard(string title, Color color, int x, int y, int w, int h, out Label valueLbl)
        {
            var pnl      = new Panel();
            pnl.BackColor= color;
            pnl.Location = new Point(x, y);
            pnl.Size     = new Size(w, h);

            var lTitle      = new Label();
            lTitle.Text     = title;
            lTitle.ForeColor= Color.FromArgb(220, 240, 255);
            lTitle.Font     = new Font("Segoe UI", 8.5F);
            lTitle.Location = new Point(12, 12);
            lTitle.Size     = new Size(w - 24, 20);
            lTitle.AutoSize = false;

            valueLbl          = new Label();
            valueLbl.Text     = "0";
            valueLbl.ForeColor= Color.White;
            valueLbl.Font     = new Font("Segoe UI", 26F, FontStyle.Bold);
            valueLbl.Location = new Point(10, 34);
            valueLbl.Size     = new Size(w - 20, 60);
            valueLbl.TextAlign= ContentAlignment.MiddleLeft;
            valueLbl.AutoSize = false;

            pnl.Controls.Add(lTitle);
            pnl.Controls.Add(valueLbl);
            return pnl;
        }

        private Button QuickBtn(string text, Color color, int x, int y, EventHandler handler)
        {
            var b = new Button();
            b.Text      = text;
            b.BackColor = color;
            b.ForeColor = Color.White;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.Font      = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            b.Location  = new Point(x, y);
            b.Size      = new Size(164, 42);
            b.Cursor    = Cursors.Hand;
            b.Click    += handler;
            return b;
        }
    }
}
