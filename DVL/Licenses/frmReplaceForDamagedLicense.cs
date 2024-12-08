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

namespace DVL.Licenses
{
    public partial class frmReplaceForDamagedLicense : Form
    {
        clsInfoDriverLicense driverLicense = new clsInfoDriverLicense();
        clsApplications application = new clsApplications();
        clsLicenses license = new clsLicenses();

        public frmReplaceForDamagedLicense()
        {
            InitializeComponent();
        }

        private void LoadDataForReplacement()
        {
            if (!ucFilterAndFindDriverLicense1.FoundLicense)
            {
                MessageBox.Show("No license found. Please search for a valid license.");
                llbShowLicenseHistory.Enabled = false;
                llbShowLicenseInfo.Enabled = false;
                return;
            }

            rbDamagedLicense.Checked = true;
            lbBigTitle.Text = "Replacement For Damaged License";
            lbSmallTitle.Text = "Replacement For Damaged License";


            llbShowLicenseHistory.Enabled = true;
            driverLicense = ucFilterAndFindDriverLicense1.driverLicense;

            lbApplicationDate.Text = DateTime.Now.ToString("d");
            lbFees.Text = clsApplicationsTypes.GetApplicationFee(4).ToString();
            lbOldLicenseID.Text = driverLicense.LicenseID.ToString();
            lbCreatedBy.Text = frmLogin.LoginInstance.UserID.ToString();

        }

        private void UcFilterAndFindDriverLicense1_SearchCompleted(object sender, EventArgs e)
        {
            LoadDataForReplacement();
        }

        private void frmReplaceForDamagedLicense_Load(object sender, EventArgs e)
        {
            ucFilterAndFindDriverLicense1.SearchCompleted += UcFilterAndFindDriverLicense1_SearchCompleted;
            ucFilterAndFindDriverLicense1.PerformSearch();

        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (!driverLicense.IsActive)
            {
                MessageBox.Show("Your Card license is not Active. So You can't Replaced it");
                return;
            }

            application.PersonID = clsPeople.FindPeopleByNationalNo(driverLicense.NationalNo).ID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = 2;
            application.ApplicationStatus = 3;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = Convert.ToDecimal(lbFees.Text);
            application.UserID = frmLogin.LoginInstance.UserID;

            if (application.Save())
            {
                license.ApplicationID = application.ApplicationID;
                license.DriverID = driverLicense.DriverID;
                license.LicenseClass = clsLicenseClasses.GetLicenseClassID(driverLicense.ClassName);
                license.IssueDate = DateTime.Now;

                if (clsLicenseClasses.GetLicenseClassID(driverLicense.ClassName) == 1 || clsLicenseClasses.GetLicenseClassID(driverLicense.ClassName) == 2)
                {
                    license.ExpirationDate = DateTime.Now.AddYears(5);
                }
                else
                {
                    license.ExpirationDate = DateTime.Now.AddYears(10);
                }

                license.PaidFees = application.PaidFees;
                license.IsActive = true;

                if (rbLostLicense.Checked)
                {
                    license.IssueReason = 3;
                }

                if (rbDamagedLicense.Checked)
                {
                    license.IssueReason = 4;
                }

                license.CreatedByUserID = frmLogin.LoginInstance.UserID;

                if (license.AddNewLicense())
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

            lbLRApplicationID.Text = application.ApplicationID.ToString();
            lbReplacedLicenseID.Text = license.LicenseID.ToString();

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

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLostLicense.Checked)
            {
                lbBigTitle.Text = "Replacement For Lost License";
                lbSmallTitle.Text = "Replacement For Lost License";
                lbFees.Text = clsApplicationsTypes.GetApplicationFee(3).ToString();
            }
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDamagedLicense.Checked)
            {
                lbBigTitle.Text = "Replacement For Damaged License";
                lbSmallTitle.Text = "Replacement For Damaged License";
                lbFees.Text = clsApplicationsTypes.GetApplicationFee(4).ToString();
            }
        }
    }
}
