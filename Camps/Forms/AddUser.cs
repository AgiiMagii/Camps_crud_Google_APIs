using Camps.Lib;
using Camps.Services;
using Camps.Views;
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
    public partial class AddUser : Form
    {
        
        Factory factory = new Factory();
        ErrorProvider errorProvider = new ErrorProvider();
        Validation validation = new Validation();
        public AddUser()
        {
            InitializeComponent();
            TxtName.TextChanged += TextBox_TextChanged;
            TxtSurname.TextChanged += TextBox_TextChanged;
            TxtUsername.TextChanged += TextBox_TextChanged;
            TxtPassword.TextChanged += TextBox_TextChanged;
            TxtConfirm.TextChanged += TextBox_TextChanged;
            this.AcceptButton = btnSubmit;
            this.ShowIcon = false;
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            if (Session.CurrentUser.roleID == 1)
            {
                cbRole.Enabled = true;
            }
        }

        private void LoadComboBox()
        {
            cbRole.DataSource = factory.GetRoles();
            cbRole.DisplayMember = "Description";
            cbRole.ValueMember = "roleID";
            cbRole.SelectedIndex = 1;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            List<string> errors = new List<string>();
            if (!validation.IsPasswordValid(TxtPassword.Text, TxtConfirm.Text))
            {
                errors.Add("Password must be 6-60 chars and match confirmation.");
            }
            if (validation.IsNameSurnameValid(TxtName.Text) == false)
            {
                errors.Add("Name must be 2-50 chars, no digits.");
            }
            if (validation.IsNameSurnameValid(TxtSurname.Text) == false)
            {
                errors.Add("Surname must be 2-50 chars, no digits.");
            }
            if (validation.IsUsernameValid(TxtUsername.Text) == false)
            {
                errors.Add("Username not valid.");
            }
            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors), "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CreateUser();
        }

        private void CreateUser()
        {
            Users usersuserData = new Users
            {
                Name = TxtName.Text,
                Surname = TxtSurname.Text,
                Username = TxtUsername.Text,
                passwordHash = Password.HashPassword(TxtPassword.Text),
                Enabled = true,
                IsAdmin = (cbRole.SelectedValue != null && (int)cbRole.SelectedValue == 1) ? true : false,
                roleID = (int)cbRole.SelectedValue
            };
            try
            {
                if (Session.CurrentUser.roleID != 1 && usersuserData.roleID == 1)
                
                {
                    MessageBox.Show("You cannot assign admin role.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                factory.AddUser(usersuserData);
                MessageBox.Show("User created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == TxtName)
            {
                UpdateError(tb, Validation.IsNameAllowedSoFar(tb.Text), "Name must be 2-50 chars, letters only.");
            }
            else if (tb == TxtSurname)
            {
                UpdateError(tb, Validation.IsSurnameAllowedSoFar(tb.Text), "Surname must be 2-50 chars, letters only.");
            }
            else if (tb == TxtUsername)
            {
                UpdateError(tb, Validation.IsUsernameAllowedSoFar(tb.Text), "Incorrect username.");
            }
        }

        private void UpdateError(Control control, bool isValid, string errorMessage)
        {
            if (!isValid)
            {
                control.BackColor = Color.MistyRose;
                errorProvider.SetError(control, errorMessage);
            }
            else
            {
                control.BackColor = Color.White;
                errorProvider.SetError(control, "");
            }
        }
    }
}
