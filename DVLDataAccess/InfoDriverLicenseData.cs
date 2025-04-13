using System;
using System.Collections.Generic;
using System.Data;
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

            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionSetting.connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetLocalDriverLicenseInfoByApplicationID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                Found = true;

                                ClassName = (string)reader["ClassName"];
                                Name = (string)reader["Name"];
                                LicenseID = (int)reader["LicenseID"];
                                NationalNo = (string)reader["NationalNo"];

                                Gendor = Convert.ToBoolean(reader["Gendor"]);

                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                IssueReason = (byte)reader["IssueReason"];
                                IsActive = Convert.ToBoolean(reader["IsActive"]);
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


    }
}
