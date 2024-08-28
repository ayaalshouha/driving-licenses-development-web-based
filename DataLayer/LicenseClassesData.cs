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
        public static LicenseClass getClassInfo(int ClassID)
        {
            return getClassInfoAsync(ClassID).GetAwaiter().GetResult(); 
        }
        public static async Task<LicenseClass> getClassInfoAsync(int ClassID) 
        {
            try
            {
                using (var connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "select * from LicenseClasses where ID = @ClassID";
                    using (var command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@ClassID", ClassID);
                        connection.Open();
                        using (var reader = command.ExecuteReader())
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
                DataSettings.LogError(ex.Message.ToString());
                //Console.WriteLine("Error: " + e.Message);
            }
            return null;
        }
        public static async Task<int> AddAsync(LicenseClass licenseClass)
        {
            int newID = 0;
            var Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"INSERT INTO LicenseClasses 
                             VALUES (@ClassName,@MinAgeAllowed, @ValidityYears, @fee, @description);
                        SELECT SCOPE_IDENTITY();";


                var Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@ClassName", licenseClass.ClassName);
                Command.Parameters.AddWithValue("@MinAgeAllowed", licenseClass.MinAgeAllowed);
                Command.Parameters.AddWithValue("@ValidityYears", licenseClass.ValidityYears);
                Command.Parameters.AddWithValue("@fee", licenseClass.Fees);
                Command.Parameters.AddWithValue("@description", licenseClass.Description);
                
                Connection.Open();
                object result = await Command.ExecuteScalarAsync();

                if (result != null && int.TryParse(result.ToString(), out int LastID))
                {
                    newID = LastID;
                }
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return newID;
        }
        public static async Task<bool> UpdateAsync(LicenseClass Class_)
        {
            int RowAffected = 0;
            try
            {
                using (var Connection = new SqlConnection(DataSettings.ConnectionString))
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
                DataSettings.LogError(ex.Message.ToString());
            }

            return RowAffected > 0;
        }
        public static async Task<List<string>> getAllClassesNameAsync()
        {
            List<string> list = new List<string>();
            try
            {
                using (var Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "select Class from LicenseClasses;";
                    using (var command = new SqlCommand(Query, Connection))
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
                DataSettings.LogError(ex.Message.ToString());
            }
            return list;
        }
        public static async Task<IEnumerable<LicenseClass>> AllAsync()
        {
            var list = new List<LicenseClass>();
            try
            {
                using (var Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "select * from LicenseClasses;";
                    using (var command = new SqlCommand(Query, Connection))
                    {
                        Connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (await reader.ReadAsync())
                            {
                                list.Add(new LicenseClass (
                                        reader.GetInt32(reader.GetOrdinal("ID")),
                                        reader.GetString(reader.GetOrdinal("Class")),
                                        reader.GetString(reader.GetOrdinal("Description")),
                                        reader.GetDecimal(reader.GetOrdinal("Fees")),
                                        reader.GetByte(reader.GetOrdinal("MinimumAgeAllowed")),
                                        reader.GetByte(reader.GetOrdinal("ValidityYears"))
                                    ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
            }
            return list;
        }
        public static async Task<bool> isExistAsync(int classID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM LicenseClasses WHERE ID = @classID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@classID", classID);

                Connection.Open();
                object result = await command.ExecuteScalarAsync();
                isFound = (result != null);
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }
        public static async Task<bool> DeleteAsync(int classID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM LicenseClasses WHERE classID = @classID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@classID", classID);
                Connection.Open();
                RowAffected = await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return RowAffected > 0;
        }
    
    }
}
