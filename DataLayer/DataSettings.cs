#pragma warning disable CS8604 // Possible null reference argument
using Microsoft.Data.SqlClient;
using System.Data.Common;
using Microsoft.Extensions.Logging;


namespace DataLayer
{ 
    public class DataSettings
    {
       
        public static string ConnectionString = "server=.;database=DVLD_Database;user id=sa;password=sa123456;TrustServerCertificate=True;";

        private static ILogger<DataSettings> _logger;
        // Static method to initialize the logger
        public static void ConfigureLogger(ILogger<DataSettings> logger)
        {
            _logger = logger;
        }
        public static void LogError(string message)
        {
            if (_logger == null)
            {
                throw new InvalidOperationException("Logger is not initialized. Call ConfigureLogger first.");
            }

            _logger.LogError(message);
        }

    //select if user isActive or NOT.
        public static bool Authintication(string username, string password)
        {
            bool isActive = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT isActive from Users WHERE username = @username and password = @password;";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@username", username);
                Command.Parameters.AddWithValue("@password", password);

                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && Boolean.TryParse(result.ToString(), out bool ActiveResult))
                {
                    isActive = ActiveResult;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return isActive;
        }
        
        public static bool SaveLoginRecord(int UserID)
        {
            int RowAffected = 0;
            DateTime recordTime = DateTime.Now;

            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);

            try
            {
                string Query = "INSERT INTO LoginRecords VALUES (@UserID, @DateTime);";
                SqlCommand command = new SqlCommand(Query, connection);

                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@DateTime", recordTime);
                connection.Open();
                RowAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return RowAffected > 0;
        }
       
    }
}
