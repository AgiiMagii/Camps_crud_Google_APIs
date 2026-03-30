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
        List<GridAction> gridActions = new List<GridAction>
        { 
                new GridAction { Name = "Delete", Text = "Delete"},
                new GridAction { Name = "Xml", Text = "Xml"}
        };
        private readonly XmlOperation xmlOperation = new XmlOperation();
        private readonly Helper helper = new Helper();
        private readonly Factory factory = new Factory();
        private int totalContracts = 0;
        private int pageSize = 20;
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
            if (campID.HasValue)
            {
                // Filtrējam pēc camp
                List<ContractsView> campContracts = factory.GetContractByCampID(campID.Value);
                helper.ReloadGrid2(GvContracts, campContracts, gridActions);
            }
            else
            {
                // Visi kontrakti (paging)
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

        //private void BtnSaveToCSV_Click(object sender, EventArgs e)
        //{
        //    if (GvContracts.DataSource == null) return;

        //    using (SaveFileDialog sfd = new SaveFileDialog())
        //    {
        //        sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
        //        sfd.FileName = "Contracts.csv";

        //        if (sfd.ShowDialog() == DialogResult.OK)
        //        {
        //            string path = sfd.FileName;
        //            helper.GenerateCsv2(path, GvContracts.DataSource as IEnumerable<object>);
        //            MessageBox.Show($"File saved to {path}");
        //        }
        //    }
        //}

        private void BtnExecSql_Click(object sender, EventArgs e)
        {
            List<Contracts> contracts = factory.GetSqlResult<Contracts>(Rt_sql.Text).ToList();
            helper.ReloadGrid(GvContracts, contracts, true);
        }
    }
}
