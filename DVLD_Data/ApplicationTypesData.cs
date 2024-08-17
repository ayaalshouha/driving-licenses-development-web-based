using System;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Data
{
    public class ApplicationTypesData
    {
        public static bool getApplicationTypeInfo(int TypeID, ref Types type)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "select * from ApplicationTypes where ID = @typeID";

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@typeID", TypeID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    isFound = true;
                    type.ID = (int)reader["ID"];
                    type.TypeTitle = (string)reader["Type"];
                    type.Fees = (decimal)reader["Fees"];
                }
                reader.Close();
            }
            catch (Exception e)
            {
                DataSettings.StoreUsingEventLogs(e.Message.ToString());
                //Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static bool Update(Types type)
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
                Command.Parameters.AddWithValue("@Fees", type.Fees);
                Command.Parameters.AddWithValue("@Title", type.TypeTitle);
                

                Connection.Open();
                RowAffected = Command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return RowAffected > 0;
        }
        public static DataTable getAllApplicationTypes()
        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM ApplicationTypes;";
                SqlCommand command = new SqlCommand(Query, Connection);

                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.HasRows)
                {
                    table.Load(reader);
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
                Connection.Close();
            }
            return table;
        }

        public static decimal GetFee(int TypeID)
        { 
            decimal fee = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT Fees From ApplicationTypes 
                        WHERE ID = @TypeID;";


                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@TypeID", TypeID);

                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && decimal.TryParse(result.ToString(), out decimal result_))
                {
                    fee = result_;
                }
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return fee;
        }
    }
}
