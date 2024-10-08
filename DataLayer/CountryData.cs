﻿#pragma warning disable CS8604 // Possible null reference argument
using System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataLayer 
{
    //TODO Make async
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
                DataSettings.LogError(ex.Message.ToString());
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
                DataSettings.LogError(ex.Message.ToString());
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static List<string> GetAllCountries()
        {
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            List<string> Countries = new List<string>();
            try
            {
                string Query = "SELECT nicename From Countries;";
                SqlCommand command = new SqlCommand(Query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Countries.Add(reader["nicename"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return Countries;
        }
    }
}