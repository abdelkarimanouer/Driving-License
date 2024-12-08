using DVLBusinessLayer;
using System;
using System.Windows.Forms;

namespace DVL.UserControlls
{
    public partial class ucFilterAndFindDriverLicense : UserControl
    {
        public event EventHandler SearchCompleted;

        public bool FoundLicense = false;
        public clsInfoDriverLicense driverLicense = new clsInfoDriverLicense();

        public ucFilterAndFindDriverLicense()
        {
            InitializeComponent();
        }

        protected virtual void OnSearchCompleted(EventArgs e)
        {
            SearchCompleted?.Invoke(this, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        public void PerformSearch()
        {
            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                return;
            }

            int LicenseID = Convert.ToInt32(txtFilter.Text.Trim());
            int ApplicationID = clsLicenses.GetApplicationIDFromLicenses(LicenseID);

            ucDriverLicenseInfo1.PrintDriverLicenseInfo(ApplicationID);
            FoundLicense = ucDriverLicenseInfo1.FoundLicense;
            driverLicense = ucDriverLicenseInfo1.driverLicense;

            OnSearchCompleted(EventArgs.Empty);
        }
    }
}
