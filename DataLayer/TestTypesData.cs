using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOsLayer;
using System.Runtime.CompilerServices;

namespace DataLayer
{
    public class TestTypesData
    {
        public static async Task<TestType> getTestTypeInfoAsync(int TypeID)
        {
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "select * from TestTypes where ID = @typeID";

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@typeID", TypeID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    return new TestType(
                            reader.GetInt32(reader.GetOrdinal("ID")),
                            reader.GetString(reader.GetOrdinal("Type")),
                            reader.GetDecimal(reader.GetOrdinal("Fees")),
                            reader.GetString(reader.GetOrdinal("Description"))
                        ); 
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
                //Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
           
            return null;
        }

        public static async Task<int> AddAsync(TestType type)
        {
            int newID = 0;
            using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
            {
                string Query = @"INSERT INTO ApplicationTypes 
                             VALUES (@TypeTitle,@Fee, @Desc);
                        SELECT SCOPE_IDENTITY();";

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@TypeTitle", type.TypeTitle);
                    Command.Parameters.AddWithValue("@Fee", type.Fees);
                    Command.Parameters.AddWithValue("@Desc", type.Description);
                    Connection.Open();
                    object result = await Command.ExecuteScalarAsync();

                    if (result != null && int.TryParse(result.ToString(), out int LastID))
                    {
                        newID = LastID;
                    }
                }
            }
            return newID;
        }
        public static async Task<bool> UpdateAsync(TestType type)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Update TestTypes
                                SET Fees = @Fees, Type = @Title, Description = @Description
                                WHERE ID = @TypeID;";

                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@TypeID", type.ID);
                Command.Parameters.AddWithValue("@Fees", type.Fees);
                Command.Parameters.AddWithValue("@Title", type.TypeTitle);
                Command.Parameters.AddWithValue("@Description", type.Description);

                Connection.Open();
                RowAffected = await Command.ExecuteNonQueryAsync();
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
        public static async Task<IEnumerable<TestType>> getAllTestTypesAsync()
        {
            var table = new List<TestType>();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM TestTypes;";
                SqlCommand command = new SqlCommand(Query, Connection);

                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (await reader.ReadAsync())
                {
                    table.Add(
                            new TestType(
                                reader.GetInt32(reader.GetOrdinal("ID")),
                                reader.GetString(reader.GetOrdinal("Type")),
                                reader.GetDecimal(reader.GetOrdinal("Fees")),
                                reader.GetString(reader.GetOrdinal("Description")))
                        );
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return table;
        }

    }
}
