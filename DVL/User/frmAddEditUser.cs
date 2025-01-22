using DVL.UserControlls;
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
    public partial class frmAddEditUser : Form
    {
        int _UserID = 0;
        enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode;

        clsUser user;

        public frmAddEditUser(int userID)
        {
            InitializeComponent();
            _UserID = userID;

            if (_UserID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode= enMode.Update;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ucFilterAndFindPerson.CheckifPersonIsUser)
            {
                MessageBox.Show("Selected Person already has a user, choose another one.");
                return;
            }
            else
            {
                // Switch to the next page
                int currentPageIndex = tabControl1.SelectedIndex;

                // Check if there is a next page
                if (currentPageIndex < tabControl1.TabPages.Count - 1)
                {
                    tabControl1.SelectedIndex = currentPageIndex + 1;
                }
                else
                {
                    MessageBox.Show("You are already on the last page.");
                }
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError( txtPassword, "Password Can not be blank" );
                txtPassword.Focus();
            }
            
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            if ( string.IsNullOrEmpty(txtConfirmPassword.Text) )
            {
                errorProvider1.SetError(txtConfirmPassword, "Password Can not be blank");
                txtConfirmPassword.Focus();
                return;
            }
            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Password Confimation does not match Password!");
                txtConfirmPassword.Focus();
                return;
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "Please Enter UserName Before Enter Password!");
                txtUserName.Focus();
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode != enMode.Update)
            {
                if (clsUser.UserExists(txtUserName.Text))
                {
                    MessageBox.Show("UserName Already Exist, Enter Another One");
                    txtUserName.Focus();
                    return;
                }
            }

            user.PersonID = ucFilterAndFindPerson.PersonID;
            user.UserName = txtUserName.Text;

            user.Password = txtPassword.Text;
            user.IsActive = cbIsActive.Checked;

            if (user.Save())
            {
                MessageBox.Show("Successfully");
            }
            else
            {
                MessageBox.Show("Faild!");
            }

            lbUserID.Text = user.UserID.ToString();
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                lbMode.Text = "Add New User";
                lbTitleForm.Text = "Add New User";
                user = new clsUser();
                return;
            }

            user = clsUser.FindUserByUserID( _UserID );

            if (user == null)
            {
                MessageBox.Show("This Form Will Close, Try Again!");
                this.Close(); 
            }

            lbMode.Text = "Update User";
            lbTitleForm.Text = "Update User";

            ucFilterAndFindPerson.PersonID = user.PersonID;
            ucFilterAndFindPerson.LoadPersonInfo();

            lbUserID.Text = user.UserID.ToString();
            txtUserName.Text = user.UserName;
            cbIsActive.Checked = user.IsActive;

        }
    }
}
