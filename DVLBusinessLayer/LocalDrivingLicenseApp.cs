using DVLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLBusinessLayer
{
    public class clsLocalDrivingLicenseApp
    {
        public int LDLApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public static bool GetLocalDLAppInfoFromView(int LocalDrivingLicenseApplicationID,ref string ClassName,ref byte PassedTestCount)
        {
            return clsLocalDrivingLicenseAppData.GetLocalDLAppInfoFromView(LocalDrivingLicenseApplicationID,ref ClassName,ref PassedTestCount);
        }

        public static string ClassNameByLDLAppID(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseAppData.ClassNameByLDLAppID(LocalDrivingLicenseApplicationID); ;
        }

        public static int LicenseClassIDByLDLAppID(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseAppData.LicenseClassIDByLDLAppID(LocalDrivingLicenseApplicationID); ;
        }

        public static bool CheckIfStatusIsCompleted(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseAppData.CheckIfStatusIsCompleted(LocalDrivingLicenseApplicationID);
        }

        public static DataTable ListsLocalDrivingLicenseApps()
        {
            return clsLocalDrivingLicenseAppData.ListsLocalDrivingLicenseApps();
        }

        public static DataTable FilterByNationalNo(string NationalNo)
        {
            return clsLocalDrivingLicenseAppData.FilterByNationalNoLists(NationalNo);
        }

        public static DataTable FilterByLDLAppID(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseAppData.FilterByLDLAppID(LocalDrivingLicenseApplicationID);
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {
            return clsLocalDrivingLicenseAppData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static DataTable FilterByFullName(string FullName)
        {
            return clsLocalDrivingLicenseAppData.FilterByFullName(FullName);
        }

        public static DataTable FilterByStatus(string Status)
        {
            return clsLocalDrivingLicenseAppData.FilterByStatus(Status);
        }

        public static int CountRecords()
        {
            return clsLocalDrivingLicenseAppData.ListsLocalDrivingLicenseApps().Rows.Count;
        }

        private bool _AddNewLocalDrivingLicenseClass()
        {
            LDLApplicationID = clsLocalDrivingLicenseAppData.AddNewLocalDrivingLicenseApp(this.ApplicationID, this.LicenseClassID);
            return (LDLApplicationID != -1);
        }

        public bool Save()
        {
            return _AddNewLocalDrivingLicenseClass();
        }

        public static bool CheckIfPersonHasTheSameApp(string NationalNo, string ClassName)
        {
            return clsLocalDrivingLicenseAppData.CheckIfPersonHasTheSameApp(NationalNo, ClassName);
        }

        public static int GetApplicationIDFromLocalDLAppTable(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseAppData.GetApplicationIDFromLocalDLAppTable(LocalDrivingLicenseApplicationID);
        }

        public static bool CheckIfPersonCancelledApp(string NationalNo, string ClassName)
        {
            return clsLocalDrivingLicenseAppData.CheckIfPersonCancelledApp(NationalNo, ClassName) ;
        }

        public static bool CheckIfStatusNew(string NationalNo, string ClassName)
        {
            return clsLocalDrivingLicenseAppData.CheckIfStatusNew(NationalNo, ClassName) ;
        }

        public static bool DeleteLocalDLApplication(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseAppData.DeleteLocalDLApplication(LocalDrivingLicenseApplicationID );
        }

        public static int PassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseAppData.PassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public clsLocalDrivingLicenseApp()
        {
            this.LDLApplicationID = -1;
            this.ApplicationID = -1;
            this.LicenseClassID = -1;
        }

        private clsLocalDrivingLicenseApp(int ldlappid, int appid, int licenseclassid)
        {
            this.LDLApplicationID = ldlappid;
            this.ApplicationID = appid;
            this.LicenseClassID = licenseclassid;
        }


    }
}
