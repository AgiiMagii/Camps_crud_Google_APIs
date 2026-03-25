using Camps.Interfaces;
using Camps.Lib;
using Camps.Views;
using Google.Apis.Sheets.v4.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Camps.Forms
{
    public partial class CustomersControl : UserControl, IAddable, IRefreshable
    {
        private readonly Factory factory = new Factory();
        private readonly Helper helper = new Helper();
        private List<SheetDataView> sheetData;
        private SheetDataView selectedSheetRow = null;
        public CustomersControl()
        {
            InitializeComponent();

            SuspendLayout();

            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.FixedPanel = FixedPanel.Panel2;
            splitContainer2.Panel2MinSize = 200;
            splitContainer2.IsSplitterFixed = false;
            splitContainer2.Panel1.AutoScroll = true;
            splitContainer2.Panel2.AutoScroll = true;
            splitContainer2.Panel2Collapsed = true;
            splitContainer2.ResumeLayout(false);

            ResumeLayout(true);
        }
        public void Add()
        {
            if (tabControl.SelectedTab == tabPage1)
            {

            } 
            else if (tabControl.SelectedTab == tabPage2)
            {
                splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
            }
        }
        private void LoadComboBoxes()
        {
            List<Camps> camps = factory.GetCamps();
            CbCamp.DataSource = camps;
            CbCamp.DisplayMember = "Name";
            CbCamp.ValueMember = "campID";
            CbCamp.SelectedIndex = -1;

            int currentYear = DateTime.Now.Year;

            List<int> years = Enumerable
                .Range(currentYear - 18, 12)
                .Reverse()
                .ToList();

            CbBirthYear.DataSource = years;
            CbBirthYear.SelectedIndex = -1;

            CbParent.DataSource = Enum.GetValues(typeof(Enums.Parents));
            CbParent.SelectedIndex = -1;

            CbGender.DataSource = Enum.GetValues(typeof(Enums.Gender));
            CbGender.SelectedIndex = -1;

            CbParent2.DataSource = Enum.GetValues(typeof(Enums.Parents));
            CbParent2.SelectedIndex = -1;
        }
        public void LoadData()
        {
            helper.ReloadGrid(GvParticipiants, factory.MapToParticipiantView());
            LoadComboBoxes();
        }
        public async Task LoadDataAsync()
        {
            try
            {
                sheetData = await factory.GetSheetDataAsync(
                    "1ySwP3-xn8RUxH7NenO-gZ-q_FhhZZ1_h9l3e9hRKfzg",
                    "'Form Responses 1'!A1:U"
                );

                helper.ReloadGrid(GvSheetData, sheetData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load data: {ex.Message}");
            }
        }
        private void GvSheetData_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            helper.ClearForm(splitContainer2.Panel2.Controls);
            if (e.RowIndex >= 0)
            {
                int sheetDataId = Convert.ToInt32(GvSheetData.Rows[e.RowIndex].Cells["RowIndex"].Value);
                SheetDataView selectedData = sheetData.FirstOrDefault(s => s.RowIndex == sheetDataId);
                selectedSheetRow = selectedData;
                if (!splitContainer2.Panel2Collapsed)
                {
                    Enums.Gender gender;

                    switch (selectedData.Gender)
                    {
                        case "Vīrietis":
                            gender = Enums.Gender.Male;
                            break;

                        case "Sieviete":
                            gender = Enums.Gender.Female;
                            break;

                        default:
                            throw new Exception("Unknown gender value");
                    }

                    Enums.Parents parents;

                    switch (selectedData.ParentType)
                    {
                        case "Māte":
                            parents = Enums.Parents.Mother;
                            break;

                        case "Tēvs":
                            parents = Enums.Parents.Father;
                            break;

                        case "Aizbildnis":
                            parents = Enums.Parents.Guardian;
                            break;

                        default:
                            throw new Exception("Unknown parent type");
                    }

                    Enums.Parents parents2;

                    switch (selectedData.ParentType1)
                    {
                        case "Māte":
                            parents2 = Enums.Parents.Mother;
                            break;
                        case "Tēvs":
                            parents2 = Enums.Parents.Father;
                            break;
                        case "Aizbildnis":
                            parents2 = Enums.Parents.Guardian;
                            break;
                        default : 
                            parents2 = (Enums.Parents)(-1); // Default value, can be adjusted as needed
                            break;

                    }

                    CbCamp.SelectedItem = CbCamp.Items.Cast<Camps>().FirstOrDefault(c => c.Name == selectedData.Camp);

                    TxtChildName.Text = selectedData.ChildName.ToString();
                    TxtChildSurname.Text = selectedData.ChildSurname.ToString();
                    CbGender.SelectedItem = gender;
                    CbBirthYear.SelectedItem = CbCamp.Items.Cast<Camps>().FirstOrDefault(c => c.Name == selectedData.Camp) != null
                        ? (int?)Convert.ToInt32(selectedData.BirthYear)
                        : null;

                    CbParent.SelectedItem = parents;
                    TxtParentName.Text = selectedData.ParentName.ToString();
                    TxtParentSurname.Text = selectedData.ParentSurname.ToString();
                    TxtPhone.Text = selectedData.ParentPhone.ToString();
                    TxtEmail.Text = selectedData.ParentEmail.ToString();
                    TxtAddress.Text = selectedData.ParentAddress.ToString();

                    CbParent2.SelectedItem = parents2;
                    TxtParentName2.Text = selectedData.ParentName1 ?? string.Empty;
                    TxtParentSur2.Text = selectedData.ParentSurname1 ?? string.Empty;
                    TxtPhone2.Text = selectedData.ParentPhone1 ?? string.Empty;
                }
            }
        }
        private string ConvertGenderForDb(string gender)
        {
            switch (gender)
            {
                case "Male":
                    return "M";
                case "Female":
                    return "F";
                default:
                    return null;
            }
        }
        private Children CreateChild()
        {
            return new Children
            {
                Name = TxtChildName.Text,
                Surname = TxtChildSurname.Text,
                Gender = ConvertGenderForDb(CbGender.SelectedItem?.ToString()),
                BirthYear = CbBirthYear.SelectedItem != null ? (short?)Convert.ToInt16(CbBirthYear.SelectedItem) : null
            };
        }
        private List<Parents> CreateParents()
        {
            List<Parents> parentsList = new List<Parents>();
            if (CbParent.SelectedItem != null)
            {
                parentsList.Add(new Parents
                {
                    Name = TxtParentName.Text,
                    Surname = TxtParentSurname.Text,
                    Phone = TxtPhone.Text,
                    Email = TxtEmail.Text,
                    Address = TxtAddress.Text,
                    Parent = CbParent.SelectedItem.ToString()
                });
            }
            if (!string.IsNullOrWhiteSpace(TxtPhone2.Text))
            {
                parentsList.Add(new Parents
                {
                    Name = TxtParentName2.Text,
                    Surname = TxtParentSur2.Text,
                    Phone = TxtPhone2.Text,
                    Parent = CbParent2.SelectedItem.ToString()
                });
            }
            return parentsList;
        }
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            Children child = CreateChild();
            List<Parents> parents = CreateParents();
            Camps selectedCamp = CbCamp.SelectedItem as Camps;
            if (selectedCamp != null)
            {
                factory.GetCampByName(selectedCamp.Name);
            }
            if (child != null && parents.Count > 0 && selectedCamp != null) 
            {
                factory.CreateContract(child, parents, selectedCamp);
                if (selectedSheetRow != null)
                {
                    await factory.MarkProcessedRows(selectedSheetRow.RowIndex);
                }
                selectedSheetRow = null;
                helper.ClearForm(splitContainer2.Panel2.Controls);
                splitContainer2.Panel2Collapsed = true;
                MessageBox.Show("Data saved successfully!");
            }
            else
            { 
                MessageBox.Show("Please fill in all required fields and select a camp.");
            }
        }
        private void GvParticipiants_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GvParentDetails.DataSource = null;
            if (e.RowIndex >= 0)
            {
                int childId = Convert.ToInt32(GvParticipiants.Rows[e.RowIndex].Cells["ChildID"].Value);
                helper.ReloadGrid(GvParentDetails, factory.MapToParentsView(childId));
            }
        }
        public void Refreshdata()
        {
            if (tabControl.SelectedTab == tabPage1)
            {
                LoadData();
            }
            else if (tabControl.SelectedTab == tabPage2)
            {
                _ = LoadDataAsync();
            }
        }
    }
}
