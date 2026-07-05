using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ContactsBusinessLayer;
using System.Threading.Tasks;

namespace Contacts_PresentationLayer
{
    internal class Program
    {
        
        static void testFindContact(int contactID)
        {
            clsContact C1 = ContactsBusinessLayer.clsContact.Find(contactID);

            if (C1 != null)
            {
                Console.WriteLine("Contact ID: " + C1.ID);
                Console.WriteLine("Full Name: " + C1.FirstName + C1.LastName);
                Console.WriteLine("Email: " + C1.Email);
                Console.WriteLine("Phone: " + C1.Phone);
                Console.WriteLine("Image Path: " + C1.ImagePath);
                Console.WriteLine("Country ID: " + C1.CountryID);
            }
            else
            {
                Console.WriteLine("Contact " + contactID + " not found.");
            }

        }
        
        static void testAddNewContact()
        {
            clsContact C1 = new clsContact();

            C1.FirstName = "Mohammad Ghaith";
            C1.LastName = "Salloum";
            C1.Email = "G@email.com";
            C1.Phone = "12345";
            C1.Address = "WhateverAddress";
            C1.DateOfBirth = new DateTime(2004, 3, 7, 10, 30, 0);
            C1.CountryID = 1;
            C1.ImagePath = "";

            if (C1.Save())
            {
                Console.WriteLine("Contact with the ID " + C1.ID + " Added Successfully!");
            }


        }
        
        static void testUpdateContact(int ID)
        {
            clsContact C1 = ContactsBusinessLayer.clsContact.Find(ID);

            C1.FirstName = "Mohammad Ghaith";
            C1.LastName = "Salloum";
            C1.Email = "G@email.com";
            C1.Phone = "12345";
            C1.Address = "WhateverAddress";
            C1.DateOfBirth = new DateTime(2004, 3, 7, 10, 30, 0);
            C1.CountryID = 1;
            C1.ImagePath = "";

            if (C1.Save())
            {
                Console.WriteLine("Contact Updated Successfully!");
            }

        }

        static void testDeleteContact(int ID)
        {
            if (clsContact.DeleteContact(ID))

                Console.WriteLine("Contact Deleted Successfully. ");
            else
                Console.WriteLine("Faild to delete contact.");
        }

        static void testGetAllContacts() {

            DataTable dt = clsContact.GetAllContacts();

        Console.WriteLine("Contacts Data: ");

            foreach (DataRow row in dt.Rows){
                Console.WriteLine($"{row["ContactID"]}, {row["FirstName"]}, {row["LastName"]}");
            }
        
        
        
        }
        
        static void isContactExist(int ID)
        {
            if (clsContact.isContactExists(ID))
                Console.WriteLine("Contact Exists.");
            else
                Console.WriteLine("Contact Does Not Exist.");
        }

        static void testFindCountryByID(int ID)

        {
            clsCountry Country1 = clsCountry.Find(ID);

            if (Country1 != null)
            {
                Console.WriteLine(Country1.CountryName);

            }

            else
            {
                Console.WriteLine("Country [" + ID + "] Not found!");
            }
        }


        static void testFindCountryByName(string CountryName)

        {
            clsCountry Country1 = clsCountry.Find(CountryName);

            if (Country1 != null)
            {
                Console.WriteLine("Country [" + CountryName + "] isFound with ID = " + Country1.ID);

            }

            else
            {
                Console.WriteLine("Country [" + CountryName + "] Is Not found!");
            }
        }


        static void testIsCountryExistByID(int ID)

        {

            if (clsCountry.isCountryExist(ID))

                Console.WriteLine("Yes, Country is there.");

            else
                Console.WriteLine("No, Country Is not there.");

        }

        static void testIsCountryExistByName(string CountryName)

        {

            if (clsCountry.isCountryExist(CountryName))

                Console.WriteLine("Yes, Country is there.");

            else
                Console.WriteLine("No, Country Is not there.");

        }

        static void ListCountries()
        {

            DataTable dataTable = clsCountry.GetAllCountries();

            Console.WriteLine("Coutries Data:");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["CountryID"]},  {row["CountryName"]} , {row["Code"]}, {row["PhoneCode"]}");
            }

        }

        static void Main(string[] args)
        {

            //testFindCountryByID(1);
            //testFindCountryByID(100);
            //testFindCountryByName("United States");
            //testFindCountryByName("UK");

            //testIsCountryExistByID(1);
            //testIsCountryExistByID(100);

            //testIsCountryExistByName("United States");
            //testIsCountryExistByName("UK"); 

            ListCountries();

            Console.ReadKey();

        }
    }
}
