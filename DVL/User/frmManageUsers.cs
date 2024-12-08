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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVL.User
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close ();
        }

        private void RefrechUsers()
        {
            dgvUsers.DataSource = clsUser.GetAllUsers();

            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            lbRecords.Text = clsUser.CountUsers().ToString();

            cbFilter.SelectedIndex = 0;
        }
        
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            RefrechUsers();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
            {
                dgvUsers.DataSource = clsUser.GetAllUsers();
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                txtFilter.Visible = false;
                return;
            }

            if (cbFilter.Text == "IsActive")
            {
                cbTypeActive.SelectedIndex = 0;
                txtFilter.Visible = false;
                cbTypeActive.Visible = true;
                return;
            }

            else if (cbFilter.SelectedIndex != 0)
            {
                txtFilter.Visible = true;
                return;
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilter.Text))
            {
                dgvUsers.DataSource = clsUser.GetAllUsers();
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                return;
            }

            if (cbFilter.Text == "UserID")
            {
                dgvUsers.DataSource = clsUser.FilterByUserID( Convert.ToInt32(txtFilter.Text) );
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                return;
            }

            if (cbFilter.Text == "PersonID")
            {
                dgvUsers.DataSource = clsUser.FilterByPersonID(Convert.ToInt32(txtFilter.Text));
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                return;
            }

            if (cbFilter.Text == "UserName")
            {
                dgvUsers.DataSource = clsUser.FilterByUserName(txtFilter.Text);
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                return;
            }

            if (cbFilter.Text == "FullName")
            {
                dgvUsers.DataSource = clsUser.FilterByFullName(txtFilter.Text);
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                return;
            }

        }

        private void cbTypeActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTypeActive.Text == "Yes")
            {
                dgvUsers.DataSource = clsUser.FilterByIsActive(true);
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                return;
            }
            else if (cbTypeActive.Text == "No")
            {
                dgvUsers.DataSource = clsUser.FilterByIsActive(false);
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                return;
            }
            else
            {
                dgvUsers.DataSource = clsUser.GetAllUsers();
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                return;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser AddUser = new frmAddEditUser(-1);
            AddUser.ShowDialog();

            RefrechUsers();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "UserID" || cbFilter.Text == "PersonID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

        }

        private void tsmAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser AddUser = new frmAddEditUser(-1);
            AddUser.ShowDialog();

            RefrechUsers();
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (   clsUser.DeleteUser( Convert.ToInt32( dgvUsers.CurrentRow.Cells[0].Value.ToString() ) )   )
            {
                MessageBox.Show("User Deleted Successfully");
            }
            else
            {
                MessageBox.Show("Faild");
            }

            RefrechUsers();
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            frmAddEditUser AddUser = new frmAddEditUser(Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value.ToString()));
            AddUser.ShowDialog();

            RefrechUsers();
        }

        private void tsmSendEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Under Developement, Comming Soon!");
        }

        private void tsmPhoneCall_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Under Developement, Comming Soon!");
        }

        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            frmUserDetails UserDetails = new frmUserDetails(Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value.ToString()));
            UserDetails.ShowDialog();
            RefrechUsers();
        }

        private void tsmChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword(Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value.ToString()));
            changePassword.ShowDialog();
            RefrechUsers();
        }
    }
}
