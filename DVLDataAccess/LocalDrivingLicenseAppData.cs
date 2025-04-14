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
    public class LocalDrivingLicenseAppData
    {
        public static bool GetLocalDLAppInfoFromView(int LocalDrivingLicenseApplicationID, ref string ClassName, ref byte PassedTestCount)
        {
            bool Found = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetLocalDLAppInfoFromView", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Found = true;

                                ClassName = (string)reader["ClassName"];
                                PassedTestCount = (byte)reader["PassedTestCount"];

                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
                Found = false;
            }

            return Found;
        }

        public static string ClassNameByLDLAppID(int LocalDrivingLicenseApplicationID)
        {
            string ClassName = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetClassNameByLDLAppID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ClassName = (string)reader["ClassName"];
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return ClassName;
        }

        public static int LicenseClassIDByLDLAppID(int LocalDrivingLicenseApplicationID)
        {
            int LicenseClassID = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_LicenseClassIDByLDLAppID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                        object Result = command.ExecuteScalar();

                        if (Result != null && Result != DBNull.Value)
                        {
                            LicenseClassID = Convert.ToInt32(Result);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return LicenseClassID;
        }

        public static bool CheckIfStatusIsCompleted(int LocalDrivingLicenseApplicationID)
        {
            bool Status = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_CheckIfStatusIsCompleted", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                        object Result = command.ExecuteScalar();

                        if (Result != null && Result != DBNull.Value)
                        {
                            Status = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
                Status = false;
            }

            return Status;
        }

        public static DataTable ListsLocalDrivingLicenseApps()
        {
            DataTable dtLDLicenseApp = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_ListsLocalDrivingLicenseApps", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtLDLicenseApp.Load(reader);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }

            return dtLDLicenseApp;
        }

        public static DataTable FilterByNationalNoLists(string NationalNo)
        {
            DataTable dtLDLicenseApp = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_FilterByNationalNoLists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@NationalNo", NationalNo);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtLDLicenseApp.Load(reader);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }

            return dtLDLicenseApp;
        }

        public static DataTable FilterByFullName(string FullName)
        {
            DataTable dtLDLicenseApp = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_FilterByFullName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@FullName", FullName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtLDLicenseApp.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }

            return dtLDLicenseApp;
        }

        public static int AddNewLocalDrivingLicenseApp(int ApplicationID, int LicenseClassID)
        {
            int LastID = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewLocalDrivingLicenseApp", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                        object Result = command.ExecuteScalar();

                        if (Result != null && Result != DBNull.Value)
                        {
                            LastID = Convert.ToInt32(Result);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }


            return LastID;
        }

        public static bool CheckIfPersonHasTheSameApp(string NationalNo, string ClassName)
        {
            bool Found = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_CheckIfPersonHasTheSameApp", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        command.Parameters.AddWithValue("@ClassName", ClassName);

                        object Result = command.ExecuteScalar();

                        if (Result != null && Result != DBNull.Value)
                        {
                            Found = true;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
                Found = false;
            }

            return Found;
        }

        public static int GetApplicationIDFromLocalDLAppTable(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetApplicationIDFromLocalDLAppTable", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                        object Result = command.ExecuteScalar();

                        if (Result != null && Result != DBNull.Value)
                        {
                            ApplicationID = Convert.ToInt32(Result);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }

            return ApplicationID;
        }

        public static bool CheckIfPersonCancelledApp(string NationalNo, string ClassName)
        {
            bool Found = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_CheckIfPersonCancelledApp", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        command.Parameters.AddWithValue("@ClassName", ClassName);

                        object Result = command.ExecuteScalar();

                        if (Result != null && Result != DBNull.Value)
                        {
                            Found = true;
                        }
                        else
                        {
                            Found = false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
                Found = false;
            }

            return Found;
        }

        public static bool CheckIfStatusNew(string NationalNo, string ClassName)
        {
            bool Found = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_CheckIfStatusNew", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        command.Parameters.AddWithValue("@ClassName", ClassName);

                        object Result = command.ExecuteScalar();

                        if (Result != null && Result != DBNull.Value)
                        {
                            Found = true;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
                Found = false;
            }

            return Found;
        }

        public static bool DeleteLocalDLApplication(int LocalDrivingLicenseApplicationID)
        {
            int RowEffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DeleteLocalDLApplication", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                        RowEffected = command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }


            return (RowEffected > 0);
        }

        public static int PassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            int PassedCount = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_PassedTestCount", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                        object Result = command.ExecuteScalar();

                        if (Result != null && Result != DBNull.Value)
                        {
                            PassedCount = Convert.ToInt32(Result);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }

            return PassedCount;
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsActive = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_IsThereAnActiveScheduledTest", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                        object Result = command.ExecuteScalar();

                        if (Result != null && Result != DBNull.Value)
                        {
                            IsActive = true;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }

            return IsActive;
        }

    }
}
