using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDataAccess
{
    public class clsDetainedLicenseData
    {
        public static bool IsDetainedOrNot(int LicenseID)
        {
            bool IsDetained = false;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"select Found = 1 from DetainedLicenses   where LicenseID = @LicenseID and IsReleased = 0";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    IsDetained = true;
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
                IsDetained = false;
            }
            finally
            {
                connection.Close();
            }

            return IsDetained;
        }

        public static int AddNewDetain(int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID = -1, int ReleaseApplicationID = -1)
        {
            int DetainID = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"INSERT INTO [dbo].[DetainedLicenses]
                                     ( [LicenseID], [DetainDate], [FineFees], [CreatedByUserID], [IsReleased], [ReleaseDate], [ReleasedByUserID], [ReleaseApplicationID] )
                             VALUES
                                     (  @LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID  )
                            select SCOPE_IDENTITY() ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);


            if (ReleaseDate == DateTime.MinValue)
            {
                command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            }

            if (ReleasedByUserID == -1)
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            }

            if (ReleaseApplicationID == -1)
            {
                command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            }


            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    DetainID = Convert.ToInt32(Result);
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }
            finally { connection.Close(); }



            return DetainID;
        }

        public static bool GetDetainedInfo(int LicenseID, ref int DetainID, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID,
            ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = "select * from DetainedLicenses    where LicenseID = @LicenseID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;

                    DetainID = (int) reader["DetainID"];
                    DetainDate = (DateTime) reader["DetainDate"];
                    FineFees = Convert.ToDecimal( reader["FineFees"] );
                    CreatedByUserID = (int) reader["CreatedByUserID"];
                    IsReleased = Convert.ToBoolean( reader["IsReleased"] );

                    if (reader["ReleaseDate"] == DBNull.Value)
                    {
                        ReleaseDate = DateTime.MinValue;
                    }
                    else
                    {
                        ReleaseDate = (DateTime)reader["ReleaseDate"];
                    }

                    if (reader["ReleasedByUserID"] == DBNull.Value)
                    {
                        ReleasedByUserID = -1;
                    }
                    else
                    {
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];
                    }

                    if (reader["ReleaseApplicationID"] == DBNull.Value)
                    {
                        ReleaseApplicationID = -1;
                    }
                    else
                    {
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];
                    }

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

        public static bool ReleaseDetainedLicense(int LicenseID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int RowEffected = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"update DetainedLicenses
                             set  IsReleased = @IsReleased, ReleaseDate = @ReleaseDate, ReleasedByUserID = @ReleasedByUserID, ReleaseApplicationID = @ReleaseApplicationID
                             where  LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);


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
    
        public static DataTable ListDetainedLicenses()
        {
            DataTable dtDetainedLicenses = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @" SELECT DetainedLicenses.DetainID, DetainedLicenses.LicenseID, DetainedLicenses.DetainDate, DetainedLicenses.IsReleased, DetainedLicenses.FineFees, DetainedLicenses.ReleaseDate, People.NationalNo, 
                              People.FirstName + ' ' + ISNULL(People.SecondName, '') + ' ' + ISNULL(People.ThirdName, '') + ' ' + People.LastName as FullName , DetainedLicenses.ReleaseApplicationID as ReleaseAppID
                               FROM     Applications INNER JOIN
                               DetainedLicenses ON Applications.ApplicationID = DetainedLicenses.ReleaseApplicationID INNER JOIN
                               People ON Applications.ApplicantPersonID = People.PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtDetainedLicenses.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }
            finally
            {
                connection.Close();
            }

            return dtDetainedLicenses;
        }

    }
}
