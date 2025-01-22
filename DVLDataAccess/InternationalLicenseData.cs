using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDataAccess
{
    public class clsInternationalLicenseData
    {
        public static DataTable ListsInternationalLicenses()
        {
            DataTable dtInternational = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = "SELECT InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID as LocallicenseID, IssueDate, ExpirationDate, IsActive     FROM     InternationalLicenses";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) 
                {
                    dtInternational.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }
            finally { connection.Close(); }

            return dtInternational;


        }

        public static DataTable ListsInternationalLicensesByPersonID(int ApplicantPersonID)
        {
            DataTable dtInternational = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"SELECT InternationalLicenseID, ApplicationID, IssuedUsingLocalLicenseID as LocallicenseID, IssueDate, ExpirationDate, IsActive     FROM     InternationalLicenses
                              where ApplicationID in (SELECT Applications.ApplicationID
                                    FROM     Applications INNER JOIN
                                             InternationalLicenses ON Applications.ApplicationID = InternationalLicenses.ApplicationID
                                                      where ApplicantPersonID = @ApplicantPersonID)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtInternational.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }
            finally { connection.Close(); }

            return dtInternational;


        }

        public static bool GetInternationalLicenseInfo(int InternationalLicenseID, ref int ApplicationID, ref int DriverID, ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = "select * from InternationalLicenses      where InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand (query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                }
                else
                {
                    Found = false;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
                Found = false;
            }
            finally
            {
                connection.Close();
            }


            return Found;
        }

        public static int AddNewInternationalLicenseApp(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int ID = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"INSERT INTO [dbo].[InternationalLicenses]
                                   ( [ApplicationID], [DriverID], [IssuedUsingLocalLicenseID], [IssueDate], [ExpirationDate], [IsActive], [CreatedByUserID] )
                             VALUES
                                   ( @ApplicationID, @DriverID, @IssuedUsingLocalLicenseID,@IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID )
                             select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null) 
                {
                    ID = Convert.ToInt32(Result);
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }
            finally
            {
                connection.Close();
            }


            return ID;
        }

        public static bool CheckifInternationalLicenseAlreadyExistByLicenseID(int IssuedUsingLocalLicenseID)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"select found = 1 from InternationalLicenses    where IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    Found = true;
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
                Found = false;
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }

        public static int GetApplicationIDByInternationalLicenseID(int InternationalLicenseID)
        {
            int ApplicationID = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @" select ApplicationID from InternationalLicenses    where InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(@query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);


            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    ApplicationID = Convert.ToInt32(Result);
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }
            finally
            {
                connection.Close();
            }


            return ApplicationID;
        }

        public static bool UpdateLocalLicenseID(int OldLicenseID, int NewLicenseID)
        {
            int RowEffected = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"update InternationalLicenses   set IssuedUsingLocalLicenseID = @NewLicenseID
                                where IssuedUsingLocalLicenseID = @OldLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OldLicenseID", OldLicenseID);
            command.Parameters.AddWithValue("@NewLicenseID", NewLicenseID);

            try
            {
                connection.Open();

                RowEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }
            finally
            {
                connection.Close();
            }

            return (RowEffected > 0);
        }


        public static int GetApplicationIDByLocalLicenseID(int IssuedUsingLocalLicenseID)
        {
            int ApplicationID = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @" select ApplicationID from InternationalLicenses    where IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID";

            SqlCommand command = new SqlCommand(@query, connection);

            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);


            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    ApplicationID = Convert.ToInt32(Result);
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }
            finally
            {
                connection.Close();
            }


            return ApplicationID;
        }

    }
}
