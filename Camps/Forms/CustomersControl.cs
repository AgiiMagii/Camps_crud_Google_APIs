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
    public partial class CustomersControl : UserControl, IAddable
    {
        private readonly Factory factory = new Factory();
        private readonly Helper helper = new Helper();
        private List<SheetDataView> sheetData;
        public CustomersControl()
        {
            InitializeComponent();
            
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.FixedPanel = FixedPanel.Panel2;
            splitContainer2.Panel2MinSize = 300;
            splitContainer2.Panel1.AutoScroll = true;
            splitContainer2.Panel2.AutoScroll = true;
            splitContainer2.Panel2Collapsed = true;
        }

        public void Add()
        {
            splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
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
        }
        public void LoadData()
        {
            LoadComboBoxes();
        }
        public async Task LoadDataAsync()
        {
            try
            {
                sheetData = await factory.GetSheetDataAsync(
                    "1ySwP3-xn8RUxH7NenO-gZ-q_FhhZZ1_h9l3e9hRKfzg",
                    "'Form Responses 1'!A1:T"
                );

                helper.ReloadGrid(GvSheetData, sheetData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load data: {ex.Message}");
            }
        }
        private void MapSheetToClasses()
        {
            
        }
        private void GvSheetData_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int sheetDataId = Convert.ToInt32(GvSheetData.Rows[e.RowIndex].Cells["RowIndex"].Value);
                SheetDataView selectedData = sheetData.FirstOrDefault(s => s.RowIndex == sheetDataId);
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
                }
            }
        }
    }
}
