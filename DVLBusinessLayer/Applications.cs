using DVLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLBusinessLayer
{
    public class clsApplications
    {
        public int ApplicationID { get; set; }
        public int PersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public byte ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int UserID { get; set; }

        public static clsApplications GetApplicationInfo(int applicationid)
        {
            int personid = 0, applicationtypeid = 0, userid = 0;
            byte applicationstatus = 0;
            DateTime applicationdate = DateTime.MinValue, laststatusdate = DateTime.MinValue;
            decimal fees = 0;

            if (clsApplicationsData.GetApplicationInfo(applicationid, ref personid, ref applicationdate, ref applicationtypeid, ref applicationstatus, ref laststatusdate, ref fees, ref userid) )
            {
                return new clsApplications(applicationid, personid, applicationdate, applicationtypeid, applicationstatus, laststatusdate, fees, userid);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationsData.AddNewApplication(this.PersonID, this.ApplicationDate,
                this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.UserID);

            return (ApplicationID != -1);
        }

        public static bool CancelApplication(int ApplicationID)
        {
            return clsApplicationsData.CancelApplication(ApplicationID);
        }

        public static bool CompleteTestsApplication(int ApplicationID)
        {
            return clsApplicationsData.CompleteTestsApplication(ApplicationID);
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            return clsApplicationsData.DeleteApplication(ApplicationID);
        }

        public bool Save()
        {
            return _AddNewApplication();
        }

        public clsApplications()
        {
            this.ApplicationID = -1;
            this.PersonID = -1;
            this.ApplicationDate = DateTime.MinValue;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = 0;
            this.LastStatusDate = DateTime.MinValue;
            this.PaidFees = -1;
            this.UserID = -1;
        }

        private clsApplications(int applicationid, int personid, DateTime applicationdate, int applicationtypeid,
                                         byte applicationstatus, DateTime laststatusdate, decimal paidfees, int userid)
        {
            this.ApplicationID = applicationid;
            this.PersonID = personid;
            this.ApplicationDate = applicationdate;
            this.ApplicationTypeID = applicationtypeid;
            this.ApplicationStatus = applicationstatus;
            this.LastStatusDate = laststatusdate;
            this.PaidFees = paidfees;
            this.UserID = userid;
        }

    }
}
