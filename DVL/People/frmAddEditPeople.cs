using DVL.Properties;
using DVLBusinessLayer;
using DVLD.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL.People
{
    public partial class frmAddEditPeople : Form
    {
        public static frmAddEditPeople InstanceAdd;

        public int _PersonID = 0;
        private string LocationImage = "";
        public enum enMode { AddNew = 0, Update = 1};
        enMode _Mode;

        clsPeople _Person;

        public frmAddEditPeople(int PersonID)
        {
            InitializeComponent();
            InstanceAdd = this;
            this._PersonID = PersonID;

            if (_PersonID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
            }


        }

        private void FillCbCountries()
        {
            DataTable dtCountries = clsCountries.GetALlCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountries.Items.Add(row["CountryName"] );
            }
        }

        private void _Load()
        {
            FillCbCountries();

            cbCountries.SelectedIndex = 118;

            if (_Mode == enMode.AddNew)
            {
                lbMode.Text = "Add New Person";
                this._Person = new clsPeople();
                return;
            }

            _Person = clsPeople.FindPeopleByPersonID(this._PersonID);

            if (_Person == null)
            {
                MessageBox.Show("This Window will be close!");
                this.Close();
            }

            lbMode.Text = "Update Person";
            lbPersonID.Text = _Person.ID.ToString();

            txtFirstName.Text = _Person.FirstName;
            txtLastName.Text = _Person.LastName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtNationalNo.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.Phone;
            txtAddress.Text = _Person.Address;

            cbCountries.SelectedIndex = _Person.NationalityID - 1 ;

            if (_Person.Gendor == "Male")
            {
                rbMale.Checked = true;
            }
            else if (_Person.Gendor == "Female")
            {
                rbFemale.Checked = true;
            }

            if (!string.IsNullOrEmpty(_Person.ImagePath) )
            {
                pbImage.Load(_Person.ImagePath);
                lblRemove.Visible = true;
            }

        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != pbImage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (pbImage.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }

        private void frmAddEditPeople_Load(object sender, EventArgs e)
        {
            _Load();
        }

        private void txtNationalNo_Leave(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                return;
            }

            if (clsPeople.CheckIfNationalNoisExist(txtNationalNo.Text))
            {
                errorProvider1.SetError(txtNationalNo, "National Number is used for another person!");
                txtNationalNo.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandlePersonImage())
                return;

            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.Email = txtEmail.Text;
            _Person.Phone = txtPhone.Text;
            _Person.NationalNo = txtNationalNo.Text.ToUpper();

            if (rbMale.Checked)
            {
                _Person.Gendor = "0";
            }
            if (rbFemale.Checked)
            {
                _Person.Gendor = "1";
            }

            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Address = txtAddress.Text;
            _Person.NationalityID = cbCountries.SelectedIndex + 1;

            if (pbImage.ImageLocation != null)
                _Person.ImagePath = pbImage.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
            {
                MessageBox.Show("Successfully");
                _PersonID = _Person.ID;
            }
            else
            {
                MessageBox.Show("Faild");
            }



            lbMode.Text = "Update Person";
            lbPersonID.Text = _Person.ID.ToString();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                pbImage.Image = Properties.Resources.Male_512;
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
            {
                pbImage.Image = Properties.Resources.Female_512;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if ( !string.IsNullOrEmpty(txtEmail.Text) )
            {
                if (!txtEmail.Text.EndsWith("@gmail.com"))
                {
                    errorProvider1.SetError(txtEmail, "Invalid Email");
                    txtEmail.Focus();
                }
            }

        }

        private void lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string selectedFilePath = openFileDialog.FileName;
                    pbImage.Load(selectedFilePath);
                    lblRemove.Visible = true;

                }
            }
        }

        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (pbImage.Image != null)
            {
                pbImage.Image.Dispose(); 
            }

            pbImage.ImageLocation = null;

            if (rbMale.Checked)
                pbImage.Image = Resources.Male_512;
            else
                pbImage.Image = Resources.Female_512;

            lblRemove.Visible = false;
        }

    }
}
