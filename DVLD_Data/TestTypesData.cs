using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class TestTypesData
    {
        public static bool getTestTypeInfo(int TypeID, ref Types type)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "select * from TestTypes where ID = @typeID";

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
                    type.Description = (string)reader["Description"]; 
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
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
                string Query = @"Update TestTypes
                                SET Fees = @Fees, Type = @Title, Description = @Description
                                WHERE ID = @TypeID;";

                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@TypeID", type.ID);
                Command.Parameters.AddWithValue("@Fees", type.Fees);
                Command.Parameters.AddWithValue("@Title", type.TypeTitle);
                Command.Parameters.AddWithValue("@Description", type.Description);

                Connection.Open();
                RowAffected = Command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }

            return RowAffected > 0;
        }
        public static DataTable getAllTestTypes()
        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM TestTypes;";
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
            }
            finally
            {
                Connection.Close();
            }
            return table;
        }

    }
}
