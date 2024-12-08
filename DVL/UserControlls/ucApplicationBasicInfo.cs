using DVL.People;
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
    public partial class ucApplicationBasicInfo : UserControl
    {
        clsApplications application;

        public ucApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public void GetApplicationData(int ApplicationID)
        {
            application = clsApplications.GetApplicationInfo(ApplicationID);

            if (application != null)
            {
                lbApplicationID.Text = application.ApplicationID.ToString();

                if (application.ApplicationStatus == 1)
                {
                    lbApplicationStatus.Text = "New";
                }
                else
                {
                    lbApplicationStatus.Text = application.ApplicationStatus.ToString();
                }

                lbPaidFees.Text = application.PaidFees.ToString();
                lbApplicationType.Text = clsApplicationsTypes.FindApplicationTypeByID(application.ApplicationTypeID).ApplicationTypeTitle;
                lbApplicant.Text = clsPeople.FindPeopleByPersonID(application.PersonID).FullName();

                lbApplicationDate.Text = application.ApplicationDate.ToShortDateString();

                lbStatusDate.Text = application.LastStatusDate.ToShortDateString();

                lbCreatedBy.Text = clsUser.GetUserNameOfCurrentUser(application.UserID);
            }

        }


        private void llbPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails personDetails = new frmPersonDetails(application.PersonID);
            personDetails.ShowDialog();
        }

    }
}
