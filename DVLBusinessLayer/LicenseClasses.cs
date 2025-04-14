using DVLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLBusinessLayer
{
    public class LicenseClasses
    {
        public static DataTable ListsOfLicenseClasses()
        {
            return clsLicenseClassesData.listOfLicenseClasses();
        }

        public static decimal ApplicationFees(string ClassName)
        {
            return clsLicenseClassesData.GetApplicationFeesByClassName(ClassName);
        }

        public static int GetLicenseClassID(string ClassName)
        {
            return clsLicenseClassesData.GetLicenseClassIDByClassName(ClassName);
        }
    }
}
