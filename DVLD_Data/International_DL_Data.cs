using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Data
{
    public class International_DL_Data
    {
        public static bool getApplicationInfo(int ApplicationID, ref stInternationalLicenses application)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "select * from InternationalLicenses where ID = @ApplicationID";

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    isFound = true;
                    application.ID = (int)reader["ID"];
                    application.ApplicationID = (int)reader["ApplicationID"];
                    application.DriverID = (int)reader["DriverID"];
                    application.isActive = (bool)reader["isActive"];
                    application.IssueDate = (DateTime)reader["IssueDate"];
                    application.ExpDate = (DateTime)reader["ExpirationDate"];
                    application.IssuedByLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    application.CreatedByUserID = (int)reader["CreatedByUserID"]; 
                    
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

        public static int Add(stInternationalLicenses application)
        {
            int newID = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                //deactivating all previous international licenses before adding a new one to the same driver

                string Query = @"UPDATE InternationalLicenses SET isActive = 0 
                                    WHERE DriverID = @DriverID;

                            INSERT INTO InternationalLicenses 
                             VALUES (@ApplicationID,@DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, @isActive, @CreatedByUserID);
                        SELECT SCOPE_IDENTITY();";


                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@ApplicationID", application.ApplicationID);
                Command.Parameters.AddWithValue("@DriverID", application.DriverID);
                Command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", application.IssuedByLocalLicenseID);
                Command.Parameters.AddWithValue("@IssueDate", application.IssueDate);
                Command.Parameters.AddWithValue("@ExpirationDate", application.ExpDate);
                Command.Parameters.AddWithValue("@isActive", application.isActive);
                Command.Parameters.AddWithValue("@CreatedByUserID", application.CreatedByUserID);
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

        public static bool Update(stInternationalLicenses application)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Update InternationalLicenses
                SET ApplicationID = @ApplicationID,
                        DriverID = @DriverID, IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID, 
                        IssueDate = @IssueDate,ExpirationDate = @ExpirationDate, isActive = @isActive,
                        CreatedByUserID = @CreatedByUserID
                WHERE ID = @LicenseID;";

                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@LicenseID", application.ID);
                Command.Parameters.AddWithValue("@ApplicationID", application.ApplicationID);
                Command.Parameters.AddWithValue("@DriverID", application.DriverID);
                Command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", application.IssuedByLocalLicenseID);
                Command.Parameters.AddWithValue("@IssueDate", application.IssueDate);
                Command.Parameters.AddWithValue("@ExpirationDate", application.ExpDate);
                Command.Parameters.AddWithValue("@isActive", application.isActive);
                Command.Parameters.AddWithValue("@CreatedByUserID", application.CreatedByUserID);

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
                string Query = "DELETE  FROM InternationalLicenses WHERE ID = @LicenseID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@LicenseID", ApplicationID);
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
        public static bool isExist(int ApplicationID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM InternationalLicenses WHERE ID = @ApplicationID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

        public static DataTable getInternationalLicenses()
        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM InternationalLicenses;";
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

        public static int GetActiveLicenseID(int DriverID)
        {
            int ID = -1; 
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT ID FROM InternationalLicenses
                            WHERE DriverID = @DriverID and isActive = 1;";

                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@DriverID", DriverID);

                Connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedResult))
                {
                    ID = InsertedResult;
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
            return ID;
        }
    }
}
