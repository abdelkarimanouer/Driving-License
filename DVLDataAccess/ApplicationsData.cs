using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDataAccess
{
    public class clsApplicationsData
    {
        public static bool GetApplicationInfo(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID,
                              ref byte ApplicationStatus, ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = "Select * from Applications Where ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;

                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
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

        public static int AddNewApplication(int PersonID, DateTime ApplicationDate, int ApplicationTypeID, byte ApplicationStatus,
                                                DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int LastID = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"INSERT INTO Applications
                             VALUES
	                               (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus,
                                         @LastStatusDate, @PaidFees, @CreatedByUserID);
                             select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(@query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    LastID = Convert.ToInt32( Result );
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

        public static bool CancelApplication(int ApplicationID)
        {
            int RowEffected = 0;
            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"update Applications
                                 set ApplicationStatus = 2 
                                 where ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(@query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);


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

        public static bool CompleteTestsApplication(int ApplicationID)
        {
            int RowEffected = 0;
            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"update Applications
                                 set ApplicationStatus = 3
                                 where ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(@query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);


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


        public static bool DeleteApplication(int ApplicationID)
        {
            int RowEffected = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = "delete from Applications    where ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

    }
}
