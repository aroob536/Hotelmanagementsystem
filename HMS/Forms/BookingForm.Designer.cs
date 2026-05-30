namespace HMS.Forms
{
    partial class BookingForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel         pnlHeader;
        private Label         lblFormTitle;
        private Panel         pnlLeft;
        private Label         lblFormHeader;
        private Label         lblCustomer;
        private ComboBox      cmbCustomer;
        private Label         lblRoom;
        private ComboBox      cmbRoom;
        private Label         lblTotal;
        private Label         lblCheckIn;
        private DateTimePicker dtpCheckIn;
        private Label         lblCheckOut;
        private DateTimePicker dtpCheckOut;
        private Label         lblAdults;
        private NumericUpDown nudAdults;
        private Label         lblStatus;
        private ComboBox      cmbStatus;
        private Label         lblTotalAmount;
        private TextBox       txtTotalAmount;
        private Label         lblPaidAmount;
        private TextBox       txtPaidAmount;
        private Label         lblNotes;
        private TextBox       txtNotes;
        private Button        btnSave;
        private Button        btnCancelBooking;
        private Button        btnClear;
        private Panel         pnlRight;
        private Label         lblFilter;
        private ComboBox      cmbFilter;
        private Label         lblCount;
        private DataGridView  dgvBookings;
        private DataGridViewTextBoxColumn colBId;
        private DataGridViewTextBoxColumn colCustomer;
        private DataGridViewTextBoxColumn colRoom;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colCheckIn;
        private DataGridViewTextBoxColumn colCheckOut;
        private DataGridViewTextBoxColumn colNights;
        private DataGridViewTextBoxColumn colAdults;
        private DataGridViewTextBoxColumn colBStatus;
        private DataGridViewTextBoxColumn colBTotal;
        private DataGridViewTextBoxColumn colBPaid;
        private DataGridViewTextBoxColumn colBalance;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            colBId      = new DataGridViewTextBoxColumn();
            colCustomer = new DataGridViewTextBoxColumn();
            colRoom     = new DataGridViewTextBoxColumn();
            colType     = new DataGridViewTextBoxColumn();
            colCheckIn  = new DataGridViewTextBoxColumn();
            colCheckOut = new DataGridViewTextBoxColumn();
            colNights   = new DataGridViewTextBoxColumn();
            colAdults   = new DataGridViewTextBoxColumn();
            colBStatus  = new DataGridViewTextBoxColumn();
            colBTotal   = new DataGridViewTextBoxColumn();
            colBPaid    = new DataGridViewTextBoxColumn();
            colBalance  = new DataGridViewTextBoxColumn();
            dgvBookings = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            SuspendLayout();

            // ── HEADER ──────────────────────────────────────────────────────
            pnlHeader           = new Panel();
            pnlHeader.BackColor = Color.FromArgb(52, 73, 94);
            pnlHeader.Dock      = DockStyle.Top;
            pnlHeader.Height    = 50;

            lblFormTitle           = new Label();
            lblFormTitle.Text      = "Booking Management";
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Font      = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblFormTitle.Location  = new Point(15, 10);
            lblFormTitle.Size      = new Size(400, 30);
            lblFormTitle.AutoSize  = false;
            pnlHeader.Controls.Add(lblFormTitle);

            // ── LEFT PANEL ───────────────────────────────────────────────────
            pnlLeft            = new Panel();
            pnlLeft.BackColor  = Color.White;
            pnlLeft.Dock       = DockStyle.Left;
            pnlLeft.Width      = 315;
            pnlLeft.AutoScroll = true;

            lblFormHeader           = new Label();
            lblFormHeader.Text      = "New / Edit Booking";
            lblFormHeader.ForeColor = Color.FromArgb(52, 73, 94);
            lblFormHeader.Font      = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFormHeader.Location  = new Point(12, 10);
            lblFormHeader.Size      = new Size(288, 26);
            lblFormHeader.AutoSize  = false;

            // Row 1 — Customer  y=44
            lblCustomer          = L("Customer  *", 12, 44);
            cmbCustomer          = CB(12, 64, 288);

            // Row 2 — Room  y=102
            lblRoom              = L("Room  *", 12, 102);
            cmbRoom              = CB(12, 122, 288);
            cmbRoom.SelectedIndexChanged += cmbRoom_SelectedIndexChanged;

            // Price info  y=152
            lblTotal             = new Label();
            lblTotal.Text        = "Select room and dates";
            lblTotal.ForeColor   = Color.FromArgb(22, 160, 133);
            lblTotal.Font        = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblTotal.Location    = new Point(12, 152);
            lblTotal.Size        = new Size(288, 18);
            lblTotal.AutoSize    = false;

            // Row 3 — Check-In / Check-Out  y=178
            lblCheckIn           = new Label();
            lblCheckIn.Text      = "Check-In  *";
            lblCheckIn.ForeColor = Color.FromArgb(60, 60, 80);
            lblCheckIn.Font      = new Font("Segoe UI", 8.5F);
            lblCheckIn.Location  = new Point(12, 178);
            lblCheckIn.Size      = new Size(138, 18);
            lblCheckIn.AutoSize  = false;

            dtpCheckIn           = new DateTimePicker();
            dtpCheckIn.Font      = new Font("Segoe UI", 9F);
            dtpCheckIn.Format    = DateTimePickerFormat.Short;
            dtpCheckIn.Location  = new Point(12, 198);
            dtpCheckIn.Size      = new Size(138, 26);
            dtpCheckIn.Value     = DateTime.Today;
            dtpCheckIn.ValueChanged += dtpCheckIn_ValueChanged;

            lblCheckOut          = new Label();
            lblCheckOut.Text     = "Check-Out  *";
            lblCheckOut.ForeColor= Color.FromArgb(60, 60, 80);
            lblCheckOut.Font     = new Font("Segoe UI", 8.5F);
            lblCheckOut.Location = new Point(162, 178);
            lblCheckOut.Size     = new Size(138, 18);
            lblCheckOut.AutoSize = false;

            dtpCheckOut          = new DateTimePicker();
            dtpCheckOut.Font     = new Font("Segoe UI", 9F);
            dtpCheckOut.Format   = DateTimePickerFormat.Short;
            dtpCheckOut.Location = new Point(162, 198);
            dtpCheckOut.Size     = new Size(138, 26);
            dtpCheckOut.Value    = DateTime.Today.AddDays(1);
            dtpCheckOut.ValueChanged += dtpCheckOut_ValueChanged;

            // Row 4 — Adults / Status  y=238
            lblAdults            = new Label();
            lblAdults.Text       = "Adults";
            lblAdults.ForeColor  = Color.FromArgb(60, 60, 80);
            lblAdults.Font       = new Font("Segoe UI", 8.5F);
            lblAdults.Location   = new Point(12, 238);
            lblAdults.Size       = new Size(138, 18);
            lblAdults.AutoSize   = false;

            nudAdults            = new NumericUpDown();
            nudAdults.Font       = new Font("Segoe UI", 9.5F);
            nudAdults.Location   = new Point(12, 258);
            nudAdults.Size       = new Size(138, 26);
            nudAdults.Minimum    = 1;
            nudAdults.Maximum    = 20;
            nudAdults.Value      = 1;

            lblStatus            = new Label();
            lblStatus.Text       = "Status";
            lblStatus.ForeColor  = Color.FromArgb(60, 60, 80);
            lblStatus.Font       = new Font("Segoe UI", 8.5F);
            lblStatus.Location   = new Point(162, 238);
            lblStatus.Size       = new Size(138, 18);
            lblStatus.AutoSize   = false;

            cmbStatus            = CB(162, 258, 138);

            // Row 5 — Total / Paid  y=298
            lblTotalAmount           = new Label();
            lblTotalAmount.Text      = "Total Amount (Rs.)";
            lblTotalAmount.ForeColor = Color.FromArgb(60, 60, 80);
            lblTotalAmount.Font      = new Font("Segoe UI", 8.5F);
            lblTotalAmount.Location  = new Point(12, 298);
            lblTotalAmount.Size      = new Size(138, 18);
            lblTotalAmount.AutoSize  = false;

            txtTotalAmount             = new TextBox();
            txtTotalAmount.Font        = new Font("Segoe UI", 9.5F);
            txtTotalAmount.BorderStyle = BorderStyle.FixedSingle;
            txtTotalAmount.Location    = new Point(12, 318);
            txtTotalAmount.Size        = new Size(138, 26);
            txtTotalAmount.Text        = "0";

            lblPaidAmount            = new Label();
            lblPaidAmount.Text       = "Paid Amount (Rs.)";
            lblPaidAmount.ForeColor  = Color.FromArgb(60, 60, 80);
            lblPaidAmount.Font       = new Font("Segoe UI", 8.5F);
            lblPaidAmount.Location   = new Point(162, 298);
            lblPaidAmount.Size       = new Size(138, 18);
            lblPaidAmount.AutoSize   = false;

            txtPaidAmount             = new TextBox();
            txtPaidAmount.Font        = new Font("Segoe UI", 9.5F);
            txtPaidAmount.BorderStyle = BorderStyle.FixedSingle;
            txtPaidAmount.ForeColor   = Color.FromArgb(39, 174, 96);
            txtPaidAmount.Location    = new Point(162, 318);
            txtPaidAmount.Size        = new Size(138, 26);
            txtPaidAmount.Text        = "0";

            // Row 6 — Notes  y=358
            lblNotes              = L("Notes", 12, 358);
            txtNotes              = new TextBox();
            txtNotes.Font         = new Font("Segoe UI", 9.5F);
            txtNotes.BorderStyle  = BorderStyle.FixedSingle;
            txtNotes.Location     = new Point(12, 378);
            txtNotes.Size         = new Size(288, 52);
            txtNotes.Multiline    = true;
            txtNotes.ScrollBars   = ScrollBars.Vertical;

            // Buttons  y=444
            btnSave          = Btn("Add Booking",    Color.FromArgb(52,73,94),    Color.White, 12,  444, 138, 36);
            btnCancelBooking = Btn("Cancel Booking", Color.FromArgb(192,57,43),   Color.White, 162, 444, 138, 36);
            btnClear         = Btn("Clear Form",     Color.FromArgb(127,140,141), Color.White, 12,  488, 288, 34);

            btnSave.Click          += btnSave_Click;
            btnCancelBooking.Click += btnCancelBooking_Click;
            btnClear.Click         += btnClear_Click;

            pnlLeft.Controls.Add(lblFormHeader);
            pnlLeft.Controls.Add(lblCustomer);     pnlLeft.Controls.Add(cmbCustomer);
            pnlLeft.Controls.Add(lblRoom);         pnlLeft.Controls.Add(cmbRoom);
            pnlLeft.Controls.Add(lblTotal);
            pnlLeft.Controls.Add(lblCheckIn);      pnlLeft.Controls.Add(dtpCheckIn);
            pnlLeft.Controls.Add(lblCheckOut);     pnlLeft.Controls.Add(dtpCheckOut);
            pnlLeft.Controls.Add(lblAdults);       pnlLeft.Controls.Add(nudAdults);
            pnlLeft.Controls.Add(lblStatus);       pnlLeft.Controls.Add(cmbStatus);
            pnlLeft.Controls.Add(lblTotalAmount);  pnlLeft.Controls.Add(txtTotalAmount);
            pnlLeft.Controls.Add(lblPaidAmount);   pnlLeft.Controls.Add(txtPaidAmount);
            pnlLeft.Controls.Add(lblNotes);        pnlLeft.Controls.Add(txtNotes);
            pnlLeft.Controls.Add(btnSave);
            pnlLeft.Controls.Add(btnCancelBooking);
            pnlLeft.Controls.Add(btnClear);

            // ── RIGHT PANEL ──────────────────────────────────────────────────
            pnlRight           = new Panel();
            pnlRight.BackColor = Color.FromArgb(245, 247, 250);
            pnlRight.Dock      = DockStyle.Fill;

            lblFilter            = new Label();
            lblFilter.Text       = "Filter:";
            lblFilter.ForeColor  = Color.FromArgb(60, 60, 60);
            lblFilter.Font       = new Font("Segoe UI", 9F);
            lblFilter.Location   = new Point(12, 14);
            lblFilter.Size       = new Size(44, 22);
            lblFilter.AutoSize   = false;

            cmbFilter            = CB(60, 12, 150);
            cmbFilter.Items.Add("All");
            cmbFilter.Items.Add("Reserved");
            cmbFilter.Items.Add("Checked-In");
            cmbFilter.Items.Add("Checked-Out");
            cmbFilter.Items.Add("Cancelled");
            cmbFilter.SelectedIndex = 0;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;

            lblCount             = new Label();
            lblCount.Text        = "Bookings: 0";
            lblCount.ForeColor   = Color.FromArgb(80, 80, 80);
            lblCount.Font        = new Font("Segoe UI", 9F);
            lblCount.Location    = new Point(220, 14);
            lblCount.Size        = new Size(180, 20);
            lblCount.AutoSize    = false;

            // Grid columns
            colBId.HeaderText      = "ID";         colBId.Name      = "BId";      colBId.FillWeight      = 40;
            colCustomer.HeaderText = "Customer";   colCustomer.Name = "Customer"; colCustomer.FillWeight = 140;
            colRoom.HeaderText     = "Room";       colRoom.Name     = "Room";     colRoom.FillWeight     = 70;
            colType.HeaderText     = "Type";       colType.Name     = "Type";     colType.FillWeight     = 90;
            colCheckIn.HeaderText  = "Check-In";   colCheckIn.Name  = "CheckIn";  colCheckIn.FillWeight  = 80;
            colCheckOut.HeaderText = "Check-Out";  colCheckOut.Name = "CheckOut"; colCheckOut.FillWeight = 80;
            colNights.HeaderText   = "Nights";     colNights.Name   = "Nights";   colNights.FillWeight   = 55;
            colAdults.HeaderText   = "Adults";     colAdults.Name   = "Adults";   colAdults.FillWeight   = 55;
            colBStatus.HeaderText  = "Status";     colBStatus.Name  = "Status";   colBStatus.FillWeight  = 90;
            colBTotal.HeaderText   = "Total";      colBTotal.Name   = "Total";    colBTotal.FillWeight   = 90;
            colBPaid.HeaderText    = "Paid";       colBPaid.Name    = "Paid";     colBPaid.FillWeight    = 90;
            colBalance.HeaderText  = "Balance";    colBalance.Name  = "Balance";  colBalance.FillWeight  = 90;
            colBalance.DefaultCellStyle.ForeColor = Color.FromArgb(192, 57, 43);

            dgvBookings.Location = new Point(10, 46);
            dgvBookings.Anchor   = AnchorStyles.Top | AnchorStyles.Bottom
                                 | AnchorStyles.Left | AnchorStyles.Right;
            dgvBookings.Size     = new Size(840, 530);
            dgvBookings.BackgroundColor = Color.White;
            dgvBookings.BorderStyle     = BorderStyle.None;
            dgvBookings.GridColor       = Color.FromArgb(210, 215, 225);
            dgvBookings.ColumnHeadersHeight = 36;
            dgvBookings.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvBookings.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBookings.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvBookings.EnableHeadersVisualStyles = false;
            dgvBookings.DefaultCellStyle.Font     = new Font("Segoe UI", 9F);
            dgvBookings.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 190, 210);
            dgvBookings.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvBookings.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 251);
            dgvBookings.RowHeadersVisible   = false;
            dgvBookings.ReadOnly            = true;
            dgvBookings.AllowUserToAddRows  = false;
            dgvBookings.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.MultiSelect         = false;
            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookings.Columns.AddRange(new DataGridViewColumn[]
            {
                colBId, colCustomer, colRoom, colType, colCheckIn, colCheckOut,
                colNights, colAdults, colBStatus, colBTotal, colBPaid, colBalance
            });
            dgvBookings.Columns["BId"].Visible = false;
            dgvBookings.SelectionChanged += dgvBookings_SelectionChanged;

            pnlRight.Controls.Add(lblFilter);
            pnlRight.Controls.Add(cmbFilter);
            pnlRight.Controls.Add(lblCount);
            pnlRight.Controls.Add(dgvBookings);

            // ── FORM ────────────────────────────────────────────────────────
            BackColor     = Color.FromArgb(240, 245, 250);
            ClientSize    = new Size(1170, 660);
            Name          = "BookingForm";
            Text          = "Bookings - HMS";
            StartPosition = FormStartPosition.CenterScreen;

            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlHeader);

            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            ResumeLayout(false);
        }

        private Label L(string t, int x, int y) => new Label
        {
            Text=t, ForeColor=Color.FromArgb(60,60,80), Font=new Font("Segoe UI",8.5F),
            Location=new Point(x,y), Size=new Size(288,18), AutoSize=false
        };
        private ComboBox CB(int x, int y, int w) => new ComboBox
        {
            Font=new Font("Segoe UI",9.5F), DropDownStyle=ComboBoxStyle.DropDownList,
            Location=new Point(x,y), Size=new Size(w,26)
        };
        private Button Btn(string t, Color back, Color fore, int x, int y, int w, int h)
        {
            var b = new Button
            {
                Text=t, BackColor=back, ForeColor=fore, FlatStyle=FlatStyle.Flat,
                Font=new Font("Segoe UI",9F,FontStyle.Bold),
                Location=new Point(x,y), Size=new Size(w,h), Cursor=Cursors.Hand
            };
            b.FlatAppearance.BorderSize=0; return b;
        }
    }
}
