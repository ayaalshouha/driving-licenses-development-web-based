using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Data
{
    public class Tests_Data
    {
        public static bool getTestInfo(int TestID, ref stTests test)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "select * from Tests where ID = @ID";

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ID", TestID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    isFound = true;
                    test.ID = (int)reader["ID"];
                    test.AppointmentID = (int)reader["AppointmentID"];
                    test.Notes = (string)reader["Notes"];
                    test.CreatedByUserID = (int)reader["CreatedByUserID"];
                    test.Result = (bool)reader["Result"];
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

        public static bool GetLastTestPerTestType(int PersonID, int ClassID, int TestType, ref stTests test)
        {
            bool isFound = false;
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
                while (reader.Read())
                {
                    isFound = true;
                    test.ID = (int)reader["ID"];
                    test.AppointmentID = (int)reader["AppointmentID"];
                    test.Notes = (string)reader["Notes"];
                    test.CreatedByUserID = (int)reader["CreateByUserID"];
                    test.Result = (bool)reader["Result"];
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
        public static int Add(stTests test)
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

        public static bool Update(stTests test)
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
        public static bool Delete(int testID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM Tests WHERE ID = @testID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@testID", testID);
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
        public static bool isExist(int testID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM Tests WHERE ID = @testID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@testID", testID);

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

        public static DataTable getTestsTable()
        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM Tests;";
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

        //public static bool PassedFailedResult()
        //{
        //    bool Result = false;


        //    select Result from Tests
        //    where AppointmentID = @AppointmentID;
        //}
    
    }
}
