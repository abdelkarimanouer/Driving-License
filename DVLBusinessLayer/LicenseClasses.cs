using DVLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLBusinessLayer
{
    public class clsLicenseClasses
    {
        public static DataTable ListsOfLicenseClasses()
        {
            return clsLicenseClassesData.listOfLicenseClasses();
        }

        public static decimal ApplicationFees(string ClassName)
        {
            return clsLicenseClassesData.ApplicationFees(ClassName);
        }

        public static int GetLicenseClassID(string ClassName)
        {
            return clsLicenseClassesData.GetLicenseClassID(ClassName);
        }
    }
}
