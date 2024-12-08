using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDataAccess
{
    public class clsDriversData
    {
        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int DriverID = 0;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"INSERT INTO Drivers
                                    (PersonID, CreatedByUserID, CreatedDate)
                              VALUES
                                    (@PersonID, @CreatedByUserID, @CreatedDate )
                             select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    DriverID = Convert.ToInt32(Result);
                }


            }
            catch { }
            finally { connection.Close(); }


            return DriverID;
        }

        public static DataTable ListDrivers()
        {
            DataTable dtDrivers = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @" WITH DistinctDrivers AS (  SELECT  Drivers.DriverID, Drivers.PersonID, People.NationalNo, FullName = People.FirstName + ' ' + isnull( People.SecondName, '') + ' ' + isnull( People.ThirdName, '') + ' ' + People.LastName, 
                                  Drivers.CreatedDate as Date, Licenses.IsActive as ActiveLicenses,
                              ROW_NUMBER() OVER(PARTITION BY Drivers.PersonID ORDER BY Drivers.CreatedDate ASC) AS RowNum
                               FROM     Drivers 
                                   INNER JOIN People ON Drivers.PersonID = People.PersonID 
                                   INNER JOIN Licenses ON Drivers.DriverID = Licenses.DriverID
                               WHERE 
                                   Licenses.IsActive = 1
                           )
                           SELECT  DriverID,  PersonID, NationalNo, FullName, Date, ActiveLicenses
                           FROM   DistinctDrivers
                           WHERE  RowNum = 1;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtDrivers.Load(reader);
                }
                reader.Close();
            }
            catch
            {

            }
            finally
            { connection.Close(); }

            return dtDrivers;
        }
    
    }
}
