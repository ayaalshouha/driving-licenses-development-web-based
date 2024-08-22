using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using DTOsLayer;

namespace DataLayer
{
    public class LicenseClassesData
    {
        public static async Task<LicenseClass> getClassInfoAsync(int ClassID) 
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "select * from LicenseClasses where ID = @ClassID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@ClassID", ClassID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (await reader.ReadAsync())
                            {
                                return new LicenseClass
                                    (
                                        reader.GetInt32(reader.GetOrdinal("ID")),
                                        reader.GetString(reader.GetOrdinal("Class")),
                                        reader.GetString(reader.GetOrdinal("Description")),
                                        reader.GetDecimal(reader.GetOrdinal("Fees")),
                                        reader.GetByte(reader.GetOrdinal("MinimumAgeAllowed")),
                                        reader.GetByte(reader.GetOrdinal("ValidityYears"))
                                    );
                            }
                        }
                    }
                }  
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
                //Console.WriteLine("Error: " + e.Message);
            }
            return null;
        }
        public static async Task<bool> UpdateAsync(LicenseClass Class_)
        {
            int RowAffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {

                    string Query = @"Update LicenseClasses
                                SET Fees = @Fees
                                WHERE ID = @licenseID;";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@licenseID", Class_.ID);
                        Command.Parameters.AddWithValue("@Fees", Class_.Fees);
                        Connection.Open();
                        RowAffected = await Command.ExecuteNonQueryAsync();
                    }
                }
            }

            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }

            return RowAffected > 0;
        }
        public static async Task<List<string>> getAllClassesNameAsync()
        {
            List<string> list = new List<string>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "select Class from LicenseClasses;";
                    using (SqlCommand command = new SqlCommand(Query, Connection))
                    {
                        Connection.Open();
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (await reader.ReadAsync())
                            {
                                list.Add(reader["Class"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            return list;
        }
    }
}
