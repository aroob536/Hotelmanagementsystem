namespace HMS.Forms
{
    partial class CustomerForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel        pnlHeader;
        private Label        lblFormTitle;
        private Panel        pnlLeft;
        private Label        lblFormHeader;
        private Label        lblName;
        private TextBox      txtName;
        private Label        lblCnic;
        private TextBox      txtCnic;
        private Label        lblPhone;
        private TextBox      txtPhone;
        private Label        lblNationality;
        private ComboBox     cmbNationality;
        private Button       btnSave;
        private Button       btnDelete;
        private Button       btnClear;
        private Panel        pnlRight;
        private Label        lblSearch;
        private TextBox      txtSearch;
        private Button       btnSearch;
        private Button       btnRefresh;
        private Label        lblCount;
        private DataGridView dgvCustomers;
        private DataGridViewTextBoxColumn colCId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colCnic;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colNat;
        private DataGridViewTextBoxColumn colDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            colCId   = new DataGridViewTextBoxColumn();
            colName  = new DataGridViewTextBoxColumn();
            colCnic  = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colNat   = new DataGridViewTextBoxColumn();
            colDate  = new DataGridViewTextBoxColumn();
            dgvCustomers = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();

            // ── HEADER ──────────────────────────────────────────────────────
            pnlHeader           = new Panel();
            pnlHeader.BackColor = Color.FromArgb(22, 160, 133);
            pnlHeader.Dock      = DockStyle.Top;
            pnlHeader.Height    = 50;

            lblFormTitle           = new Label();
            lblFormTitle.Text      = "Customer Details";
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
            lblFormHeader.Text      = "Customer Information";
            lblFormHeader.ForeColor = Color.FromArgb(22, 160, 133);
            lblFormHeader.Font      = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFormHeader.Location  = new Point(15, 14);
            lblFormHeader.Size      = new Size(248, 26);
            lblFormHeader.AutoSize  = false;

            // Row 1 — Full Name  y=52
            lblName          = L("Full Name  *", 15, 52);
            txtName          = TB(15, 72, 248);

            // Row 2 — CNIC  y=110
            lblCnic          = L("CNIC", 15, 110);
            txtCnic          = TB(15, 130, 248);

            // Row 3 — Phone  y=168
            lblPhone         = L("Phone Number  *", 15, 168);
            txtPhone         = TB(15, 188, 248);

            // Row 4 — Nationality  y=226
            lblNationality           = L("Nationality", 15, 226);
            cmbNationality           = new ComboBox();
            cmbNationality.Font      = new Font("Segoe UI", 9.5F);
            cmbNationality.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNationality.Location  = new Point(15, 246);
            cmbNationality.Size      = new Size(248, 26);
            cmbNationality.Items.Add("Pakistani");
            cmbNationality.Items.Add("Indian");
            cmbNationality.Items.Add("American");
            cmbNationality.Items.Add("British");
            cmbNationality.Items.Add("Saudi");
            cmbNationality.Items.Add("UAE");
            cmbNationality.Items.Add("Chinese");
            cmbNationality.Items.Add("Other");
            cmbNationality.SelectedIndex = 0;

            // Buttons  y=292
            btnSave   = Btn("Add Customer", Color.FromArgb(22,160,133), Color.White, 15,  292, 118, 36);
            btnDelete = Btn("Delete",       Color.FromArgb(192,57,43),  Color.White, 145, 292, 118, 36);
            btnClear  = Btn("Clear Form",   Color.FromArgb(127,140,141),Color.White, 15,  336, 248, 34);

            btnSave.Click   += btnSave_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click  += btnClear_Click;

            pnlLeft.Controls.Add(lblFormHeader);
            pnlLeft.Controls.Add(lblName);        pnlLeft.Controls.Add(txtName);
            pnlLeft.Controls.Add(lblCnic);        pnlLeft.Controls.Add(txtCnic);
            pnlLeft.Controls.Add(lblPhone);       pnlLeft.Controls.Add(txtPhone);
            pnlLeft.Controls.Add(lblNationality); pnlLeft.Controls.Add(cmbNationality);
            pnlLeft.Controls.Add(btnSave);        pnlLeft.Controls.Add(btnDelete);
            pnlLeft.Controls.Add(btnClear);

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
            txtSearch.Size        = new Size(220, 26);
            txtSearch.KeyDown    += txtSearch_KeyDown;

            btnSearch  = Btn("Search",   Color.FromArgb(52,152,219),  Color.White, 296, 10, 76, 28);
            btnRefresh = Btn("Show All", Color.FromArgb(127,140,141), Color.White, 380, 10, 76, 28);
            btnSearch.Click  += btnSearch_Click;
            btnRefresh.Click += btnRefresh_Click;

            lblCount           = new Label();
            lblCount.Text      = "Total Customers: 0";
            lblCount.ForeColor = Color.FromArgb(80, 80, 80);
            lblCount.Font      = new Font("Segoe UI", 9F);
            lblCount.Location  = new Point(464, 14);
            lblCount.Size      = new Size(220, 20);
            lblCount.AutoSize  = false;

            // Grid columns
            colCId.HeaderText   = "ID";          colCId.Name   = "CId";   colCId.FillWeight   = 40;
            colName.HeaderText  = "Full Name";   colName.Name  = "Name";  colName.FillWeight  = 200;
            colCnic.HeaderText  = "CNIC";        colCnic.Name  = "Cnic";  colCnic.FillWeight  = 150;
            colPhone.HeaderText = "Phone";       colPhone.Name = "Phone"; colPhone.FillWeight = 120;
            colNat.HeaderText   = "Nationality"; colNat.Name   = "Nat";   colNat.FillWeight   = 110;
            colDate.HeaderText  = "Registered";  colDate.Name  = "Date";  colDate.FillWeight  = 100;

            dgvCustomers.Location = new Point(10, 48);
            dgvCustomers.Anchor   = AnchorStyles.Top | AnchorStyles.Bottom
                                  | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomers.Size     = new Size(840, 520);
            dgvCustomers.BackgroundColor = Color.White;
            dgvCustomers.BorderStyle     = BorderStyle.None;
            dgvCustomers.GridColor       = Color.FromArgb(200, 230, 225);
            dgvCustomers.ColumnHeadersHeight = 36;
            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(22, 160, 133);
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.DefaultCellStyle.Font     = new Font("Segoe UI", 9F);
            dgvCustomers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(178,223,219);
            dgvCustomers.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245,252,250);
            dgvCustomers.RowHeadersVisible   = false;
            dgvCustomers.ReadOnly            = true;
            dgvCustomers.AllowUserToAddRows  = false;
            dgvCustomers.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect         = false;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.Columns.AddRange(new DataGridViewColumn[]
                { colCId, colName, colCnic, colPhone, colNat, colDate });
            dgvCustomers.Columns["CId"].Visible = false;
            dgvCustomers.SelectionChanged += dgvCustomers_SelectionChanged;

            pnlRight.Controls.Add(lblSearch);  pnlRight.Controls.Add(txtSearch);
            pnlRight.Controls.Add(btnSearch);  pnlRight.Controls.Add(btnRefresh);
            pnlRight.Controls.Add(lblCount);   pnlRight.Controls.Add(dgvCustomers);

            // ── FORM ────────────────────────────────────────────────────────
            BackColor     = Color.FromArgb(240, 245, 250);
            ClientSize    = new Size(1150, 640);
            MinimumSize   = new Size(900, 560);
            Name          = "CustomerForm";
            Text          = "Customer Details - HMS";
            StartPosition = FormStartPosition.CenterScreen;

            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlHeader);

            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
        }

        private Label L(string t, int x, int y) => new Label
        {
            Text=t, ForeColor=Color.FromArgb(60,60,80), Font=new Font("Segoe UI",8.5F),
            Location=new Point(x,y), Size=new Size(248,18), AutoSize=false
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
