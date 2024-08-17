using System;
using System.Data.SqlClient;
using System.Data;
namespace DVLD_Data
{
    public class Appointments_Data
    {
        public static bool getAppointmentInfo(int AppointmentID, ref stAppointment appointment)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "select * from TestAppointments where ID = @ID";

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ID", AppointmentID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    isFound = true;
                    appointment.ID = (int)reader["ID"];
                    appointment.Date = (DateTime)reader["Date"];
                    appointment.PaidFees = (decimal)reader["PaidFees"];
                    appointment.LocalLicenseApplicationID = (int)reader["LocalDrvingLicenseApplicationID"];
                    appointment.isLocked = (bool)reader["isLocked"];
                    appointment.TestType = (int)reader["TestTypeID"];
                    appointment.CreatedByUserID = (int)reader["CreateByUserID"];


                    if (reader["RetakeTestApplicationID"] == DBNull.Value)
                        appointment.RetakeTestID = -1;
                    else
                        appointment.RetakeTestID = (int)reader["RetakeTestApplicationID"];

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

        public static int Add(stAppointment appointment)
        {
            int newID = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"INSERT INTO TestAppointments 
                             VALUES (@TestTypeID,@Date,@PaidFees,0, @CreatedByUserID,@LocalDrivingLicenseApplicationIDID,@RetakeTestApplicationID);
                        SELECT SCOPE_IDENTITY();";


                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@TestTypeID", appointment.TestType);
                Command.Parameters.AddWithValue("@Date", appointment.Date);
                Command.Parameters.AddWithValue("@PaidFees", appointment.PaidFees);
                Command.Parameters.AddWithValue("@CreatedByUserID", appointment.CreatedByUserID);
                Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationIDID", appointment.LocalLicenseApplicationID);
                if(appointment.RetakeTestID == -1)
                {
                    Command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
                }
                else
                {
                    Command.Parameters.AddWithValue("@RetakeTestApplicationID", appointment.RetakeTestID);
                }
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
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return newID;
        }

        public static bool Update(stAppointment appointment)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
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

                SqlCommand Command = new SqlCommand(Query, Connection);

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
                RowAffected = Command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return RowAffected > 0;
        }
        public static bool Delete(int AppointmentID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM TestAppointments WHERE ID = @TestAppointmentID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@AppointmentID", AppointmentID);
                Connection.Open();
                RowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return RowAffected > 0;
        }
        public static bool isExist(int AppointmentID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM TestAppointmentID WHERE ID = @AppointmentID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@AppointmentID", AppointmentID);

                Connection.Open();
                object result = command.ExecuteScalar();
                isFound = (result != null);
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static DataTable getAppointmentsTablePerTestType(int LocalApplicationID,int TestType)
        {
            DataTable table = new DataTable();
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

                if (reader.HasRows)
                {
                    table.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return table;
        }


        public static int getTestID(int AppointmentID)
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
                object result = command.ExecuteScalar(); 

                if(result!=null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    TestID = InsertedID; 
                }
               
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
                //Console.WriteLine("Error: "+ e.Message);

            }
            finally
            {
                Connection.Close(); 
            }
            return TestID;
        }

        public static bool isThereAnyActiveAppointments(int LocalID, int TestType)
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
                object result = command.ExecuteScalar();

                if(result!= null)
                {
                    isFound = true;
                }
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
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
