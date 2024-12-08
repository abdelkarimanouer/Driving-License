using DVLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLBusinessLayer
{
    public class clsAppointments
    {
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDLAppID { get; set; }
        public DateTime Date { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }
        enum enMode { AddNew = 0, Update = 1 }
        enMode _mode;

        private bool _AddNewAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentsData.AddNewAppointment(this.TestTypeID, this.LocalDLAppID, this.Date, this.PaidFees, 
                this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);

            return (TestAppointmentID != -1);
        }

        private bool _UpdateAppointment()
        {
            return clsTestAppointmentsData.UpdateAppointment( this.TestAppointmentID, this.Date, this.IsLocked );
        }


        public static DataTable ListsAppointments(int TestTypeID)
        {
            return clsTestAppointmentsData.ListsAppointments(TestTypeID);
        }

        public static clsAppointments FindAppointment(int appointmentid)
        {
            int testtypeid = 0, localDLappid = 0, createdbyuserid = 0, retaketestid = 0;
            DateTime date = DateTime.MinValue;
            decimal paidfees = 0;
            bool islocked = false;

            if (clsTestAppointmentsData.GetAppointmentDetails(appointmentid, ref testtypeid, ref localDLappid, ref date, ref paidfees, ref createdbyuserid, ref islocked, ref retaketestid) )
            {
                return new clsAppointments( appointmentid, testtypeid, localDLappid, date, paidfees, createdbyuserid, islocked, retaketestid );
            }
            else
            {
                return null;
            }

        }

        public bool Save()
        {
            switch (_mode)
            {
                case enMode.AddNew:
                    return _AddNewAppointment();

                case enMode.Update:
                    return _UpdateAppointment();
            }

            return false;
        }

        private clsAppointments(int testappointmentid, int testtypeid, int localDLappid, DateTime date, decimal paidfees, int createdbyuserid, bool islocked, int retaketestid)
        {
            this.TestAppointmentID = testappointmentid;
            this.TestTypeID = testtypeid;
            this.LocalDLAppID = localDLappid;
            this.Date = date;
            this.PaidFees = paidfees;
            this.CreatedByUserID = createdbyuserid;
            this.IsLocked = islocked;
            this.RetakeTestApplicationID = retaketestid;

            _mode = enMode.Update;
        }

        public clsAppointments() 
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDLAppID = -1;
            this.Date = DateTime.MinValue;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationID = -1;

            _mode = enMode.AddNew;
        }
    
    
    
    }
}
