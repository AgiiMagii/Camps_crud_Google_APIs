using Camps.Interfaces;
using Camps.Lib;
using Camps.Services;
using Camps.Views;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Camps.Forms
{
    public partial class ContractsControl : UserControl, INavigate
    {
        private readonly List<GridAction> gridActions = new List<GridAction>();
        private readonly XmlOperation xmlOperation = new XmlOperation();
        private readonly Helper helper = new Helper();
        private readonly Factory factory = new Factory();
        private int totalContracts = 0;
        private readonly int pageSize = 10;
        private int currentPage = 1;
        public ContractsControl()
        {
            InitializeComponent();
        }

        public void Back()
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadData();
            }
        }

        public void Forward()
        {
            int totalPages = (int)Math.Ceiling((double)totalContracts / pageSize);

            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData();
            }
        }

        public void LoadData(long? campID = null)
        {
            gridActions.Clear();
            if (Session.CurrentUser?.roleID != 2)
            {
                gridActions.Add(new GridAction { Name = "Delete", Text = "Delete" });
            }

            gridActions.Add(new GridAction { Name = "Xml", Text = "Xml" });

            if (campID.HasValue)
            {
                List<ContractsView> campContracts = factory.GetContractByCampID(campID.Value);
                helper.ReloadGrid2(GvContracts, campContracts, gridActions);
            }
            else
            {
                totalContracts = factory.GetTotalContractCount();
                helper.ReloadGrid2(GvContracts, factory.GetTContracts(pageSize, currentPage), gridActions);
            }
        }

        private void GvContracts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == GvContracts.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                int contractId = Convert.ToInt32(GvContracts.Rows[e.RowIndex].Cells["contractID"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this contract?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (Session.CurrentUser?.roleID == 2)
                    {
                        MessageBox.Show("You do not have permission to delete this contract.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    factory.DeleteContract(contractId);
                    LoadData();
                    MessageBox.Show("Contract deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (e.ColumnIndex == GvContracts.Columns["Xml"].Index && e.RowIndex >= 0)
            {
                ContractsView contract = (ContractsView)GvContracts.Rows[e.RowIndex].DataBoundItem;
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
                    Title = "Save Contract as XML",
                    FileName = $"Contract_{contract.contractID}.xml"

                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    xmlOperation.PrepareXml(contract, filePath);
                    MessageBox.Show($"Contract saved as XML at: {filePath}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
