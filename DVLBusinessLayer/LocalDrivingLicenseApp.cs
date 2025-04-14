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
            return LocalDrivingLicenseAppData.GetLocalDLAppInfoFromView(LocalDrivingLicenseApplicationID,ref ClassName,ref PassedTestCount);
        }

        public static string ClassNameByLDLAppID(int LocalDrivingLicenseApplicationID)
        {
            return LocalDrivingLicenseAppData.ClassNameByLDLAppID(LocalDrivingLicenseApplicationID); ;
        }

        public static int LicenseClassIDByLDLAppID(int LocalDrivingLicenseApplicationID)
        {
            return LocalDrivingLicenseAppData.LicenseClassIDByLDLAppID(LocalDrivingLicenseApplicationID); ;
        }

        public static bool CheckIfStatusIsCompleted(int LocalDrivingLicenseApplicationID)
        {
            return LocalDrivingLicenseAppData.CheckIfStatusIsCompleted(LocalDrivingLicenseApplicationID);
        }

        public static DataTable ListsLocalDrivingLicenseApps()
        {
            return LocalDrivingLicenseAppData.ListsLocalDrivingLicenseApps();
        }

        public static DataTable FilterByNationalNo(string NationalNo)
        {
            return LocalDrivingLicenseAppData.FilterByNationalNoLists(NationalNo);
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {
            return LocalDrivingLicenseAppData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static DataTable FilterByFullName(string FullName)
        {
            return LocalDrivingLicenseAppData.FilterByFullName(FullName);
        }

        public static int CountRecords()
        {
            return LocalDrivingLicenseAppData.ListsLocalDrivingLicenseApps().Rows.Count;
        }

        private bool _AddNewLocalDrivingLicenseClass()
        {
            LDLApplicationID = LocalDrivingLicenseAppData.AddNewLocalDrivingLicenseApp(this.ApplicationID, this.LicenseClassID);
            return (LDLApplicationID != -1);
        }

        public bool Save()
        {
            return _AddNewLocalDrivingLicenseClass();
        }

        public static bool CheckIfPersonHasTheSameApp(string NationalNo, string ClassName)
        {
            return LocalDrivingLicenseAppData.CheckIfPersonHasTheSameApp(NationalNo, ClassName);
        }

        public static int GetApplicationIDFromLocalDLAppTable(int LocalDrivingLicenseApplicationID)
        {
            return LocalDrivingLicenseAppData.GetApplicationIDFromLocalDLAppTable(LocalDrivingLicenseApplicationID);
        }

        public static bool CheckIfPersonCancelledApp(string NationalNo, string ClassName)
        {
            return LocalDrivingLicenseAppData.CheckIfPersonCancelledApp(NationalNo, ClassName) ;
        }

        public static bool CheckIfStatusNew(string NationalNo, string ClassName)
        {
            return LocalDrivingLicenseAppData.CheckIfStatusNew(NationalNo, ClassName) ;
        }

        public static bool DeleteLocalDLApplication(int LocalDrivingLicenseApplicationID)
        {
            return LocalDrivingLicenseAppData.DeleteLocalDLApplication(LocalDrivingLicenseApplicationID );
        }

        public static int PassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return LocalDrivingLicenseAppData.PassedTestCount(LocalDrivingLicenseApplicationID);
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
