using System;
using Microsoft.Data.SqlClient;
using System.Data;
using DTOsLayer; 

namespace DataLayer
{
    public class DriverData
    {
        public static async Task<Driver> getDriverInfo_ByPersonIDAsync(int PersonID)
        {
           
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT * from Drivers WHERE PersonID = @PersonID;";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@PersonID", PersonID);

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                while (await Reader.ReadAsync())
                {
                    return new Driver(
                            Reader.GetInt32(Reader.GetOrdinal("ID")),
                            Reader.GetInt32(Reader.GetOrdinal("PersonID")),
                            DateOnly.FromDateTime(Reader.GetDateTime(Reader.GetOrdinal("CreationDate"))),
                            Reader.GetInt32(Reader.GetOrdinal("CreatedByUserID"))
                        );
                   
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
               // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return null;
        }
        public static async Task<Driver> getDriverInfo_ByIDAsync(int DriverID)
        {
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT * from Drivers WHERE ID = @DriverID;";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@DriverID", DriverID);

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                while (await Reader.ReadAsync())
                {
                    return new Driver(
                            Reader.GetInt32(Reader.GetOrdinal("ID")),
                            Reader.GetInt32(Reader.GetOrdinal("PersonID")),
                            DateOnly.FromDateTime(Reader.GetDateTime(Reader.GetOrdinal("CreationDate"))),
                            Reader.GetInt32(Reader.GetOrdinal("CreatedByUserID"))
                        );
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return null;
        }
        public static async Task<int> AddAsync(Driver Driver)
        {
            int newID = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"INSERT INTO Drivers 
                             VALUES (@PersonID, @CreationDate,@CreatedByUserID);
                        SELECT SCOPE_IDENTITY();";


                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@CreationDate", Driver.CreationDate);
                Command.Parameters.AddWithValue("@PersonID", Driver.PersonID);
                Command.Parameters.AddWithValue("@CreatedByUserID", Driver.CreatedByUserID);
             

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
            }
            finally
            {
                Connection.Close();
            }

            return newID;
        }
        public static async Task<bool> UpdateAsync(Driver driver)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Update Drivers
                    SET PersonID = @PeronID,
                        CreationDate = @CreationDate, 
                        CreatedByUserID = @CreatedByUserID
                   WHERE ID = @DriverID;";

                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@DriverID", driver.ID);
                Command.Parameters.AddWithValue("@PersonID", driver.PersonID);
                Command.Parameters.AddWithValue("@CreationDate", driver.CreationDate);
                Command.Parameters.AddWithValue("@CreatedByUserID", driver.CreatedByUserID);

                Connection.Open();
                RowAffected = await Command.ExecuteNonQueryAsync();
            }

            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return RowAffected > 0;
        }
        public static async Task<bool> DeleteAsync(int DrvierID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM Drivers WHERE ID = @DrvierID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@DrvierID", DrvierID);
                Connection.Open();
                RowAffected = await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return RowAffected > 0;
        }
        public static async Task<bool> isExistAsync(int DriverID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM Drivers WHERE ID = @DriverID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@DriverID", DriverID);

                Connection.Open();
                object result = await command.ExecuteScalarAsync();
                isFound = (result != null);
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }
        public static async Task<bool> isExist_ByPersonIDAsync(int PersonID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM Drivers WHERE PersonID = @PersonID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                Connection.Open();
                object result = await command.ExecuteScalarAsync();
                isFound = (result != null);
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }
        public static async Task<IEnumerable<Driver_View>> ListAsync()
        {
            var dt = new List<Driver_View>();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "select * from Drivers_Views order by ID asc;";
                SqlCommand command = new SqlCommand(Query, Connection);

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                while (await Reader.ReadAsync())
                {
                    dt.Add(
                        new Driver_View(
                            Reader.GetInt32(Reader.GetOrdinal("ID")),
                            Reader.GetInt32(Reader.GetOrdinal("PersonID")),
                            Reader.GetString(Reader.GetOrdinal("FullName")),
                            DateOnly.FromDateTime(Reader.GetDateTime(Reader.GetOrdinal("Date"))),
                            Reader.GetString(Reader.GetOrdinal("NationalID")),
                            Reader.GetInt32(Reader.GetOrdinal("ActiveLicenses"))
                        ));
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }
        
        //get all active licenses that driver issued before
        public static async Task<IEnumerable<ActiveLicense>> getActiveLicensesAsync(int DriverID)
        {
            var dt = new List<ActiveLicense>();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT Licenses.ID, Licenses.ApplicationID, 
                   LicenseClasses.Class, Licenses.IssueDate,
                    Licenses.ExpirationDate, Licenses.isActive 
                    FROM Licenses INNER JOIN LicenseClasses 
                    ON Licenses.LicenseClass = LicenseClasses.ID 
                   WHERE DriverID = @DriverID 
                      Order by IssueDate desc;";

                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@DriverID", DriverID);

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                while (await Reader.ReadAsync())
                {
                    dt.Add(new ActiveLicense(
                            Reader.GetInt32(Reader.GetOrdinal("ID")),
                            Reader.GetInt32(Reader.GetOrdinal("ApplicationID")),
                            Reader.GetString(Reader.GetOrdinal("Class")),
                            DateOnly.FromDateTime(Reader.GetDateTime(Reader.GetOrdinal("IssueDate"))),
                            DateOnly.FromDateTime(Reader.GetDateTime(Reader.GetOrdinal("ExpirationDate"))),
                            Reader.GetBoolean(Reader.GetOrdinal("isActive"))
                        ));
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }
        public static async Task<IEnumerable<DriverInterNationalLicense>> getInternationalLicensesAsync(int DriverID)
        {
            var dt = new List<DriverInterNationalLicense>();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT InternationalLicenses.ID, InternationalLicenses.ApplicationID, 
                   InternationalLicenses.IssuedUsingLocalLicenseID, InternationalLicenses.IssueDate,
                    InternationalLicenses.ExpirationDate, InternationalLicenses.isActive 
                    FROM InternationalLicenses  
                    WHERE DriverID = @DriverID 
                      Order by IssueDate desc;";

                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@DriverID", DriverID); 
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                while (await Reader.ReadAsync())
                {
                    dt.Add(new DriverInterNationalLicense(
                            Reader.GetInt32(Reader.GetOrdinal("ID")),
                            Reader.GetInt32(Reader.GetOrdinal("ApplicationID")),
                            Reader.GetInt32(Reader.GetOrdinal("IssuedUsingLocalLicenseID")),
                            DateOnly.FromDateTime(Reader.GetDateTime(Reader.GetOrdinal("IssueDate"))),
                            DateOnly.FromDateTime(Reader.GetDateTime(Reader.GetOrdinal("ExpirationDate"))),
                            Reader.GetBoolean(Reader.GetOrdinal("isActive"))
                        ));
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }
        public static async Task<int> GetActiveLicenseIDAsync(int DriverID)
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
                object result = await command.ExecuteScalarAsync();

                if (result != null && int.TryParse(result.ToString(), out int InsertedResult))
                {
                    ID = InsertedResult;
                }
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return ID;
        }
    }
}
