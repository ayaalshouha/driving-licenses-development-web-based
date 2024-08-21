using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Input;
using DTOsLayer;

namespace DataLayer
{
    public static class UserData
    {
        public static User getUserInfo_ByPersonID(int PersonID)
        {
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
                    return new User(
                        Reader.GetInt32(Reader.GetOrdinal("ID")),
                        Reader.GetString(Reader.GetOrdinal("username")),
                        Reader.GetString(Reader.GetOrdinal("password")),
                        Reader.GetBoolean(Reader.GetOrdinal("isActive")),
                        Reader.GetInt32(Reader.GetOrdinal("PersonID"))
                        );
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
               // DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return null;
        }
        public static User getUserInfo_ByID(int UserID)
        {
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
                    return new User(
                         Reader.GetInt32(Reader.GetOrdinal("ID")),
                         Reader.GetString(Reader.GetOrdinal("username")),
                         Reader.GetString(Reader.GetOrdinal("password")),
                         Reader.GetBoolean(Reader.GetOrdinal("isActive")),
                         Reader.GetInt32(Reader.GetOrdinal("PersonID"))
                         );
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
               // DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return null;
        }
        public static User getUserInfo(string username)
        {
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
                    return new User(
                         Reader.GetInt32(Reader.GetOrdinal("ID")),
                         Reader.GetString(Reader.GetOrdinal("username")),
                         Reader.GetString(Reader.GetOrdinal("password")),
                         Reader.GetBoolean(Reader.GetOrdinal("isActive")),
                         Reader.GetInt32(Reader.GetOrdinal("PersonID"))
                         );
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
               // DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return null;
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
                if (result != null)
                {
                    username = (string)result;
                }
            }
            catch (Exception ex)
            {
               // DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return username;
        }
        public static int Add(User user)
        {
            int newID = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"INSERT INTO Users 
                             VALUES (@PersonID, @username,@password,@isActive);
                        SELECT SCOPE_IDENTITY();";


                SqlCommand Command = new SqlCommand(Query, Connection);

                if (user.username == string.Empty)
                    Command.Parameters.AddWithValue("@username", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@username", user.username);

                if (user.password == string.Empty)
                    Command.Parameters.AddWithValue("@password", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@password", user.password);


                Command.Parameters.AddWithValue("@isActive", user.isActive);
                Command.Parameters.AddWithValue("@PersonID", user.PersonID);

                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int LastID))
                {
                    newID = LastID;
                }
            }
            catch (Exception ex)
            {
              //  DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }

            return newID;
        }
        public static bool Update(User user)
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
                Command.Parameters.AddWithValue("@UserID", user.ID);
                Command.Parameters.AddWithValue("@username", user.username);
                Command.Parameters.AddWithValue("@password", user.password);
                Command.Parameters.AddWithValue("@isActive", user.isActive);

                Connection.Open();
                RowAffected = Command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
               // DataSettings.StoreUsingEventLogs(ex.Message.ToString());
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
               // DataSettings.StoreUsingEventLogs(ex.Message.ToString());
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
               // DataSettings.StoreUsingEventLogs(ex.Message.ToString());
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
             //   DataSettings.StoreUsingEventLogs(ex.Message.ToString());
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
               // DataSettings.StoreUsingEventLogs(ex.Message.ToString());
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
                //DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }
        public static List<UserSummery> List()
        {
            var UsersList = new List<UserSummery>();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM UsersSummaryData;";
                SqlCommand command = new SqlCommand(Query, Connection);

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    UsersList.Add(new UserSummery
                       (
                            Reader.GetInt32(Reader.GetOrdinal("ID")),
                            Reader.GetInt32(Reader.GetOrdinal("PersonID")),
                            Reader.GetString(Reader.GetOrdinal("FullName")),
                            Reader.GetString(Reader.GetOrdinal("username")),
                            Reader.GetBoolean(Reader.GetOrdinal("isActive"))
                       ));
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                //DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return UsersList;
        }
        public static List<User> ActiveUsersList()
        {
            var UsersList = new List<User>();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM AvtiveUsers_View;";
                SqlCommand command = new SqlCommand(Query, Connection);

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    UsersList.Add(new User
                       (
                            Reader.GetInt32(Reader.GetOrdinal("ID")),
                            Reader.GetString(Reader.GetOrdinal("username")),
                            Reader.GetString(Reader.GetOrdinal("password")),
                            Reader.GetBoolean(Reader.GetOrdinal("isActive")),
                            Reader.GetInt32(Reader.GetOrdinal("PersonID"))
                       ));
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                //DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return UsersList;
        }
        public static List<User> NonActiveUsersList()
        {
            var UsersList = new List<User>();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM NonAvtiveUsers_View;";
                SqlCommand command = new SqlCommand(Query, Connection);

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    UsersList.Add(new User
                       (
                            Reader.GetInt32(Reader.GetOrdinal("ID")),
                            Reader.GetString(Reader.GetOrdinal("username")),
                            Reader.GetString(Reader.GetOrdinal("password")),
                            Reader.GetBoolean(Reader.GetOrdinal("isActive")),
                            Reader.GetInt32(Reader.GetOrdinal("PersonID"))
                       ));
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                //DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return UsersList;
        }

    }
}