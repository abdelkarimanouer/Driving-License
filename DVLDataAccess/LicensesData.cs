using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDataAccess
{
    public class clsLicensesData
    {
        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate,
            string Notes, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int LicenseID = 0;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewLicense", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@DriverID", DriverID);
                        command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                        command.Parameters.AddWithValue("@IssueDate", IssueDate);
                        command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

                        if (Notes == "")
                        {
                            command.Parameters.AddWithValue("@Notes", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Notes", Notes);
                        }

                        command.Parameters.AddWithValue("@PaidFees", PaidFees);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@IssueReason", IssueReason);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


                        object Result = command.ExecuteScalar();

                        if (Result != null && Result != DBNull.Value)
                        {
                            LicenseID = Convert.ToInt32(Result);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return LicenseID;
        }

        public static DataTable GetLocalLicenseHistoryByPersonID(int ApplicantPersonID)
        {
            DataTable dtLicensehistory = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetLocalLicenseHistoryByPersonID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtLicensehistory.Load(reader);
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }

            return dtLicensehistory;
        }

        public static int GetApplicationIDFromLicenses(int LicenseID)
        {
            int ApplicationID = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetApplicationIDFromLicenses", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        public static int GetLicenseIDByAppID(int ApplicationID)
        {
            int LicenseID = 0;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetLicenseIDByAppID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                        object Result = command.ExecuteScalar();

                        if (Result != null && Result != DBNull.Value)
                        {
                            LicenseID = Convert.ToInt32(Result);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }


            return LicenseID;
        }

        public static bool DisableLicense(int LicenseID)
        {
            int RowEffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DisableLicense", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LicenseID", LicenseID);

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
    
    }
}
