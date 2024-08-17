using System;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Data
{
    public class Local_DL_Data
    {
        public static bool getLocalLicenseInfo_ByApplicationID(int ApplicationID, ref stLocalDrivingLicensesApplication application)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "select * from LocalDrivingLicensesApplications where ApplicationID = @ApplicationID;";

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    isFound = true;
                    application.ID = (int)reader["ID"];
                    application.ApplicationID = (int)reader["ApplicationID"];
                    application.LicenseClassID = (int)reader["LicenseClassID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
               // Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static bool getLocalLicenseInfo(int localApplicationID, ref stLocalDrivingLicensesApplication application)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT * FROM LocalDrivingLicensesApplications
                     WHERE ID = @localApplicationID;";

                SqlCommand command = new SqlCommand(Query, connection);

                command.Parameters.AddWithValue("@localApplicationID", localApplicationID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    isFound = true;
                    application.ID = (int)reader["ID"];
                    application.ApplicationID = (int)reader["ApplicationID"];
                    application.LicenseClassID = (int)reader["LicenseClassID"];
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
        public static int Add(stLocalDrivingLicensesApplication application)
        {
            int newID = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"INSERT INTO LocalDrivingLicensesApplications 
                             VALUES (@ApplicationID,@LicenseClassID);
                        SELECT SCOPE_IDENTITY();";


                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@ApplicationID", application.ApplicationID);
                Command.Parameters.AddWithValue("@LicenseClassID", application.LicenseClassID);
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

        public static bool Update(stLocalDrivingLicensesApplication application)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Update LocalDrivingLicensesApplications
                SET ApplicationID = @ApplicationID,
                        LicenseClassID = @LicenseClassID
                WHERE ID = @LocalLicenseID;";

                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@LocalLicenseID", application.ID);
                Command.Parameters.AddWithValue("@ApplicationID", application.ApplicationID);
                Command.Parameters.AddWithValue("@LicenseClassID", application.LicenseClassID);
               
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
        public static bool Delete(int ApplicationID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM LocalDrivingLicensesApplications WHERE ID = @LocalLicenseID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@LocalLicenseID", ApplicationID);
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

        public static DataTable LocalApplicationsView()
        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM LocalDrivingLicensesApplications_Views;";
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

        public static bool isRepeatedClass(int PersonID, int LicenseClassID)
        {
            bool isRepeated = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);

            try
            {
                string Query = @"SELECT LicenseClassID FFROM LocalDrivingLicensesApplications 
                        INNER JOIN Applications
                        ON LocalDrivingLicensesApplications.ID = ApplicationID
                        WHERE Applications.PersonID = @PersonID 
                        AND LocalDrivingLicensesApplications.LicenseClassID = @LicenseClassID;";
                            

                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@PersonID", PersonID);
                Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int result_))
                {
                    isRepeated=true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Connection.Close();
            }

            return isRepeated;
        }

        public static DataTable New_LocalApplicationsView()
        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM New_LocalDrivingLicensesApplications_Views;";
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
        public static DataTable Cancelled_LocalApplicationsView()
        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM Cancelled_LocalDrivingLicensesApplications_Views;";
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

        public static DataTable Completed_LocalApplicationsView()
        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM Completed_LocalDrivingLicensesApplications_Views;";
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

        public static int getPassedTestCount(int localAppID)
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
                object result = Command.ExecuteScalar();

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

        public static bool DoesItCancelled(int LocalID)
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
                object result = Command.ExecuteScalar();

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

        public static bool DoesItCompleted(int LocalID)
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
                object result = Command.ExecuteScalar();

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

        public static bool isTestPassed(int localAppID, int TestType)
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

                object result = command.ExecuteScalar();

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

        public static bool DoesAttendTestType(int LocalAppID, int TestTypeID)
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
                object result = command.ExecuteScalar();

                if (result != null)
                    IsFound = true;
            }

            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }

            finally
            {
                connection.Close();
            }
            return IsFound;
        }


    }
}
