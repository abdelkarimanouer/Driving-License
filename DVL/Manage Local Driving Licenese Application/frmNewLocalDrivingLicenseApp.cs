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

namespace DVL.New_Driving_Licenese_Application
{
    public partial class frmNewLocalDrivingLicenseApp : Form
    {
        public frmNewLocalDrivingLicenseApp()
        {
            InitializeComponent();

        }

        private void FillCbLicenseClass()
        {
            DataTable dtLicenseClasses = LicenseClasses.ListsOfLicenseClasses();

            foreach (DataRow row in dtLicenseClasses.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }

        }

        private void LoadApplicationInfoData()
        {
            lbApplicationDate.Text = DateTime.Now.ToString("d");
             
            FillCbLicenseClass();

            cbLicenseClass.SelectedIndex = 2;

            lbFees.Text = clsApplicationsTypes.GetApplicationFee(1).ToString();

            lbCreatedBy.Text = clsUser.GetUserNameOfCurrentUser(clsUserLog.user.UserID );

        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Switch to the next page
            int currentPageIndex = tabControl1.SelectedIndex;

            // Check if there is a next page
            if (currentPageIndex < tabControl1.TabPages.Count - 1)
            {
                tabControl1.SelectedIndex = currentPageIndex + 1;
            }
            else
            {
                MessageBox.Show("You are already on the last page.");
            }
        }

        private void frmNewLocalDrivingLicenseApp_Load(object sender, EventArgs e)
        {
            LoadApplicationInfoData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (   clsLocalDrivingLicenseApp.CheckIfPersonHasTheSameApp(ucFilterAndFindPerson.NationlNo, cbLicenseClass.Text)  )
            {
                if (clsLocalDrivingLicenseApp.CheckIfPersonCancelledApp(ucFilterAndFindPerson.NationlNo, cbLicenseClass.Text))
                {
                    if (clsLocalDrivingLicenseApp.CheckIfStatusNew(ucFilterAndFindPerson.NationlNo, cbLicenseClass.Text))
                    {
                        MessageBox.Show("This Person Already Has This LicenseClass, Please Choose Another One ");
                        cbLicenseClass.Focus();
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("This Person Already Has This LicenseClass, Please Choose Another One ");
                    cbLicenseClass.Focus();
                    return;
                }
            }



            clsApplications application = new clsApplications();
            clsLocalDrivingLicenseApp localDrivingLicenseApp = new clsLocalDrivingLicenseApp();

            application.PersonID = ucFilterAndFindPerson.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = 1;
            application.ApplicationStatus = 1;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = clsApplicationsTypes.GetApplicationFee(1);
            application.UserID = clsUserLog.user.UserID;

            if (application.Save())
            {
                localDrivingLicenseApp.ApplicationID = application.ApplicationID;
                localDrivingLicenseApp.LicenseClassID = LicenseClasses.GetLicenseClassID(cbLicenseClass.Text); 

                if (localDrivingLicenseApp.Save())
                {
                    MessageBox.Show("Successfully");
                }
                else
                {
                    MessageBox.Show("Faild");
                }
            }

            lbDLApplicationID.Text = localDrivingLicenseApp.LDLApplicationID.ToString();

        }
    
    }
}
