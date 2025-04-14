using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDataAccess
{
    public class clsLicenseClassesData
    {
        public static DataTable listOfLicenseClasses()
        {
            DataTable dtLicenseClasses = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_listOfLicenseClasses", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtLicenseClasses.Load(reader);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return dtLicenseClasses;
        }

        public static decimal GetApplicationFeesByClassName(string ClassName)
        {
            decimal Fees = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetApplicationFeesByClassName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@ClassName", SqlDbType.NVarChar).Value = ClassName;

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

        public static int GetLicenseClassIDByClassName(string ClassName)
        {
            int LicenseClassID = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetLicenseClassIDByClassName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@ClassName", SqlDbType.NVarChar).Value = ClassName;

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

    }
}
