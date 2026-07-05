using ContactsDataAccessLayer;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBusinessLayer
{
    public class clsCountry
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int ID { set; get; }
        public string CountryName { set; get; }
        public string Code { set; get; }
        public string PhoneCode { set; get; }

        public clsCountry()
        {
            this.ID = -1;
            this.CountryName = "";

            Mode = enMode.AddNew;
        }

        private clsCountry(int ID, string CountryName, string Code, string PhoneCode)
        {
            this.ID = ID;
            this.CountryName = CountryName;
            this.Code = Code;
            this.PhoneCode = PhoneCode;

            Mode = enMode.Update;
        }

        public static clsCountry Find(int ID)
        {



            string CountryName = "";
            string Code = "";
            string PhoneCode = "";
            ID = -1;
            if (CountriesData.getCountryInfoByID(ID, ref CountryName, ref Code, ref PhoneCode))
            {
                return new clsCountry(ID, CountryName, Code, PhoneCode);
            }
            else
            {
                return null;
            }
        }

        public static clsCountry Find(string CountryName)
        {
            int ID = -1;
            string Code = "";
            string PhoneCode = "";

            if (CountriesData.getCountryInfoByName(CountryName, ref ID, ref Code, ref PhoneCode))
            {
                return new clsCountry(ID, CountryName, Code, PhoneCode);
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

        public static DataTable GetAllCountries()
        {
            return CountriesData.GetAllCountries();
        }

        public static bool DeleteCountry(int ID)
        {
            return CountriesData.DeleteCountry(ID);
        }

        private bool _AddNewCountry()
        {
            this.ID = CountriesData.AddCountry(CountryName, Code, PhoneCode);

            return this.ID != -1;
        }

        private bool _UpdateCountry()
        {
            return CountriesData.UpdateCountry(this.ID, this.CountryName, this.Code, this.PhoneCode);
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCountry())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateCountry();

            }




            return false;


        }

    }
}
