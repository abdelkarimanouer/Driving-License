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

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetApplicationType", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Found = true;
                                ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                                ApplicationFees = (decimal)reader["ApplicationFees"];
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

        public static DataTable ListsApplicationsTypes()
        {
            DataTable dtApplicationsTypes = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_ListsApplicationsTypes", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtApplicationsTypes.Load(reader);
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return dtApplicationsTypes;
        }

        public static bool UpdateApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            int RowEffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdateApplicationType", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                        command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
                        command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

                        RowEffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.ToString() );

            }

            return (RowEffected > 0);
        }

        public static decimal GetApplicationFee(int ApplicationTypeID) 
        {
            decimal Fees = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetApplicationFee", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                        object Result = command.ExecuteScalar();

                        if (Result != null && Result != DBNull.Value)
                        {
                            Fees = Convert.ToDecimal(Result);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }


            return Fees;
        }

    }
}
