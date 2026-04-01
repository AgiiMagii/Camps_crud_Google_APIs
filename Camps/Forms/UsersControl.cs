using Camps.Interfaces;
using Camps.Lib;
using Camps.Services;
using Camps.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Camps.Forms
{
    public partial class UsersControl : UserControl, IAddable, IDeletable
    {
        Factory factory = new Factory();
        Helper helper = new Helper();

        public UsersControl()
        {
            InitializeComponent();
        }
        public bool CanAdd => true;
        public bool CanDelete => true;

        public void Add()
        {
            using (AddUser addForm = new AddUser())
            {
                addForm.ShowDialog();
                if (addForm.DialogResult == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        public void Delete()
        {
            if (gvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }
            UserView selectedUser = (UserView)gvUsers.SelectedRows[0].DataBoundItem;
            
            DialogResult result = MessageBox.Show($"Are you sure you want to delete user '{selectedUser.Username}'?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (selectedUser.Username == Session.CurrentUser.Username && Session.CurrentUser.roleID != 1)
                {
                    MessageBox.Show("You can not delete this account.");
                    return;
                }
                bool success = factory.DeleteUser(selectedUser.Username);
                if (success)
                {
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Failed to delete the user. Please try again.");
                }
            }

        }

        public void LoadData()
        {
            List<UserView> users = factory.MapToUserView();

            helper.ReloadGrid(gvUsers, users, false);

            int columnIndex = gvUsers.Columns["Role"].Index;
            gvUsers.Columns.Remove("Role");

            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn
            {
                Name = "Role",
                HeaderText = "Role",
                DataPropertyName = "Role", // sasaista ar UserView.Role (string)
                DisplayMember = "Description", // ko rāda Grid
                ValueMember = "Description",   // kas tiek sasaistīts ar DataPropertyName
                DataSource = factory.GetRoles(), // List<UserRoles>
                FlatStyle = FlatStyle.Flat
            };

            gvUsers.Columns.Insert(columnIndex, combo);

            gvUsers.Columns["Status"].ReadOnly = true;
            if (Session.CurrentUser.roleID != 1)
            {
                gvUsers.Columns["Role"].ReadOnly = true;
            }
        }

        private void gvUsers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.RowIndex >= gvUsers.Rows.Count - 1) return;

            UserView userView = (UserView)gvUsers.Rows[e.RowIndex].DataBoundItem;
            factory.UpdateUser(userView);
        }
    }
}