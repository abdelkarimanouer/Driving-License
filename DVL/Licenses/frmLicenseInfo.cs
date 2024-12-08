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
    public partial class frmLicenseInfo : Form
    {
        int _ApplicationID = 0;

        public frmLicenseInfo(int applicationid)
        {
            InitializeComponent();
            _ApplicationID = applicationid;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {
            ucDriverLicenseInfo1.PrintDriverLicenseInfo(_ApplicationID);
        }
    }
}
