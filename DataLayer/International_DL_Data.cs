using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using DTOsLayer;

namespace DataLayer
{
    public class International_DL_Data
    {
        public static async Task<InternationalLicense> getLicenseInfoAsync(int licenseID)
        {
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "select * from InternationalLicenses where ID = @licenseID";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@licenseID", licenseID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    return new InternationalLicense(
                            reader.GetInt32(reader.GetOrdinal("ID")),
                            reader.GetInt32(reader.GetOrdinal("ApplicationID")),
                            reader.GetInt32(reader.GetOrdinal("DriverID")),
                            reader.GetInt32(reader.GetOrdinal("IssuedUsingLocalLicenseID")),
                            DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("IssueDate"))),
                            DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("ExpirationDate"))),
                            reader.GetBoolean(reader.GetOrdinal("isActive")),
                            reader.GetInt32(reader.GetOrdinal("CreatedByUserID"))
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
        public static async Task<int> AddAsync(InternationalLicense license)
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

                Command.Parameters.AddWithValue("@ApplicationID", license.ApplicationID);
                Command.Parameters.AddWithValue("@DriverID", license.DriverID);
                Command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", license.IssuedByLocalLicenseID);
                Command.Parameters.AddWithValue("@IssueDate", license.IssueDate);
                Command.Parameters.AddWithValue("@ExpirationDate", license.ExpDate);
                Command.Parameters.AddWithValue("@isActive", license.isActive);
                Command.Parameters.AddWithValue("@CreatedByUserID", license.CreatedByUserID);
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
        public static async Task<bool> UpdateAsync(InternationalLicense license)
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
                Command.Parameters.AddWithValue("@LicenseID", license.ID);
                Command.Parameters.AddWithValue("@ApplicationID", license.ApplicationID);
                Command.Parameters.AddWithValue("@DriverID", license.DriverID);
                Command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", license.IssuedByLocalLicenseID);
                Command.Parameters.AddWithValue("@IssueDate", license.IssueDate);
                Command.Parameters.AddWithValue("@ExpirationDate", license.ExpDate);
                Command.Parameters.AddWithValue("@isActive", license.isActive);
                Command.Parameters.AddWithValue("@CreatedByUserID", license.CreatedByUserID);

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
        public static async Task<bool> DeleteAsync(int licenseID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM InternationalLicenses WHERE ID = @licenseID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@licenseID", licenseID);
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
        public static async Task<bool> isExistAsync(int licenseID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM InternationalLicenses WHERE ID = @licenseID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@licenseID", licenseID);

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
        public static async Task<IEnumerable<InternationalLicense>> ListAsync()
        {
            var table = new List<InternationalLicense>();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM InternationalLicenses;";
                SqlCommand command = new SqlCommand(Query, Connection);

                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (await reader.ReadAsync())
                {
                    table.Add(new InternationalLicense(
                            reader.GetInt32(reader.GetOrdinal("ID")),
                            reader.GetInt32(reader.GetOrdinal("ApplicationID")),
                            reader.GetInt32(reader.GetOrdinal("DriverID")),
                            reader.GetInt32(reader.GetOrdinal("IssuedUsingLocalLicenseID")),
                            DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("IssueDate"))),
                            DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("ExpirationDate"))),
                            reader.GetBoolean(reader.GetOrdinal("isActive")),
                            reader.GetInt32(reader.GetOrdinal("CreatedByUserID"))
                        ));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return table;
        }
   
    }
}
