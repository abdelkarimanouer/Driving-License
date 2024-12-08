using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDataAccess
{
    public class clsTestData
    {
        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int ID = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"INSERT INTO Tests
                                    (TestAppointmentID, TestResult, Notes, CreatedByUserID )
                             VALUES
                                    (  @TestAppointmentID,  @TestResult,  @Notes,  @CreatedByUserID  )
                             select SCOPE_IDENTITY() ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            if (Notes == string.Empty)
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    ID = Convert.ToInt32(Result);
                }

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return ID;
        }

        public static bool FaildOrNot(int TestAppointmentID)
        {
            bool Faild = false;
            SqlConnection connection = new SqlConnection (clsConnectionSetting.connectionstring);

            string query = @"select Failed = 1 from Tests       where TestAppointmentID = @TestAppointmentID and TestResult = 0";

            SqlCommand command = new SqlCommand (query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);


            try
            {
                connection.Open ();
                object Result = command.ExecuteScalar();

                if (Result != null) 
                {
                    Faild = true;
                }
            }
            catch
            {
                Faild = false;
            }
            finally
            {
                connection.Close ();
            }

            return Faild;
        }

    }
}
