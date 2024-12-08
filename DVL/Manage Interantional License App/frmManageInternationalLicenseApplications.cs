using DVL.Licenses;
using DVL.People;
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

namespace DVL.Manage_Interantional_License_App
{
    public partial class frmManageInternationalLicenseApplications : Form
    {
        public frmManageInternationalLicenseApplications()
        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData()
        {
            dgvInternationalDrivingLicense.DataSource = clsInternationalLicense.ListsInternationalLicenses();
            dgvInternationalDrivingLicense.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            lbRecords.Text = clsInternationalLicense.ListsInternationalLicenses().Rows.Count.ToString();
        }

        private void frmManageInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnNewIntenationalDrivingLicenseApp_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApp newInternationalLicenseApp = new frmNewInternationalLicenseApp();
            newInternationalLicenseApp.ShowDialog();

            LoadData();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = clsInternationalLicense.GetApplicationIDByInternationalLicenseID(  Convert.ToInt32(dgvInternationalDrivingLicense.CurrentRow.Cells[0].Value)  );

            frmPersonDetails person = new frmPersonDetails( clsApplications.GetApplicationInfo(ApplicationID).PersonID );
            person.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalDriverInfo driverinfo = new frmInternationalDriverInfo(Convert.ToInt32(dgvInternationalDrivingLicense.CurrentRow.Cells[0].Value));
            driverinfo.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = clsInternationalLicense.GetApplicationIDByInternationalLicenseID(Convert.ToInt32(dgvInternationalDrivingLicense.CurrentRow.Cells[0].Value));

            frmLicenseHistory licenseHistory = new frmLicenseHistory(  clsApplications.GetApplicationInfo(ApplicationID).PersonID );
            licenseHistory.ShowDialog();
        }


    }
}
