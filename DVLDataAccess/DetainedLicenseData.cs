using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDataAccess
{
    public class clsDetainedLicenseData
    {
        public static bool IsDetainedOrNot(int LicenseID)
        {
            bool IsDetained = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_IsDetainedOrNot", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LicenseID", LicenseID);

                        object Result = command.ExecuteScalar();

                        if (Result != null)
                        {
                            IsDetained = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.ToString());
                IsDetained = false;
            }

            return IsDetained;
        }

        public static int AddNewDetain(int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID = -1, int ReleaseApplicationID = -1)
        {
            int DetainID = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewDetain", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

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


                        object Result = command.ExecuteScalar();

                        if (Result != null)
                        {
                            DetainID = Convert.ToInt32(Result);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.ToString());
            }

            return DetainID;
        }

        public static bool GetDetainedInfo(int LicenseID, ref int DetainID, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID,
            ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool Found = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetDetainedInfo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Found = true;

                                DetainID = (int)reader["DetainID"];
                                DetainDate = (DateTime)reader["DetainDate"];
                                FineFees = Convert.ToDecimal(reader["FineFees"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                IsReleased = Convert.ToBoolean(reader["IsReleased"]);

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

        public static bool ReleaseDetainedLicense(int LicenseID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int RowEffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_ReleaseDetainedLicense", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        command.Parameters.AddWithValue("@IsReleased", IsReleased);
                        command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                        command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                        command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

                        RowEffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.ToString());
            }


            return (RowEffected > 0);
        }
    
        public static DataTable ListDetainedLicenses()
        {
            DataTable dtDetainedLicenses = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_ListDetainedLicenses", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtDetainedLicenses.Load(reader);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }

            return dtDetainedLicenses;
        }

    }
}
