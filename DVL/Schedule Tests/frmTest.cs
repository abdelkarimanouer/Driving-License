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
    public partial class frmTest : Form
    {
        int _LocalDLAppID = 0;
        int AppointmentID = 0;
        clsAppointments appointment;
        int TestTypeID = 0;

        public frmTest(int LocalDLAppID)
        {
            InitializeComponent();
            _LocalDLAppID = LocalDLAppID;

            TestTypeID = clsLocalDrivingLicenseApp.PassedTestCount(_LocalDLAppID);

            if (TestTypeID == 0)
            {
                lblTitle.Text = "Vision Test Appointments";
                lbsmallTitle.Text = "Vision Test Appointments"; ;
                pictureBox1.Image = Properties.Resources.Vision_512;
            }

            if (TestTypeID == 1)
            {
                lblTitle.Text = "Written Test Appointments";
                lbsmallTitle.Text = "Written Test Appointments"; ;
                pictureBox1.Image = Properties.Resources.Written_Test_512;
            }

            if (TestTypeID == 2)
            {
                lblTitle.Text = "Street Test Appointments";
                lbsmallTitle.Text = "Street Test Appointments"; ;
                pictureBox1.Image = Properties.Resources.driving_test_512;
            }
        }

        private void LoadAppointments()
        {
            dgvLicenseTestAppointments.DataSource = clsAppointments.ListsAppointments(TestTypeID + 1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshData()
        {
            ucLDLApplicationInfo1.GetLDLAppInfoFromView(_LocalDLAppID);

            LoadAppointments();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            RefreshData();
        }



        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            if (clsLocalDrivingLicenseApp.IsThereAnActiveScheduledTest(_LocalDLAppID, clsLocalDrivingLicenseApp.PassedTestCount(_LocalDLAppID) + 1))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                msEdit.Enabled = true;
                msTakeTest.Enabled = true;
                return;
            }
            else
            {
                msEdit.Enabled = false;
                msTakeTest.Enabled = false;
            }

            if (clsLocalDrivingLicenseApp.PassedTestCount(_LocalDLAppID) == 3)
            {
                btnAddNewAppointment.Enabled = false;
                return;
            }
            else
            {
                btnAddNewAppointment.Enabled = true ;
            }

            frmAddEditTest addtest = new frmAddEditTest(_LocalDLAppID, -1);
            addtest.ShowDialog();

            RefreshData();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            int AppointmentID = Convert.ToInt32( dgvLicenseTestAppointments.CurrentRow.Cells[0].Value) ;
            frmAddEditTest addtest = new frmAddEditTest(_LocalDLAppID, AppointmentID);
            addtest.ShowDialog();

            RefreshData();
        }

        private void TakeTest_Click(object sender, EventArgs e)
        {
            AppointmentID = Convert.ToInt32(dgvLicenseTestAppointments.CurrentRow.Cells[0].Value);
            frmTakeTest taketest = new frmTakeTest(_LocalDLAppID, AppointmentID);
            taketest.ShowDialog();

            appointment = clsAppointments.FindAppointment(AppointmentID);

            appointment.IsLocked = true;
            appointment.Save();
            btnAddNewAppointment.Enabled = true;

            msEdit.Enabled = false;
            msTakeTest.Enabled = false;


            RefreshData();
        }

        private void cmsTest_Opening(object sender, CancelEventArgs e)
        {
            if (clsLocalDrivingLicenseApp.IsThereAnActiveScheduledTest(_LocalDLAppID, clsLocalDrivingLicenseApp.PassedTestCount(_LocalDLAppID) + 1))
            {
                msEdit.Enabled = true;
                msTakeTest.Enabled = true;
                return;
            }
            else
            {
                msEdit.Enabled = false;
                msTakeTest.Enabled = false;
            }
        }
    }
}
