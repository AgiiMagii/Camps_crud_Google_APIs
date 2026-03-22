using Camps.Lib;
using Camps.Views;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace Camps.Forms
{
    public partial class AddCamp : Form
    {
        Factory factory = new Factory();
        Camps _camps = null;
        Address _address = null;
        private bool _isLoading = false;
        private bool _isEditAddress = false;

        public AddCamp(Camps camp, Address address)
        {
            InitializeComponent();
            this.ShowIcon = false;
            _camps = camp;
            _address = address;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                long addressId = HandleAddress();

                if (addressId == -1)
                    return;

                if (_camps == null)
                    InsertCamp(addressId);
                else
                    UpdateCamp(addressId);

                MessageBox.Show("Success!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private long HandleAddress()
        {
            if (_isEditAddress && _address != null)
            {
                _address.Country = CbCountry.SelectedItem?.ToString();
                _address.City = CbCity.SelectedItem?.ToString();
                _address.Region = CbRegion.SelectedItem?.ToString();
                _address.Address1 = TxtAddress.Text.Trim();
                _address.ZipCode = TxtZipcode.Text.Trim();

                factory.UpdateAddress(_address);
                MessageBox.Show("Address updated successfully!");
                _isEditAddress = false;
                CbExisting.Enabled = true;
                GbAddress.Enabled = false;
                return -1;
            }

            long addressId = 0;
            if (CbExisting.SelectedIndex != -1)
            {
                Address selectedAddress = (Address)CbExisting.SelectedItem;
                addressId = selectedAddress.addressID;
            }
            else
            {
                Address newAddress = new Address
                {
                    Country = CbCountry.SelectedItem?.ToString(),
                    City = CbCity.SelectedItem?.ToString(),
                    Region = CbRegion.SelectedItem?.ToString(),
                    Address1 = TxtAddress.Text,
                    ZipCode = TxtZipcode.Text
                };
                factory.AddAddress(newAddress);
                addressId = factory.GetLastAddressID();
            }

            return addressId;
        }

        private void InsertCamp(long addressId)
        {
            Camps newCamp = new Camps
            {
                Name = Txtname.Text,
                Description = TxtDesc.Text,
                Capacity = (short)NumCapacity.Value,
                addressID = addressId
            };
            factory.AddCamp(newCamp);
        }

        private void UpdateCamp(long addressId)
        {
            _camps.Name = Txtname.Text;
            _camps.Description = TxtDesc.Text;
            _camps.Capacity = (short)NumCapacity.Value;
            _camps.addressID = addressId;
            factory.UpdateCamp(_camps);
        }

        private void LoadAddressCombos()
        {

            CbCountry.DataSource = Enum.GetValues(typeof(Enums.Country));
            CbCity.DataSource = Enum.GetValues(typeof(Enums.City));
            CbRegion.DataSource = Enum.GetValues(typeof(Enums.Region));

            List<Address> addresses = factory.GetAddresses();
            CbExisting.DataSource = addresses;
            CbExisting.DisplayMember = "Address1";
            CbExisting.ValueMember = "addressID";
            if (_address != null)
            {
                CbExisting.SelectedValue = _address.addressID;
            }
            else 
            { 
                CbExisting.SelectedIndex = -1;
            }
        }

        private void AddCamp_Load(object sender, EventArgs e)
        {
            _isLoading = true;
            LblEditAddress.AutoSize = true;
            LblEditAddress.Cursor = Cursors.Hand;

            TtEdit.ShowAlways = true;
            TtEdit.SetToolTip(LblEditAddress, "Edit address");
            LoadAddressCombos();

            if (_camps != null)
            {
                Txtname.Text = _camps.Name;
                TxtDesc.Text = _camps.Description;
                NumCapacity.Value = _camps.Capacity ?? 0;

                if (_address != null)
                {
                    CbExisting.SelectedValue = _address.addressID;
                    CbCountry.SelectedItem = Enum.Parse(typeof(Enums.Country), _address.Country);
                    CbCity.SelectedItem = Enum.Parse(typeof(Enums.City), _address.City);
                    CbRegion.SelectedItem = Enum.Parse(typeof(Enums.Region), _address.Region);
                    TxtAddress.Text = _address.Address1;
                    TxtZipcode.Text = _address.ZipCode;
                    GbAddress.Enabled = false;
                }
            }

            _isLoading = false;
        }

        private void CbExisting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;

            if (CbExisting.SelectedIndex != -1)
            {
                Address selectedAddress = (Address)CbExisting.SelectedItem;

                _address = selectedAddress;

                CbCountry.SelectedItem = Enum.Parse(typeof(Enums.Country), selectedAddress.Country);
                CbCity.SelectedItem = Enum.Parse(typeof(Enums.City), selectedAddress.City);
                CbRegion.SelectedItem = Enum.Parse(typeof(Enums.Region), selectedAddress.Region);
                TxtAddress.Text = selectedAddress.Address1;
                TxtZipcode.Text = selectedAddress.ZipCode;

                GbAddress.Enabled = false;
            }
            else
            {
                _address = null;

                GbAddress.Enabled = true;
                ClearAddressFields();
            }
        }

        private void CbExisting_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CbExisting.Text))
            {
                GbAddress.Enabled = true;
                ClearAddressFields();
            }
        }

        private void ClearAddressFields()
        {
            CbCountry.SelectedIndex = -1;
            CbCity.SelectedIndex = -1;
            CbRegion.SelectedIndex = -1;
            TxtAddress.Clear();
            TxtZipcode.Clear();
        }

        private void LblEditAddress_Click(object sender, EventArgs e)
        {
            if (_address == null)
            {
                MessageBox.Show("Please select an address to edit.");
                return;
            }
            _isEditAddress = true;
            GbAddress.Enabled = true;
            CbExisting.Enabled = false;

        }
    }
}
