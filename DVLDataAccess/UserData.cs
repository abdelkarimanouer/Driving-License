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

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = "select * from Users      where UserName = @UsName and Password = @Pw ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UsName", UserName);
            command.Parameters.AddWithValue("@Pw", Password);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;

                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];

                }

                reader.Close();

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
                Found = false;
                clsErrorLoggerDAL.EventLogError(ex.Message);
            }
            finally
            {
                connection.Close();
            }



            return Found;
        }

        public static string GetUserNameOfCurrentUser(int UserID)
        {
            string UserName = string.Empty;


            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = "select UserName from Users      where UserID = @UserID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null) 
                {
                    UserName = (string)Result;
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

            return UserName;
        }

        public static bool FindUserByUserID( int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = "select * from Users      where UserID = @UserID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;

                    UserName = (string)reader["UserName"];
                    PersonID = (int)reader["PersonID"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];

                }

                reader.Close();

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
                Found = false;
            }
            finally
            {
                connection.Close();
            }



            return Found;
        }

        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            int UserID = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"INSERT INTO Users
                                 VALUES
                            	            (@PersonID, @UserName , @Password , @IsActive)
                             select SCOPE_IDENTITY() ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID",PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

              
            try
            {
                connection.Open();
                
                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int InsetedID) )
                {
                    UserID = InsetedID;
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

            return UserID;
        }

        public static bool UpdateUser(int UserID, string UserName, string Password, bool IsActive)
        {
            int RowEffected = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"UPDATE Users
                               SET
                                  UserName = @UserName
                                  ,Password = @Password
                                  ,IsActive = @IsActive
                             WHERE UserID = @UserID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);


            try
            {
                connection.Open();

                RowEffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }
            finally
            {
                connection.Close();
            }

            return (RowEffected > 0);
        }

        public static DataTable ListUsers()
        {
            DataTable dtUsers = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"SELECT Users.UserID, People.PersonID, People.FirstName + ' ' + ISNULL(People.SecondName, '') + ' ' + ISNULL(People.ThirdName, '') + ' ' + People.LastName AS FullName,
	                                Users.UserName, Users.IsActive
                             FROM People 
                             INNER JOIN Users ON People.PersonID = Users.PersonID;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.HasRows)
                {
                    dtUsers.Load(reader);
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




            return dtUsers;
        }

        public static DataTable FilterByUserID(int UserID)
        {
            DataTable dtUsers = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @" SELECT Users.UserID, Users.PersonID, FullName = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName , Users.UserName, Users.IsActive
                              FROM     People INNER JOIN
                              Users ON People.PersonID = Users.PersonID
                              Where UserID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    dtUsers.Load(reader);
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




            return dtUsers;
        }

        public static DataTable FilterByPersonID(int PersonID)
        {
            DataTable dtUsers = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @" SELECT Users.UserID, Users.PersonID, FullName = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName , Users.UserName, Users.IsActive
                              FROM     People INNER JOIN
                              Users ON People.PersonID = Users.PersonID
                              Where Users.PersonID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    dtUsers.Load(reader);
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




            return dtUsers;
        }

        public static DataTable FilterByUserName(string UserName)
        {
            DataTable dtUsers = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @" SELECT Users.UserID, Users.PersonID, FullName = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName , Users.UserName, Users.IsActive
                              FROM     People INNER JOIN
                              Users ON People.PersonID = Users.PersonID
                              Where UserName LIKE '' + @UserName +'%'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    dtUsers.Load(reader);
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




            return dtUsers;
        }

        public static DataTable FilterByFullName(string FullName)
        {
            DataTable dtUsers = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @" SELECT * From (
                             SELECT Users.UserID, Users.PersonID, FullName = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName , Users.UserName, Users.IsActive
                              FROM     People INNER JOIN
                              Users ON People.PersonID = Users.PersonID
                                            ) R1
                              Where R1.FullName LIKE '' + @FullName +'%'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FullName", FullName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    dtUsers.Load(reader);
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




            return dtUsers;
        }

        public static DataTable FilterByIsActive(bool IsActive)
        {
            DataTable dtUsers = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @" SELECT Users.UserID, Users.PersonID, FullName = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName , Users.UserName, Users.IsActive
                              FROM     People INNER JOIN
                              Users ON People.PersonID = Users.PersonID
                              Where Users.IsActive = @IsActive";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.HasRows)
                {
                    dtUsers.Load(reader);
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




            return dtUsers;
        }

        public static bool CheckPersonIsUser(int PersonID)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @" select Found = 1 from Users
                                    where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    Found = true;
                }


            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
                Found = false;
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }

        public static bool UserExists(string UserName)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @" select Found = 1 from Users
                                    where UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    Found = true;
                }


            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);
                Found = false;
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }

        public static bool DeleteUser(int UserID)
        {
            int RowEffected = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"delete from Users
                                    where UserID = @UserID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);


            try
            {
                connection.Open();
                RowEffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                clsErrorLoggerDAL.EventLogError(ex.Message);

            }
            finally
            {
                connection.Close();
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
