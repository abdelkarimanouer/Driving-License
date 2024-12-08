using DVLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLBusinessLayer
{
    public class clsCountries
    {
        public int ID { get; set; }
        public string CountryName { get; set; }

        public static clsCountries FindCountry(int CountryID)
        {
            string countryname = string.Empty;

            if ( clsCountriesData.GetCountry(CountryID, ref countryname) )
            {
                return new clsCountries(CountryID, countryname);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetALlCountries()
        {
            return clsCountriesData.GetAllCountries();
        }

        private clsCountries(int id, string countryname)
        {
            this.ID = id;
            this.CountryName = countryname;
        }
    }
}
