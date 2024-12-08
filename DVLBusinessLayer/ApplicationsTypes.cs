using DVLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLBusinessLayer
{
    public class clsApplicationsTypes
    {
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }



        public static clsApplicationsTypes FindApplicationTypeByID(int ApplicationTypeID)
        {
            string applicationtypetitle = null;
            decimal applicationfees = 0;

            if (clsApplicationsTypeData.GetApplicationType(ApplicationTypeID, ref applicationtypetitle, ref applicationfees))
            {
                return new clsApplicationsTypes(ApplicationTypeID, applicationtypetitle, applicationfees);
            }
            else 
            {
                return null;
            }
        }

        public static decimal GetApplicationFee(int ApplicationTypeID)
        {
            return clsApplicationsTypeData.GetApplicationFee(ApplicationTypeID);
        }

        public bool UpdateApplicationType()
        {
            return clsApplicationsTypeData.UpdateApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
        }

        public static DataTable GetApplicationsTypes()
        {
            return clsApplicationsTypeData.ListsApplicationsTypes();
        }

        public static int CountApplicationsTypes()
        {
            return clsApplicationsTypeData.ListsApplicationsTypes().Rows.Count;

        }
    
        private clsApplicationsTypes(int applicationTypeID, string applicationTypeTitle, decimal applicationFees)
        {
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationTypeTitle = applicationTypeTitle;
            this.ApplicationFees = applicationFees;
        }
    }
}
