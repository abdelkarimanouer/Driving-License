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

namespace DVL.Licenses
{
    public partial class frmLicenseHistory : Form
    {
        int _PersonID = 0;

        public frmLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetPersonInfo(int PersonID)
        {
            ucFilterAndFindPerson1.gbFilter.Enabled = false;
            ucFilterAndFindPerson1.PersonID = PersonID;
            ucFilterAndFindPerson1.LoadPersonInfo();
            
        }

        private void LoadData()
        {

            GetPersonInfo( _PersonID );

            dgvLocalLicenseHistory.DataSource = clsLicenses.GetLocalLicenseHistoryByPersonID(_PersonID);
            dgvLocalLicenseHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lbRecords.Text = clsLicenses.GetLocalLicenseHistoryByPersonID(_PersonID).Rows.Count.ToString();

        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                dgvLocalLicenseHistory.DataSource = clsLicenses.GetLocalLicenseHistoryByPersonID(_PersonID);
                dgvLocalLicenseHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                lbRecords.Text = clsLicenses.GetLocalLicenseHistoryByPersonID(_PersonID).Rows.Count.ToString();
                return;
            }

            if (tabControl1.SelectedIndex == 1)
            {
                dgvInternationalLicenseHistory.DataSource = clsInternationalLicense.ListsInternationalLicensesByPersonID(_PersonID);
                dgvInternationalLicenseHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                lbRecords.Text = clsInternationalLicense.ListsInternationalLicensesByPersonID(_PersonID).Rows.Count.ToString();
                return;
            }

        }
    }
}
