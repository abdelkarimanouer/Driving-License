using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Net;
using System.Security.Policy;

namespace DVLDataAccess
{
    public class clsPeopleData
    {
        public static bool GetPersonByPersonID(int ID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref string Gendor, ref string Address,
        ref string Phone, ref string Email, ref int CountryID, ref string ImagePath)
        {
            bool Found = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetPersonByPersonID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID", ID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Found = true;
                                NationalNo = reader["NationalNo"] as string;
                                FirstName = reader["FirstName"] as string;
                                SecondName = reader["SecondName"] == DBNull.Value ? "" : reader["SecondName"] as string;
                                ThirdName = reader["ThirdName"] == DBNull.Value ? "" : reader["ThirdName"] as string;
                                LastName = reader["LastName"] as string;
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Gendor = reader["Gendor"] as string;
                                Address = reader["Address"] as string;
                                Phone = reader["Phone"] as string;
                                Email = reader["Email"] == DBNull.Value ? "" : reader["Email"] as string;
                                CountryID = (int)reader["NationalityCountryID"];
                                ImagePath = reader["ImagePath"] == DBNull.Value ? "" : reader["ImagePath"] as string;
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

        public static bool GetPersonByNationalNo(string NationalNo, ref int ID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref string Gendor, ref string Address,
            ref string Phone, ref string Email, ref int CountryID, ref string ImagePath)
        {
            bool Found = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetPersonByNationalNo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@NNo", NationalNo);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Found = true;
                                ID = (int)reader["PersonID"];
                                FirstName = reader["FirstName"] as string;
                                SecondName = reader["SecondName"] == DBNull.Value ? "" : reader["SecondName"] as string;
                                ThirdName = reader["ThirdName"] == DBNull.Value ? "" : reader["ThirdName"] as string;
                                LastName = reader["LastName"] as string;
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Gendor = reader["Gendor"] as string;
                                Address = reader["Address"] as string;
                                Phone = reader["Phone"] as string;
                                Email = reader["Email"] == DBNull.Value ? "" : reader["Email"] as string;
                                CountryID = (int)reader["NationalityCountryID"];
                                ImagePath = reader["ImagePath"] == DBNull.Value ? "" : reader["ImagePath"] as string;
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

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, string Gendor, string Address,
            string Phone, string Email, int NationalCountryID, string ImagePath)
        {
            int IDPerson = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewPerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@NNo", NationalNo);
                        command.Parameters.AddWithValue("@FName", FirstName);
                        command.Parameters.AddWithValue("@SName", string.IsNullOrEmpty(SecondName) ? DBNull.Value : (object)SecondName);
                        command.Parameters.AddWithValue("@TName", string.IsNullOrEmpty(ThirdName) ? DBNull.Value : (object)ThirdName);
                        command.Parameters.AddWithValue("@LName", LastName);
                        command.Parameters.AddWithValue("@DOfB", DateOfBirth);
                        command.Parameters.AddWithValue("@Gend", Gendor);
                        command.Parameters.AddWithValue("@Addr", Address);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? DBNull.Value : (object)Email);
                        command.Parameters.AddWithValue("@CID", NationalCountryID);
                        command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? DBNull.Value : (object)ImagePath);

                        connection.Open();

                        object Result = command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int Identity))
                        {
                            IDPerson = Identity;
                        }
                    }
                        
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
                IDPerson = -1;
            }

            return IDPerson;
        }

        public static bool UpdatePerson(int ID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, string Gendor, string Address,
            string Phone, string Email, int NationalCountryID, string ImagePath)
        {
            int RowEffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdatePerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ID", ID);
                        command.Parameters.AddWithValue("@NNo", NationalNo);
                        command.Parameters.AddWithValue("@FName", FirstName);
                        command.Parameters.AddWithValue("@SName", string.IsNullOrEmpty(SecondName) ? DBNull.Value : (object)SecondName);
                        command.Parameters.AddWithValue("@TName", string.IsNullOrEmpty(ThirdName) ? DBNull.Value : (object)ThirdName);
                        command.Parameters.AddWithValue("@LName", LastName);
                        command.Parameters.AddWithValue("@DOfB", DateOfBirth);
                        command.Parameters.AddWithValue("@Gend", Gendor);
                        command.Parameters.AddWithValue("@Addr", Address);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? DBNull.Value : (object)Email);
                        command.Parameters.AddWithValue("@CID", NationalCountryID);
                        command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? DBNull.Value : (object)ImagePath);

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

        public static bool DeletePeople(int ID)
        {
            int RowEffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    SqlCommand command = new SqlCommand("SP_DeletePeople", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", ID);

                    connection.Open();

                    RowEffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return (RowEffected > 0);
        }

        public static DataTable ListsPeople()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    SqlCommand command = new SqlCommand("SP_ListsPeople", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return dt;
        }
        public static DataTable FilterPersonsByPersonID(int PersonID)
        {
            DataTable dtPeople = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    SqlCommand command = new SqlCommand("SP_FilterPersonsByPersonID", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dtPeople.Load(reader);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return dtPeople;
        }

        public static DataTable FilterPersonsByNationalNo(string NationalNo)
        {
            DataTable dtPeople = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    SqlCommand command = new SqlCommand("SP_FilterPersonsByNationalNo", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dtPeople.Load(reader);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return dtPeople;
        }

        public static DataTable FilterPersonsByFirstName(string FirstName)
        {
            DataTable dtPeople = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    SqlCommand command = new SqlCommand("SP_FilterPersonsByFirstName", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", FirstName);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dtPeople.Load(reader);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return dtPeople;
        }

        public static DataTable FilterPersonsBySecondName(string SecondName)
        {
            DataTable dtPeople = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    SqlCommand command = new SqlCommand("SP_FilterPersonsBySecondName", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SecondName", SecondName);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dtPeople.Load(reader);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return dtPeople;
        }

        public static DataTable FilterPersonsByThirdName(string ThirdName)
        {
            DataTable dtPeople = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    SqlCommand command = new SqlCommand("SP_FilterPersonsByThirdName", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ThirdName", ThirdName);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dtPeople.Load(reader);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return dtPeople;
        }

        public static DataTable FilterPersonsByLastName(string LastName)
        {
            DataTable dtPeople = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    SqlCommand command = new SqlCommand("SP_FilterPersonsByLastName", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LastName", LastName);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dtPeople.Load(reader);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return dtPeople;
        }

        public static DataTable FilterPersonsByGendor(string Gendor)
        {
            DataTable dtPeople = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    SqlCommand command = new SqlCommand("SP_FilterPersonsByGendor", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Gendor", Gendor);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dtPeople.Load(reader);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return dtPeople;
        }

        public static DataTable FilterPersonsByEmail(string Email)
        {
            DataTable dtPeople = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    SqlCommand command = new SqlCommand("SP_FilterPersonsByEmail", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", Email);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dtPeople.Load(reader);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return dtPeople;
        }

        public static DataTable FilterPersonsByPhone(string Phone)
        {
            DataTable dtPeople = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    SqlCommand command = new SqlCommand("SP_FilterPersonsByPhone", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Phone", Phone);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dtPeople.Load(reader);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return dtPeople;
        }

        public static bool CheckIfNationalNoisExist(string NationalNo)
        {
            bool Found = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    SqlCommand command = new SqlCommand("SP_CheckIfNationalNoisExist", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NNo", NationalNo);

                    connection.Open();
                    object Result = command.ExecuteScalar();
                    if (Result != null && Result != DBNull.Value)
                    {
                        Found = true;
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

    }
}
