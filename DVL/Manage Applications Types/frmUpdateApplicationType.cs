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
    public partial class frmUpdateApplicationType : Form
    {
        int _ApplicationTypeID = 0;
        clsApplicationsTypes applicationsTypes;

        public frmUpdateApplicationType(int applicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = applicationTypeID;
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            applicationsTypes = clsApplicationsTypes.FindApplicationTypeByID(_ApplicationTypeID);

            if (applicationsTypes != null) 
            {
                lbApplicationTypeID.Text = applicationsTypes.ApplicationTypeID.ToString();
                txtTitle.Text = applicationsTypes.ApplicationTypeTitle;
                txtFees.Text = applicationsTypes.ApplicationFees.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            applicationsTypes.ApplicationTypeTitle = txtTitle.Text;
            applicationsTypes.ApplicationFees = Convert.ToDecimal(txtFees.Text);

            if (applicationsTypes.UpdateApplicationType())
            {
                MessageBox.Show("Successfully");
            }
            else
            {
                MessageBox.Show("Faild");
            }
        }
    }
}
