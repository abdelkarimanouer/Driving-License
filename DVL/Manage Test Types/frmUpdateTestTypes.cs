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
    public partial class frmUpdateTestTypes : Form
    {
        int _TestTypeID = 0;
        clsTestTypes TestType;
        public frmUpdateTestTypes(int testTypeID)
        {
            InitializeComponent();
            _TestTypeID = testTypeID;
        }

        private void frmUpdateTestTypes_Load(object sender, EventArgs e)
        {
            TestType = clsTestTypes.FindTestType(_TestTypeID);

            if (TestType != null)
            {
                lbID.Text = TestType.TestTypeID.ToString();
                txtTitle.Text = TestType.TestTypeTitle;
                txtDescription.Text = TestType.TestTypeDescription;
                txtFees.Text = TestType.TestTypeFees.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TestType.TestTypeTitle = txtTitle.Text;
            TestType.TestTypeDescription = txtDescription.Text;
            TestType.TestTypeFees = Convert.ToDecimal(txtFees.Text);

            if (TestType.UpdateTestType())
            {
                MessageBox.Show("Successfully");
            }
            else
            {
                MessageBox.Show("Faild");
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
    }
}
