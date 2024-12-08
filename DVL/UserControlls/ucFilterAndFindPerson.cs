using DVL.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL.UserControlls
{
    public partial class ucFilterAndFindPerson : UserControl
    {
        public int PersonID = 0;
        public string NationlNo = string.Empty;

        public ucFilterAndFindPerson()
        {
            InitializeComponent();
            cbFilter.SelectedIndex = 1;
        }

        public bool CheckifPersonIsUser = false;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbFilter.Text == "PersonID")
            {
                if (txtFilter.Text == "")
                {
                    return;
                }

                ucPersonDetails.PersonDetailsByPersonID( Convert.ToInt32(txtFilter.Text) );
                CheckifPersonIsUser = ucPersonDetails.CheckifPersonIsUser;
                PersonID = ucPersonDetails.PersonID;
                NationlNo = ucPersonDetails.NationalNo;
            }

            if (cbFilter.Text == "NationalNo")
            {
                if (txtFilter.Text == "")
                {
                    return;
                }

                ucPersonDetails.PersonDetailsByNationalNo(txtFilter.Text);
                CheckifPersonIsUser = ucPersonDetails.CheckifPersonIsUser;
                PersonID = ucPersonDetails.PersonID;
                NationlNo = ucPersonDetails.NationalNo;
            }

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPeople Add = new frmAddEditPeople(-1);
            Add.ShowDialog();

            int PID = frmAddEditPeople.InstanceAdd._PersonID;

            ucPersonDetails.PersonDetailsByPersonID(PID);
            PersonID = PID;

            cbFilter.SelectedIndex = 0;
            txtFilter.Text = PersonID.ToString();

        }

        public void LoadPersonInfo()
        {
                ucPersonDetails.PersonDetailsByPersonID(PersonID);
                cbFilter.SelectedIndex = 0;
                txtFilter.Text = PersonID.ToString();
                gbFilter.Enabled = false;

        }

        private void ucFilterAndFindPerson_Load(object sender, EventArgs e)
        {

        }

        private void ucPersonDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
