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

        static void Main(string[] args)
        {

            isContactExist(1);
            isContactExist(100);
            Console.ReadKey();

        }
    }
}
