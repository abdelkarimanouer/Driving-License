using DVLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLBusinessLayer
{
    public class clsInfoDriverLicense
    {
        public string ClassName { get; set; }
        public string Name { get; set; }
        public int LicenseID { get; set; }
        public string NationalNo { get; set; }
        public bool Gendor { get; set; }
        public DateTime IssueDate { get; set; }
        public byte IssueReason { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int DriverID { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string ImagePath { get; set; }

        public static clsInfoDriverLicense GetDriverLicenseInfoByApplicationID(int ApplicationID)
        {
            string classname = string.Empty, name = string.Empty, nationalNo = string.Empty, notes = string.Empty, imagePath = string.Empty;
            int licenseID = -1, driverID = -1; 
            bool gendor = false, isActive = false; 
            DateTime issueDate = DateTime.MinValue, dateOfBirth = DateTime.MinValue, expirationDate = DateTime.MinValue;
            byte issueReason = 0;

            if (clsInfoDriverLicenseData.GetLocalDriverLicenseInfoByApplicationID(ApplicationID, ref classname, ref name, ref licenseID, ref nationalNo, ref gendor, ref issueDate, ref issueReason,
                ref notes, ref isActive, ref dateOfBirth, ref driverID, ref expirationDate, ref imagePath) )
            {
                return new clsInfoDriverLicense(classname, name, nationalNo, notes, imagePath, licenseID, driverID, gendor, isActive, issueDate, dateOfBirth, expirationDate, issueReason);
            }
            else
            {
                return null;
            }

        }

        private clsInfoDriverLicense(string classname, string name, string nationalNo, string notes, string imagePath, int licenseID, int driverID, bool gendor,
            bool isActive, DateTime issueDate, DateTime dateOfBirth, DateTime expirationDate, byte issueReason)
        {
            this.ClassName = classname;
            this.Name = name;
            this.NationalNo = nationalNo;
            this.Notes = notes;
            this.ImagePath = imagePath;
            this.LicenseID = licenseID;
            this.DriverID = driverID;
            this.Gendor = gendor;
            this.IsActive = isActive;
            this.IssueDate = issueDate;
            this.DateOfBirth = dateOfBirth;
            this.ExpirationDate = expirationDate;
            this.IssueReason = issueReason;
        }

        public clsInfoDriverLicense()
        { 
        }
    }
}
