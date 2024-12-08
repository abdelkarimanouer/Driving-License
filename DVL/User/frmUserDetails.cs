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
    public partial class frmUserDetails : Form
    {
        int _UserID = 0;
        public frmUserDetails(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            usUserDetails1.PrintUserDetails(_UserID);
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
