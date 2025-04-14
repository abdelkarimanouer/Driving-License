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
using static System.Net.Mime.MediaTypeNames;

namespace DVL.Schedule_Tests
{
    public partial class frmAddEditTest : Form
    {
        int _LocalDLAppID = 0;
        int PassedTestCount = 0;
        int _testappointmentID = 0;
        bool _IsRetake = false;

        enum enMode { AddNew = 0, Update = 1 }
        enMode _mode;

        clsAppointments _appointment;

        public frmAddEditTest(int localdlappid, int testappointmentID, bool isretake = false)
        {
            InitializeComponent();
            this._LocalDLAppID = localdlappid;
            this._testappointmentID = testappointmentID;
            this._IsRetake = isretake;

            if (_testappointmentID == -1)
            {
                _mode = enMode.AddNew;
                _appointment = new clsAppointments();
                dtpDate.MinDate = DateTime.Now;
            }
            else if (_testappointmentID != -1 && _IsRetake == true)
            {
                _mode = enMode.AddNew;
                _appointment = clsAppointments.FindAppointment(_testappointmentID);
                dtpDate.MinDate = _appointment.Date;
            }
            else
            {
                _mode = enMode.Update;
                _appointment = clsAppointments.FindAppointment(_testappointmentID);
                dtpDate.MinDate = _appointment.Date;
            }

            PassedTestCount = clsLocalDrivingLicenseApp.PassedTestCount(_LocalDLAppID);

            if (PassedTestCount == 0)
            {
                lbTestType.Text = "Vision Test";
                gbTestType.Text = "Vision Test"; 
                pictureBox1.Image = Properties.Resources.Vision_512;
            }

            if (PassedTestCount == 1)
            {
                lbTestType.Text = "Written Test";
                gbTestType.Text = "Written Test"; ;
                pictureBox1.Image = Properties.Resources.Written_Test_512;
            }

            if (PassedTestCount == 2)
            {
                lbTestType.Text = "Street Test";
                gbTestType.Text = "Street Test"; ;
                pictureBox1.Image = Properties.Resources.driving_test_512;
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

        private void LoadData()
        {
            if (_IsRetake)
            {
                gbRetakeTestInfo.Enabled = true;
            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lbRAppFees.Text = "0";
            }

            if (_mode == enMode.Update)
            {
                dtpDate.Value = _appointment.Date;

            }

            int ApplicationID = clsLocalDrivingLicenseApp.GetApplicationIDFromLocalDLAppTable(_LocalDLAppID);
            clsApplications applications = clsApplications.GetApplicationInfo(ApplicationID);

            lbID.Text = _LocalDLAppID.ToString();
            lbDClass.Text = clsLocalDrivingLicenseApp.ClassNameByLDLAppID(_LocalDLAppID);
            lbName.Text = clsPeople.FindPeopleByPersonID(applications.PersonID).FullName();
            lbFees.Text = LicenseClasses.ApplicationFees(lbDClass.Text).ToString();

            lbTotalFees.Text = (Convert.ToDecimal(lbFees.Text) + Convert.ToDecimal(lbRAppFees.Text)).ToString();


        }

        private void frmAddTest_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_IsRetake)
            {
                clsAppointments appoint = new clsAppointments();
                appoint.TestTypeID = _appointment.TestTypeID;
                appoint.LocalDLAppID = _LocalDLAppID;
                appoint.Date = _appointment.Date;
                appoint.PaidFees = Convert.ToDecimal(lbTotalFees.Text);
                appoint.CreatedByUserID = _appointment.CreatedByUserID;
                appoint.IsLocked = _appointment.IsLocked;

                appoint.RetakeTestApplicationID = _appointment.TestAppointmentID;

                if (appoint.Save())
                {
                    MessageBox.Show("Successfully");
                }
                else
                {
                    MessageBox.Show("Faild");
                }
                lbRTestAppID.Text = appoint.RetakeTestApplicationID.ToString();
                return;
            }

            else
            {
                _appointment.TestTypeID = PassedTestCount + 1;
                _appointment.LocalDLAppID = _LocalDLAppID;
                _appointment.Date = dtpDate.Value;
                _appointment.PaidFees = Convert.ToDecimal(lbTotalFees.Text);
                _appointment.CreatedByUserID = clsUserLog.user.UserID;
                _appointment.IsLocked = false;


                if (_appointment.Save())
                {
                    MessageBox.Show("Successfully");
                }
                else
                {
                    MessageBox.Show("Faild");
                }
            }

            this.Close();

        }

    }
}
