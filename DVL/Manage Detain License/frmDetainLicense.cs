using DVL.Global_Classes;
using DVL.Licenses;
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
    public partial class frmDetainLicense : Form
    {
        clsInfoDriverLicense driverLicense = new clsInfoDriverLicense();
        clsDetainedLicense DetainedLicense = new clsDetainedLicense();

        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadDataForDetain()
        {
            if (!ucFilterAndFindDriverLicense1.FoundLicense)
            {
                MessageBox.Show("No license found. Please search for a valid license.");
                llbShowLicenseHistory.Enabled = false;
                llbShowLicenseInfo.Enabled = false;
                btnDetain.Enabled = false;
                return;
            }

            driverLicense = ucFilterAndFindDriverLicense1.driverLicense;

            if (clsDetainedLicense.IsDetainedOrNot(driverLicense.LicenseID))
            {
                MessageBox.Show("Selected License Already Detained, Choose Another One.");
                llbShowLicenseHistory.Enabled = false;
                llbShowLicenseInfo.Enabled = false;
                btnDetain.Enabled = false;
                return;
            }

            btnDetain.Enabled = true;
            llbShowLicenseHistory.Enabled = true;

            lbDetainDate.Text = DateTime.Now.ToString("d");
            lbFees.Text = "150";
            lbLicenseID.Text = driverLicense.LicenseID.ToString();
            lbCreatedBy.Text = clsUser.GetUserNameOfCurrentUser( clsUserLog.user.UserID );

        }

        private void UcFilterAndFindDriverLicense1_SearchCompleted(object sender, EventArgs e)
        {
            LoadDataForDetain();
        }


        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            ucFilterAndFindDriverLicense1.SearchCompleted += UcFilterAndFindDriverLicense1_SearchCompleted;
            ucFilterAndFindDriverLicense1.PerformSearch();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            DetainedLicense.LicenseID = driverLicense.LicenseID;
            DetainedLicense.DetainDate = DateTime.Now;
            DetainedLicense.FineFees = Convert.ToDecimal( lbFees.Text );
            DetainedLicense.CreatedByUserID = clsUserLog.user.UserID;
            DetainedLicense.IsReleased = false;

            if (DetainedLicense.Save())
            {
                MessageBox.Show("Successfully");
                llbShowLicenseInfo.Enabled = true;
            }
            else
            {
                MessageBox.Show("Faild");
                llbShowLicenseInfo.Enabled = false;
            }
        }

        private void llbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory licenseHistory = new frmLicenseHistory(clsPeople.FindPeopleByNationalNo(driverLicense.NationalNo).ID);
            licenseHistory.ShowDialog();
        }

        private void llbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int ApplicationID = clsLicenses.GetApplicationIDFromLicenses(driverLicense.LicenseID);
            frmLicenseInfo licenseInfo = new frmLicenseInfo(ApplicationID);
            licenseInfo.ShowDialog();
        }

    }
}
