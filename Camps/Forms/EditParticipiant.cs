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
    public partial class EditParticipiant : Form
    {

        public EditParticipiant()
        {
            InitializeComponent();
            this.ShowIcon = false;
        }
        private void LoadChildCombos()
        {
            int currentYear = DateTime.Now.Year;

            int minYear = currentYear - 17;
            int maxYear = currentYear - 7;

            List<int> years = Enumerable
                .Range(minYear, maxYear - minYear + 1)
                .Reverse()
                .ToList();

            CbBirthYear.DataSource = years;
            CbBirthYear.SelectedIndex = -1;

            CbGender.DataSource = Enum.GetValues(typeof(Enums.Gender));
            CbGender.SelectedIndex = -1;

        }
        private void LoadParentCombo()
        {
            CbParent.DataSource = Enum.GetValues(typeof(Enums.Parents));
            CbParent.SelectedIndex = -1;
        }
        public void LoadData(Children child = null, Parents parent = null)
        {
            if (child != null)
            {
                GbChild.Visible = true;
                LoadChildCombos();

                TxtChildName.Text = child.Name;
                TxtChildSurname.Text = child.Surname;
                if (child.Gender == "M")
                    CbGender.SelectedItem = Enums.Gender.Male;
                else if (child.Gender == "F")
                    CbGender.SelectedItem = Enums.Gender.Female;
                else
                    CbGender.SelectedItem = null;
                CbBirthYear.SelectedItem = child.BirthYear.HasValue
                    ? (int)child.BirthYear.Value
                    : (int?)null;

            }
            else if (parent != null)
            {
                GbParent.Visible = true;
                LoadParentCombo();

                if (Enum.TryParse<Enums.Parents>(parent.Parent, out var parentEnum))
                {
                    CbParent.SelectedItem = parentEnum;
                }
                else
                {
                    CbParent.SelectedIndex = -1;
                }
                TxtParentName.Text = parent.Name;
                TxtParentSurname.Text = parent.Surname;
                TxtPhone.Text = parent.Phone;

                if (parent.Email != null && parent.Address != null)
                {
                    PanelAdditional.Visible = true;
                    TxtEmail.Text = parent.Email;
                    TxtAddress.Text = parent.Address;
                }
            }
        }
    }
}
