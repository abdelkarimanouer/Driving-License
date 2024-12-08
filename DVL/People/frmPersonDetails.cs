using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL.People
{
    public partial class frmPersonDetails : Form
    {
        int _PersonID = 0;

        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
                ucPersonDetails1.PersonDetailsByPersonID(_PersonID);
        }
    }
}
