using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsDataAccessLayer;



namespace ContactsBusinessLayer
{

    public class clsContact
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImagePath { get; set; }
        public int CountryID { get; set; }

        public clsContact()
        {
            this.ID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.ImagePath = "";
            this.CountryID = -1;

            Mode = enMode.AddNew;
        }

        private clsContact(int ID, string FirstName, string LastName, string Email, string Phone, string Address, DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;
            this.Mode = enMode.Update;
        }

        public static clsContact Find(int ID)
        {
            string FirstName = "";
            string LastName = "";
            string Email = "";
            string Phone = "";
            string Address = "";
            string ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int CountryID = -1;

            if (ContactsDataAccessLayer.Class1.GetContactByID(ID, ref FirstName, ref LastName, ref Email,
                ref Phone, ref Address, ref DateOfBirth, ref CountryID, ref ImagePath))
            {
                return new clsContact(ID, FirstName, LastName, Email, Phone,
                    Address, DateOfBirth, CountryID, ImagePath);
            }
            else return null;
        }

        private bool _AddNewContact()
        {
            this.ID = ContactsDataAccessLayer.Class1.AddNewContact(this.FirstName, this.LastName, this.Email,
                this.Phone, this.Address, this.DateOfBirth, this.CountryID, this.ImagePath);

            return ID != -1;

        }

        private bool _UpdateContact()
        {
            return ContactsDataAccessLayer.Class1.UpdateContact(this.ID, this.FirstName, this.LastName, 
                this.Email, this.Phone, this.Address, this.DateOfBirth, this.CountryID, this.ImagePath);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewContact())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                        return _UpdateContact();  
            }
            return false;
        }

        public static bool DeleteContact(int ContactID)
        {
            return Class1.DeleteContact(ContactID);
        }

        public static DataTable GetAllContacts()
        {
                       return Class1.GetAllContacts();
        }

        public static bool isContactExists(int ContactID)
        {
            return Class1.isContactExists(ContactID);
        }

    }
}
