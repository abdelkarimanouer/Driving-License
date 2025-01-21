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

namespace DVL.Schedule_Tests
{
    public partial class frmTakeTest : Form
    {
        int _LocalDLAppID = 0;
        int PassedTestCount = 0;
        int _TestAppointment = 0;

        public frmTakeTest(int localdlappid, int testappointment)
        {
            InitializeComponent();
            _LocalDLAppID = localdlappid;
            _TestAppointment = testappointment;

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

        private void LoadData()
        {
            int ApplicationID = clsLocalDrivingLicenseApp.GetApplicationIDFromLocalDLAppTable(_LocalDLAppID);
            clsApplications applications = clsApplications.GetApplicationInfo(ApplicationID);

            lbID.Text = _LocalDLAppID.ToString();
            lbDClass.Text = clsLocalDrivingLicenseApp.ClassNameByLDLAppID(_LocalDLAppID);
            lbName.Text = clsPeople.FindPeopleByPersonID(applications.PersonID).FullName();
            lbFees.Text = clsLicenseClasses.ApplicationFees(lbDClass.Text).ToString();
            lbDate.Text = clsAppointments.FindAppointment(_TestAppointment).Date.ToString("d") ;
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsTests test = new clsTests();

            test.TestAppointmentID = _TestAppointment;

            if (rbPass.Checked)
            {
                test.TestResult = true;
            }
            else if (rbFail.Checked)
            {
                test.TestResult = false;
            }

            test.Notes = txtNotes.Text;
            test.CreatedByUserID = clsUserLog.user.UserID;

            if (test.Save())
            {
                MessageBox.Show("Successfully");
            }
            else
            {
                MessageBox.Show("Faild");
            }

            lbTestID.Text = test.TestID.ToString();

            this.Close();
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}
