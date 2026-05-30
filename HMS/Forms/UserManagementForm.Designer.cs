namespace HMS.Forms
{
    partial class UserManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel        pnlHeader;
        private Label        lblFormTitle;
        private Panel        pnlLeft;
        private Label        lblFormHeader;
        private Label        lblUsername;
        private TextBox      txtUsername;
        private Label        lblFullName;
        private TextBox      txtFullName;
        private Label        lblEmail;
        private TextBox      txtEmail;
        private Label        lblRole;
        private ComboBox     cmbRole;
        private Label        lblPassword;
        private TextBox      txtPassword;
        private Label        lblPwdNote;
        private Label        lblConfirmPwd;
        private TextBox      txtConfirmPwd;
        private Label        lblActive;
        private CheckBox     chkActive;
        private Button       btnSave;
        private Button       btnDelete;
        private Button       btnClear;
        private Button       btnRefresh;
        private Panel        pnlRight;
        private Label        lblCount;
        private DataGridView dgvUsers;
        private DataGridViewTextBoxColumn colUserId;
        private DataGridViewTextBoxColumn colUsername;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colRole;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colCreated;
        private DataGridViewTextBoxColumn colLastLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            colUserId   = new DataGridViewTextBoxColumn();
            colUsername = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colRole     = new DataGridViewTextBoxColumn();
            colEmail    = new DataGridViewTextBoxColumn();
            colStatus   = new DataGridViewTextBoxColumn();
            colCreated  = new DataGridViewTextBoxColumn();
            colLastLogin= new DataGridViewTextBoxColumn();
            dgvUsers    = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();

            // ── HEADER ──────────────────────────────────────────────────────
            pnlHeader           = new Panel();
            pnlHeader.BackColor = Color.FromArgb(44, 62, 80);
            pnlHeader.Dock      = DockStyle.Top;
            pnlHeader.Height    = 50;

            lblFormTitle           = new Label();
            lblFormTitle.Text      = "User Management";
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
            pnlLeft.Width     = 300;

            lblFormHeader           = new Label();
            lblFormHeader.Text      = "User Details";
            lblFormHeader.ForeColor = Color.FromArgb(44, 62, 80);
            lblFormHeader.Font      = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFormHeader.Location  = new Point(15, 12);
            lblFormHeader.Size      = new Size(265, 26);
            lblFormHeader.AutoSize  = false;

            lblUsername          = L("Username  *", 15, 48);
            txtUsername          = TB(15, 68, 265);

            lblFullName          = L("Full Name  *", 15, 106);
            txtFullName          = TB(15, 126, 265);

            lblEmail             = L("Email", 15, 164);
            txtEmail             = TB(15, 184, 265);

            lblRole              = L("Role", 15, 222);
            cmbRole              = new ComboBox();
            cmbRole.Font         = new Font("Segoe UI", 9.5F);
            cmbRole.DropDownStyle= ComboBoxStyle.DropDownList;
            cmbRole.Location     = new Point(15, 242);
            cmbRole.Size         = new Size(265, 26);
            cmbRole.Items.Add("admin");
            cmbRole.Items.Add("staff");
            cmbRole.Items.Add("receptionist");
            cmbRole.SelectedIndex= 1;

            lblPassword          = L("Password", 15, 280);
            txtPassword          = TB(15, 300, 265);
            txtPassword.PasswordChar = '●';

            lblPwdNote           = new Label();
            lblPwdNote.Text      = "Leave blank to keep unchanged";
            lblPwdNote.ForeColor = Color.FromArgb(150, 150, 150);
            lblPwdNote.Font      = new Font("Segoe UI", 7.5F, FontStyle.Italic);
            lblPwdNote.Location  = new Point(15, 328);
            lblPwdNote.Size      = new Size(265, 16);
            lblPwdNote.AutoSize  = false;

            lblConfirmPwd        = L("Confirm Password", 15, 350);
            txtConfirmPwd        = TB(15, 370, 265);
            txtConfirmPwd.PasswordChar = '●';

            lblActive            = L("Account Status", 15, 408);
            chkActive            = new CheckBox();
            chkActive.Text       = "Active Account";
            chkActive.Font       = new Font("Segoe UI", 9.5F);
            chkActive.ForeColor  = Color.FromArgb(39, 174, 96);
            chkActive.Location   = new Point(15, 428);
            chkActive.Size       = new Size(200, 24);
            chkActive.Checked    = true;

            btnSave    = Btn("Add User",  Color.FromArgb(44,62,80),    Color.White, 15,  468, 125, 36);
            btnDelete  = Btn("Delete",    Color.FromArgb(192,57,43),   Color.White, 155, 468, 125, 36);
            btnClear   = Btn("Clear",     Color.FromArgb(127,140,141), Color.White, 15,  512, 125, 34);
            btnRefresh = Btn("Refresh",   Color.FromArgb(52,152,219),  Color.White, 155, 512, 125, 34);

            btnSave.Click    += btnSave_Click;
            btnDelete.Click  += btnDelete_Click;
            btnClear.Click   += btnClear_Click;
            btnRefresh.Click += btnRefresh_Click;

            pnlLeft.Controls.Add(lblFormHeader);
            pnlLeft.Controls.Add(lblUsername);   pnlLeft.Controls.Add(txtUsername);
            pnlLeft.Controls.Add(lblFullName);   pnlLeft.Controls.Add(txtFullName);
            pnlLeft.Controls.Add(lblEmail);      pnlLeft.Controls.Add(txtEmail);
            pnlLeft.Controls.Add(lblRole);       pnlLeft.Controls.Add(cmbRole);
            pnlLeft.Controls.Add(lblPassword);   pnlLeft.Controls.Add(txtPassword);
            pnlLeft.Controls.Add(lblPwdNote);
            pnlLeft.Controls.Add(lblConfirmPwd); pnlLeft.Controls.Add(txtConfirmPwd);
            pnlLeft.Controls.Add(lblActive);     pnlLeft.Controls.Add(chkActive);
            pnlLeft.Controls.Add(btnSave);       pnlLeft.Controls.Add(btnDelete);
            pnlLeft.Controls.Add(btnClear);      pnlLeft.Controls.Add(btnRefresh);

            // ── RIGHT PANEL ──────────────────────────────────────────────────
            pnlRight           = new Panel();
            pnlRight.BackColor = Color.FromArgb(245, 247, 250);
            pnlRight.Dock      = DockStyle.Fill;

            lblCount           = new Label();
            lblCount.Text      = "Users: 0";
            lblCount.ForeColor = Color.FromArgb(80,80,80);
            lblCount.Font      = new Font("Segoe UI", 9F);
            lblCount.Location  = new Point(15, 14);
            lblCount.Size      = new Size(200, 20);
            lblCount.AutoSize  = false;

            // DataGridView columns
            colUserId.HeaderText  = "ID";       colUserId.Name  = "UserId";   colUserId.FillWeight   = 40;
            colUsername.HeaderText= "Username"; colUsername.Name= "Username"; colUsername.FillWeight = 120;
            colFullName.HeaderText= "Full Name";colFullName.Name= "FullName"; colFullName.FillWeight = 150;
            colRole.HeaderText    = "Role";     colRole.Name    = "Role";     colRole.FillWeight     = 80;
            colEmail.HeaderText   = "Email";    colEmail.Name   = "Email";    colEmail.FillWeight    = 150;
            colStatus.HeaderText  = "Status";   colStatus.Name  = "Status";   colStatus.FillWeight   = 70;
            colCreated.HeaderText = "Created";  colCreated.Name = "Created";  colCreated.FillWeight  = 90;
            colLastLogin.HeaderText="Last Login";colLastLogin.Name="LastLogin";colLastLogin.FillWeight=110;

            dgvUsers.Location = new Point(10, 44);
            dgvUsers.Anchor   = AnchorStyles.Top | AnchorStyles.Bottom
                              | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.Size     = new Size(840, 528);
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle     = BorderStyle.None;
            dgvUsers.GridColor       = Color.FromArgb(210, 220, 230);
            dgvUsers.ColumnHeadersHeight = 36;
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.DefaultCellStyle.Font     = new Font("Segoe UI", 9F);
            dgvUsers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 195, 215);
            dgvUsers.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 251);
            dgvUsers.RowHeadersVisible   = false;
            dgvUsers.ReadOnly            = true;
            dgvUsers.AllowUserToAddRows  = false;
            dgvUsers.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect         = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[]
            {
                colUserId, colUsername, colFullName, colRole,
                colEmail, colStatus, colCreated, colLastLogin
            });
            dgvUsers.Columns["UserId"].Visible = false;
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;

            pnlRight.Controls.Add(lblCount);
            pnlRight.Controls.Add(dgvUsers);

            // ── FORM ────────────────────────────────────────────────────────
            BackColor     = Color.FromArgb(240, 245, 250);
            ClientSize    = new Size(1150, 640);
            Name          = "UserManagementForm";
            Text          = "User Management - HMS";
            StartPosition = FormStartPosition.CenterScreen;

            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlHeader);

            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
        }

        private Label L(string t, int x, int y) => new Label
        {
            Text=t, ForeColor=Color.FromArgb(60,60,80), Font=new Font("Segoe UI",8.5F),
            Location=new Point(x,y), Size=new Size(265,18), AutoSize=false
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
            b.FlatAppearance.BorderSize=0;
            return b;
        }
    }
}
