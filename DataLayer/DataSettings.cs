using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Diagnostics;

namespace DataLayer
{ 
    public struct stDriver
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public DateOnly CreationDate { get; set; }
        public int CreatedByUserID { get; set; }
    }
   
    public struct stDetainedLicenses
    {
        public int ID { get; set; }
        public int ReleaseApplicationID { get; set; }
        public int LicenseID { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DetainDate { get; set; }
        public bool isReleased { get; set; }
        public decimal FineFees { get; set; }
        public int ReleasedByUserID { get; set; }
        public int CreatedByUserID { get; set; }
    }
  
   
    public struct stInternationalLicenses
    {
        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedByLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpDate { get; set; }
        public bool isActive { get; set; }
        public int CreatedByUserID { get; set; }
    }
    public struct stAppointment
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int TestType { get; set; }
        public decimal PaidFees { get; set; }
        public bool isLocked { get; set; }
        public int CreatedByUserID { get; set; }
        public int LocalLicenseApplicationID { get; set; }
        public int RetakeTestID { get; set; }

    }
    
   
    public class DataSettings
    {
        public static string ConnectionString = "server=.;database=DVLD_Database;user id=sa;password=sa123456;TrustServerCertificate=True;";
        //ConfigurationManager.AppSettings["ConnectionString"]; 
        public static void StoreUsingEventLogs(string message)
        {
            string sourceName = "DVLD_API_App";

            //if (!EventLog.SourceExists(sourceName))
            //    EventLog.CreateEventSource(sourceName, "Application");

            //EventLog.WriteEntry(sourceName, message, EventLogEntryType.Error);

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
