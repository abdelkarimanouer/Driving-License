using DVLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DVLBusinessLayer
{
    public class clsUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PersonID { get; set; }
        public bool IsActive { get; set; }
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode;


        public static clsUser FindUserByUserNameAndPassword(string username, string password)
        {
            int userId = -1, personId = -1;
            bool isactive = false;

            if ( clsUserData.FindUserByUserNameAndPassword(username, password, ref userId, ref personId, ref isactive) )
            {
                return new clsUser( userId, username, password, personId, isactive );
            }
            else
            {
                return null;
            }
        }

        public static clsUser FindUserByUserID(int UserID)
        {
            int personId = -1;
            string username = null, password = null;
            bool isactive = false;

            if (clsUserData.FindUserByUserID(UserID, ref personId, ref username, ref password, ref isactive ) )
            {
                return new clsUser(UserID, username, password, personId, isactive);
            }
            else
            {
                return null;
            }
        }

        public static string GetUserNameOfCurrentUser(int userid)
        {
            return clsUserData.GetUserNameOfCurrentUser(userid);
        }

        private bool _UpdateUser()
        {
           return clsUserData.UpdateUser(UserID, UserName, Password, IsActive);
        }

        private bool _AddNewUser()
        {
            UserID = clsUserData.AddNewUser( PersonID, UserName, Password, IsActive );
            return (UserID != -1);
        }

        public static int CountUsers()
        {
            return clsUserData.ListUsers().Rows.Count;

        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.ListUsers();
        }

        public static DataTable FilterByUserID(int UserID)
        {
            return clsUserData.FilterByUserID(UserID);
        }

        public static DataTable FilterByPersonID(int PersonID)
        {
            return clsUserData.FilterByPersonID(PersonID);
        }

        public static DataTable FilterByUserName(string UserName)
        {
            return clsUserData.FilterByUserName(UserName);
        }

        public static DataTable FilterByFullName(string FullName)
        {
            return clsUserData.FilterByFullName(FullName);
        }

        public static DataTable FilterByIsActive(bool IsActive)
        {
            return clsUserData.FilterByIsActive(IsActive);
        }

        public static bool CheckPersonIsUser(int PersonID)
        {
            return clsUserData.CheckPersonIsUser(PersonID);
        }

        public static bool UserExists(string UserName)
        {
            return clsUserData.UserExists(UserName);
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    return _AddNewUser();
                case enMode.Update:
                    return _UpdateUser();
            }

            return false;
        }

        public clsUser() 
        {
            this.UserID = -1;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.PersonID = -1;
            this.IsActive = false;

            _Mode = enMode.AddNew;

        }

        private clsUser(int userID, string userName, string password, int personID, bool isActive)
        {
            this.UserID = userID;
            this.UserName = userName;
            this.Password = password;
            this.PersonID = personID;
            this.IsActive = isActive;

            _Mode = enMode.Update;
        }

        public void SaveUserDataInFile()
        {
            clsUserData.SaveUserDataInRegistry(UserName, Password);
        }

        public static void DeleteRecordFromFile()
        {
            clsUserData.DeleteRecordFromFile();
        }

        public static void GetUserFromFileIfSaveHisInfoInLastLogin(ref string UserName, ref string Password)
        {
            clsUserData.GetUserFromFileIfSaveHisInfoInLastLogin(ref UserName, ref Password);
        }

    }
}
