using DVL.Drivers;
using DVL.Global_Classes;
using DVL.Licenses;
using DVL.Manage_Applications_Types;
using DVL.Manage_Detain_License;
using DVL.Manage_Interantional_License_App;
using DVL.Manage_Local_Driving_Licenese_Application;
using DVL.Manage_Test_Types;
using DVL.New_Driving_Licenese_Application;
using DVL.People;
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

namespace DVL
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void peoplesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople managePeople = new frmManagePeople();

            managePeople.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsUserLog.user = null;
            this.Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers manageusers = new frmManageUsers();
            manageusers.ShowDialog();
        }

        private void currentUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails userDetails = new frmUserDetails(clsUserLog.user.UserID);
            userDetails.ShowDialog();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword( clsUserLog.user.UserID );
            changePassword.ShowDialog();
        }

        private void manageApplicationsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationsTypes ApplicationsTypes = new frmManageApplicationsTypes();
            ApplicationsTypes.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes manageTestTypes = new frmManageTestTypes();
            manageTestTypes.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApp NewLocal = new frmNewLocalDrivingLicenseApp();
            NewLocal.ShowDialog();
        }

        private void localDriviingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenseApplications localDrivingLicenseApplications = new frmManageLocalDrivingLicenseApplications();
            localDrivingLicenseApplications.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDrivers Driver = new frmManageDrivers();
            Driver.ShowDialog();
        }

        private void internationalLicenseApplcationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageInternationalLicenseApplications international = new frmManageInternationalLicenseApplications();
            international.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApp newInternationalLicenseApp = new frmNewInternationalLicenseApp();
            newInternationalLicenseApp.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicenseApplication Renew = new frmRenewLicenseApplication();
            Renew.ShowDialog();
        }

        private void replacementForLostOrDaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceForDamagedLicense damagedLicense = new frmReplaceForDamagedLicense();
            damagedLicense.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense detainLicense = new frmDetainLicense();
            detainLicense.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense release = new frmReleaseDetainedLicense();
            release.ShowDialog();
        }

        private void manageReleasedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListReleasedLicenses listReleasedLicenses = new frmListReleasedLicenses();
            listReleasedLicenses.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense release = new frmReleaseDetainedLicense();
            release.ShowDialog();
        }
    }
}
