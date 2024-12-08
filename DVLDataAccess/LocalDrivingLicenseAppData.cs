using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDataAccess
{
    public class clsLocalDrivingLicenseAppData
    {
        public static bool GetLocalDLAppInfoFromView(int LocalDrivingLicenseApplicationID, ref string ClassName, ref byte PassedTestCount)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"select * from LocalDrivingLicenseApplications_View
                                 where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;

                    ClassName = (string)reader["ClassName"];
                    PassedTestCount = (byte)reader["PassedTestCount"];

                }
                reader.Close();
            }
            catch
            {
                Found = false;
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }

        public static string ClassNameByLDLAppID(int LocalDrivingLicenseApplicationID)
        {
            string ClassName = string.Empty;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"select ClassName from LocalDrivingLicenseApplications_View
                                 where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ClassName = (string)reader["ClassName"];

                }
                reader.Close();
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }

            return ClassName;
        }

        public static int LicenseClassIDByLDLAppID(int LocalDrivingLicenseApplicationID)
        {
            int LicenseClassID = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"select LicenseClassID from LocalDrivingLicenseApplications
                            where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    LicenseClassID = Convert.ToInt32( Result );
                }

            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }

            return LicenseClassID;
        }

        public static bool CheckIfStatusIsCompleted(int LocalDrivingLicenseApplicationID)
        {
            bool Status = false;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"select Status = 'Completed' from LocalDrivingLicenseApplications_View
                             where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and Status = 'Completed'";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    Status = true;
                }

            }
            catch
            {
                Status = false;
            }
            finally
            {
                connection.Close();
            }

            return Status;
        }

        public static DataTable ListsLocalDrivingLicenseApps()
        {
            DataTable dtLDLicenseApp = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = "select * from LocalDrivingLicenseApplications_View";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtLDLicenseApp.Load(reader);
                }

                reader.Close();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }


            return dtLDLicenseApp;
        }

        public static DataTable FilterByNationalNoLists(string NationalNo)
        {
            DataTable dtLDLicenseApp = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"select * from LocalDrivingLicenseApplications_View
                                  where NationalNo LIKE '' + @NationalNo +'%' ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtLDLicenseApp.Load(reader);
                }

                reader.Close();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }


            return dtLDLicenseApp;
        }

        public static DataTable FilterByLDLAppID(int LocalDrivingLicenseApplicationID)
        {
            DataTable dtLDLicenseApp = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"select * from LocalDrivingLicenseApplications_View
                                  where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtLDLicenseApp.Load(reader);
                }

                reader.Close();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }


            return dtLDLicenseApp;
        }

        public static DataTable FilterByFullName(string FullName)
        {
            DataTable dtLDLicenseApp = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"select * from LocalDrivingLicenseApplications_View
                                  where FullName LIKE '' + @FullName +'%' ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FullName", FullName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtLDLicenseApp.Load(reader);
                }

                reader.Close();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }


            return dtLDLicenseApp;
        }

        public static DataTable FilterByStatus(string Status)
        {
            DataTable dtLDLicenseApp = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"select * from LocalDrivingLicenseApplications_View
                                  where Status LIKE '' + @Status +'%' ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Status", Status);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtLDLicenseApp.Load(reader);
                }

                reader.Close();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }


            return dtLDLicenseApp;
        }

        public static int AddNewLocalDrivingLicenseApp(int ApplicationID, int LicenseClassID)
        {
            int LastID = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"INSERT INTO LocalDrivingLicenseApplications
                             VALUES
	                               (@ApplicationID, @LicenseClassID);
                             select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(@query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    LastID = Convert.ToInt32(Result);
                }

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }


            return LastID;
        }

        public static bool CheckIfPersonHasTheSameApp(string NationalNo, string ClassName)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"select Found = 1 from LocalDrivingLicenseApplications_View
                                where (NationalNo = @NationalNo and ClassName = @ClassName)";

            SqlCommand command = new SqlCommand(@query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    Found = true;
                }

            }
            catch
            {
                Found = false;
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }

        public static int GetApplicationIDFromLocalDLAppTable(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"SELECT LocalDrivingLicenseApplications.ApplicationID
                                FROM  LocalDrivingLicenseApplications
                             where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(@query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    ApplicationID = Convert.ToInt32(Result);
                }

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }


            return ApplicationID;
        }

        public static bool CheckIfPersonCancelledApp(string NationalNo, string ClassName)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"select Found = 1 from LocalDrivingLicenseApplications_View
                                where (NationalNo = @NationalNo and ClassName = @ClassName) and ( Status = 'Cancelled' )";

            SqlCommand command = new SqlCommand(@query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    Found = true;
                }

            }
            catch
            {
                Found = false;
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }

        public static bool CheckIfStatusNew(string NationalNo, string ClassName)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"select Found = 1 from LocalDrivingLicenseApplications_View
                                where (NationalNo = @NationalNo and ClassName = @ClassName) and ( Status = 'New' )";

            SqlCommand command = new SqlCommand(@query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    Found = true;
                }

            }
            catch
            {
                Found = false;
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }

        public static bool DeleteLocalDLApplication(int LocalDrivingLicenseApplicationID)
        {
            int RowEffected = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"  delete from Tests where TestAppointmentID in ( select TestAppointmentID from TestAppointments where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)
                               delete from TestAppointments    where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                               delete from LocalDrivingLicenseApplications    where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                RowEffected = command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }


            return (RowEffected > 0);
        }

        public static int PassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            int PassedCount = -1;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = "select PassedTestCount from LocalDrivingLicenseApplications_View     where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                
                object Result = command.ExecuteScalar();

                if (Result != null) 
                {
                    PassedCount = Convert.ToInt32(Result);
                }

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }


            return PassedCount;
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {

            bool Result = false;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)  
                            AND(TestAppointments.TestTypeID = @TestTypeID) and isLocked=0
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null)
                {
                    Result = true;
                }

            }

            catch
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return Result;
        }

    }
}
