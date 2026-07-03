using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using ContactsBusinessLayer;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;


namespace Contacts_PresentationLayer
{
    public class Class1
    {

        static void testFindContact(int contactID)
        {
            clsContact C1 = ContactsBusinessLayer.Class1.Find(contactID);

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

        static void Main(string[] args)
        {
            testFindContact(55);

            Console.ReadKey();
        }


    }


}
       
    
