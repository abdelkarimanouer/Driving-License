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
    public partial class ucDriverInternationalLicenseInfo : UserControl
    {
        public ucDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public void GetDriverIntLicenseInfo(int InternationlLicenseID)
        {
            int ApplicationID = clsInternationalLicense.GetApplicationIDByInternationalLicenseID(InternationlLicenseID);

            clsInternationalLicense intlicense = clsInternationalLicense.FindInternationlLicense(InternationlLicenseID);

            if (intlicense != null) 
            {
                lbName.Text = clsPeople.FindPeopleByPersonID( clsApplications.GetApplicationInfo(ApplicationID).PersonID ).FullName() ;
                lbIntLicenseID.Text = InternationlLicenseID.ToString();
                lbLicenseID.Text = intlicense.IssuedUsingLocalLicenseID.ToString() ;
                lbNationalNo.Text = clsPeople.FindPeopleByPersonID(clsApplications.GetApplicationInfo(ApplicationID).PersonID).NationalNo;
                lbIssueDate.Text = intlicense.IssueDate.ToString("d");
                lbApplicationID.Text = ApplicationID.ToString();
                lbDriverID.Text = intlicense.DriverID.ToString();

                lbGendor.Text = clsPeople.FindPeopleByPersonID(clsApplications.GetApplicationInfo(ApplicationID).PersonID).Gendor;
 

                if (intlicense.IsActive)
                {
                    lbIsActive.Text = "Yes";
                }
                else
                {
                    lbIsActive.Text = "No";
                }

                lbDateOfBirth.Text = clsPeople.FindPeopleByPersonID(clsApplications.GetApplicationInfo(ApplicationID).PersonID).DateOfBirth.ToString("d");
                lbExpirationDate.Text = intlicense.ExpirationDate.ToString("d");
                
            }
        }

    }
}
