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


            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth, 
                                   CASE
                                       WHEN Gendor = 0 THEN 'Male'
                                       WHEN Gendor = 1 THEN 'Female'
                                   END as Gendor
,                           NationalityCountryID, People.Address, People.Phone, People.Email, 
                                              People.ImagePath
                            FROM     People INNER JOIN
                                              Countries ON People.NationalityCountryID = Countries.CountryID
                            where PersonID = @ID ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;

                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];

                    if (reader["SecondName"] == DBNull.Value)
                    {
                        SecondName = "";
                    }
                    else
                    {
                        SecondName = (string)reader["SecondName"];
                    }


                    if (reader["ThirdName"] == DBNull.Value)
                    {
                        ThirdName = "";
                    }
                    else
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (string)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];


                    if (reader["Email"] == DBNull.Value)
                    {
                        Email = "";
                    }
                    else
                    {
                        Email = (string)reader["Email"];
                    }

                    CountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] == DBNull.Value)
                    {
                        ImagePath = "";
                    }
                    else
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }


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

        public static bool GetPersonByNationalNo(string NationalNo, ref int ID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref string Gendor, ref string Address,
    ref string Phone, ref string Email, ref int CountryID, ref string ImagePath)
        {
            bool Found = false;


            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth, 
                                   CASE
                                       WHEN Gendor = 0 THEN 'Male'
                                       WHEN Gendor = 1 THEN 'Female'
                                   END as Gendor
,                           NationalityCountryID, People.Address, People.Phone, People.Email, 
                                              People.ImagePath
                            FROM     People INNER JOIN
                                              Countries ON People.NationalityCountryID = Countries.CountryID
                            where NationalNo = @NNo ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;

                    ID = (int) reader["PersonID"];
                    FirstName = (string)reader["FirstName"];

                    if (reader["SecondName"] == DBNull.Value)
                    {
                        SecondName = "";
                    }
                    else
                    {
                        SecondName = (string)reader["SecondName"];
                    }


                    if (reader["ThirdName"] == DBNull.Value)
                    {
                        ThirdName = "";
                    }
                    else
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (string)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];


                    if (reader["Email"] == DBNull.Value)
                    {
                        Email = "";
                    }
                    else
                    {
                        Email = (string)reader["Email"];
                    }

                    CountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] == DBNull.Value)
                    {
                        ImagePath = "";
                    }
                    else
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }


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


        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, string Gendor, string Address,
            string Phone, string Email, int NationalCountryID, string ImagePath)
        {
            int IDPerson = -1;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @" INSERT INTO People
                                  VALUES
                                        (@NNo ,@FName ,@SName ,@TName ,@LName , @DOfB, @Gend, @Addr, @Phone, @Email, @CID, @ImagePath);
                             select SCOPE_IDENTITY() from People;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NNo", NationalNo);
            command.Parameters.AddWithValue("@FName", FirstName);


            if (SecondName == "")
            {
                command.Parameters.AddWithValue("@SName", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@SName", SecondName);
            }


            if (ThirdName == "")
            {
                command.Parameters.AddWithValue("@TName", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@TName", ThirdName);
            }

            command.Parameters.AddWithValue("@LName", LastName);
            command.Parameters.AddWithValue("@DOfB", DateOfBirth);
            command.Parameters.AddWithValue("@Gend", Gendor);
            command.Parameters.AddWithValue("@Addr", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email == "")
            {
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Email", Email);
            }

            command.Parameters.AddWithValue("@CID", NationalCountryID);

            if (ImagePath == "")
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }



            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int Identity))
                {
                    IDPerson = Identity;
                }

            }
            catch (Exception ex)
            {
                IDPerson = -1;
            }
            finally
            {
                connection.Close();
            }



            return IDPerson ;
        }

        public static bool UpdatePerson(int ID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, string Gendor, string Address,
    string Phone, string Email, int NationalCountryID, string ImagePath)
        {
            int RowEffected = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @" UPDATE People SET
                              NationalNo = @NNo
                             ,FirstName = @FName
                             ,SecondName = @SName
                             ,ThirdName = @TName
                             ,LastName = @LName
                             ,DateOfBirth = @DOfB
                             ,Gendor = @Gend
                             ,Address = @Addr
                             ,Phone = @Phone
                             ,Email = @Email
                             ,NationalityCountryID = @CID
                             ,ImagePath = @ImagePath
                        WHERE PersonID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            command.Parameters.AddWithValue("@NNo", NationalNo);
            command.Parameters.AddWithValue("@FName", FirstName);


            if (SecondName == "")
            {
                command.Parameters.AddWithValue("@SName", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@SName", SecondName);
            }


            if (ThirdName == "")
            {
                command.Parameters.AddWithValue("@TName", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@TName", ThirdName);
            }

            command.Parameters.AddWithValue("@LName", LastName);
            command.Parameters.AddWithValue("@DOfB", DateOfBirth);
            command.Parameters.AddWithValue("@Gend", Gendor);
            command.Parameters.AddWithValue("@Addr", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email == "")
            {
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Email", Email);
            }

            command.Parameters.AddWithValue("@CID", NationalCountryID);

            if (ImagePath == "")
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }



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



            return (RowEffected > 0) ;
        }

        public static bool DeletePeople(int ID)
        {
            int RowEffected = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @" Delete From People WHERE PersonID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

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

        public static DataTable ListsPeople()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query =
              @"SELECT People.PersonID, People.NationalNo,
              People.FirstName, People.SecondName, People.ThirdName, People.LastName,
			  People.DateOfBirth, People.Gendor,  
				  CASE
                  WHEN People.Gendor = 0 THEN 'Male'

                  ELSE 'Female'

                  END as GendorCaption ,
			  People.Address, People.Phone, People.Email, 
              People.NationalityCountryID, Countries.CountryName, People.ImagePath
              FROM            People INNER JOIN
                         Countries ON People.NationalityCountryID = Countries.CountryID
                ORDER BY People.FirstName";




            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();

            }
            catch
            {

            }
            finally 
            {
                connection.Close();
            }




            return dt;
        }

        public static DataTable FilterByPersonID(int PersonID)
        {
            DataTable dtPeople = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, 
                                   CASE
                                       WHEN Gendor = 0 THEN 'Male'
                                       WHEN Gendor = 1 THEN 'Female'
                                   END as Gendor

                                   , People.DateOfBirth, Countries.CountryName as Nationality, People.Phone, People.Email
                                   FROM     People INNER JOIN
                                                     Countries ON People.NationalityCountryID = Countries.CountryID
                                   where PersonID = @PersonID ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    dtPeople.Load(reader);
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




            return dtPeople;
        }

        public static DataTable FilterByNationalNo(string NationalNo)
        {
            DataTable dtPeople = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, 
                                   CASE
                                       WHEN Gendor = 0 THEN 'Male'
                                       WHEN Gendor = 1 THEN 'Female'
                                   END as Gendor

                                   , People.DateOfBirth, Countries.CountryName as Nationality, People.Phone, People.Email
                                   FROM     People INNER JOIN
                                                     Countries ON People.NationalityCountryID = Countries.CountryID
                                   where NationalNo LIKE '' + @NationalNo +'%' ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    dtPeople.Load(reader);
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




            return dtPeople;
        }

        public static DataTable FilterByFirstName(string FirstName)
        {
            DataTable dtPeople = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, 
                                   CASE
                                       WHEN Gendor = 0 THEN 'Male'
                                       WHEN Gendor = 1 THEN 'Female'
                                   END as Gendor

                                   , People.DateOfBirth, Countries.CountryName as Nationality, People.Phone, People.Email
                                   FROM     People INNER JOIN
                                                     Countries ON People.NationalityCountryID = Countries.CountryID
                                   where FirstName LIKE '' + @FirstName +'%' ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.HasRows)
                {
                    dtPeople.Load(reader);
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




            return dtPeople;
        }

        public static DataTable FilterBySecondName(string SecondName)
        {
            DataTable dtPeople = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, 
                                   CASE
                                       WHEN Gendor = 0 THEN 'Male'
                                       WHEN Gendor = 1 THEN 'Female'
                                   END as Gendor

                                   , People.DateOfBirth, Countries.CountryName as Nationality, People.Phone, People.Email
                                   FROM     People INNER JOIN
                                                     Countries ON People.NationalityCountryID = Countries.CountryID
                                   where SecondName LIKE '' + @SecondName +'%' ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.HasRows)
                {
                    dtPeople.Load(reader);
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




            return dtPeople;
        }

        public static DataTable FilterByThirdName(string ThirdName)
        {
            DataTable dtPeople = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, 
                                   CASE
                                       WHEN Gendor = 0 THEN 'Male'
                                       WHEN Gendor = 1 THEN 'Female'
                                   END as Gendor

                                   , People.DateOfBirth, Countries.CountryName as Nationality, People.Phone, People.Email
                                   FROM     People INNER JOIN
                                                     Countries ON People.NationalityCountryID = Countries.CountryID
                                   where ThirdName LIKE '' + @ThirdName +'%' ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.HasRows)
                {
                    dtPeople.Load(reader);
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




            return dtPeople;
        }

        public static DataTable FilterByLastName(string LastName)
        {
            DataTable dtPeople = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, 
                                   CASE
                                       WHEN Gendor = 0 THEN 'Male'
                                       WHEN Gendor = 1 THEN 'Female'
                                   END as Gendor

                                   , People.DateOfBirth, Countries.CountryName as Nationality, People.Phone, People.Email
                                   FROM     People INNER JOIN
                                                     Countries ON People.NationalityCountryID = Countries.CountryID
                                   where LastName LIKE '' + @LastName +'%' ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LastName", LastName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.HasRows)
                {
                    dtPeople.Load(reader);
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




            return dtPeople;
        }

        public static DataTable FilterByGendor(string Gendor)
        {
            DataTable dtPeople = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"select * from 
                            (
                            SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, 
                                                               CASE
                                                                   WHEN Gendor = 0 THEN 'Male'
                                                                   WHEN Gendor = 1 THEN 'Female'
                                                               END as Gendor
                            
                                                               , People.DateOfBirth, Countries.CountryName as Nationality, People.Phone, People.Email
                                                               FROM     People INNER JOIN
                                                                                 Countries ON People.NationalityCountryID = Countries.CountryID
                            ) R1
                             where R1.Gendor LIKE '' + @Gendor +'%'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Gendor", Gendor);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.HasRows)
                {
                    dtPeople.Load(reader);
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




            return dtPeople;
        }

        public static DataTable FilterByEmail(string Email)
        {
            DataTable dtPeople = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, 
                                   CASE
                                       WHEN Gendor = 0 THEN 'Male'
                                       WHEN Gendor = 1 THEN 'Female'
                                   END as Gendor

                                   , People.DateOfBirth, Countries.CountryName as Nationality, People.Phone, People.Email
                                   FROM     People INNER JOIN
                                                     Countries ON People.NationalityCountryID = Countries.CountryID
                                   where Email LIKE '' + @Email +'%' ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", Email);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.HasRows)
                {
                    dtPeople.Load(reader);
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




            return dtPeople;
        }

        public static DataTable FilterByPhone(string Phone)
        {
            DataTable dtPeople = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, 
                                   CASE
                                       WHEN Gendor = 0 THEN 'Male'
                                       WHEN Gendor = 1 THEN 'Female'
                                   END as Gendor

                                   , People.DateOfBirth, Countries.CountryName as Nationality, People.Phone, People.Email
                                   FROM     People INNER JOIN
                                                     Countries ON People.NationalityCountryID = Countries.CountryID
                                   where Phone LIKE '' + @Phone +'%' ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Phone", Phone);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.HasRows)
                {
                    dtPeople.Load(reader);
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




            return dtPeople;
        }

        public static bool CheckIfNationalNoisExist(string NationalNo)
        {
            bool Found = false;


            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"select Found = 1    from People
                             where People.NationalNo = @NNo ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NNo", NationalNo);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    Found = true ;
                }


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

    }
}
