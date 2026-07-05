using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBusinessLayer
{
    public class clsCountry
    {
        public int ID { set; get; }
        public string CountryName { set; get; }

        public clsCountry()
        {
            this.ID = -1;
            this.CountryName = "";

        }

        private clsCountry(int ID, string CountryName)

        {
            this.ID = ID;
            this.CountryName = CountryName;

        }

        public static clsCountry Find(int ID)
        {



            string CountryName = "";
            ID = -1;
            if(CountriesData.getCountryInfoByID(ID, ref CountryName))
            {
                return new clsCountry(ID, CountryName);
            }
            else
            {
                return null;
            }
        }

        public static clsCountry Find(string CountryName)
        {
            int ID = -1;

            if (CountriesData.getCountryInfoByName(CountryName,ref ID))
            {
                return new clsCountry(ID, CountryName);
            }
            else
            {
                return null;
            }
        }

        public static bool isCountryExist(int ID)
        {
            return CountriesData.isCountryExist(ID);
        }

        public static bool isCountryExist(string CountryName)
        {
            return CountriesData.isCountryExist(CountryName);
        }

    }
}
