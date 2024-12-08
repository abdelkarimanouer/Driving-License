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

namespace DVL.User
{
    public partial class frmChangePassword : Form
    {
        int _UserID = 0;
        clsUser user;

        public frmChangePassword(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            usUserDetails1.PrintUserDetails(_UserID);
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCurrentPassword_Leave(object sender, EventArgs e)
        {
            user = clsUser.FindUserByUserID(_UserID);

            if (user != null) 
            {
                if (user.Password != txtCurrentPassword.Text)
                {
                    errorProvider1.SetError(txtCurrentPassword, "Current Password is Wrong!");
                    txtCurrentPassword.Focus();
                }
            }
        }

        private void txtNewPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                errorProvider1.SetError(txtNewPassword, "Please Enter New Password First!");
                txtNewPassword.Focus();
            }
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Please Repeat New Password To Confirm Password!");
                txtConfirmPassword.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            user.Password = txtNewPassword.Text;

            if (user.Save())
            {
                MessageBox.Show("Password Changed Successfully.");
            }
            else
            {
                MessageBox.Show("Faild");
            }
        }

    }
}
