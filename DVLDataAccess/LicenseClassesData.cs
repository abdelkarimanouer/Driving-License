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

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = "select * from LicenseClasses";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.HasRows)
                {
                    dtLicenseClasses.Load(reader);
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



            return dtLicenseClasses;
        }

        public static decimal ApplicationFees(string ClassName)
        {
            decimal Fees = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @" select ClassFees from LicenseClasses
                              where ClassName = @ClassName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    Fees = Convert.ToDecimal(Result);
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
            return Fees;
        }

        public static int GetLicenseClassID(string ClassName)
        {
            int LicenseClassID = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"select LicenseClassID from LicenseClasses where ClassName = @ClassName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    LicenseClassID = Convert.ToInt32(Result);
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
            return LicenseClassID;
        }

    }
}
