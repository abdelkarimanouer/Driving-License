using DVLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLBusinessLayer
{
    public class clsLicenses
    {
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public byte IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        public bool AddNewLicense()
        {
            this.LicenseID = clsLicensesData.AddNewLicense(ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            return (LicenseID != -1);
        }

        public static DataTable GetLocalLicenseHistoryByPersonID(int PersonID)
        {
            return clsLicensesData.GetLocalLicenseHistoryByPersonID(PersonID);
        }

        public static int GetApplicationIDFromLicenses(int LicenseID)
        {
            return clsLicensesData.GetApplicationIDFromLicenses(LicenseID);
        }

        public static bool DisableLicense(int LicenseID)
        {
            return clsLicensesData.DisableLicense(LicenseID);
        }

        public static int GetLicenseIDByAppID(int ApplicationID)
        {
            return clsLicensesData.GetLicenseIDByAppID(ApplicationID);
        }
        private clsLicenses(int licenseid, int appid, int driverid, int licenseclass, DateTime issuedate,
            DateTime expirationdate, string notes, decimal paidfees, bool isactive, byte issuereason, int userid)
        {
            this.LicenseID = licenseid;
            this.ApplicationID = appid;
            this.DriverID = driverid;
            this.LicenseClass = licenseclass;
            this.IssueDate = issuedate;
            this.ExpirationDate = expirationdate;
            this.Notes = notes;
            this.PaidFees = paidfees;
            this.IsActive = isactive;
            this.IssueReason = issuereason;
            this.CreatedByUserID = userid;

        }

        public clsLicenses() 
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.MinValue;
            this.ExpirationDate = DateTime.MinValue;
            this.Notes = string.Empty;
            this.PaidFees = 0;
            this.IsActive = false;
            this.IssueReason = 0;
            this.CreatedByUserID = -1;
        }
    }
}
