using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

public class Class1
{
  

    static void PrintAllContacts()
    {
        
        SqlConnection connection = new SqlConnection("Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;");
        
        string query = "SELECT * FROM Contacts";

        SqlCommand command = new SqlCommand(query, connection);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int ConactID = (int)reader["ContactID"];
                string FirstName = (string)reader["FirstName"];
                string LastName = (string)reader["LastName"];
                string Email = (string)reader["Email"];
                string Phone = (string)reader["Phone"];
                string Address = (string)reader["Address"];
                int CountryID = (int)reader["CountryID"];

                Console.WriteLine($"ContactID: {ConactID}");
                Console.WriteLine($"FirstName: {FirstName}");
                Console.WriteLine($"LastName: {LastName}");
                Console.WriteLine($"Email: {Email}");
                Console.WriteLine($"Phone: {Phone}");
                Console.WriteLine($"Address: {Address}");
                Console.WriteLine($"CountryID: {CountryID}");
                Console.WriteLine();
            }
            connection.Close();
            reader.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Error" + e.Message);
            throw;
        }


    }
  
    struct stContact
    {
       public int ContactID { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string Email { get; set; }
       public string Phone { get; set; }
       public string Address { get; set; }
       public int CountryID { get; set; }
    }

    static void insertContact(stContact contact)
    {

        SqlConnection connection = new SqlConnection("Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;");

        string query = @"INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, CountryID) 
                      VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @CountryID)
                      SELECT SCOPE_IDENTITY()";

       SqlCommand command= new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@FirstName", contact.FirstName);
        command.Parameters.AddWithValue("@LastName", contact.LastName);
        command.Parameters.AddWithValue("@Email", contact.Email);
        command.Parameters.AddWithValue("@Phone", contact.Phone);
        command.Parameters.AddWithValue("@Address", contact.Address);
        command.Parameters.AddWithValue("@CountryID", contact.CountryID);

        try
        {
            connection.Open();

            object result = command.ExecuteScalar();

            if (result != null && int.TryParse(result.ToString(), out int insertedID))
            {
                Console.WriteLine($"New inserted ID: {insertedID}");
            }
            else
            {
                Console.WriteLine("Failed to insert contact.");
            }


        }
        catch (Exception e)
        {
            Console.WriteLine("Error" + e.Message);
            throw;
        }





    }

    static void editContact(int ContactID, stContact contact)
    {

        SqlConnection connection = new SqlConnection("Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;");

        string query = @"UPDATE Contacts
                      SET FirstName = @FirstName
                        ,LastName = @LastName
                        ,Email = @Email
                        ,Phone = @Phone
                        ,Address = @Address
                        ,CountryID = @CountryID
                      WHERE ContactID = @ContactID";

        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@FirstName", contact.FirstName);
        command.Parameters.AddWithValue("@LastName", contact.LastName);
        command.Parameters.AddWithValue("@Email", contact.Email);
        command.Parameters.AddWithValue("@Phone", contact.Phone);
        command.Parameters.AddWithValue("@Address", contact.Address);
        command.Parameters.AddWithValue("@CountryID", contact.CountryID);
        command.Parameters.AddWithValue("@ContactID", ContactID);

        try
        {
            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Contact updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update contact.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error" + e.Message);
            throw;
        }
        finally
        {
            connection.Close();
        }
    }

    static void deleteContact(int ContactID)
    {

        SqlConnection conn = new SqlConnection("Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;");

        string query = @"DELETE FROM Contacts WHERE ContactID = @ContactID";

        SqlCommand cmd = new SqlCommand(query, conn);

        cmd.Parameters.AddWithValue("@ContactID", ContactID);


        try
        {
            conn.Open();

            int rawsAffected = cmd.ExecuteNonQuery();

            if (rawsAffected > 0)
            {
                Console.WriteLine("Contact deleted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to delete contact.");
            }

        }
        catch (Exception)
        {
            throw;
        }



    }





    static void Main(string[] args)
    {
        stContact contact = new stContact
        {
            FirstName = "Jane",
            LastName = "Doe",
            Email = "Joe@gmail.com",
            Phone = "123456789",
            Address = "123 Main St",
            CountryID = 1

        };
        
        insertContact(contact);

        PrintAllContacts();


    }
}
