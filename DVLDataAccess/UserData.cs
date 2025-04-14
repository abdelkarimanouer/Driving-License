using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.CodeDom.Compiler;
using System.Data;
using System.IO;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace DVLDataAccess
{
    public class clsUserData
    {
        public static bool FindUserByUserNameAndPassword(string UserName, string Password, ref int UserID, ref int PersonID, ref bool IsActive)
        {
            bool Found = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SP_FindUserByUserNameAndPassword", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UsName", UserName);
                        command.Parameters.AddWithValue("@Pw", Password);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Found = true;
                                UserID = (int)reader["UserID"];
                                PersonID = (int)reader["PersonID"];
                                IsActive = (bool)reader["IsActive"];
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

        public static string GetUserNameOfCurrentUser(int UserID)
        {
            string UserName = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetUserNameOfCurrentUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", UserID);

                        connection.Open();

                        object Result = command.ExecuteScalar();
                        if (Result != null && Result != DBNull.Value)
                        {
                            UserName = (string)Result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return UserName;
        }

        public static bool FindUserByUserID(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool Found = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SP_FindUserByUserID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", UserID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Found = true;
                                UserName = (string)reader["UserName"];
                                PersonID = (int)reader["PersonID"];
                                Password = (string)reader["Password"];
                                IsActive = (bool)reader["IsActive"];
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

        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            int UserID = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);

                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                        {
                            UserID = InsertedID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return UserID;
        }

        public static bool UpdateUser(int UserID, string UserName, string Password, bool IsActive)
        {
            int RowEffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);

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

        public static DataTable ListUsers()
        {
            DataTable dtUsers = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SP_ListUsers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dtUsers.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return dtUsers;
        }

        public static DataTable FilterByUserID(int UserID)
        {
            DataTable dtUsers = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SP_FilterByUserID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID", UserID);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            dtUsers.Load(reader);
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return dtUsers;
        }

        public static DataTable FilterByPersonID(int PersonID)
        {
            DataTable dtUsers = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SP_FilterByPersonID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID", PersonID);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            dtUsers.Load(reader);
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return dtUsers;
        }

        public static DataTable FilterByUserName(string UserName)
        {
            DataTable dtUsers = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SP_FilterByUserName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", UserName);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            dtUsers.Load(reader);
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return dtUsers;
        }

        public static DataTable FilterByFullName(string FullName)
        {
            DataTable dtUsers = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SP_FilterUsersByFullName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FullName", FullName);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            dtUsers.Load(reader);
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return dtUsers;
        }

        public static DataTable FilterByIsActive(bool IsActive)
        {
            DataTable dtUsers = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SP_FilterUsersByIsActive", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IsActive", IsActive);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.HasRows)
                        {
                            dtUsers.Load(reader);
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

            return dtUsers;
        }

        public static bool CheckPersonIsUser(int PersonID)
        {
            bool Found = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SP_CheckPersonIsUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && Result != DBNull.Value)
                        {
                            Found = true;
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

        public static bool UserExists(string UserName)
        {
            bool Found = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SP_UserExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", UserName);

                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && Result != DBNull.Value)
                        {
                            Found = true;
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

        public static bool DeleteUser(int UserID)
        {
            int RowEffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DeleteUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", UserID);

                        RowEffected = command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }

            return ( RowEffected > 0 ) ;
        }

        public static void SaveUserDataInRegistry(string UserName, string Password)
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVL";
            
            string vnusername = "UserName";
            string vdusername = UserName;

            string vnpassword = "Password";
            string vdpassword = Password;

            try
            {
                Registry.SetValue(KeyPath, vnusername, vdusername, RegistryValueKind.String);
                Registry.SetValue(KeyPath, vnpassword, vdpassword , RegistryValueKind.String);
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }
        }

        public static void DeleteRecordFromFile()
        {
            string KeyPath = @"SOFTWARE\DVL";

            string vnusername = "UserName";
            string vnpassword = "Password";

            try
            {
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey key = baseKey.OpenSubKey(KeyPath, true))
                    {
                        if (key != null)
                        {
                            key.DeleteValue(vnusername);
                            key.DeleteValue(vnpassword);

                        }
                        else
                        {
                            Console.WriteLine($"Registry key '{KeyPath}' not found");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }

        }

        public static void GetUserFromFileIfSaveHisInfoInLastLogin(ref string UserName, ref string Password)
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVL";

            string vnusername = "UserName";
            string vnpassword = "Password";

            try
            {
                UserName = Registry.GetValue(KeyPath, vnusername, null) as string;
                Password = Registry.GetValue(KeyPath, vnpassword, null) as string;
            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }
        }


    }
}
