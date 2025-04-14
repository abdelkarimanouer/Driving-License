using System;
using System.Collections.Generic;
using System.Data;
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

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewTest", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

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


                        object Result = command.ExecuteScalar();

                        if (Result != null && Result != DBNull.Value)
                        {
                            ID = Convert.ToInt32(Result);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }

            return ID;
        }

    }
}
