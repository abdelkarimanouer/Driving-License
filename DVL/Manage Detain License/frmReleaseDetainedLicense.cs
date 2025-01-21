using DVL.Global_Classes;
using DVL.User;
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

namespace DVL.Manage_Detain_License
{
    public partial class frmReleaseDetainedLicense : Form
    {
        clsInfoDriverLicense driverLicense = new clsInfoDriverLicense();
        clsDetainedLicense DetainedLicense = new clsDetainedLicense();
        clsApplications application = new clsApplications();

        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        private void LoadDataForReleased()
        {
            lbApplicationID.Text = "?????";

            if (!ucFilterAndFindDriverLicense1.FoundLicense)
            {
                MessageBox.Show("No license found. Please search for a valid license.");
                llbShowLicenseHistory.Enabled = false;
                llbShowLicenseInfo.Enabled = false;
                btnRelease.Enabled = false;
                return;
            }

            driverLicense = ucFilterAndFindDriverLicense1.driverLicense;
            lbLicenseID.Text = driverLicense.LicenseID.ToString();

            if (!clsDetainedLicense.IsDetainedOrNot(driverLicense.LicenseID))
            {
                MessageBox.Show("Selected License is not detained, choose another one.");
                llbShowLicenseHistory.Enabled = false;
                llbShowLicenseInfo.Enabled = false;
                btnRelease.Enabled = false;
                return;
            }

            btnRelease.Enabled = true;
            llbShowLicenseHistory.Enabled = true;

            DetainedLicense = clsDetainedLicense.GetDetainedInfo(driverLicense.LicenseID);

            if (DetainedLicense != null)
            {
                lbDetainID.Text = DetainedLicense.DetainID.ToString();
                lbDetainDate.Text = DateTime.Now.ToString("d");
                lbApplicationFees.Text = clsApplicationsTypes.GetApplicationFee(5).ToString();
                lbFineFees.Text = DetainedLicense.FineFees.ToString();
                lbCreatedBy.Text = clsUser.GetUserNameOfCurrentUser(DetainedLicense.CreatedByUserID);
                lbtotalFees.Text = (Convert.ToDecimal(lbFineFees.Text) + Convert.ToDecimal(lbApplicationFees.Text)).ToString() ;

            }

        }

        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            ucFilterAndFindDriverLicense1.SearchCompleted += UcFilterAndFindDriverLicense1_SearchCompleted;
            ucFilterAndFindDriverLicense1.PerformSearch();
        }
        
        private void UcFilterAndFindDriverLicense1_SearchCompleted(object sender, EventArgs e)
        {
            LoadDataForReleased();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to release this detained license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            application.PersonID = clsPeople.FindPeopleByNationalNo(driverLicense.NationalNo).ID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = 2;
            application.ApplicationStatus = 3;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = Convert.ToDecimal(lbtotalFees.Text);
            application.UserID = clsUserLog.user.UserID;

            if (application.Save())
            {
                DetainedLicense.IsReleased = true;
                DetainedLicense.ReleaseDate = DateTime.Now;
                DetainedLicense.ReleasedByUserID = clsUserLog.user.UserID;
                DetainedLicense.ReleaseApplicationID = application.ApplicationID;

                if (DetainedLicense.Save())
                {
                    MessageBox.Show("Detained License Released Succussfully", "Done");
                    llbShowLicenseInfo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Faild");
                    llbShowLicenseInfo.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Faild");
                llbShowLicenseInfo.Enabled = false;
            }

            lbApplicationID.Text = application.ApplicationID.ToString();
        }
    }
}
