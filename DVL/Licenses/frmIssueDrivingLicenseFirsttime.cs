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

namespace DVL.Manage_Local_Driving_Licenese_Application
{
    public partial class frmIssueDrivingLicenseFirsttime : Form
    {
        int _LocalDLAppID = 0;

        public frmIssueDrivingLicenseFirsttime(int localDLAppID)
        {
            InitializeComponent();
            this._LocalDLAppID = localDLAppID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIssueDrivingLicenseFirsttime_Load(object sender, EventArgs e)
        {
            ucLDLApplicationInfo1.GetLDLAppInfoFromView(_LocalDLAppID);
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int ApplicationID = clsLocalDrivingLicenseApp.GetApplicationIDFromLocalDLAppTable(_LocalDLAppID);
            clsApplications application = clsApplications.GetApplicationInfo(ApplicationID);

            clsDrivers driver = new clsDrivers();
            driver.PersonID = clsApplications.GetApplicationInfo(ApplicationID).PersonID;
            driver.CreatedByUserID = clsUserLog.user.UserID ;
            driver.CreatedDate = DateTime.Now;

            if (driver.AddNewDriver())
            {
                clsLicenses license = new clsLicenses();

                license.ApplicationID = ApplicationID;
                license.DriverID = driver.DriverID;
                license.LicenseClass = clsLocalDrivingLicenseApp.LicenseClassIDByLDLAppID(_LocalDLAppID);
                license.IssueDate = application.ApplicationDate;

                if (license.LicenseClass == 1 || license.LicenseClass == 2)
                {
                    license.ExpirationDate = license.IssueDate.AddYears(5);
                }
                else
                {
                    license.ExpirationDate = license.IssueDate.AddYears(10);
                }

                license.Notes = txtNotes.Text;
                license.PaidFees = application.PaidFees;
                license.IsActive = true;
                license.IssueReason = 1;
                license.CreatedByUserID = clsUserLog.user.UserID;

                if (license.AddNewLicense())
                {
                    MessageBox.Show("Successfully");

                    clsApplications.CompleteTestsApplication(ApplicationID);
                }

            }


        }
    
    }
}
