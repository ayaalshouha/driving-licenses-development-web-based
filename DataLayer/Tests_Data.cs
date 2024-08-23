using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.CompilerServices;
using DTOsLayer; 

namespace DataLayer
{
    public class Tests_Data
    {
        public static async Task<Test> getTestInfoAsync(int TestID)
        {
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "select * from Tests where ID = @ID";

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ID", TestID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    return new Test(
                             reader.GetInt32(reader.GetOrdinal("ID")),
                            reader.GetInt32(reader.GetOrdinal("AppointmentID")),
                            reader.GetBoolean(reader.GetOrdinal("Result")),
                            reader.GetString(reader.GetOrdinal("Notes")),
                            reader.GetInt32(reader.GetOrdinal("CreatedByUserID"))
                        );
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
            return null;
        }
        public static async Task<Test> GetLastTestPerTestTypeAsync(int PersonID, int ClassID, int TestType)
        {
            
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT Tests.ID, Tests.AppointmentID, Tests.Result, Tests.CreateByUserID, Tests.Notes
                        FROM LocalDrivingLicensesApplications 
                    INNER JOIN Tests 
                    INNER JOIN TestAppointments 
					    ON Tests.AppointmentID = TestAppointments.ID
				    	ON TestAppointments.LocalDrvingLicenseApplicationID = LocalDrivingLicensesApplications.ID
					INNER JOIN Applications 
                        ON Applications.ID = LocalDrivingLicensesApplications.ApplicationID
					WHERE (Applications.PersonID = @PersonID)
					   AND  (TestAppointments.TestTypeID = @TestType)
					   AND  (LocalDrivingLicensesApplications.LicenseClassID = @ClassID)
					Order by Tests.AppointmentID desc; ";

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@ClassID", ClassID);
                command.Parameters.AddWithValue("@TestType", TestType);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    return new Test(
                            reader.GetInt32(reader.GetOrdinal("ID")),
                           reader.GetInt32(reader.GetOrdinal("AppointmentID")),
                           reader.GetBoolean(reader.GetOrdinal("Result")),
                           reader.GetString(reader.GetOrdinal("Notes")),
                           reader.GetInt32(reader.GetOrdinal("CreatedByUserID"))
                       );
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
            return null;

        }
        public static async Task<int> AddAsync(Test test)
        {
            int newID = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"INSERT INTO Tests 
                             VALUES (@AppointmentID,@Result,@Notes,@CreatedByUserID);

                            UPDATE TestAppointments 
                                SET isLocked=1 where ID = @AppointmentID;
                        SELECT SCOPE_IDENTITY();";


                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@AppointmentID", test.AppointmentID);
                Command.Parameters.AddWithValue("@Result", test.Result);
                Command.Parameters.AddWithValue("@Notes", test.Notes);
                Command.Parameters.AddWithValue("@CreatedByUserID", test.CreatedByUserID);
            
                Connection.Open();
                object result = await Command.ExecuteScalarAsync();

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
        public static async Task<bool> UpdateAsync(Test test)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Update TestAppointments
                SET AppointmentID = @AppointmentID,
                        Result = @Result, 
                        Notes = @Notes, 
                        CreatedByUserID = @CreatedByUserID, 

                WHERE ID = @testID;";

                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@testID", test.ID);
                Command.Parameters.AddWithValue("@AppointmentID", test.AppointmentID);
                Command.Parameters.AddWithValue("@Result", test.Result);
                Command.Parameters.AddWithValue("@Notes", test.Notes);

                Connection.Open();
                RowAffected = await Command.ExecuteNonQueryAsync();
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
        public static async Task<bool> DeleteAsync(int testID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM Tests WHERE ID = @testID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@testID", testID);
                Connection.Open();
                RowAffected = await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                //DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return RowAffected > 0;
        }
        public static async Task<bool> isExistAsync(int testID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM Tests WHERE ID = @testID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@testID", testID);

                Connection.Open();
                object result = await command.ExecuteScalarAsync();
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
        public static async Task<IEnumerable<Test>> getTestsTableAsync() 
        {
            var table = new List<Test>();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM Tests;";
                SqlCommand command = new SqlCommand(Query, Connection);

                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (await reader.ReadAsync())
                {
                    table.Add(
                        new Test(
                             reader.GetInt32(reader.GetOrdinal("ID")),
                            reader.GetInt32(reader.GetOrdinal("AppointmentID")),
                            reader.GetBoolean(reader.GetOrdinal("Result")),
                            reader.GetString(reader.GetOrdinal("Notes")),
                            reader.GetInt32(reader.GetOrdinal("CreatedByUserID"))
                        ));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                //DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return table;
        }     
    
    }
}
