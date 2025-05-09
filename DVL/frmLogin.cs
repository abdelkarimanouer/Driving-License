﻿using DVL.Global_Classes;
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
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser user = clsUser.FindUserByUserNameAndPassword(txtUserName.Text, txtPassword.Text);

            if (user == null)
            {
                MessageBox.Show("UserName Or Password is Incorrect!");
                return;
            }

            if (user.IsActive == false)
            {
                MessageBox.Show("Your Are Not Activated, Please Contact Your Admin!");
                return;
            }

            clsUserLog.user = user;

            if (chbRememberme.Checked)
            {
                user.SaveUserDataInFile(txtPassword.Text);
            }
            else
            {
                clsUser.DeleteRecordFromFile();
            }

            frmMain main = new frmMain();
            main.Show();

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = null, Password = null;
            clsUser.GetUserFromFileIfSaveHisInfoInLastLogin(ref UserName, ref Password);

            txtUserName.Text = UserName;
            txtPassword.Text = Password;

        }
    }
}
