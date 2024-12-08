using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDataAccess
{
    public class clsInfoDriverLicenseData
    {
        public static bool GetLocalDriverLicenseInfoByApplicationID(int ApplicationID, ref string ClassName, ref string Name, ref int LicenseID, ref string NationalNo, ref bool Gendor,
    ref DateTime IssueDate, ref byte IssueReason, ref string Notes, ref bool IsActive, ref DateTime DateOfBirth, ref int DriverID, ref DateTime ExpirationDate, ref string ImagePath)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring);
            string query = @"SELECT LicenseClasses.ClassName, People.FirstName + ' ' + ISNULL(People.SecondName, '') + ' ' + ISNULL(People.ThirdName, '') + ' ' + People.LastName AS Name, Licenses.LicenseID, People.NationalNo, People.Gendor, Licenses.IssueDate, Licenses.IssueReason, Licenses.Notes, 
                                                Licenses.IsActive, People.DateOfBirth, Drivers.DriverID, Licenses.ExpirationDate, People.ImagePath
                              FROM     Licenses INNER JOIN
                                                Drivers ON Licenses.DriverID = Drivers.DriverID INNER JOIN
                                                People ON Drivers.PersonID = People.PersonID INNER JOIN
                                                LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                              WHERE  (Licenses.ApplicationID = @ApplicationID)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;

                    ClassName = (string)reader["ClassName"];
                    Name = (string)reader["Name"];
                    LicenseID = (int)reader["LicenseID"];
                    NationalNo = (string)reader["NationalNo"];

                    Gendor = Convert.ToBoolean (reader["Gendor"]);

                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    IssueReason = (byte)reader["IssueReason"];
                    IsActive = Convert.ToBoolean( reader["IsActive"] );
                    IssueDate = (DateTime)reader["IssueDate"];
                    DriverID = (int)reader["DriverID"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];

                    if (reader["Notes"] == DBNull.Value)
                    {
                        Notes = "No Notes";
                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
                    }

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
            catch
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
