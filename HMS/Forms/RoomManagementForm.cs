using HMS.Database;
using HMS.Models;

namespace HMS.Forms
{//ROOM MANAGEMENT_ADD/DELETE/UPDATE OR DISPLAY ROOMS
    public partial class RoomManagementForm : Form
    {
        private readonly User _user;
        private readonly RoomRepository _repo = new();
        private Room? _selected;

        public RoomManagementForm(User user)
        {
            _user = user;
            InitializeComponent();
            LoadRooms();
        }
//LOAD ALL ROOMS FROM DATABASE
        private void LoadRooms()
        {
            try
            {
                var rooms = _repo.GetAll();
                dgvRooms.Rows.Clear();
                foreach (var r in rooms)
                    dgvRooms.Rows.Add(r.RoomId, r.RoomNumber, r.RoomType, r.Floor,
                        $"Rs. {r.PricePerNight:N0}", r.Capacity, r.Status, r.Description);
                lblCount.Text = $"Total Rooms: {rooms.Count}";
            }
            catch (Exception ex) { MessageBox.Show("Error loading rooms: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
//CLEAR FORM FIELDS_RETURN TO ADD MODE
        private void ClearForm()
        {
            txtRoomNumber.Clear(); cmbType.SelectedIndex = 0; nudFloor.Value = 1;
            nudPrice.Value = 3500; nudCapacity.Value = 2; cmbStatus.SelectedIndex = 0;
            txtDescription.Clear(); _selected = null; btnSave.Text = "Add Room";
        }
//FIELDS GET FILLED ON SELECTING ROOMS IN GRID
        private void dgvRooms_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRooms.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvRooms.CurrentRow.Cells[0].Value);
            _selected = _repo.GetById(id);
            if (_selected == null) return;
            txtRoomNumber.Text = _selected.RoomNumber;
            cmbType.SelectedItem = _selected.RoomType;
            nudFloor.Value = _selected.Floor;
            nudPrice.Value = _selected.PricePerNight;
            nudCapacity.Value = _selected.Capacity;
            cmbStatus.SelectedItem = _selected.Status;
            txtDescription.Text = _selected.Description ?? "";
            btnSave.Text = "Update Room";
        }
//SAVE ROOMS_IF NEW THEN ADD,IF SELECTED THEN UPDATE
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoomNumber.Text))
            { MessageBox.Show("Room number is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var r = new Room
            {
                RoomNumber = txtRoomNumber.Text.Trim(),
                RoomType = cmbType.SelectedItem?.ToString() ?? "Standard",
                Floor = (int)nudFloor.Value,
                PricePerNight = nudPrice.Value,
                Capacity = (int)nudCapacity.Value,
                Status = cmbStatus.SelectedItem?.ToString() ?? "Available",
                Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim()
            };

            bool ok;
            if (_selected == null)
            {
                ok = _repo.Add(r);
                if (ok) MessageBox.Show("Room added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                r.RoomId = _selected.RoomId;
                ok = _repo.Update(r);
                if (ok) MessageBox.Show("Room updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (!ok) MessageBox.Show("Operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ClearForm(); LoadRooms();
        }
        //DELEYE THE SELECTED ROOM
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selected == null) { MessageBox.Show("Select a room first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (MessageBox.Show($"Delete Room {_selected.RoomNumber}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_repo.Delete(_selected.RoomId))
                    MessageBox.Show("Room deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Cannot delete room with bookings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearForm(); LoadRooms();
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();
        private void btnRefresh_Click(object sender, EventArgs e) => LoadRooms();
        //BY TYPING IN SEARCH BOX REAL TIME FILTER OCCUR IN GRID
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string q = txtSearch.Text.ToLower();
            foreach (DataGridViewRow row in dgvRooms.Rows)
            {
                bool visible = row.Cells.Cast<DataGridViewCell>()
                    .Any(c => c.Value?.ToString()?.ToLower().Contains(q) == true);
                row.Visible = visible;
            }
        }
    }
}
