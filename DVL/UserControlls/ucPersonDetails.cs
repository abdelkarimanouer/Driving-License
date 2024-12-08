using DVL.People;
using DVL.Properties;
using DVLBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVL.UserControlls
{
    public partial class ucPersonDetails : UserControl
    {
        clsPeople _Person;
        public int PersonID = 0;
        public string NationalNo = string.Empty;
        public bool CheckifPersonIsUser = false;

        public ucPersonDetails()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {
            if (_Person.Gendor == "Male")
                pbImage.Image = Resources.Male_512;
            else
                pbImage.Image = Resources.Female_512;

            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void PersonDetailsByPersonID(int personid)
        {
            _Person = clsPeople.FindPeopleByPersonID(personid);

            if ( _Person != null )
            {
                this.PersonID = _Person.ID;
                this.NationalNo = _Person.NationalNo.ToUpper();

                lbPersonID.Text = personid.ToString();
                lbName.Text = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;
                lbNationalNo.Text = _Person.NationalNo;
                lbGendor.Text = _Person.Gendor.ToString();
                lbEmail.Text = _Person.Email;
                lbPhone.Text = _Person.Phone;
                lbAddress.Text = _Person.Address;
                lbDateOfBirth.Text = _Person.DateOfBirth.ToString();
                _LoadPersonImage();

                clsCountries country = clsCountries.FindCountry( _Person.NationalityID);

                if (country != null)
                {
                    lbCountry.Text = country.CountryName;
                }

                if (clsUser.CheckPersonIsUser(_Person.ID))
                {
                    CheckifPersonIsUser = true;
                }
                else
                {
                    CheckifPersonIsUser = false;
                }
            }
            
            else
            {
                MessageBox.Show("Person Not Found, Try Again!");
            }
        }

        public void PersonDetailsByNationalNo(string nationalno)
        {
            _Person = clsPeople.FindPeopleByNationalNo(nationalno);

            if (_Person != null)
            {
                this.PersonID = _Person.ID;
                this.NationalNo = _Person.NationalNo.ToUpper();

                lbNationalNo.Text = nationalno;
                lbPersonID.Text = _Person.ID.ToString() ;
                lbName.Text = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;
                lbGendor.Text = _Person.Gendor.ToString();
                lbEmail.Text = _Person.Email;
                lbPhone.Text = _Person.Phone;
                lbAddress.Text = _Person.Address;
                lbDateOfBirth.Text = _Person.DateOfBirth.ToString();

                _LoadPersonImage();

                clsCountries country = clsCountries.FindCountry(_Person.NationalityID);

                if (country != null)
                {
                    lbCountry.Text = country.CountryName;
                }

                if (clsUser.CheckPersonIsUser(_Person.ID))
                {
                    CheckifPersonIsUser = true;
                }
                else
                {
                    CheckifPersonIsUser = false;
                    
                }

            }

            else
            {
                MessageBox.Show("Person Not Found, Try Again!");
            }

        }

        private void llbEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPeople Edit = new frmAddEditPeople(_Person.ID);
            Edit.ShowDialog();

            PersonDetailsByPersonID(_Person.ID);
        }

    }
}
