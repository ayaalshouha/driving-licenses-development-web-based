using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Input;

namespace DVLD_Data
{
    public static class UserData
    {
        //user data
        public static bool getUserInfo_ByPersonID(int PersonID, ref stUser User)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT * from Users WHERE PersonID = @PersonID;";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@PersonID", PersonID);

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    isFound = true;
                    User.ID = (int)Reader["ID"];
                    User.PersonID = (int)Reader["PersonID"];
                    User.username = (string)Reader["username"];
                    User.password = (string)Reader["password"]; 
                    User.isActive = Convert.ToBoolean(Reader["isActive"]);
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool getUserInfo_ByID(int UserID, ref stUser User)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT * from Users WHERE ID = @UserID;";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@UserID", UserID);

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    isFound = true;
                    User.ID = (int)Reader["ID"];
                    User.PersonID = (int)Reader["PersonID"];
                    User.username = (string)Reader["username"];
                    User.password = (string)Reader["password"];
                    User.isActive = Convert.ToBoolean(Reader["isActive"]);
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool getUserInfo(string username, ref stUser User)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT * from Users WHERE username = @username;";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@username", username);

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    isFound = true;
                    User.ID = (int)Reader["ID"];
                    User.PersonID = (int)Reader["PersonID"];
                    User.username = (string)Reader["username"];
                    User.password = (string)Reader["password"];
                    User.isActive = Convert.ToBoolean(Reader["isActive"]);
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }
        public static string getUsername(int userID)
        {
            string username = "";
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT username from Users WHERE ID = @userID;";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@userID", userID);

                Connection.Open();
                object result = Command.ExecuteScalar();
                if(result!=null)
                {
                    username = (string)result;
                }
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return username;
        }

        //adding user
        public static int Add(stUser User)
        {
            int newID = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"INSERT INTO Users 
                             VALUES (@PersonID, @username,@password,@isActive);
                        SELECT SCOPE_IDENTITY();"; 
                             

                SqlCommand Command = new SqlCommand(Query, Connection);

                if(User.username == string.Empty)
                    Command.Parameters.AddWithValue("@username",DBNull.Value);
                else 
                    Command.Parameters.AddWithValue("@username", User.username);

                if (User.password == string.Empty)
                    Command.Parameters.AddWithValue("@password", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@password", User.password);


                Command.Parameters.AddWithValue("@isActive", User.isActive);
                Command.Parameters.AddWithValue("@PersonID", User.PersonID);

                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int LastID))
                {
                    newID = LastID;
                }
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }

            return newID;
        }

        public static bool Update(stUser User)
        {
            int RowAffected = 0;

            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Update Users
                    SET username = @username,
                        password = @password, 
                        isActive = @isActive
                   WHERE ID = @UserID;";

                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@UserID", User.ID);
                Command.Parameters.AddWithValue("@username", User.username);
                Command.Parameters.AddWithValue("@password", User.password);
                Command.Parameters.AddWithValue("@isActive", User.isActive);

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

        public static bool Delete(int UserID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM Users WHERE ID = @UserID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@UserID", UserID);
                Connection.Open();
                RowAffected = command.ExecuteNonQuery();
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

        public static bool isExist(int UserID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM Users WHERE ID = @UserID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@UserID", UserID);
                
                Connection.Open();
                object result = command.ExecuteScalar();
                isFound = (result != null);
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool isExist(string username)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM Users WHERE username = @username;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@username", username);

                Connection.Open();
                object result = command.ExecuteScalar();
                isFound = (result != null);
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }
        public static bool isExist(string username, string password)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM Users WHERE username = @username and password = @password;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                Connection.Open();
                object result = command.ExecuteScalar();
                isFound = (result != null);
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }
        public static bool isExist_ByPersonID(int PersonID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM Users WHERE PersonID = @PersonID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                Connection.Open();
                object result = command.ExecuteScalar();
                isFound = (result != null);
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }
        public static DataTable List()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM UsersSummaryData;";
                SqlCommand command = new SqlCommand(Query, Connection);

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }
        public static DataTable ActiveUsersList()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM AvtiveUsers_View;";
                SqlCommand command = new SqlCommand(Query, Connection);

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }
        public static DataTable NonActiveUsersList()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM NonAvtiveUsers_View;";
                SqlCommand command = new SqlCommand(Query, Connection);

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }
    }
}