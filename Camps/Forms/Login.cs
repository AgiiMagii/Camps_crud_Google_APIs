using Camps.Lib;
using Camps.Services;
using System;
using System.Windows.Forms;

namespace Camps.Forms
{
    public partial class Login : Form
    {
        Helper helper = new Helper();
        public Login()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Security security = new Security();
                Result<Users> result = security.AuthenticateUser(txtUsername.Text, txtPassword.Text);
                if (result.Data != null)
                {
                    Session.CurrentUser = result.Data;
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    MessageBox.Show("Login successful!");
                    helper.ClearForm(Controls);
                }
                else
                {
                    MessageBox.Show($"Login failed: {result.Error}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during login: {ex.Message}");
            }

        }
    }
}
