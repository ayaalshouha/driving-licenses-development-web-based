#pragma warning disable CS8604 // Possible null reference argument
using System;
using Microsoft.Data.SqlClient;
using System.Data;
using DTOsLayer;
using System.Runtime.CompilerServices;
namespace DataLayer
{
    public class Appointments_Data
    {
        public static async Task<Appointment> getAppointmentInfoAsync(int AppointmentID)
        {
            
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "select * from TestAppointments where ID = @ID";

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ID", AppointmentID);

                connection.Open();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    return new Appointment(
                        reader.GetInt32(reader.GetOrdinal("CreateByUserID")),
                        reader.IsDBNull(reader.GetOrdinal("RetakeTestApplicationID")) ? 0 :
                        reader.GetInt32(reader.GetOrdinal("RetakeTestApplicationID")),
                        reader.GetInt32(reader.GetOrdinal("TestTypeID")),
                        reader.GetInt32(reader.GetOrdinal("LocalDrvingLicenseApplicationID")),
                        reader.GetInt32(reader.GetOrdinal("ID")),
                        reader.GetDateTime(reader.GetOrdinal("Date")),
                        reader.GetDecimal(reader.GetOrdinal("PaidFees")),
                        reader.GetBoolean(reader.GetOrdinal("isLocked"))
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
        public static async Task<int> AddAsync(Appointment appointment)
        {
            int newID = 0;
            var Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"INSERT INTO TestAppointments 
                             VALUES (@TestTypeID,@Date,@PaidFees,0, @CreatedByUserID,@LocalDrivingLicenseApplicationIDID,@RetakeTestApplicationID);
                        SELECT SCOPE_IDENTITY();";


                var Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@TestTypeID", appointment.TestType);
                Command.Parameters.AddWithValue("@Date", appointment.Date);
                Command.Parameters.AddWithValue("@PaidFees", appointment.PaidFees);
                Command.Parameters.AddWithValue("@CreatedByUserID", appointment.CreatedByUserID);
                Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationIDID", appointment.LocalLicenseApplicationID);
                if(appointment.RetakeTestID == null)
                {
                    Command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
                }
                else
                {
                    Command.Parameters.AddWithValue("@RetakeTestApplicationID", appointment.RetakeTestID);
                }
                Connection.Open();
                object result = await Command.ExecuteScalarAsync();

                if (result != null && int.TryParse(result.ToString(), out int LastID))
                {
                    newID = LastID;
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

            return newID;
        }
        public static async Task<bool> UpdateAsync(Appointment appointment)
        {
            int RowAffected = 0;
            var Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Update TestAppointments
                SET TestTypeID = @TestTypeID,
                        Date = @Date, 
                        PaidFees = @PaidFees, 
                        isLocked = @isLocked, 
                        CreateByUserID = @CreatedByUserID, 
                        LocalDrvingLicenseApplicationID = @LocalDrvingLicenseApplicationID,
                        RetakeTestApplicationID = @RetakeTestID

                WHERE ID = @AppointmentID;";

                var Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@AppointmentID", appointment.ID);
                Command.Parameters.AddWithValue("@TestTypeID", appointment.TestType);
                Command.Parameters.AddWithValue("@Date", appointment.Date);
                Command.Parameters.AddWithValue("@PaidFees", appointment.PaidFees);
                Command.Parameters.AddWithValue("@isLocked", appointment.isLocked);
                Command.Parameters.AddWithValue("@CreatedByUserID", appointment.CreatedByUserID);
                Command.Parameters.AddWithValue("@LocalDrvingLicenseApplicationID", appointment.LocalLicenseApplicationID);
                if (appointment.RetakeTestID == -1)
                {
                    Command.Parameters.AddWithValue("@RetakeTestID", DBNull.Value);
                }
                else
                {
                    Command.Parameters.AddWithValue("@RetakeTestID", appointment.RetakeTestID);
                }
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
        public static async Task<bool> DeleteAsync(int AppointmentID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM TestAppointments WHERE ID = @TestAppointmentID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@AppointmentID", AppointmentID);
                Connection.Open();
                RowAffected =await command.ExecuteNonQueryAsync();
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
        public static async Task<bool> isExist(int AppointmentID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM TestAppointmentID WHERE ID = @AppointmentID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@AppointmentID", AppointmentID);

                Connection.Open();
                object result = await command.ExecuteScalarAsync();
                isFound = (result != null);
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
            return isFound;
        }
        public static async Task<IEnumerable<Appointement_>> getAppointmentsTablePerTestTypeAsync(int LocalApplicationID,int TestType)
        {
            var table = new List<Appointement_>();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT ID, Date, PaidFees, isLocked 
                                 FROM Appointments_View
                             WHERE (TestTypeID = @TestTypeID) AND
                     (LocalDrvingLicenseApplicationID = @LocalDrvingLicenseApplicationID);"; 

                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@TestTypeID", TestType);
                command.Parameters.AddWithValue("@LocalDrvingLicenseApplicationID", LocalApplicationID);

                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (await reader.ReadAsync())
                {
                    table.Add(new Appointement_(
                        reader.GetInt32(reader.GetOrdinal("ID")),
                        reader.GetDateTime(reader.GetOrdinal("Date")),
                        reader.GetDecimal(reader.GetOrdinal("PaidFees")),
                        reader.GetBoolean(reader.GetOrdinal("isLocked"))
                        ));
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
        public static async Task<int> getTestIDAsync(int AppointmentID)
        {
            int TestID = -1;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string query = @"SELECT ID FROM Tests 
                        WHERE AppointmentID = @AppointmentID";

                SqlCommand command = new SqlCommand(query, Connection);
                command.Parameters.AddWithValue("@AppointmentID", AppointmentID);

                Connection.Open();
                object result = await command.ExecuteScalarAsync(); 

                if(result!=null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    TestID = InsertedID; 
                }
               
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
                //Console.WriteLine("Error: "+ e.Message);

            }
            finally
            {
                Connection.Close(); 
            }
            return TestID;
        }
        public static async Task<bool> isThereAnyActiveAppointmentsAsync(int LocalID, int TestType)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);

            try
            {
                string query = @"SELECT TOP 1 found = 1 From LocalDrivingLicensesApplications 
                                    INNER JOIN TestAppointments 
                            ON TestAppointments.LocalDrvingLicenseApplicationID = LocalDrivingLicensesApplications.ID
                            WHERE (LocalDrivingLicensesApplications.ID = @LocalID)
                            AND (TestAppointments.TestTypeID = @TestType) 
                            AND (TestAppointments.isLocked = 0);";

                SqlCommand command = new SqlCommand(query, Connection);
                command.Parameters.AddWithValue("@LocalID", LocalID);
                command.Parameters.AddWithValue("@TestType", TestType);

                Connection.Open(); 
                object result = await command.ExecuteScalarAsync();

                if(result!= null)
                {
                    isFound = true;
                }
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
                //Console.WriteLine("Error: " +  e.Message);
            }

            finally
            {
                Connection.Close(); 
            }
            return isFound;
        }
    }
}
