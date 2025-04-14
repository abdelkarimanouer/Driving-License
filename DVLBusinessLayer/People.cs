using DVLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLBusinessLayer
{
    public class clsPeople
    {
        public int ID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string Gendor { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NationalityID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }

        public enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode;

        private bool _AddNewPerson()
        {
            ID = clsPeopleData.AddNewPerson(NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityID, ImagePath);

            return (ID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPeopleData.UpdatePerson(this.ID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityID, ImagePath);
        }

        public string FullName()
        {
            return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
        }
        public static DataTable GetAllPeople()
        {
            return clsPeopleData.ListsPeople();
        }

        public static DataTable FilterByPersonID(int PersonID)
        {
            return clsPeopleData.FilterPersonsByPersonID(PersonID);
        }

        public static DataTable FilterByNationalNo(string NationalNo)
        {
            return clsPeopleData.FilterPersonsByNationalNo(NationalNo);
        }

        public static DataTable FilterByFirstName(string FirstName)
        {
            return clsPeopleData.FilterPersonsByFirstName(FirstName);
        }

        public static DataTable FilterBySecondName(string SecondName)
        {
            return clsPeopleData.FilterPersonsBySecondName(SecondName);
        }

        public static DataTable FilterByThirdName(string ThirdName)
        {
            return clsPeopleData.FilterPersonsByThirdName(ThirdName);
        }

        public static DataTable FilterByLastName(string LastName)
        {
            return clsPeopleData.FilterPersonsByLastName(LastName);
        }

        public static DataTable FilterByGendor(string Gendor)
        {
            return clsPeopleData.FilterPersonsByGendor(Gendor);
        }

        public static DataTable FilterByEmail(string Email)
        {
            return clsPeopleData.FilterPersonsByEmail(Email);
        }

        public static DataTable FilterByPhone(string Phone)
        {
            return clsPeopleData.FilterPersonsByPhone(Phone);
        }

        public static clsPeople FindPeopleByPersonID(int ID)
        {
            string nationalno = string.Empty, firstname = string.Empty,  secondname = string.Empty,  thirdname = string.Empty,  lastname = string.Empty, gendor = string.Empty,  Address = string.Empty,  phone = string.Empty,  email = string.Empty,   imagepath = string.Empty;
            DateTime dateofbirth = DateTime.MinValue;
            int NationalCountryID = 0;

            if (clsPeopleData.GetPersonByPersonID(ID, ref nationalno, ref firstname, ref secondname, ref thirdname, ref lastname, ref dateofbirth, ref gendor, ref Address, ref phone, ref email, ref NationalCountryID, ref imagepath))
            {
                return new clsPeople(ID, nationalno, firstname, secondname, thirdname, lastname, dateofbirth, gendor, Address, phone, email, NationalCountryID, imagepath);
            }
            else
            {
                return null;
            }

        }


        public static clsPeople FindPeopleByNationalNo(string nationalno)
        {
            string  firstname = string.Empty, secondname = string.Empty, thirdname = string.Empty, lastname = string.Empty, gendor = string.Empty, Address = string.Empty, phone = string.Empty, email = string.Empty, imagepath = string.Empty;
            DateTime dateofbirth = DateTime.MinValue;
            int personid = 0, NationalCountryID = 0;

            if (clsPeopleData.GetPersonByNationalNo(nationalno, ref personid, ref firstname, ref secondname, ref thirdname, ref lastname, ref dateofbirth, ref gendor, ref Address, ref phone, ref email, ref NationalCountryID, ref imagepath))
            {
                return new clsPeople(personid, nationalno, firstname, secondname, thirdname, lastname, dateofbirth, gendor, Address, phone, email, NationalCountryID, imagepath);
            }
            else
            {
                return null;
            }

        }


        public static int CountPeople()
        {
            return clsPeopleData.ListsPeople().Rows.Count;
        }

        public static bool CheckIfNationalNoisExist(string NationalNo)
        {
            return clsPeopleData.CheckIfNationalNoisExist(NationalNo);
        }

        public static bool DeletePeople(int ID)
        {
            return clsPeopleData.DeletePeople(ID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    return _AddNewPerson();
                case enMode.Update:
                    return _UpdatePerson();
                
            }
            return false;
        }

        public clsPeople()
        {
            ID = -1;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            Gendor = string.Empty;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            NationalityID = -1;
            DateOfBirth = DateTime.MinValue;
            ImagePath = string.Empty;

            _Mode = enMode.AddNew;
        }

        private clsPeople(int ID, string nationalno ,string firstname, string secondname, string thirdname, string lastname, DateTime dateofbirth, string gendor, string Address, string phone, string email, int nationalityID, string imagepath )
        {
            this.ID = ID;
            this.NationalNo = nationalno;
            this.FirstName = firstname;
            this.SecondName = secondname;
            this.ThirdName = thirdname;
            this.LastName = lastname;
            this.Gendor = gendor;
            this.Address = Address;
            this.Phone = phone;
            this.Email = email;
            this.NationalityID = nationalityID;
            this.DateOfBirth = dateofbirth;
            this.ImagePath = imagepath;

            _Mode = enMode.Update;
        }


    }
}
