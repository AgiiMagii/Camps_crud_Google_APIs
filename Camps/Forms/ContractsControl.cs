using Camps.Lib;
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
    public partial class ContractsControl : UserControl
    {
        private readonly Helper helper = new Helper();
        private readonly Factory factory = new Factory();
        public ContractsControl()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            helper.ReloadGrid(GvContracts, factory.MapToContractsView(), true);
        }

        private void GvContracts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == GvContracts.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                int contractId = Convert.ToInt32(GvContracts.Rows[e.RowIndex].Cells["contractID"].Value);
                var result = MessageBox.Show("Are you sure you want to delete this contract?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
