using DVLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLBusinessLayer
{
    public class clsDrivers
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public bool AddNewDriver()
        {
            this.DriverID = clsDriversData.AddNewDriver(this.PersonID, CreatedByUserID, CreatedDate);

            return ( this.DriverID != -1 );
        }

        public static DataTable ListDrivers()
        {
            return clsDriversData.ListDrivers();
        }

        public clsDrivers() 
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.MinValue;
        }

        private clsDrivers(int driverid, int personid, int userid, DateTime createddate)
        {
            this.DriverID = driverid;
            this.PersonID = personid;
            this.CreatedByUserID = userid;
            this.CreatedDate = createddate;
        }


    }
}
