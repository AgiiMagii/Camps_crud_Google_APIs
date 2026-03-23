using Camps.Interfaces;
using Camps.Lib;
using Camps.Services;
using Camps.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace Camps.Forms
{
    public partial class CampsControl : UserControl, IAddable, IDeletable
    {
        private readonly Factory factory = new Factory();
        private readonly Helper helper = new Helper();
        public CampsControl()
        {
            InitializeComponent();
        }

        public void Add()
        {
            using (AddCamp addForm = new AddCamp(null, null))
            {
                addForm.ShowDialog();
                if (addForm.DialogResult == DialogResult.OK)
                {
                    LoadData();
                    _ = Task.Run(async () =>
                    {
                        try
                        {
                            await SyncCampsToGForm();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Sync error: {ex.Message}");
                        }
                    });
                }
            }
        }

        public void Delete()
        {
            if (GvCamps.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to delete this camp'?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool success = factory.DeleteCamp((long)GvCamps.SelectedRows[0].Cells["campID"].Value);
                if (success)
                {
                    MessageBox.Show("Camp deleted successfully.");
                    LoadData();
                    _ = Task.Run(async () =>
                    {
                        try
                        {
                            await SyncCampsToGForm();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Sync error: {ex.Message}");
                        }
                    });
                }
                else
                {
                    MessageBox.Show("Failed to delete the user. Please try again.");
                }
            }
        }

        public void LoadData()
        {
            List<CampsView> camps = new Factory().MapToCampsView();
            helper.ReloadGrid(GvCamps, camps);
            GvCamps.Columns["campID"].Visible = false;
        }

        private async void GvCamps_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                long campID = (long)GvCamps.Rows[e.RowIndex].Cells["campID"].Value;
                if (campID == 0)
                {
                    MessageBox.Show("Invalid camp selected.");
                    return;
                }
                else
                {
                    Camps camp = factory.GetCampByID(campID);
                    Address address = factory.GetAddressByID(camp.addressID ?? 0);
                    if (camp == null)
                    {
                        MessageBox.Show("Camp not found.");
                        return;
                    }
                    using (AddCamp editForm = new AddCamp(camp, address))
                    {
                        editForm.ShowDialog();
                        if (editForm.DialogResult == DialogResult.OK)
                        {
                            LoadData();
                            await SyncCampsToGForm();
                        }
                    }
                }
            }
        }

        public async Task SyncCampsToGForm()
        {
            string formId = "1lUzhU0ZjLNwUYT-tuW9aNQkdR1219c16Q4JAetMx2EQ"; // Replace with your actual form ID
            string questionId = "607ad2ef"; // Replace with your actual question ID
            await factory.SyncCampsToGoogleFormsAsync(formId, questionId);
        }

        private void BtnRefresh_Click(object sender, System.EventArgs e)
        {
            _ = SyncCampsToGForm();
        }
    }
}
