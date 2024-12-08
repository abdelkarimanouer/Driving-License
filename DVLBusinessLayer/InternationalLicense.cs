using DVLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLBusinessLayer
{
    public class clsInternationalLicense
    {
        public int ILicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public static clsInternationalLicense FindInternationlLicense(int InternationalLicenseID)
        {
            int applicationid = 0, driverid = 0, locallicenseid = 0, userid = 0;
            DateTime issuedate = DateTime.MinValue , expirationdate = DateTime.MinValue ;
            bool isactive = false;

            if (clsInternationalLicenseData.GetInternationalLicenseInfo(InternationalLicenseID, ref applicationid, ref driverid, ref locallicenseid, ref issuedate, ref expirationdate, ref isactive, ref userid))
            {
                return new clsInternationalLicense(InternationalLicenseID, applicationid, driverid, locallicenseid, issuedate, expirationdate, isactive, userid);
            }
            else
            {
                return null;
            }

        }

        private bool AddNewInternationalLicenseApp()
        {
            this.ILicenseID = clsInternationalLicenseData.AddNewInternationalLicenseApp(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate,
                this.ExpirationDate, this.IsActive, this.CreatedByUserID);

            return (ILicenseID != -1);
        }

        public static bool UpdateLocalLicenseID(int OldLicenseID, int NewLicenseID)
        {
            return clsInternationalLicenseData.UpdateLocalLicenseID(OldLicenseID, NewLicenseID);
        }

        public bool Save()
        {
            return AddNewInternationalLicenseApp();
        }

        public static bool CheckifInternationalLicenseAlreadyExistByLicenseID(int IssuedUsingLocalLicenseID)
        {
            return clsInternationalLicenseData.CheckifInternationalLicenseAlreadyExistByLicenseID(IssuedUsingLocalLicenseID);
        }

        public static int GetApplicationIDByInternationalLicenseID(int InternationalLicenseID)
        {
            return clsInternationalLicenseData.GetApplicationIDByInternationalLicenseID(InternationalLicenseID);
        }


        public static int GetApplicationIDByLocalLicenseID(int IssuedUsingLocalLicenseID)
        {
            return clsInternationalLicenseData.GetApplicationIDByLocalLicenseID(IssuedUsingLocalLicenseID);
        }


        public static DataTable ListsInternationalLicenses()
        {
            return clsInternationalLicenseData.ListsInternationalLicenses();
        }

        public static DataTable ListsInternationalLicensesByPersonID(int ApplicantPersonID)
        {
            return clsInternationalLicenseData.ListsInternationalLicensesByPersonID(ApplicantPersonID);
        }
        public clsInternationalLicense() 
        {
            this.ILicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.MinValue;
            this.ExpirationDate = DateTime.MinValue;
            this.IsActive = false;
            this.CreatedByUserID = -1;
        }

        private clsInternationalLicense(int ilicenseid, int applicationid, int driverid, int locallicenseid, DateTime issuedate, DateTime expirationdate, bool isactive, int userid)
        {
            this.ILicenseID = ilicenseid;
            this.ApplicationID = applicationid;
            this.DriverID = driverid;
            this.IssuedUsingLocalLicenseID = locallicenseid;
            this.IssueDate = issuedate;
            this.ExpirationDate = expirationdate;
            this.IsActive = isactive;
            this.CreatedByUserID = userid;
        }


    }
}
