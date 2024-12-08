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

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"INSERT INTO [dbo].[Licenses]
                                        ([ApplicationID], [DriverID], [LicenseClass], [IssueDate], [ExpirationDate], [Notes], [PaidFees], [IsActive], [IssueReason], [CreatedByUserID])
                                  VALUES
                                        (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID)
                             select SCOPE_IDENTITY(); ";

            SqlCommand command = new SqlCommand (query, connection);

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

            try
            {
                connection.Open ();

                object Result = command.ExecuteScalar();

                if (Result != null) 
                {
                    LicenseID = Convert.ToInt32( Result);
                }

            }
            catch { }
            finally { connection.Close(); }



            return LicenseID;
        }

        public static DataTable GetLocalLicenseHistoryByPersonID(int ApplicantPersonID)
        {
            DataTable dtLicensehistory = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"select LicenseID,ApplicationID, LicenseClass, IssueDate, ExpirationDate, IsActive from Licenses 
                                 where LicenseID in (select LicenseID from Licenses
                                        where ApplicationID in (select ApplicationID from Applications
                                               where ApplicantPersonID = @ApplicantPersonID))";

            SqlCommand command = new SqlCommand (query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                { 
                    dtLicensehistory.Load(reader);
                }
                reader.Close();
            }
            catch
            {
                
            }
            finally
            { connection.Close(); }

            return dtLicensehistory;
        }

        public static int GetApplicationIDFromLicenses(int LicenseID)
        {
            int ApplicationID = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"select ApplicationID from Licenses   where LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(@query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        public static int GetLicenseIDByAppID(int ApplicationID)
        {
            int LicenseID = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"select LicenseID from Licenses    where ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(@query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    LicenseID = Convert.ToInt32(Result);
                }

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }


            return LicenseID;
        }

        public static bool DisableLicense(int LicenseID)
        {
            int RowEffected = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"update Licenses  set IsActive = 0  where LicenseID = @LicenseID";
            
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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
                connection.Close() ;
            }

            return (RowEffected > 0);
        }
    
    }
}
