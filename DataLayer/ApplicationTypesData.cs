using System;
using System.Data;
using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using DTOsLayer; 

namespace DataLayer
{
    public class ApplicationTypesData
    {
        public static async Task<ApplicationType> getApplicationTypeInfoAsync(int TypeID)
        {
            var connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "select * from ApplicationTypes where ID = @typeID";

                var command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@typeID", TypeID);

                connection.Open();
                var reader = command.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    return new ApplicationType(
                            reader.GetInt32(reader.GetOrdinal("ID")),
                             reader.GetString(reader.GetOrdinal("Type")),
                              reader.GetDecimal(reader.GetOrdinal("Fees"))
                        );
                }
                reader.Close();
            }
            catch (Exception e)
            {
                DataSettings.LogError(e.Message.ToString());
                //Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
            return null;
        }
        public static async Task<bool> UpdateAsync(ApplicationType type)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Update ApplicationTypes
                                SET Fees = @Fees, Type = @Title
                                WHERE ID = @TypeID;";

                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@TypeID", type.ID);
                Command.Parameters.AddWithValue("@Fees", type.TypeFee);
                Command.Parameters.AddWithValue("@Title", type.TypeTitle);
                

                Connection.Open();
                RowAffected = await Command.ExecuteNonQueryAsync();
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

            return RowAffected > 0;
        }
        public static async Task<IEnumerable<ApplicationType>> getAllApplicationTypesAsync()
        {
            var table = new List<ApplicationType>();
            var Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM ApplicationTypes;";
                var command = new SqlCommand(Query, Connection);

                Connection.Open();
                var reader = command.ExecuteReader();

                while (await reader.ReadAsync())
                {
                    table.Add(
                        new ApplicationType(
                            reader.GetInt32(reader.GetOrdinal("ID")),
                            reader.GetString(reader.GetOrdinal("Type")),
                            reader.GetDecimal(reader.GetOrdinal("Fees"))
                              )
                        );
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
                Connection.Close();
            }
            return table;
        }
        public static async Task<decimal> GetFeeAsync(int TypeID)
        { 
            decimal fee = 0;
            var Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT Fees From ApplicationTypes 
                        WHERE ID = @TypeID;";


                var Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@TypeID", TypeID);

                Connection.Open();
                object result = await Command.ExecuteScalarAsync();

                if (result != null && decimal.TryParse(result.ToString(), out decimal result_))
                {
                    fee = result_;
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

            return fee;
        }
        public static async Task<bool> isExistAsync(int typeID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM ApplicationTypes WHERE ID = @typeID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@typeID", typeID);

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
        public static async Task<bool> DeleteAsync(int typeID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM ApplicationTypes WHERE ID = @typeID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@typeID", typeID);
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
