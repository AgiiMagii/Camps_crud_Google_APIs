using Camps.Lib;
using Camps.Services;
using Services.Camps;
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
    public partial class ChangePassword : Form
    {
        Security security = new Security();
        Validation validation = new Validation();
        public ChangePassword()
        {
            InitializeComponent();
            this.ShowIcon = false;
        }

        private void BtnSavePass_Click(object sender, EventArgs e)
        {
            string newPassword = TxtNewPassword.Text;
            string confirmPassword = TxtConfirmNew.Text;

            List<string> errors = new List<string>();
            if (!validation.IsPasswordValid(newPassword, confirmPassword))
                errors.Add("New password must be at least 8 characters long and contain a mix of letters and numbers.");

            try
            {
                string hashedPassword = Password.HashPassword(newPassword);
                bool success = security.ChangePassword(Session.CurrentUser.Username, hashedPassword);

                MessageBox.Show(
                    success ? "Password changed successfully." : "Failed to change password. Please try again.",
                    success ? "Success" : "Error",
                    MessageBoxButtons.OK,
                    success ? MessageBoxIcon.Information : MessageBoxIcon.Error
                );

                if (success)
                    Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
