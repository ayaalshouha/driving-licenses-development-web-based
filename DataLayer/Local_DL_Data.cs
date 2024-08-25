using System;
using System.Data;
using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using DTOsLayer;
using System.Runtime.CompilerServices;

namespace DataLayer
{
    public class Local_DL_Data
    {
        public static async Task<LocalDLApp> getLocalLicenseInfo_ByApplicationIDAsync(int ApplicationID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "select * from LocalDrivingLicensesApplications where ApplicationID = @ApplicationID;";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (await reader.ReadAsync())
                            {
                                return new LocalDLApp
                                    (
                                        reader.GetInt32(reader.GetOrdinal("ID")),
                                        reader.GetInt32(reader.GetOrdinal("ApplicationID")),
                                        reader.GetInt32(reader.GetOrdinal("LicenseClassID"))

                                    );
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
               // Console.WriteLine("Error: " + e.Message);
            }
          
            return null;
        }
        public static async Task<LocalDLApp> getLocalLicenseInfoAsync(int localApplicationID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = @"SELECT * FROM LocalDrivingLicensesApplications
                     WHERE ID = @localApplicationID;";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@localApplicationID", localApplicationID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (await reader.ReadAsync())
                            {
                                return new LocalDLApp
                                   (
                                       reader.GetInt32(reader.GetOrdinal("ID")),
                                       reader.GetInt32(reader.GetOrdinal("ApplicationID")),
                                       reader.GetInt32(reader.GetOrdinal("LicenseClassID"))

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
        public static async Task<int> AddAsync(LocalDLApp application)
        {
            int newID = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {

                    string Query = @"INSERT INTO LocalDrivingLicensesApplications 
                             VALUES (@ApplicationID,@LicenseClassID);
                        SELECT SCOPE_IDENTITY();";

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@ApplicationID", application.ApplicationID);
                        Command.Parameters.AddWithValue("@LicenseClassID", application.LicenseClassID);
                        Connection.Open();
                        object result = await Command.ExecuteScalarAsync();

                        if (result != null && int.TryParse(result.ToString(), out int LastID))
                        {
                            newID = LastID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
            }

            return newID;
        }
        public static async Task<bool> UpdateAsync(LocalDLApp application)
        {
            int RowAffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = @"Update LocalDrivingLicensesApplications
                    SET ApplicationID = @ApplicationID,
                        LicenseClassID = @LicenseClassID
                    WHERE ID = @LocalLicenseID;";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@LocalLicenseID", application.ID);
                        Command.Parameters.AddWithValue("@ApplicationID", application.ApplicationID);
                        Command.Parameters.AddWithValue("@LicenseClassID", application.LicenseClassID);

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
        public static async Task<bool> DeleteAsync(int ApplicationID)
        {
            int RowAffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "DELETE  FROM LocalDrivingLicensesApplications WHERE ID = @LocalLicenseID;";
                    using(SqlCommand command = new SqlCommand(Query, Connection)){
                        command.Parameters.AddWithValue("@LocalLicenseID", ApplicationID);
                        Connection.Open();
                        RowAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
            }
            
            return RowAffected > 0;
        }
        public static async Task<IEnumerable<LocalDLApp_View>> LocalApplicationsViewAsync()
        {
            var table = new List<LocalDLApp_View>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "SELECT * FROM LocalDrivingLicensesApplications_Views;";
                    using(SqlCommand command = new SqlCommand(Query, Connection))
                    {
                        Connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (await reader.ReadAsync())
                        {
                            table.Add
                                (
                                    new LocalDLApp_View(
                                        reader.GetInt32(reader.GetOrdinal("ID")),
                                        reader.GetString(reader.GetOrdinal("NationalID")),
                                        reader.GetString(reader.GetOrdinal("Class")),
                                        reader.GetString(reader.GetOrdinal("FullName")),
                                        DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("Date"))),
                                        reader.GetInt32(reader.GetOrdinal("PassedTestCount")),
                                        reader.GetString(reader.GetOrdinal("Status"))
                                    )
                                ); 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
            }
           
            return table; 
        }
        public static async Task<bool> isRepeatedClassAsync(int PersonID, int LicenseClassID)
        {
            bool isRepeated = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = @"SELECT LicenseClassID FFROM LocalDrivingLicensesApplications 
                        INNER JOIN Applications
                        ON LocalDrivingLicensesApplications.ID = ApplicationID
                        WHERE Applications.PersonID = @PersonID 
                        AND LocalDrivingLicensesApplications.LicenseClassID = @LicenseClassID;";

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@PersonID", PersonID);
                        Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                        Connection.Open();
                        object result = await Command.ExecuteScalarAsync();

                        if (result != null && int.TryParse(result.ToString(), out int result_))
                        {
                            isRepeated = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return isRepeated;
        }       
        public static async Task<IEnumerable<LocalDLApp_View>> New_LocalApplicationsViewAsync()
        {
            IEnumerable<LocalDLApp_View> list = await LocalApplicationsViewAsync();
            return list.Where(E=>E.Status == "New");
        }
        public static async Task<IEnumerable<LocalDLApp_View>> Cancelled_LocalApplicationsViewAsync()
        {
            IEnumerable<LocalDLApp_View> list = await LocalApplicationsViewAsync();
            return list.Where(E => E.Status == "Cancelled");
        }
        public static async Task<IEnumerable<LocalDLApp_View>> Completed_LocalApplicationsViewAsync()
        {
            IEnumerable<LocalDLApp_View> list = await LocalApplicationsViewAsync();
            return list.Where(E => E.Status == "Completed");
        }
        public static async Task<int> getPassedTestCountAsync(int localAppID)
        {
            int Count = 0;
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string query = @"SELECT PassedTestCount FROM LocalDrivingLicensesApplications_Views
                                    WHERE ID = @localAppID;";
                

                SqlCommand Command = new SqlCommand(query, connection);
                Command.Parameters.AddWithValue("@localAppID", localAppID);

                connection.Open();
                object result = await Command.ExecuteScalarAsync();

                if(result!= null && int.TryParse(result.ToString(), out int result2))
                {
                    Count = result2;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
            return Count; 
        }

        public static async Task<bool> DoesItCancelledAsync(int LocalID)
        {
            string StatusText = "";
            bool Cancelled = false;

            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string query = @"SELECT Status FROM LocalDrivingLicensesApplications_Views
                                  WHERE ID = @LocalID;";


                SqlCommand Command = new SqlCommand(query, connection);
                Command.Parameters.AddWithValue("@LocalID", LocalID);

                connection.Open();
                object result = await Command.ExecuteScalarAsync();

                if (result != null)
                {
                    StatusText = result.ToString();

                    if(StatusText == "Cancelled")
                    {
                        Cancelled = true;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
            return Cancelled;
        }

        public static async Task<bool> DoesItCompletedAsync(int LocalID)
        {
            string StatusText = "";
            bool Completed = false;

            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string query = @"SELECT Status FROM LocalDrivingLicensesApplications_Views
                                  WHERE ID = @LocalID;";


                SqlCommand Command = new SqlCommand(query, connection);
                Command.Parameters.AddWithValue("@LocalID", LocalID);

                connection.Open();
                object result = await Command.ExecuteScalarAsync();

                if (result != null)
                {
                    StatusText = result.ToString();

                    if (StatusText == "Completed")
                    {
                        Completed = true;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
            return Completed;
        }

        public static async Task<bool> isTestPassedAsync(int localAppID, int TestType)
        {
            bool testResult = false;
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);

            try
            {
                string query = @"SELECT TOP 1 Result FROM LocalDrivingLicensesApplications 
                                 INNER JOIN TestAppointments 
                ON LocalDrivingLicensesApplications.ID = TestAppointments.LocalDrvingLicenseApplicationID
                                 INNER JOIN Tests 
                         ON Tests.AppointmentID = TestAppointments.ID
                              WHERE (LocalDrivingLicensesApplications.ID = @localAppID) 
                             AND (TestTypeID = @TestType)
                        ORDER BY TestAppointments.ID desc;";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@localAppID", localAppID);
                command.Parameters.AddWithValue("@TestType", TestType);
                connection.Open();

                object result = await command.ExecuteScalarAsync();

                if (result != null && bool.TryParse(result.ToString(), out bool returnedResult))
                {
                    testResult = returnedResult;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
            return testResult;
        }

        public static async Task<bool> DoesAttendTestTypeAsync(int LocalAppID, int TestTypeID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);

            try
            {
                string query = @" SELECT top 1 Found=1 FROM LocalDrivingLicensesApplications 
                            INNER JOIN TestAppointments 
                        ON LocalDrivingLicensesApplications.ID = TestAppointments.LocalDrvingLicenseApplicationID
                            INNER JOIN Tests
                        ON TestAppointments.ID = Tests.AppointmentID
                            WHERE
                            (LocalDrivingLicensesApplications.ID = @LocalAppID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.ID desc";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocalAppID", LocalAppID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                connection.Open();
                object result = await command.ExecuteScalarAsync();

                if (result != null)
                    IsFound = true;
            }

            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
            }

            finally
            {
                connection.Close();
            }
            return IsFound;
        }


    }
}
