using DVLBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL.UserControlls
{
    public partial class ucDriverLicenseInfo : UserControl
    {
        public bool FoundLicense = false;
        public clsInfoDriverLicense driverLicense = new clsInfoDriverLicense();

        public ucDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public void PrintDriverLicenseInfo(int ApplicationID)
        {
            driverLicense = clsInfoDriverLicense.GetDriverLicenseInfoByApplicationID(ApplicationID);

            if (driverLicense != null)
            {
                lbClass.Text = driverLicense.ClassName;
                lbName.Text = driverLicense.Name;
                lbLicenseID.Text = driverLicense.LicenseID.ToString();
                lbNationalNo.Text = driverLicense.NationalNo;

                if (driverLicense.Gendor)
                {
                    lbGendor.Text = "Female";
                }
                else
                {
                    lbGendor.Text = "Male";
                }

                lbIssueDate.Text = driverLicense.IssueDate.ToString("d");

                if (driverLicense.IssueReason == 1)
                {
                    lbIssueReason.Text = "First Time";
                }
                else if (driverLicense.IssueReason == 2)
                {
                    lbIssueReason.Text = "Renew";
                }
                else if (driverLicense.IssueReason == 3)
                {
                    lbIssueReason.Text = "Rep For Lost";
                }
                else if (driverLicense.IssueReason == 4)
                {
                    lbIssueReason.Text = "Rep For damaged";
                }
                else if (driverLicense.IssueReason == 5)
                {
                    lbIssueReason.Text = "Release Detained";
                }
                else
                {
                    lbIssueReason.Text = "Unknown";
                }


                lbNotes.Text = driverLicense.Notes;

                if (driverLicense.IsActive)
                {
                    lbIsActive.Text = "Yes";
                }
                else
                {
                    lbIsActive.Text = "No";
                }

                lbDateOfBirth.Text = driverLicense.DateOfBirth.ToString("d");
                lbDriverID.Text = driverLicense.DriverID.ToString();
                lbExpirationDate.Text = driverLicense.ExpirationDate.ToString("d");

                if (clsDetainedLicense.IsDetainedOrNot(driverLicense.LicenseID))
                {
                    lbIsDetained.Text = "Yes";
                }
                else
                {
                    lbIsDetained.Text = "No";
                }


                if (driverLicense.ImagePath == "")
                {
                    if (driverLicense.Gendor)
                    {
                        pbImage.Image = Properties.Resources.Female_512;
                    }
                    else
                    {
                        pbImage.Image = Properties.Resources.Male_512;
                    }
                }
                FoundLicense = true;

            }
            else
            {
                FoundLicense = false;
            }

        }

    }
}
