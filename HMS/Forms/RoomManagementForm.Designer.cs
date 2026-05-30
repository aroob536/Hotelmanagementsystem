namespace HMS.Forms
{
    partial class RoomManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel        pnlHeader;
        private Label        lblFormTitle;
        private Panel        pnlLeft;
        private Label        lblFormHeader;
        private Label        lblRoomNumber;
        private TextBox      txtRoomNumber;
        private Label        lblType;
        private ComboBox     cmbType;
        private Label        lblFloor;
        private NumericUpDown nudFloor;
        private Label        lblCapacity;
        private NumericUpDown nudCapacity;
        private Label        lblPrice;
        private NumericUpDown nudPrice;
        private Label        lblStatus;
        private ComboBox     cmbStatus;
        private Label        lblDescription;
        private TextBox      txtDescription;
        private Button       btnSave;
        private Button       btnDelete;
        private Button       btnClear;
        private Button       btnRefresh;
        private Panel        pnlRight;
        private Label        lblSearch;
        private TextBox      txtSearch;
        private Label        lblCount;
        private DataGridView dgvRooms;
        private DataGridViewTextBoxColumn colRoomId;
        private DataGridViewTextBoxColumn colRoomNumber;
        private DataGridViewTextBoxColumn colRoomType;
        private DataGridViewTextBoxColumn colFloor;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colCapacity;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colDesc;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            colRoomId     = new DataGridViewTextBoxColumn();
            colRoomNumber = new DataGridViewTextBoxColumn();
            colRoomType   = new DataGridViewTextBoxColumn();
            colFloor      = new DataGridViewTextBoxColumn();
            colPrice      = new DataGridViewTextBoxColumn();
            colCapacity   = new DataGridViewTextBoxColumn();
            colStatus     = new DataGridViewTextBoxColumn();
            colDesc       = new DataGridViewTextBoxColumn();
            dgvRooms      = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            SuspendLayout();

            // ── HEADER ──────────────────────────────────────────────────────
            pnlHeader           = new Panel();
            pnlHeader.BackColor = Color.FromArgb(15, 76, 129);
            pnlHeader.Dock      = DockStyle.Top;
            pnlHeader.Height    = 50;

            lblFormTitle           = new Label();
            lblFormTitle.Text      = "Room Management";
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Font      = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblFormTitle.Location  = new Point(15, 10);
            lblFormTitle.Size      = new Size(400, 30);
            lblFormTitle.AutoSize  = false;
            pnlHeader.Controls.Add(lblFormTitle);

            // ── LEFT PANEL ───────────────────────────────────────────────────
            pnlLeft           = new Panel();
            pnlLeft.BackColor = Color.White;
            pnlLeft.Dock      = DockStyle.Left;
            pnlLeft.Width     = 280;

            lblFormHeader           = new Label();
            lblFormHeader.Text      = "Room Details";
            lblFormHeader.ForeColor = Color.FromArgb(15, 76, 129);
            lblFormHeader.Font      = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFormHeader.Location  = new Point(14, 12);
            lblFormHeader.Size      = new Size(250, 26);
            lblFormHeader.AutoSize  = false;

            // Row 1 — Room Number  y=46
            lblRoomNumber           = L("Room Number  *", 14, 46);
            txtRoomNumber           = TB(14, 66, 250);

            // Row 2 — Room Type    y=106
            lblType                 = L("Room Type", 14, 106);
            cmbType                 = new ComboBox();
            cmbType.Font            = new Font("Segoe UI", 9.5F);
            cmbType.DropDownStyle   = ComboBoxStyle.DropDownList;
            cmbType.Location        = new Point(14, 126);
            cmbType.Size            = new Size(250, 26);
            cmbType.Items.Add("Standard");
            cmbType.Items.Add("Deluxe");
            cmbType.Items.Add("Suite");
            cmbType.Items.Add("Presidential Suite");
            cmbType.SelectedIndex   = 0;

            // Row 3 — Floor (left) + Capacity (right)  y=166
            lblFloor                = new Label();
            lblFloor.Text           = "Floor";
            lblFloor.ForeColor      = Color.FromArgb(60, 60, 80);
            lblFloor.Font           = new Font("Segoe UI", 8.5F);
            lblFloor.Location       = new Point(14, 166);
            lblFloor.Size           = new Size(118, 18);
            lblFloor.AutoSize       = false;

            nudFloor                = new NumericUpDown();
            nudFloor.Font           = new Font("Segoe UI", 9.5F);
            nudFloor.Location       = new Point(14, 186);
            nudFloor.Size           = new Size(118, 26);
            nudFloor.Minimum        = 1;
            nudFloor.Maximum        = 50;
            nudFloor.Value          = 1;

            lblCapacity             = new Label();
            lblCapacity.Text        = "Capacity (persons)";
            lblCapacity.ForeColor   = Color.FromArgb(60, 60, 80);
            lblCapacity.Font        = new Font("Segoe UI", 8.5F);
            lblCapacity.Location    = new Point(146, 166);
            lblCapacity.Size        = new Size(118, 18);
            lblCapacity.AutoSize    = false;

            nudCapacity             = new NumericUpDown();
            nudCapacity.Font        = new Font("Segoe UI", 9.5F);
            nudCapacity.Location    = new Point(146, 186);
            nudCapacity.Size        = new Size(118, 26);
            nudCapacity.Minimum     = 1;
            nudCapacity.Maximum     = 20;
            nudCapacity.Value       = 2;

            // Row 4 — Price  y=226
            lblPrice                    = L("Price Per Night (Rs.)", 14, 226);
            nudPrice                    = new NumericUpDown();
            nudPrice.Font               = new Font("Segoe UI", 9.5F);
            nudPrice.Location           = new Point(14, 246);
            nudPrice.Size               = new Size(250, 26);
            nudPrice.Minimum            = 500;
            nudPrice.Maximum            = 999999;
            nudPrice.Value              = 3500;
            nudPrice.ThousandsSeparator = true;
            nudPrice.DecimalPlaces      = 0;

            // Row 5 — Status  y=286
            lblStatus               = L("Status", 14, 286);
            cmbStatus               = new ComboBox();
            cmbStatus.Font          = new Font("Segoe UI", 9.5F);
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Location      = new Point(14, 306);
            cmbStatus.Size          = new Size(250, 26);
            cmbStatus.Items.Add("Available");
            cmbStatus.Items.Add("Occupied");
            cmbStatus.Items.Add("Reserved");
            cmbStatus.Items.Add("Under Maintenance");
            cmbStatus.SelectedIndex = 0;

            // Row 6 — Description  y=346
            lblDescription             = L("Description (optional)", 14, 346);
            txtDescription             = new TextBox();
            txtDescription.Font        = new Font("Segoe UI", 9.5F);
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Location    = new Point(14, 366);
            txtDescription.Size        = new Size(250, 52);
            txtDescription.Multiline   = true;
            txtDescription.ScrollBars  = ScrollBars.Vertical;

            // Buttons  y=432
            btnSave    = Btn("Add Room",  Color.FromArgb(15,76,129),    Color.White, 14,  432, 118, 36);
            btnDelete  = Btn("Delete",    Color.FromArgb(192,57,43),    Color.White, 146, 432, 118, 36);
            btnClear   = Btn("Clear",     Color.FromArgb(127,140,141),  Color.White, 14,  476, 118, 34);
            btnRefresh = Btn("Refresh",   Color.FromArgb(39,174,96),    Color.White, 146, 476, 118, 34);

            btnSave.Click    += btnSave_Click;
            btnDelete.Click  += btnDelete_Click;
            btnClear.Click   += btnClear_Click;
            btnRefresh.Click += btnRefresh_Click;

            pnlLeft.Controls.Add(lblFormHeader);
            pnlLeft.Controls.Add(lblRoomNumber); pnlLeft.Controls.Add(txtRoomNumber);
            pnlLeft.Controls.Add(lblType);       pnlLeft.Controls.Add(cmbType);
            pnlLeft.Controls.Add(lblFloor);      pnlLeft.Controls.Add(nudFloor);
            pnlLeft.Controls.Add(lblCapacity);   pnlLeft.Controls.Add(nudCapacity);
            pnlLeft.Controls.Add(lblPrice);      pnlLeft.Controls.Add(nudPrice);
            pnlLeft.Controls.Add(lblStatus);     pnlLeft.Controls.Add(cmbStatus);
            pnlLeft.Controls.Add(lblDescription);pnlLeft.Controls.Add(txtDescription);
            pnlLeft.Controls.Add(btnSave);       pnlLeft.Controls.Add(btnDelete);
            pnlLeft.Controls.Add(btnClear);      pnlLeft.Controls.Add(btnRefresh);

            // ── RIGHT PANEL ──────────────────────────────────────────────────
            pnlRight           = new Panel();
            pnlRight.BackColor = Color.FromArgb(245, 247, 250);
            pnlRight.Dock      = DockStyle.Fill;

            lblSearch           = new Label();
            lblSearch.Text      = "Search:";
            lblSearch.ForeColor = Color.FromArgb(60, 60, 60);
            lblSearch.Font      = new Font("Segoe UI", 9F);
            lblSearch.Location  = new Point(12, 14);
            lblSearch.Size      = new Size(52, 22);
            lblSearch.AutoSize  = false;

            txtSearch             = new TextBox();
            txtSearch.Font        = new Font("Segoe UI", 9.5F);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Location    = new Point(68, 12);
            txtSearch.Size        = new Size(230, 26);
            txtSearch.TextChanged += txtSearch_TextChanged;

            lblCount           = new Label();
            lblCount.Text      = "Total Rooms: 0";
            lblCount.ForeColor = Color.FromArgb(80, 80, 80);
            lblCount.Font      = new Font("Segoe UI", 9F);
            lblCount.Location  = new Point(312, 14);
            lblCount.Size      = new Size(200, 20);
            lblCount.AutoSize  = false;

            // Grid columns — flat declarations
            colRoomId.HeaderText     = "ID";           colRoomId.Name     = "RoomId";     colRoomId.FillWeight     = 40;
            colRoomNumber.HeaderText = "Room No.";     colRoomNumber.Name = "RoomNumber";  colRoomNumber.FillWeight = 80;
            colRoomType.HeaderText   = "Type";         colRoomType.Name   = "RoomType";    colRoomType.FillWeight   = 110;
            colFloor.HeaderText      = "Floor";        colFloor.Name      = "Floor";       colFloor.FillWeight      = 50;
            colPrice.HeaderText      = "Price/Night";  colPrice.Name      = "Price";       colPrice.FillWeight      = 110;
            colCapacity.HeaderText   = "Capacity";     colCapacity.Name   = "Capacity";    colCapacity.FillWeight   = 70;
            colStatus.HeaderText     = "Status";       colStatus.Name     = "Status";      colStatus.FillWeight     = 110;
            colDesc.HeaderText       = "Description";  colDesc.Name       = "Description"; colDesc.FillWeight       = 180;

            dgvRooms.Location = new Point(10, 48);
            dgvRooms.Anchor   = AnchorStyles.Top | AnchorStyles.Bottom
                              | AnchorStyles.Left | AnchorStyles.Right;
            dgvRooms.Size     = new Size(860, 530);
            dgvRooms.BackgroundColor = Color.White;
            dgvRooms.BorderStyle     = BorderStyle.None;
            dgvRooms.GridColor       = Color.FromArgb(210, 225, 240);
            dgvRooms.ColumnHeadersHeight = 36;
            dgvRooms.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 76, 129);
            dgvRooms.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRooms.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvRooms.EnableHeadersVisualStyles = false;
            dgvRooms.DefaultCellStyle.Font     = new Font("Segoe UI", 9F);
            dgvRooms.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 215, 250);
            dgvRooms.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvRooms.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 254);
            dgvRooms.RowHeadersVisible   = false;
            dgvRooms.ReadOnly            = true;
            dgvRooms.AllowUserToAddRows  = false;
            dgvRooms.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.MultiSelect         = false;
            dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRooms.Columns.AddRange(new DataGridViewColumn[]
            {
                colRoomId, colRoomNumber, colRoomType, colFloor,
                colPrice, colCapacity, colStatus, colDesc
            });
            dgvRooms.Columns["RoomId"].Visible = false;
            dgvRooms.SelectionChanged += dgvRooms_SelectionChanged;

            pnlRight.Controls.Add(lblSearch);
            pnlRight.Controls.Add(txtSearch);
            pnlRight.Controls.Add(lblCount);
            pnlRight.Controls.Add(dgvRooms);

            // ── FORM ────────────────────────────────────────────────────────
            BackColor     = Color.FromArgb(240, 245, 250);
            ClientSize    = new Size(1160, 650);
            MinimumSize   = new Size(900, 560);
            Name          = "RoomManagementForm";
            Text          = "Room Management - HMS";
            StartPosition = FormStartPosition.CenterScreen;

            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlHeader);

            ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
            ResumeLayout(false);
        }

        private Label L(string t, int x, int y) => new Label
        {
            Text=t, ForeColor=Color.FromArgb(60,60,80), Font=new Font("Segoe UI",8.5F),
            Location=new Point(x,y), Size=new Size(250,18), AutoSize=false
        };
        private TextBox TB(int x, int y, int w) => new TextBox
        {
            Font=new Font("Segoe UI",9.5F), BorderStyle=BorderStyle.FixedSingle,
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
