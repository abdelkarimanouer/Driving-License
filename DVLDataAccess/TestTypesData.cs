using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDataAccess
{
    public class clsTestTypesData
    {
        public static bool GetTestType(int TestTypeID, ref string TestTypeTitle, ref string TestTypeDescription, ref decimal TestTypeFees)
        {
            bool Found = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetTestType", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Found = true;
                                TestTypeTitle = (string)reader["TestTypeTitle"];
                                TestTypeDescription = (string)reader["TestTypeDescription"];
                                TestTypeFees = (decimal)reader["TestTypeFees"];
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

        public static DataTable ListsTestTypes()
        {
            DataTable dtTestTypes = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_ListsTestTypes", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.HasRows)
                            {
                                dtTestTypes.Load(reader);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }

            return dtTestTypes;
        }

        public static bool UpdateTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            int RowEffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdateTestType", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                        command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
                        command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
                        command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);


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
