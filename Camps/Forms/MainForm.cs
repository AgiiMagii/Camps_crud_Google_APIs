using Camps.Forms;
using Camps.Interfaces;
using Camps.Lib;
using Camps.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Camps
{
    public partial class MainForm : Form
    {
        private readonly TabControl tabMain;

        public MainForm()
        {
            InitializeComponent();
            tabMain = new TabControl
            {
                Dock = DockStyle.Fill,
                Multiline = true

            };
            panelMain.Controls.Add(tabMain);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Welcome, {Session.CurrentUser?.Name}!";
            ApplyRolePermissions();

        }

        private void ApplyRolePermissions()
        {
            Users user = Session.CurrentUser;
            if (user == null) return;

            switch (user.roleID)
            {
                case 1: // Admin
                    BtnUsers.Visible = true;
                    BtnCustomer.Visible = true;
                    BtnCamp.Visible = true;
                    break;

                case 3: // Manager
                    BtnUsers.Visible = true;
                    BtnCustomer.Visible = true;
                    BtnCamp.Visible = true;
                    break;

                default: // User
                    BtnUsers.Visible = false;
                    BtnCustomer.Visible = true;
                    BtnCamp.Visible = false;
                    break;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Session.CurrentUser != null)
            {
                Application.Exit();
            }
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            UsersControl usersControl = new UsersControl();
            OpenTab("Users", usersControl);
            ShowLabelCloseTab();
            usersControl.LoadData();
        }

        private void BtnCustomer_Click(object sender, EventArgs e)
        {
            CustomersControl customersControl = new CustomersControl();
            OpenTab("Customers", customersControl);
            ShowLabelCloseTab();
            customersControl.LoadData();
            _ = customersControl.LoadDataAsync();
        }

        private void BtnCamp_Click(object sender, EventArgs e)
        {
            CampsControl campsControl = new CampsControl();
            OpenTab("Camps", campsControl);
            ShowLabelCloseTab();
            campsControl.LoadData();
        }

        private void OpenTab(string title, UserControl control)
        {
            // Check if the tab already exists
            foreach (TabPage page in tabMain.TabPages)
            {
                if (page.Text == title)
                {
                    tabMain.SelectedTab = page;
                    return;
                }
            }
            // Create a new tab
            TabPage newPage = new TabPage(title);
            control.Dock = DockStyle.Fill;
            newPage.Controls.Add(control);
            tabMain.TabPages.Add(newPage);
            tabMain.SelectedTab = newPage;
            ActivateActionButtons();
        }

        private void ShowLabelCloseTab()
        {
            if (tabMain.TabPages.Count > 0)
            {
                LblCloseTab.Visible = true;
            }
            else
            {
                LblCloseTab.Visible = false;
            }
        }

        private void LblCloseTab_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab != null)
            {
                tabMain.TabPages.Remove(tabMain.SelectedTab);
                ShowLabelCloseTab();
            }
            if (tabMain.TabPages.Count == 0)
            {
                LblCloseTab.Visible = false;
                ActivateActionButtons();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab != null)
            {
                UserControl control = tabMain.SelectedTab.Controls.OfType<UserControl>().FirstOrDefault();
                if (control is IAddable addable)
                {
                    addable.Add();
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab != null)
            {
                UserControl control = tabMain.SelectedTab.Controls.OfType<UserControl>().FirstOrDefault();
                if (control is IDeletable deletable)
                {
                    deletable.Delete();
                }
            }
        }

        private void ActivateActionButtons()
        {
            if (tabMain.SelectedTab != null)
            {
                UserControl control = tabMain.SelectedTab.Controls.OfType<UserControl>().FirstOrDefault();
                BtnAdd.Enabled = control is IAddable;
                BtnDelete.Enabled = control is IDeletable;
            }
            else
            {
                BtnAdd.Enabled = false;
                BtnDelete.Enabled = false;
            }
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            Session.CurrentUser = null;
            tabMain.TabPages.Clear();
            Login loginForm = Application.OpenForms.OfType<Login>().FirstOrDefault();
            loginForm?.Show();
            this.Close();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            if (!CmSettings.Visible)
            {
                CmSettings.Show(BtnSettings, 0, BtnSettings.Height);
            }
            else
            {
                CmSettings.Hide();

            }
        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword changePasswordForm = new ChangePassword();
            changePasswordForm.ShowDialog();
        }

        private void BtnContracts_Click(object sender, EventArgs e)
        {
            ContractsControl contractsControl = new ContractsControl();
            OpenTab("Contracts", contractsControl);
            ShowLabelCloseTab();
            contractsControl.LoadData();
        }
    }
}
