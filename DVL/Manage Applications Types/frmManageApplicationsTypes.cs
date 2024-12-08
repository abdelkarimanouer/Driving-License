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

namespace DVL.Manage_Applications_Types
{
    public partial class frmManageApplicationsTypes : Form
    {
        public frmManageApplicationsTypes()
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

        private void RefrechLists()
        {
            dgvApplicationTypes.DataSource = clsApplicationsTypes.GetApplicationsTypes();
            dgvApplicationTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lbRecords.Text = clsApplicationsTypes.CountApplicationsTypes().ToString();
        }

        private void frmManageApplicationsTypes_Load(object sender, EventArgs e)
        {
            RefrechLists();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationType updateApplicationType = new frmUpdateApplicationType( Convert.ToInt32(dgvApplicationTypes.CurrentRow.Cells[0].Value) );
            updateApplicationType.ShowDialog();
            RefrechLists();

        }

    }
}
