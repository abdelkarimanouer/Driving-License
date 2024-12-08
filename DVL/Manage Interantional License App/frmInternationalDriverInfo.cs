﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL.Manage_Interantional_License_App
{
    public partial class frmInternationalDriverInfo : Form
    {
        int _InternationalLicenseID = 0;
        public frmInternationalDriverInfo(int internationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID = internationalLicenseID;
        }

        private void frmInternationalDriverInfo_Load(object sender, EventArgs e)
        {
            ucDriverInternationalLicenseInfo1.GetDriverIntLicenseInfo(_InternationalLicenseID);
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
