using DVL.New_Driving_Licenese_Application;
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
using System.Net.Mail;
using DVL.Schedule_Tests;
using DVL.Licenses;

namespace DVL.Manage_Local_Driving_Licenese_Application
{
    public partial class frmManageLocalDrivingLicenseApplications : Form
    {
        public frmManageLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dgvLocalDrivingLicense.DataSource = clsLocalDrivingLicenseApp.ListsLocalDrivingLicenseApps();
            dgvLocalDrivingLicense.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cbFilter.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;
            lbRecords.Text = clsLocalDrivingLicenseApp.CountRecords().ToString();
        }

        private void btnX_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnNewLocalDrivingLicenseApp_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApp newLocalDrivingLicenseApp = new frmNewLocalDrivingLicenseApp();
            newLocalDrivingLicenseApp.ShowDialog();

            LoadData();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (txtFilter.Text == "")
            {
                dgvLocalDrivingLicense.DataSource = clsLocalDrivingLicenseApp.ListsLocalDrivingLicenseApps();
                dgvLocalDrivingLicense.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                return;
            }

            if (cbFilter.Text == "NationalNo")
            {
                dgvLocalDrivingLicense.DataSource = clsLocalDrivingLicenseApp.FilterByNationalNo(txtFilter.Text);
                dgvLocalDrivingLicense.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                return;
            }

            if (cbFilter.Text == "FullName")
            {
                dgvLocalDrivingLicense.DataSource = clsLocalDrivingLicenseApp.FilterByFullName(txtFilter.Text);
                dgvLocalDrivingLicense.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                return;
            }

            if (cbFilter.Text == "L.D.L.AppID")
            {
                dgvLocalDrivingLicense.DataSource = clsLocalDrivingLicenseApp.FilterByLDLAppID( Convert.ToInt32(txtFilter.Text) );
                dgvLocalDrivingLicense.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                return;
            }


        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text == "Status")
            {
                txtFilter.Visible = false;
                cbStatus.Visible = true;
                return;
            }
            else  if (cbFilter.SelectedIndex != 0)
            {
                txtFilter.Visible = true;
                cbStatus.Visible = false;
            }
            else
            {
                txtFilter.Visible= false;
                cbStatus.Visible= false;
            }
        }

        private void cbStatus_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbStatus.SelectedIndex == 0)
            {
                dgvLocalDrivingLicense.DataSource = clsLocalDrivingLicenseApp.ListsLocalDrivingLicenseApps();
                dgvLocalDrivingLicense.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                return;
            }

            if (cbFilter.Text == "Status")
            {
                dgvLocalDrivingLicense.DataSource = clsLocalDrivingLicenseApp.FilterByStatus(cbStatus.Text);
                dgvLocalDrivingLicense.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                return;
            }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = clsLocalDrivingLicenseApp.GetApplicationIDFromLocalDLAppTable( Convert.ToInt32(dgvLocalDrivingLicense.CurrentRow.Cells[0].Value) );

            if (MessageBox.Show("Are You Sure you want to Cancelled This App, This will delete it alse", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsApplications.CancelApplication(ApplicationID))
                {
                    if (clsLocalDrivingLicenseApp.DeleteLocalDLApplication(Convert.ToInt32(dgvLocalDrivingLicense.CurrentRow.Cells[0].Value)))
                    {
                        if (clsApplications.DeleteApplication(ApplicationID))
                        {
                            MessageBox.Show("Successfully");
                        }
                        else
                        {
                            MessageBox.Show("Faild");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Faild");
                }
            }

            LoadData();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = clsLocalDrivingLicenseApp.GetApplicationIDFromLocalDLAppTable(Convert.ToInt32(dgvLocalDrivingLicense.CurrentRow.Cells[0].Value));

            if (clsLocalDrivingLicenseApp.DeleteLocalDLApplication(Convert.ToInt32(dgvLocalDrivingLicense.CurrentRow.Cells[0].Value)))
            {
                if (clsApplications.DeleteApplication(ApplicationID))
                {
                    MessageBox.Show("Successfully");
                }
                else
                {
                    MessageBox.Show("Faild");
                }

            }

            LoadData();
        }

        private void scheduleTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDLApp = Convert.ToInt32(dgvLocalDrivingLicense.CurrentRow.Cells[0].Value);

            frmTest test = new frmTest(LocalDLApp);
            test.ShowDialog();

            LoadData();
        }

        private void cmsLocalDLApp_Opening(object sender, CancelEventArgs e)
        {
            if (dgvLocalDrivingLicense.Rows.Count == 0 || (dgvLocalDrivingLicense.Rows.Count == 1 && dgvLocalDrivingLicense.Rows[0].IsNewRow))
            {
                e.Cancel = true;
                return;
            }


            int LocalDLApp = Convert.ToInt32(dgvLocalDrivingLicense.CurrentRow.Cells[0].Value);


            if (clsLocalDrivingLicenseApp.CheckIfStatusIsCompleted(LocalDLApp))
            {
                showLicenseToolStripMenuItem.Enabled = true;
                scheduleTestsToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                editApplicationToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                return;
            }
            else
            {
                showLicenseToolStripMenuItem.Enabled = false;
                editApplicationToolStripMenuItem.Enabled = true;
                deleteApplicationToolStripMenuItem.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;
            }


            if (clsLocalDrivingLicenseApp.PassedTestCount(LocalDLApp) == 3)
            {
                scheduleTestsToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                return;
            }
            else
            {
                scheduleTestsToolStripMenuItem.Enabled = true;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;

                if (clsLocalDrivingLicenseApp.PassedTestCount(LocalDLApp) == 0)
                {
                    scheduleVisionTestToolStripMenuItem.Enabled = true;
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;

                }
                else if (clsLocalDrivingLicenseApp.PassedTestCount(LocalDLApp) == 1)
                {
                    scheduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWrittenTestToolStripMenuItem.Enabled = true;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                }
                else if (clsLocalDrivingLicenseApp.PassedTestCount(LocalDLApp) == 2)
                {
                    scheduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = true;
                }
                else
                {

                    scheduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                    return;
                }

            }



        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDLApp = Convert.ToInt32(dgvLocalDrivingLicense.CurrentRow.Cells[0].Value);
            frmIssueDrivingLicenseFirsttime issue = new frmIssueDrivingLicenseFirsttime(LocalDLApp);
            issue.ShowDialog();

            LoadData();
            
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDLApp = Convert.ToInt32(dgvLocalDrivingLicense.CurrentRow.Cells[0].Value);
            int ApplicationID = clsLocalDrivingLicenseApp.GetApplicationIDFromLocalDLAppTable(LocalDLApp);
            frmLicenseInfo licenseInfo = new frmLicenseInfo(ApplicationID);
            licenseInfo.ShowDialog();
        }

        private void showPersonLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = clsLocalDrivingLicenseApp.GetApplicationIDFromLocalDLAppTable(  Convert.ToInt32(dgvLocalDrivingLicense.CurrentRow.Cells[0].Value) );

            frmLicenseHistory licenseHistory = new frmLicenseHistory( clsApplications.GetApplicationInfo(ApplicationID).PersonID );
            licenseHistory.ShowDialog();
        }

    }
}
