using Camps.Interfaces;
using Camps.Lib;
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
        private readonly Helper helper = new Helper();
        private readonly Factory factory = new Factory();
        private int totalContracts = 0;
        private int pageSize = 5;
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

        public void LoadData()
        {
            totalContracts = factory.GetTotalContractCount();
            helper.ReloadGrid(GvContracts, factory.GetTContracts(pageSize, currentPage), true);
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
        }
    }
}
