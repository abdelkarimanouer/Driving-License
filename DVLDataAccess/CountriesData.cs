using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDataAccess
{
    public class clsCountriesData
    {
        public static bool GetCountry(int CountryID, ref string CountryName)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"SELECT CountryName from Countries
                              Where CountryID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", CountryID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read() )
                {
                    Found = true;
                    CountryName = (string)reader["CountryName"];
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

        public static DataTable GetAllCountries()
        {
            DataTable dtCountries = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);

            string query = @"SELECT CountryName from Countries";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.HasRows)
                {
                    dtCountries.Load(reader);
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




            return dtCountries;
        }
    }
}
