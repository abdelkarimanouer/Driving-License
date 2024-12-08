using DVLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace DVLBusinessLayer
{
    public class clsTests
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        private bool _AddNewTest()
        {
            this.TestID = clsTestData.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);

            return ( TestID != -1 );
        }

        public bool Save()
        {
            return _AddNewTest();
        }

        public static bool FailedOrNot(int TestAppointmentID)
        {
            return clsTestData.FaildOrNot(TestAppointmentID);
        }
        
        public clsTests() 
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = string.Empty;
            this.CreatedByUserID = -1;
        }

        private clsTests(int testid, int testappointmentid, bool testresult, string notes, int createdbyuserid)
        {
            this.TestID = testid;
            this.TestAppointmentID = testappointmentid;
            this.TestResult = testresult;
            this.Notes = notes;
            this.CreatedByUserID = createdbyuserid;
        }

    }
}
