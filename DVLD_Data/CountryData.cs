using System;
using System.Data.SqlClient;
using System.Data;

namespace DVLD_Data
{
    public class CountryData
    {
        public enum enGendor { Male = 0, Female = 1 };
        public static bool GetCountryInfoByID(int ID, ref string CountryName)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                
                string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";

                SqlCommand command = new SqlCommand(query, connection);
                 command.Parameters.AddWithValue("@CountryID", ID);
           
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    CountryName = (string)reader["CountryName"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static bool GetCountryInfoByName(string CountryName, ref int ID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string query = "SELECT * FROM Countries WHERE CountryName = @CountryName";

                SqlCommand command = new SqlCommand(query, connection);
               command.Parameters.AddWithValue("@CountryName", CountryName);
            
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    ID = (int)reader["CountryID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static DataTable GetAllCountries()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string query = "SELECT nicename FROM Countries";
               SqlCommand command = new SqlCommand(query, connection);
           
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
    }
}