namespace HMS.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel   pnlTop;
        private Label   lblHotelName;
        private Label   lblSubtitle;
        private Label   lblSignIn;
        private Label   lblUsername;
        private TextBox txtUsername;
        private Label   lblPassword;
        private TextBox txtPassword;
        private Button  btnLogin;
        private Button  btnExit;
        private Label   lblFooter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            // ── TOP HEADER ──────────────────────────────────────────────────
            pnlTop           = new Panel();
            pnlTop.BackColor = Color.FromArgb(15, 76, 129);
            pnlTop.Dock      = DockStyle.Top;
            pnlTop.Height    = 110;

            lblHotelName           = new Label();
            lblHotelName.Text      = "GRAND HOTEL";
            lblHotelName.ForeColor = Color.White;
            lblHotelName.Font      = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblHotelName.TextAlign = ContentAlignment.MiddleCenter;
            lblHotelName.Location  = new Point(0, 14);
            lblHotelName.Size      = new Size(400, 48);

            lblSubtitle           = new Label();
            lblSubtitle.Text      = "Hotel Management System";
            lblSubtitle.ForeColor = Color.FromArgb(180, 220, 255);
            lblSubtitle.Font      = new Font("Segoe UI", 10F);
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            lblSubtitle.Location  = new Point(0, 68);
            lblSubtitle.Size      = new Size(400, 26);

            pnlTop.Controls.Add(lblHotelName);
            pnlTop.Controls.Add(lblSubtitle);

            // ── FORM FIELDS — placed directly on form (no inner panel) ──────
            // This avoids any panel clipping / overlap issues

            // "Sign In" heading  y=130
            lblSignIn           = new Label();
            lblSignIn.Text      = "Sign In";
            lblSignIn.ForeColor = Color.FromArgb(15, 76, 129);
            lblSignIn.Font      = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblSignIn.TextAlign = ContentAlignment.MiddleCenter;
            lblSignIn.Location  = new Point(30, 128);
            lblSignIn.Size      = new Size(340, 34);

            // Username label  y=175
            lblUsername           = new Label();
            lblUsername.Text      = "Username";
            lblUsername.ForeColor = Color.FromArgb(80, 80, 80);
            lblUsername.Font      = new Font("Segoe UI", 9F);
            lblUsername.Location  = new Point(40, 175);
            lblUsername.Size      = new Size(320, 20);

            // Username textbox  y=197  (175+20+2)
            txtUsername             = new TextBox();
            txtUsername.Font        = new Font("Segoe UI", 10F);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Location    = new Point(40, 197);
            txtUsername.Size        = new Size(320, 28);
            txtUsername.Text        = "admin";

            // Password label  y=242  (197+28+17)
            lblPassword           = new Label();
            lblPassword.Text      = "Password";
            lblPassword.ForeColor = Color.FromArgb(80, 80, 80);
            lblPassword.Font      = new Font("Segoe UI", 9F);
            lblPassword.Location  = new Point(40, 242);
            lblPassword.Size      = new Size(320, 20);

            // Password textbox  y=264  (242+20+2)
            txtPassword              = new TextBox();
            txtPassword.Font         = new Font("Segoe UI", 10F);
            txtPassword.BorderStyle  = BorderStyle.FixedSingle;
            txtPassword.PasswordChar = '●';
            txtPassword.Location     = new Point(40, 264);
            txtPassword.Size         = new Size(320, 28);
            txtPassword.Text         = "admin123";
            txtPassword.KeyDown     += txtPassword_KeyDown;

            // LOGIN button  y=314  (264+28+22)
            btnLogin                           = new Button();
            btnLogin.Text                      = "LOGIN";
            btnLogin.BackColor                 = Color.FromArgb(15, 76, 129);
            btnLogin.ForeColor                 = Color.White;
            btnLogin.FlatStyle                 = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Font                      = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.Location                  = new Point(40, 314);
            btnLogin.Size                      = new Size(148, 40);
            btnLogin.Cursor                    = Cursors.Hand;
            btnLogin.Click                    += btnLogin_Click;

            // EXIT button  y=314  (same row, x=212)
            btnExit                               = new Button();
            btnExit.Text                          = "EXIT";
            btnExit.BackColor                     = Color.White;
            btnExit.ForeColor                     = Color.FromArgb(100, 100, 100);
            btnExit.FlatStyle                     = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize     = 1;
            btnExit.FlatAppearance.BorderColor    = Color.FromArgb(200, 200, 200);
            btnExit.Font                          = new Font("Segoe UI", 10F);
            btnExit.Location                      = new Point(212, 314);
            btnExit.Size                          = new Size(148, 40);
            btnExit.Cursor                        = Cursors.Hand;
            btnExit.Click                        += btnExit_Click;

            // Footer
            lblFooter           = new Label();
            lblFooter.Text      = "© 2025 Grand Hotel Management System";
            lblFooter.ForeColor = Color.FromArgb(160, 160, 160);
            lblFooter.Font      = new Font("Segoe UI", 8F);
            lblFooter.TextAlign = ContentAlignment.MiddleCenter;
            lblFooter.Dock      = DockStyle.Bottom;
            lblFooter.Height    = 30;

            // ── FORM ────────────────────────────────────────────────────────
            AcceptButton    = btnLogin;
            BackColor       = Color.White;
            ClientSize      = new Size(400, 390);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox     = false;
            MinimizeBox     = false;
            Name            = "LoginForm";
            StartPosition   = FormStartPosition.CenterScreen;
            Text            = "Grand Hotel — Login";
            FormClosing    += LoginForm_FormClosing;

            // All controls directly on form — no inner panel
            Controls.Add(pnlTop);
            Controls.Add(lblSignIn);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Controls.Add(btnExit);
            Controls.Add(lblFooter);

            ResumeLayout(false);
        }
    }
}
