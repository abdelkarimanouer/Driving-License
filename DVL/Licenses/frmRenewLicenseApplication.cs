using DVL.Global_Classes;
using DVL.User;
using DVLBusinessLayer;
using System;
using System.Windows.Forms;

namespace DVL.Licenses
{
    public partial class frmRenewLicenseApplication : Form
    {
        clsInfoDriverLicense driverLicense = new clsInfoDriverLicense();
        clsApplications application = new clsApplications();
        clsLicenses license = new clsLicenses();

        public frmRenewLicenseApplication()
        {
            InitializeComponent();
        }

        private void LoadDataForRenewItems()
        {
            if (!ucFilterAndFindDriverLicense1.FoundLicense)
            {
                MessageBox.Show("No license found. Please search for a valid license.");
                llbShowLicenseHistory.Enabled = false;
                llbShowLicenseInfo.Enabled = false;
                return;
            }

            llbShowLicenseHistory.Enabled = true;
            driverLicense = ucFilterAndFindDriverLicense1.driverLicense;

            lbOldLicenseID.Text = driverLicense.LicenseID.ToString();
            lbApplicationDate.Text = DateTime.Now.ToString("d");
            lbissueDate.Text = DateTime.Now.ToString("d");
            lbApplicationFees.Text = clsApplicationsTypes.GetApplicationFee(2).ToString();
            lbLicenseFees.Text = LicenseClasses.ApplicationFees(driverLicense.ClassName).ToString();

            if (LicenseClasses.GetLicenseClassID(driverLicense.ClassName) == 1 || LicenseClasses.GetLicenseClassID(driverLicense.ClassName) == 2)
            {
                lbExpirationDate.Text = DateTime.Now.AddYears(5).ToString("d");
            }
            else
            {
                lbExpirationDate.Text = DateTime.Now.AddYears(10).ToString("d");
            }

            lbCreatedBy.Text = clsUserLog.user.UserID.ToString();

            decimal Total = Convert.ToDecimal(lbApplicationFees.Text) + Convert.ToDecimal(lbLicenseFees.Text);
            lbTotalFees.Text = Total.ToString();


            if (driverLicense.IsActive)
            {
                MessageBox.Show("Selected License is not yet Expiared, it will expire on: " + driverLicense.ExpirationDate.ToString("d"));
                btnRenew.Enabled = false;
            }
            else
            {
                btnRenew.Enabled = true;
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

        private void UcFilterAndFindDriverLicense1_SearchCompleted(object sender, EventArgs e)
        {
            LoadDataForRenewItems();
        }

        private void frmRenewLicenseApplication_Load(object sender, EventArgs e)
        {
            ucFilterAndFindDriverLicense1.SearchCompleted += UcFilterAndFindDriverLicense1_SearchCompleted;
            ucFilterAndFindDriverLicense1.PerformSearch();


        }

        private void btnRenew_Click(object sender, EventArgs e)
        {

            application.PersonID = clsPeople.FindPeopleByNationalNo(driverLicense.NationalNo).ID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = 2;
            application.ApplicationStatus = 3;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = Convert.ToDecimal( lbTotalFees.Text );
            application.UserID = clsUserLog.user.UserID;

            if (application.Save())
            {
                license.ApplicationID = application.ApplicationID;
                license.DriverID = driverLicense.DriverID;
                license.LicenseClass = LicenseClasses.GetLicenseClassID(driverLicense.ClassName);
                license.IssueDate = DateTime.Now;

                if (LicenseClasses.GetLicenseClassID(driverLicense.ClassName) == 1 || LicenseClasses.GetLicenseClassID(driverLicense.ClassName) == 2)
                {
                    license.ExpirationDate = DateTime.Now.AddYears(5);
                }
                else
                {
                    license.ExpirationDate = DateTime.Now.AddYears(10);
                }

                license.Notes = txtNotes.Text;
                license.PaidFees = application.PaidFees;
                license.IsActive = true;
                license.IssueReason = 2;
                license.CreatedByUserID = clsUserLog.user.UserID;

                if (license.AddNewLicense() )
                {
                    clsLicenses.DisableLicense(driverLicense.LicenseID);
                    clsInternationalLicense.UpdateLocalLicenseID(driverLicense.LicenseID, license.LicenseID);
                    llbShowLicenseHistory.Enabled = true;
                    llbShowLicenseInfo.Enabled = true;

                    MessageBox.Show("Successfully");
                }
                else
                {
                    MessageBox.Show("Faild");
                    llbShowLicenseHistory.Enabled = false;
                    llbShowLicenseInfo.Enabled = false;
                }
            }
            else
            {
                llbShowLicenseHistory.Enabled = false;
                llbShowLicenseInfo.Enabled = false;
            }

            lbRLApplicationID.Text = application.ApplicationID.ToString();
            lbRLLicenseID.Text = license.LicenseID.ToString();
            
        }

        private void llbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory licenseHistory = new frmLicenseHistory(clsPeople.FindPeopleByNationalNo(driverLicense.NationalNo).ID);
            licenseHistory.ShowDialog();
        }

        private void llbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo licenseInfo = new frmLicenseInfo(application.ApplicationID);

            licenseInfo.ShowDialog();
        }
    }
}
