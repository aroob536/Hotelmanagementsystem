namespace HMS.Forms
{
    partial class CheckInOutForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel        pnlHeader;
        private Label        lblFormTitle;
        private Button       btnRefresh;
        private Panel        pnlDetails;
        private Label        lblDetailHeader;
        private Label        lblDetBookingId;
        private Label        lblDetCustomer;
        private Label        lblDetRoom;
        private Label        lblDetCheckIn;
        private Label        lblDetCheckOut;
        private Label        lblDetNights;
        private Label        lblDetTotal;
        private Label        lblDetPaid;
        private Label        lblDetBalance;
        private Label        lblDetStatus;
        private Button       btnCheckIn;
        private Button       btnCheckOut;
        private TabControl   tabControl;
        private TabPage      tabReserved;
        private TabPage      tabCheckedIn;
        private Label        lblReservedCount;
        private Label        lblCheckedInCount;
        private DataGridView dgvReserved;
        private DataGridView dgvCheckedIn;
        private DataGridViewTextBoxColumn colR_BId;
        private DataGridViewTextBoxColumn colR_Cust;
        private DataGridViewTextBoxColumn colR_Room;
        private DataGridViewTextBoxColumn colR_Type;
        private DataGridViewTextBoxColumn colR_ChIn;
        private DataGridViewTextBoxColumn colR_ChOut;
        private DataGridViewTextBoxColumn colR_Nights;
        private DataGridViewTextBoxColumn colR_Total;
        private DataGridViewTextBoxColumn colR_Paid;
        private DataGridViewTextBoxColumn colR_Status;
        private DataGridViewTextBoxColumn colC_BId;
        private DataGridViewTextBoxColumn colC_Cust;
        private DataGridViewTextBoxColumn colC_Room;
        private DataGridViewTextBoxColumn colC_Type;
        private DataGridViewTextBoxColumn colC_ChIn;
        private DataGridViewTextBoxColumn colC_ChOut;
        private DataGridViewTextBoxColumn colC_ActualIn;
        private DataGridViewTextBoxColumn colC_Nights;
        private DataGridViewTextBoxColumn colC_Total;
        private DataGridViewTextBoxColumn colC_Balance;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            colR_BId    = new DataGridViewTextBoxColumn();
            colR_Cust   = new DataGridViewTextBoxColumn();
            colR_Room   = new DataGridViewTextBoxColumn();
            colR_Type   = new DataGridViewTextBoxColumn();
            colR_ChIn   = new DataGridViewTextBoxColumn();
            colR_ChOut  = new DataGridViewTextBoxColumn();
            colR_Nights = new DataGridViewTextBoxColumn();
            colR_Total  = new DataGridViewTextBoxColumn();
            colR_Paid   = new DataGridViewTextBoxColumn();
            colR_Status = new DataGridViewTextBoxColumn();
            colC_BId    = new DataGridViewTextBoxColumn();
            colC_Cust   = new DataGridViewTextBoxColumn();
            colC_Room   = new DataGridViewTextBoxColumn();
            colC_Type   = new DataGridViewTextBoxColumn();
            colC_ChIn   = new DataGridViewTextBoxColumn();
            colC_ChOut  = new DataGridViewTextBoxColumn();
            colC_ActualIn=new DataGridViewTextBoxColumn();
            colC_Nights = new DataGridViewTextBoxColumn();
            colC_Total  = new DataGridViewTextBoxColumn();
            colC_Balance= new DataGridViewTextBoxColumn();
            dgvReserved  = new DataGridView();
            dgvCheckedIn = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReserved).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCheckedIn).BeginInit();
            SuspendLayout();

            // ── HEADER ──────────────────────────────────────────────────────
            pnlHeader           = new Panel();
            pnlHeader.BackColor = Color.FromArgb(41, 128, 185);
            pnlHeader.Dock      = DockStyle.Top;
            pnlHeader.Height    = 50;

            lblFormTitle           = new Label();
            lblFormTitle.Text      = "Check In / Check Out";
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Font      = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblFormTitle.Location  = new Point(15, 10);
            lblFormTitle.Size      = new Size(400, 30);
            lblFormTitle.AutoSize  = false;

            btnRefresh                           = new Button();
            btnRefresh.Text                      = "Refresh";
            btnRefresh.ForeColor                 = Color.White;
            btnRefresh.BackColor                 = Color.FromArgb(30, 100, 160);
            btnRefresh.FlatStyle                 = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Font                      = new Font("Segoe UI", 9F);
            btnRefresh.Anchor                    = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Location                  = new Point(980, 12);
            btnRefresh.Size                      = new Size(90, 28);
            btnRefresh.Cursor                    = Cursors.Hand;
            btnRefresh.Click                    += btnRefresh_Click;

            pnlHeader.Controls.Add(lblFormTitle);
            pnlHeader.Controls.Add(btnRefresh);

            // ── DETAILS PANEL (right) ────────────────────────────────────────
            pnlDetails           = new Panel();
            pnlDetails.BackColor = Color.White;
            pnlDetails.Dock      = DockStyle.Right;
            pnlDetails.Width     = 272;
            pnlDetails.Visible   = false;

            lblDetailHeader           = new Label();
            lblDetailHeader.Text      = "Booking Details";
            lblDetailHeader.ForeColor = Color.FromArgb(41, 128, 185);
            lblDetailHeader.Font      = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailHeader.Location  = new Point(14, 14);
            lblDetailHeader.Size      = new Size(244, 26);
            lblDetailHeader.AutoSize  = false;

            lblDetBookingId = DL(14, 48);
            lblDetCustomer  = DL(14, 72);
            lblDetRoom      = DL(14, 96);
            lblDetCheckIn   = DL(14, 120);
            lblDetCheckOut  = DL(14, 144);
            lblDetNights    = DL(14, 168);

            var sep           = new Label();
            sep.BackColor     = Color.FromArgb(220, 230, 240);
            sep.Location      = new Point(14, 196);
            sep.Size          = new Size(244, 2);
            sep.AutoSize      = false;

            lblDetTotal           = DL(14, 206);
            lblDetTotal.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDetTotal.ForeColor = Color.FromArgb(52, 73, 94);

            lblDetPaid           = DL(14, 230);
            lblDetPaid.ForeColor = Color.FromArgb(39, 174, 96);

            lblDetBalance           = DL(14, 254);
            lblDetBalance.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDetBalance.ForeColor = Color.FromArgb(192, 57, 43);

            lblDetStatus           = DL(14, 282);
            lblDetStatus.ForeColor = Color.FromArgb(41, 128, 185);

            btnCheckIn                           = new Button();
            btnCheckIn.Text                      = "CHECK IN";
            btnCheckIn.BackColor                 = Color.FromArgb(39, 174, 96);
            btnCheckIn.ForeColor                 = Color.White;
            btnCheckIn.FlatStyle                 = FlatStyle.Flat;
            btnCheckIn.FlatAppearance.BorderSize = 0;
            btnCheckIn.Font                      = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCheckIn.Location                  = new Point(14, 322);
            btnCheckIn.Size                      = new Size(244, 42);
            btnCheckIn.Cursor                    = Cursors.Hand;
            btnCheckIn.Click                    += btnCheckIn_Click;

            btnCheckOut                           = new Button();
            btnCheckOut.Text                      = "CHECK OUT";
            btnCheckOut.BackColor                 = Color.FromArgb(231, 76, 60);
            btnCheckOut.ForeColor                 = Color.White;
            btnCheckOut.FlatStyle                 = FlatStyle.Flat;
            btnCheckOut.FlatAppearance.BorderSize = 0;
            btnCheckOut.Font                      = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCheckOut.Location                  = new Point(14, 374);
            btnCheckOut.Size                      = new Size(244, 42);
            btnCheckOut.Cursor                    = Cursors.Hand;
            btnCheckOut.Click                    += btnCheckOut_Click;

            pnlDetails.Controls.Add(lblDetailHeader);
            pnlDetails.Controls.Add(lblDetBookingId);
            pnlDetails.Controls.Add(lblDetCustomer);
            pnlDetails.Controls.Add(lblDetRoom);
            pnlDetails.Controls.Add(lblDetCheckIn);
            pnlDetails.Controls.Add(lblDetCheckOut);
            pnlDetails.Controls.Add(lblDetNights);
            pnlDetails.Controls.Add(sep);
            pnlDetails.Controls.Add(lblDetTotal);
            pnlDetails.Controls.Add(lblDetPaid);
            pnlDetails.Controls.Add(lblDetBalance);
            pnlDetails.Controls.Add(lblDetStatus);
            pnlDetails.Controls.Add(btnCheckIn);
            pnlDetails.Controls.Add(btnCheckOut);

            // ── TAB: RESERVED ─────────────────────────────────────────────
            tabReserved           = new TabPage();
            tabReserved.Text      = "  Reserved — Pending Check-In  ";
            tabReserved.BackColor = Color.FromArgb(245, 247, 250);

            lblReservedCount           = new Label();
            lblReservedCount.Text      = "Reserved Bookings: 0";
            lblReservedCount.ForeColor = Color.FromArgb(80, 80, 80);
            lblReservedCount.Font      = new Font("Segoe UI", 9F);
            lblReservedCount.Location  = new Point(12, 10);
            lblReservedCount.Size      = new Size(260, 22);
            lblReservedCount.AutoSize  = false;

            colR_BId.HeaderText    = "ID";         colR_BId.Name    = "R_BId";    colR_BId.FillWeight    = 40;
            colR_Cust.HeaderText   = "Customer";   colR_Cust.Name   = "R_Cust";   colR_Cust.FillWeight   = 160;
            colR_Room.HeaderText   = "Room";       colR_Room.Name   = "R_Room";   colR_Room.FillWeight   = 70;
            colR_Type.HeaderText   = "Type";       colR_Type.Name   = "R_Type";   colR_Type.FillWeight   = 100;
            colR_ChIn.HeaderText   = "Check-In";   colR_ChIn.Name   = "R_ChIn";   colR_ChIn.FillWeight   = 90;
            colR_ChOut.HeaderText  = "Check-Out";  colR_ChOut.Name  = "R_ChOut";  colR_ChOut.FillWeight  = 90;
            colR_Nights.HeaderText = "Nights";     colR_Nights.Name = "R_Nights"; colR_Nights.FillWeight = 60;
            colR_Total.HeaderText  = "Total";      colR_Total.Name  = "R_Total";  colR_Total.FillWeight  = 90;
            colR_Paid.HeaderText   = "Paid";       colR_Paid.Name   = "R_Paid";   colR_Paid.FillWeight   = 90;
            colR_Status.HeaderText = "Status";     colR_Status.Name = "R_Status"; colR_Status.FillWeight = 90;

            dgvReserved.Location = new Point(10, 40);
            dgvReserved.Anchor   = AnchorStyles.Top | AnchorStyles.Bottom
                                 | AnchorStyles.Left | AnchorStyles.Right;
            dgvReserved.Size     = new Size(860, 540);
            StyleDGV(dgvReserved, Color.FromArgb(52, 152, 219));
            dgvReserved.Columns.AddRange(new DataGridViewColumn[]
            {
                colR_BId, colR_Cust, colR_Room, colR_Type,
                colR_ChIn, colR_ChOut, colR_Nights, colR_Total, colR_Paid, colR_Status
            });
            dgvReserved.Columns["R_BId"].Visible = false;
            dgvReserved.SelectionChanged += dgvReserved_SelectionChanged;

            tabReserved.Controls.Add(lblReservedCount);
            tabReserved.Controls.Add(dgvReserved);

            // ── TAB: CHECKED-IN ───────────────────────────────────────────
            tabCheckedIn           = new TabPage();
            tabCheckedIn.Text      = "  Currently Checked-In  ";
            tabCheckedIn.BackColor = Color.FromArgb(245, 247, 250);

            lblCheckedInCount           = new Label();
            lblCheckedInCount.Text      = "Currently Checked-In: 0";
            lblCheckedInCount.ForeColor = Color.FromArgb(80, 80, 80);
            lblCheckedInCount.Font      = new Font("Segoe UI", 9F);
            lblCheckedInCount.Location  = new Point(12, 10);
            lblCheckedInCount.Size      = new Size(260, 22);
            lblCheckedInCount.AutoSize  = false;

            colC_BId.HeaderText     = "ID";           colC_BId.Name     = "C_BId";     colC_BId.FillWeight     = 40;
            colC_Cust.HeaderText    = "Customer";     colC_Cust.Name    = "C_Cust";    colC_Cust.FillWeight    = 150;
            colC_Room.HeaderText    = "Room";         colC_Room.Name    = "C_Room";    colC_Room.FillWeight    = 70;
            colC_Type.HeaderText    = "Type";         colC_Type.Name    = "C_Type";    colC_Type.FillWeight    = 100;
            colC_ChIn.HeaderText    = "Check-In";     colC_ChIn.Name    = "C_ChIn";    colC_ChIn.FillWeight    = 90;
            colC_ChOut.HeaderText   = "Check-Out";    colC_ChOut.Name   = "C_ChOut";   colC_ChOut.FillWeight   = 90;
            colC_ActualIn.HeaderText= "Actual In";    colC_ActualIn.Name= "C_ActIn";   colC_ActualIn.FillWeight= 120;
            colC_Nights.HeaderText  = "Nights";       colC_Nights.Name  = "C_Nights";  colC_Nights.FillWeight  = 60;
            colC_Total.HeaderText   = "Total";        colC_Total.Name   = "C_Total";   colC_Total.FillWeight   = 90;
            colC_Balance.HeaderText = "Balance";      colC_Balance.Name = "C_Balance"; colC_Balance.FillWeight = 90;
            colC_Balance.DefaultCellStyle.ForeColor = Color.FromArgb(192, 57, 43);

            dgvCheckedIn.Location = new Point(10, 40);
            dgvCheckedIn.Anchor   = AnchorStyles.Top | AnchorStyles.Bottom
                                  | AnchorStyles.Left | AnchorStyles.Right;
            dgvCheckedIn.Size     = new Size(860, 540);
            StyleDGV(dgvCheckedIn, Color.FromArgb(39, 174, 96));
            dgvCheckedIn.Columns.AddRange(new DataGridViewColumn[]
            {
                colC_BId, colC_Cust, colC_Room, colC_Type,
                colC_ChIn, colC_ChOut, colC_ActualIn, colC_Nights, colC_Total, colC_Balance
            });
            dgvCheckedIn.Columns["C_BId"].Visible = false;
            dgvCheckedIn.SelectionChanged += dgvCheckedIn_SelectionChanged;

            tabCheckedIn.Controls.Add(lblCheckedInCount);
            tabCheckedIn.Controls.Add(dgvCheckedIn);

            // ── TAB CONTROL ──────────────────────────────────────────────────
            tabControl      = new TabControl();
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Segoe UI", 10F);
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            tabControl.TabPages.Add(tabReserved);
            tabControl.TabPages.Add(tabCheckedIn);

            // ── FORM ────────────────────────────────────────────────────────
            BackColor     = Color.FromArgb(240, 245, 250);
            ClientSize    = new Size(1170, 660);
            Name          = "CheckInOutForm";
            Text          = "Check In / Check Out - HMS";
            StartPosition = FormStartPosition.CenterScreen;

            Controls.Add(tabControl);
            Controls.Add(pnlDetails);
            Controls.Add(pnlHeader);

            ((System.ComponentModel.ISupportInitialize)dgvReserved).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCheckedIn).EndInit();
            ResumeLayout(false);
        }

        private Label DL(int x, int y) => new Label
        {
            ForeColor = Color.FromArgb(60,60,80),
            Font      = new Font("Segoe UI", 9.5F),
            Location  = new Point(x, y),
            Size      = new Size(244, 22),
            AutoSize  = false
        };

        private void StyleDGV(DataGridView g, Color headerColor)
        {
            g.BackgroundColor = Color.White;
            g.BorderStyle     = BorderStyle.None;
            g.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersHeight = 36;
            g.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200,225,245);
            g.DefaultCellStyle.SelectionForeColor = Color.Black;
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247,250,253);
            g.RowHeadersVisible   = false;
            g.ReadOnly            = true;
            g.AllowUserToAddRows  = false;
            g.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            g.MultiSelect         = false;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
