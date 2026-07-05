using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace ContactsDataAccessLayer
{
    public class CountriesData
    {
        public static bool getCountryInfoByID(int ID, ref string countryName,ref string Code, ref string PhoneCode)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataBaseAccessInfo.connectionString);

            string query = @"SELECT * FROM Countries WHERE CountryID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    countryName = reader["CountryName"].ToString();
                    if (reader["Code"] != DBNull.Value)
                    {
                        Code = (string)reader["Code"];
                    }
                    else
                    {
                        Code = "";
                    }

                    if (reader["PhoneCode"] != DBNull.Value)
                    {
                        PhoneCode = (string)reader["PhoneCode"];
                    }
                    else
                    {
                        PhoneCode = "";
                    }
                }
                else
                {
                    isFound = false;
                }

                reader.Close();

            }
            catch (Exception e)
            {
                isFound = false;
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return isFound;

        }

        public static bool getCountryInfoByName(string CountryName, ref int ID, ref string Code, ref string PhoneCode)
        {

            SqlConnection connection = new SqlConnection(DataBaseAccessInfo.connectionString);

            string query = @"SELECT * FROM Countries WHERE CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            bool isFound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    ID = Convert.ToInt32(reader["CountryID"]);
                    if (reader["Code"] != DBNull.Value)
                    {
                        Code = (string)reader["Code"];
                    }
                    else
                    {
                        Code = "";
                    }

                    if (reader["PhoneCode"] != DBNull.Value)
                    {
                        PhoneCode = (string)reader["PhoneCode"];
                    }
                    else
                    {
                        PhoneCode = "";
                    }

                }
                else
                {
                    isFound = false;
                }
                reader.Close();

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

        public static bool isCountryExist(int ID)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(DataBaseAccessInfo.connectionString);

            string query = @"SELECT 1 FROM Countries WHERE CountryID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();

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

        public static bool isCountryExist(string CountryName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataBaseAccessInfo.connectionString);

            string query = @"SELECT 1 FROM Countries where CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();

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
    }
}
