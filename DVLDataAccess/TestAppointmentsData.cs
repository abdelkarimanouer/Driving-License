using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDataAccess
{
    public class clsTestAppointmentsData
    {
        public static DataTable ListsAppointments(int TestTypeID)
        {
            DataTable dtAppointments = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_ListsAppointments", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtAppointments.Load(reader);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }


            return dtAppointments;
        }

        public static bool GetAppointmentDetails(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate, ref decimal PaidFees,
     ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool Found = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAppointmentDetails", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Found = true;

                                TestTypeID = (int)reader["TestTypeID"];
                                LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                AppointmentDate = (DateTime)reader["AppointmentDate"];
                                PaidFees = (decimal)reader["PaidFees"];
                                IsLocked = (bool)reader["IsLocked"];

                                if (reader["RetakeTestApplicationID"] == DBNull.Value)
                                    RetakeTestApplicationID = -1;
                                else
                                    RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
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

        public static int AddNewAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees,
            int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID = -1)
        {
            int ID = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewAppointment", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                        command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                        command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                        command.Parameters.AddWithValue("@PaidFees", PaidFees);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue("@IsLocked", IsLocked);

                        if (RetakeTestApplicationID == -1)
                            command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

                        connection.Open();
                        object Result = command.ExecuteScalar();

                        if (Result != null && Result != DBNull.Value)
                            ID = Convert.ToInt32(Result);
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return ID;
        }

        public static bool UpdateAppointment(int TestAppointmentID, DateTime AppointmentDate, bool IsLocked)
        {
            int RowEffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateAppointment", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                        command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                        command.Parameters.AddWithValue("@IsLocked", IsLocked);

                        connection.Open();
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
