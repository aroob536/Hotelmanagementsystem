using HMS.Database;
using HMS.Models;

namespace HMS.Forms
{//CUSTOMER DETAILS_ADD/DELETE/UPDATE CUSTOMERS
    public partial class CustomerForm : Form
    {
        private readonly User _user;
        private readonly CustomerRepository _repo = new();
        private Customer? _selected;

        public CustomerForm(User user)
        {
            _user = user;
            InitializeComponent();
            LoadCustomers();
        }
//LOAD CUSTOMERS_CAN ALSO FILTER FROM SEARCH PARAMETER
        private void LoadCustomers(string search = "")
        {
            try
            {
                var list = string.IsNullOrWhiteSpace(search)
                    ? _repo.GetAll()
                    : _repo.Search(search);

                dgvCustomers.Rows.Clear();
                foreach (var c in list)
                    dgvCustomers.Rows.Add(
                        c.CustomerId,
                        c.FullName,
                        c.Cnic ?? "",
                        c.Phone,
                        c.Nationality,
                        c.CreatedDate.ToString("dd/MM/yyyy"));

                lblCount.Text = $"Total Customers: {list.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
//CLEAR THE DETAILS IN FORM
        private void ClearForm()
        {
            txtName.Clear();
            txtCnic.Clear();
            txtPhone.Clear();
            cmbNationality.SelectedIndex = 0;
            _selected    = null;
            btnSave.Text = "Add Customer";
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null) return;
            var cell = dgvCustomers.CurrentRow.Cells["CId"].Value;
            if (cell == null) return;

            int id = Convert.ToInt32(cell);
            _selected = _repo.GetById(id);
            if (_selected == null) return;

            txtName.Text  = _selected.FullName;
            txtCnic.Text  = _selected.Cnic ?? "";
            txtPhone.Text = _selected.Phone;

            int idx = cmbNationality.Items.IndexOf(_selected.Nationality);
            cmbNationality.SelectedIndex = idx >= 0 ? idx : 0;

            btnSave.Text = "Update Customer";
        }
//SAVE THE RECORD_IF NEW THEN ADD,IF SELECTED THEN UPDATE
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Full name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Phone number is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus(); return;
            }

            var c = new Customer
            {
                FullName    = txtName.Text.Trim(),
                Cnic        = string.IsNullOrWhiteSpace(txtCnic.Text) ? null : txtCnic.Text.Trim(),
                Phone       = txtPhone.Text.Trim(),
                Nationality = cmbNationality.SelectedItem?.ToString() ?? "Pakistani"
            };

            bool ok;
            if (_selected == null)
                ok = _repo.Add(c);
            else
            {
                c.CustomerId = _selected.CustomerId;
                ok = _repo.Update(c);
            }

            MessageBox.Show(
                ok ? (_selected == null ? "Customer added successfully!" : "Customer updated successfully!")
                   : "Operation failed.",
                ok ? "Success" : "Error",
                MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            ClearForm();
            LoadCustomers();
        }
//DELETE THE SELECTED CUSTOMER
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Please select a customer first.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show($"Delete customer '{_selected.FullName}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                bool ok = _repo.Delete(_selected.CustomerId);
                MessageBox.Show(
                    ok ? "Customer deleted." : "Cannot delete — customer has bookings.",
                    ok ? "Success" : "Error",
                    MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                ClearForm();
                LoadCustomers();
            }
        }
//CLEAR THE RECORD OF SELECTED CUSTOMER
        private void btnClear_Click(object sender, EventArgs e) => ClearForm();
//SEARCH BUTTON_SEARCH CUSTOMER THROUGH ID,NAME AND CNIC
        private void btnSearch_Click(object sender, EventArgs e)
            => LoadCustomers(txtSearch.Text.Trim());

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadCustomers(txtSearch.Text.Trim());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadCustomers();
        }
    }
}
