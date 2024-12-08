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
    public partial class ucUserDetails : UserControl
    {
        public ucUserDetails()
        {
            InitializeComponent();
        }

        public void PrintUserDetails(int UserID)
        {
            clsUser user = clsUser.FindUserByUserID(UserID);

            if (user != null) 
            {
                ucPersonDetails1.PersonDetailsByPersonID(user.PersonID);

                lbUserID.Text = user.UserID.ToString();
                lbUserName.Text = user.UserName;

                if (user.IsActive)
                {
                    lbIsActive.Text = "Yes";
                }
                else
                {
                    lbIsActive.Text = "No";
                }

            }
        }

        private void usUserDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
