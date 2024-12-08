using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDataAccess
{
    public class clsApplicationsTypeData
    {
        public static bool GetApplicationType(int ApplicationTypeID, ref string ApplicationTypeTitle, ref decimal ApplicationFees)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"Select * from ApplicationTypes
                             WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;
                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees = (decimal)reader["ApplicationFees"];
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                Found = false;
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }

        public static DataTable ListsApplicationsTypes()
        {
            DataTable dtApplicationsTypes = new DataTable();

            SqlConnection connection = new SqlConnection( clsConnectionSetting.connectionstring );
            string query = "select * from ApplicationTypes";

            SqlCommand command = new SqlCommand( query, connection );

            try
            {
                connection.Open(); 
                
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtApplicationsTypes.Load( reader );
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally 
            {
                connection.Close();
            }

            return dtApplicationsTypes;
        }

        public static bool UpdateApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            int RowEffected = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"UPDATE ApplicationTypes
                               SET 
                                  ApplicationTypeTitle = @ApplicationTypeTitle
                                 ,ApplicationFees = @ApplicationFees
                             WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);


            try
            {
                connection.Open();

                RowEffected = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                connection.Close();
            }

            return (RowEffected > 0);
        }

        public static decimal GetApplicationFee(int ApplicationTypeID) 
        {
            decimal Fees = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @" select ApplicationFees from ApplicationTypes
                              where ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    Fees = Convert.ToDecimal(Result);
                }


            }
            catch
            { 

            }
            finally
            {
                connection.Close();
            }
            return Fees;
        }

    }
}
