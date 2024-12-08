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
    public partial class frmListReleasedLicenses : Form
    {
        public frmListReleasedLicenses()
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

        private void LoadListofDetainedLicenses()
        {
            dgvListDetainedLicenses.DataSource = clsDetainedLicense.ListDetainedLicenses();
            lbRecords.Text = clsDetainedLicense.ListDetainedLicenses().Rows.Count.ToString();

            dgvListDetainedLicenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            LoadListofDetainedLicenses();

        }
        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense releaseDetainedLicense = new frmReleaseDetainedLicense();
            releaseDetainedLicense.ShowDialog();

            LoadListofDetainedLicenses();
        }
    }
}
