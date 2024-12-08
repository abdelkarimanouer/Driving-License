using DVLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLBusinessLayer
{
    public class clsTestTypes
    {
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

        public bool UpdateTestType()
        {
            return clsTestTypesData.UpdateTestType(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
        }

        public static clsTestTypes FindTestType(int testtypeid)
        {
            string testtypetitle = string.Empty, testtypedesc = string.Empty;
            decimal testtypefees = 0;

            if (clsTestTypesData.GetTestType(testtypeid, ref testtypetitle, ref testtypedesc, ref testtypefees))
            {
                return new clsTestTypes(testtypeid, testtypetitle, testtypedesc, testtypefees);
            }
            else
            {
                return null;
            }

        }

        public static DataTable ListsTestTypes()
        {
            return clsTestTypesData.ListsTestTypes();
        }

        public static int CountTestTypes()
        {
            return clsTestTypesData.ListsTestTypes().Rows.Count;
        }

        private clsTestTypes(int testtype, string testtypetitle, string testtypedescription, decimal testtypefees)
        {
            this.TestTypeID = testtype;
            this.TestTypeTitle = testtypetitle;
            this.TestTypeDescription = testtypedescription;
            this.TestTypeFees = testtypefees;
        }
    
    }
}
