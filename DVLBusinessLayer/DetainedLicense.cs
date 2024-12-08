using DVLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLBusinessLayer
{
    public class clsDetainedLicense
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }

        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode;


        private bool _AddNewDetain()
        {
            this.DetainID = clsDetainedLicenseData.AddNewDetain(LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            return (DetainID != -1);
        }

        private bool _UpdateDetained()
        {
            return clsDetainedLicenseData.ReleaseDetainedLicense(LicenseID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
        }

        public static clsDetainedLicense GetDetainedInfo(int LicenseID)
        {
            int detainid = -1, createdbyuserid = -1, releasedbyuserid = -1, releaseapplicationid = -1;
            DateTime detaindate = DateTime.MinValue, releasedate = DateTime.MinValue;
            decimal finefees = -1;
            bool isreleased = false;

            if ( clsDetainedLicenseData.GetDetainedInfo(LicenseID, ref detainid, ref detaindate, ref finefees, ref createdbyuserid, ref isreleased, ref releasedate, ref releasedbyuserid, ref releaseapplicationid) )
            {
                return new clsDetainedLicense(detainid, LicenseID, detaindate, finefees, createdbyuserid, isreleased, releasedate, releasedbyuserid, releaseapplicationid);
            }
            else
            {
                return null;
            }
        }

        public static bool IsDetainedOrNot(int LicenseID)
        {
            return clsDetainedLicenseData.IsDetainedOrNot(LicenseID);
        }

        public static DataTable ListDetainedLicenses()
        {
            return clsDetainedLicenseData.ListDetainedLicenses();
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    return _AddNewDetain();
                case enMode.Update:
                    return _UpdateDetained();
            }

            return false;
        }

        public clsDetainedLicense(int detainid, int licenseid, DateTime detaindate, decimal finefees, int createdbyuserid, bool isreleased,
            DateTime releasedate, int releasedbyuserid, int releaseapplicationid)
        {
            this.DetainID = detainid;
            this.LicenseID = licenseid;
            this.DetainDate = detaindate;
            this.FineFees = finefees;
            this.CreatedByUserID = createdbyuserid;
            this.IsReleased = isreleased;
            this.ReleaseDate = releasedate;
            this.ReleasedByUserID = releasedbyuserid;
            this.ReleaseApplicationID = releaseapplicationid;

            _Mode = enMode.Update;
        }

        public clsDetainedLicense()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.MinValue;
            this.FineFees = -1;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.MinValue;
            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1;

            _Mode = enMode.AddNew;
        }

    }
}
