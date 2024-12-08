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

namespace DVL.Manage_Test_Types
{
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
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

        private void RefreshTestTypesList()
        {
            dgvTestTypes.DataSource = clsTestTypes.ListsTestTypes();
            dgvTestTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            lbRecords.Text = clsTestTypes.CountTestTypes().ToString();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            RefreshTestTypesList();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestTypes updateTestTypes = new frmUpdateTestTypes( Convert.ToInt32( dgvTestTypes.CurrentRow.Cells[0].Value ) );
            updateTestTypes.ShowDialog();

            RefreshTestTypesList();
        }
    }
}
