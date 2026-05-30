using HMS.Database;
using HMS.Models;

namespace HMS.Forms
{
    public partial class UserManagementForm : Form
    {
        private readonly User _currentUser;
        private readonly UserRepository _repo = new();
        private User? _selected;

        public UserManagementForm(User currentUser)
        {
            _currentUser = currentUser;
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                var users = _repo.GetAll();
                dgvUsers.Rows.Clear();
                foreach (var u in users)
                    dgvUsers.Rows.Add(u.UserId, u.Username, u.FullName, u.Role,
                        u.Email, u.IsActive ? "Active" : "Inactive",
                        u.CreatedDate.ToString("dd/MM/yyyy"),
                        u.LastLogin?.ToString("dd/MM/yyyy HH:mm") ?? "Never");
                lblCount.Text = $"Users: {users.Count}";
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ClearForm()
        {
            txtUsername.Clear(); txtFullName.Clear(); txtEmail.Clear();
            txtPassword.Clear(); txtConfirmPwd.Clear();
            cmbRole.SelectedIndex = 0; chkActive.Checked = true;
            _selected = null; btnSave.Text = "Add User";
            lblPwdNote.Text = "Enter password for new user";
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
            _selected = _repo.GetById(id);
            if (_selected == null) return;
            txtUsername.Text = _selected.Username;
            txtFullName.Text = _selected.FullName;
            txtEmail.Text = _selected.Email ?? "";
            cmbRole.SelectedItem = _selected.Role;
            chkActive.Checked = _selected.IsActive;
            txtPassword.Clear(); txtConfirmPwd.Clear();
            btnSave.Text = "Update User";
            lblPwdNote.Text = "Leave password blank to keep unchanged";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text)) { MessageBox.Show("Username required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrWhiteSpace(txtFullName.Text)) { MessageBox.Show("Full name required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (_selected == null && string.IsNullOrWhiteSpace(txtPassword.Text)) { MessageBox.Show("Password required for new user.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!string.IsNullOrWhiteSpace(txtPassword.Text) && txtPassword.Text != txtConfirmPwd.Text)
            { MessageBox.Show("Passwords do not match.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var u = new User
            {
                Username = txtUsername.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                Role = cmbRole.SelectedItem?.ToString() ?? "staff",
                IsActive = chkActive.Checked
            };

            bool ok;
            if (_selected == null)
                ok = _repo.Add(u, txtPassword.Text);
            else
            {
                u.UserId = _selected.UserId;
                ok = _repo.Update(u);
                if (ok && !string.IsNullOrWhiteSpace(txtPassword.Text))
                    _repo.ChangePassword(_selected.UserId, _selected.PasswordHash, txtPassword.Text);
            }

            MessageBox.Show(ok ? "User saved!" : "Operation failed (username may exist).",
                ok ? "Success" : "Error", MessageBoxButtons.OK, ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            ClearForm(); LoadUsers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selected == null) { MessageBox.Show("Select a user.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (_selected.UserId == _currentUser.UserId) { MessageBox.Show("Cannot delete your own account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (MessageBox.Show($"Delete user '{_selected.Username}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                bool ok = _repo.Delete(_selected.UserId);
                MessageBox.Show(ok ? "User deleted." : "Cannot delete this user.", ok ? "Success" : "Error", MessageBoxButtons.OK, ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                ClearForm(); LoadUsers();
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();
        private void btnRefresh_Click(object sender, EventArgs e) => LoadUsers();
    }
}
