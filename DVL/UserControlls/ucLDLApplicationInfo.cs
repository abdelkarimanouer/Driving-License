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

namespace DVL.UserControlls
{
    public partial class ucLDLApplicationInfo : UserControl
    {
        public ucLDLApplicationInfo()
        {
            InitializeComponent();
        }

        public void GetLDLAppInfoFromView(int LocalApplicationID)
        {

            string classname = string.Empty;
            byte passedtest = 0;

            clsLocalDrivingLicenseApp.GetLocalDLAppInfoFromView(LocalApplicationID, ref classname, ref passedtest );
            lbClassName.Text = classname;
            lbPassedTests.Text = clsLocalDrivingLicenseApp.PassedTestCount(LocalApplicationID).ToString() ;
            lbDLAppID.Text = LocalApplicationID.ToString();

            
            int ApplicationID = clsLocalDrivingLicenseApp.GetApplicationIDFromLocalDLAppTable(LocalApplicationID);
            ucApplicationBasicInfo1.GetApplicationData(ApplicationID);


        }

    }
}
