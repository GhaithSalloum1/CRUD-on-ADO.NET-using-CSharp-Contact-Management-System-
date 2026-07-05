using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Data;

namespace ContactsDataAccessLayer
{
    public class ContactsData
    {


        public static bool GetContactByID(int ContactID, ref string FirstName, ref string LastName, ref string Email
            , ref string Phone, ref string Address, ref DateTime DateOfBirth, ref int CountryID, ref string ImagePath)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataBaseAccessInfo.connectionString);

            string query = "Select * From Contacts Where ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", ContactID);

            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;

                    FirstName = Reader["FirstName"].ToString();
                    LastName = Reader["LastName"].ToString();
                    Email = Reader["Email"].ToString();
                    Phone = Reader["Phone"].ToString();
                    Address = Reader["Address"].ToString();
                    DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                    CountryID = Convert.ToInt32(Reader["CountryID"]);

                    if (Reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = Reader["ImagePath"].ToString();
                    }
                    else
                    {
                        ImagePath = "";
                    }

                }
                else
                {
                    isFound = false;
                }

                Reader.Close(); 


            }
            catch (Exception)
            {
                isFound = false;
                throw;
            }
            finally
            {
                connection.Close();
            }
            return isFound;

        }

        public static int AddNewContact(string FirstName, string LastName, string Email, string Phone, string Address, DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            int ContactID = -1;

            SqlConnection connection = new SqlConnection(DataBaseAccessInfo.connectionString);

            string query = "Insert Into Contacts (FirstName, LastName, Email, Phone, Address, DateOfBirth, CountryID, ImagePath) " +
                "Values (@FirstName, @LastName, @Email, @Phone, @Address, @DateOfBirth, @CountryID, @ImagePath); " +
                "Select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    ContactID = InsertedID;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }


            return ContactID;


        }
    
        public static bool UpdateContact(int ID,string FirstName, string LastName, string Email, string Phone, string Address, DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataBaseAccessInfo.connectionString);

            string query = @"UPDATE Contacts 
                            SET FirstName = @FirstName
                             ,LastName = @LastName
                             ,Email = @Email
                             ,Phone = @Phone
                             ,Address = @Address
                             ,DateOfBirth = @DateOfBirth
                             ,CountryID = @CountryID
                             ,ImagePath = @ImagePath
                        WHERE ContactID = @ContactID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@CountryID", CountryID);
            cmd.Parameters.AddWithValue("@ContactID", ID);

            if(ImagePath != "")
            { 
            cmd.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
            cmd.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }

                try
                {
                    connection.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    connection.Close();
                }

            return rowsAffected > 0;
        }
   
        public static bool DeleteContact(int ContactID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataBaseAccessInfo.connectionString);

            string query = @"DELETE FROM Contacts WHERE ContactID = @ContactID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ContactID", ContactID);

            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        public static DataTable GetAllContacts()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataBaseAccessInfo.connectionString);

            string query = "SELECT * FROM Contacts";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static bool isContactExists(int ContactID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(DataBaseAccessInfo.connectionString);

            string query = @"SELECT 1 FROM Contacts Where ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", ContactID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                isExist = reader.HasRows;  

                reader.Close();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }

            return isExist;
        }

    }
}
