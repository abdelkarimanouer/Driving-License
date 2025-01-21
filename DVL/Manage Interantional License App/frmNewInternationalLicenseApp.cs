using DVL.Global_Classes;
using DVL.Licenses;
using DVL.User;
using DVLBusinessLayer;
using System;
using System.Windows.Forms;

namespace DVL.Manage_Interantional_License_App
{
    public partial class frmNewInternationalLicenseApp : Form
    {
        clsInfoDriverLicense driverLicense = new clsInfoDriverLicense();
        clsApplications application = new clsApplications();
        clsInternationalLicense internationalLicense = new clsInternationalLicense();

        public frmNewInternationalLicenseApp()
        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData()
        {
            if (!ucFilterAndFindDriverLicense1.FoundLicense)
            {
                MessageBox.Show("No license found.");
                return;
            }

            driverLicense = ucFilterAndFindDriverLicense1.driverLicense;

            lbApplicationDate.Text = DateTime.Now.ToString("d");
            lbissueDate.Text = DateTime.Now.ToString("d");
            lbFees.Text = clsApplicationsTypes.GetApplicationFee(6).ToString();
            lbLocalLicenseID.Text = driverLicense.LicenseID.ToString();
            lbExpirationDate.Text = driverLicense.ExpirationDate.ToString("d");
            lbCreatedBy.Text = clsUser.GetUserNameOfCurrentUser(clsUserLog.user.UserID);
        }

        private void frmNewInternationalLicenseApp_Load(object sender, EventArgs e)
        {
            ucFilterAndFindDriverLicense1.SearchCompleted += UcFilterAndFindDriverLicense1_SearchCompleted;

            ucFilterAndFindDriverLicense1.PerformSearch();
        }

        private void UcFilterAndFindDriverLicense1_SearchCompleted(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (clsLicenseClasses.GetLicenseClassID(driverLicense.ClassName) != 3)
            {
                MessageBox.Show("Class Name of this card does not meet the conditions ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            if (clsInternationalLicense.CheckifInternationalLicenseAlreadyExistByLicenseID(driverLicense.LicenseID))
            {
                MessageBox.Show("This Card Already issue To Internationl ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                llbShowLicenseInfo.Enabled = true;
                llbShowLicenseHistory.Enabled = true;
                return;
            }
            else
            {
                llbShowLicenseInfo.Enabled = false;
                llbShowLicenseHistory.Enabled = false;
            }

            if (!driverLicense.IsActive)
            {
                MessageBox.Show("You Can not Issue You Driving License To Internationl. Because Your Driving License Not Active.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            if (driverLicense.IssueDate > driverLicense.ExpirationDate)
            {
                MessageBox.Show("This card has expired", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            application.PersonID =  clsPeople.FindPeopleByNationalNo(driverLicense.NationalNo).ID  ;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = 6;
            application.ApplicationStatus = 3;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = Convert.ToDecimal(lbFees.Text);
            application.UserID = clsUserLog.user.UserID;

            if (application.Save())
            {
                internationalLicense.ApplicationID = application.ApplicationID;
                internationalLicense.DriverID = driverLicense.DriverID;
                internationalLicense.IssuedUsingLocalLicenseID = driverLicense.LicenseID;
                internationalLicense.IssueDate = DateTime.Now;
                internationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
                internationalLicense.IsActive = driverLicense.IsActive;
                internationalLicense.CreatedByUserID = application.UserID;

                if (internationalLicense.Save())
                {
                    MessageBox.Show("International License Issued Successfully With ID = " + internationalLicense.ILicenseID , "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    llbShowLicenseInfo.Enabled = true;
                    llbShowLicenseHistory.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Faild");
                    llbShowLicenseInfo.Enabled = false;
                    llbShowLicenseHistory.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Faild");
                llbShowLicenseInfo.Enabled = false;
                llbShowLicenseHistory.Enabled = false;
            }


            lbILApplicationID.Text = application.ApplicationID.ToString();
            lbILLicenseID.Text = internationalLicense.ILicenseID.ToString();

        }

        private void llbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalDriverInfo intlicense = new frmInternationalDriverInfo(internationalLicense.ILicenseID);
            intlicense.ShowDialog();
        }

        private void llbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmLicenseHistory licensehistoy = new frmLicenseHistory(clsPeople.FindPeopleByNationalNo(driverLicense.NationalNo).ID);
            licensehistoy.ShowDialog();
        }
    }
}
