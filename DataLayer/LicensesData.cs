using System;
using System.Collections.Generic;
using System.ComponentModel;
using DTOsLayer;
using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace DataLayer
{
    public class LicensesData
    {
        public static async Task<_License> getLicenseInfoAsync(int licenseID)
        {
            try
            {
                using (var connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "select * from Licenses where ID = @licenseID"; 
                    using(var command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@licenseID", licenseID);
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (await reader.ReadAsync())
                            {
                                return new _License
                                    (
                                        reader.GetInt32(reader.GetOrdinal("ID")),
                                        reader.GetInt32(reader.GetOrdinal("ApplicationID")),
                                        reader.GetInt32(reader.GetOrdinal("DriverID")),
                                        reader.GetInt32(reader.GetOrdinal("LicenseClass")),
                                        DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("IssueDate"))),
                                        DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("ExpirationDate"))),
                                        reader.GetBoolean(reader.GetOrdinal("isActive")),
                                        reader.GetInt32(reader.GetOrdinal("PaidFees")),
                                        reader.GetInt32(reader.GetOrdinal("IssueReason")),
                                        reader.GetString(reader.GetOrdinal("Notes")),
                                        reader.GetInt32(reader.GetOrdinal("CreateByUserID"))
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
        public static async Task<int> AddAsync(_License license)
        {
            int newID = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = @"INSERT INTO Licenses 
                             VALUES (@ApplicationID, @LicenseClass,@IssueDate,@ExpirationDate, @Notes, @PaidFees, @isActive,@IssueReason, @DriverID,@CreatedByUserID);
                        SELECT SCOPE_IDENTITY();";


                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        if (string.IsNullOrEmpty(license.Notes))
                            Command.Parameters.AddWithValue("@Notes", DBNull.Value);
                        else
                            Command.Parameters.AddWithValue("@Notes", license.Notes);
                        
                        Command.Parameters.AddWithValue("@ApplicationID", license.ApplicationID);
                        Command.Parameters.AddWithValue("@LicenseClass", license.LicenseClass);
                        Command.Parameters.AddWithValue("@IssueDate", license.IssueDate);
                        Command.Parameters.AddWithValue("@ExpirationDate", license.ExpDate);
                        Command.Parameters.AddWithValue("@PaidFees", license.PaidFees);
                        Command.Parameters.AddWithValue("@isActive", license.isActive);
                        Command.Parameters.AddWithValue("@IssueReason", license.IssueReason);
                        Command.Parameters.AddWithValue("@DriverID", license.DriverID);
                        Command.Parameters.AddWithValue("@CreatedByUserID", license.CreatedByUserID);

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
                //Console.WriteLine("Error: " + ex.Message);
            }

            return newID;
        }
        public static async Task<bool> UpdateAsync(_License license)
        {
            int RowAffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = @"Update Licenses SET ApplicationID = @ApplicationID, 
                        LicenseClass = @LicenseClass, 
                        IssueDate = @IssueDate,ExpirationDate = @ExpirationDate,
                        Notes = @Notes,PaidFees = @PaidFees,
                        isActive = @isActive, IssueReason = @IssueReason, DriverID = @DriverID, 
                        CreatedByUserID = @CreatedByUserID
                        WHERE ID = @licenseID;";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Connection.Open();
                        Command.Parameters.AddWithValue("@licenseID", license.ID);
                        Command.Parameters.AddWithValue("@ApplicationID", license.ApplicationID);
                        Command.Parameters.AddWithValue("@LicenseClass", license.LicenseClass);
                        Command.Parameters.AddWithValue("@IssueDate", license.IssueDate);
                        Command.Parameters.AddWithValue("@ExpirationDate", license.ExpDate);
                        Command.Parameters.AddWithValue("@PaidFees", license.PaidFees);
                        Command.Parameters.AddWithValue("@isActive", license.isActive);
                        Command.Parameters.AddWithValue("@IssueReason", license.IssueReason);
                        Command.Parameters.AddWithValue("@DriverID", license.DriverID);
                        Command.Parameters.AddWithValue("@CreatedByUserID", license.CreatedByUserID);

                        if (string.IsNullOrEmpty(license.Notes))
                        {
                            Command.Parameters.AddWithValue("@Notes", DBNull.Value);
                        }
                        else
                        {
                            Command.Parameters.AddWithValue("@Notes", license.Notes);
                        }
                       
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
        public static async Task<bool> DeleteAsync(int licenseID)
        {
            int RowAffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "DELETE  FROM Licenses WHERE ID = @licenseID;";
                    using (SqlCommand command = new SqlCommand(Query, Connection))
                    {
                        command.Parameters.AddWithValue("@licenseID", licenseID);
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
        public static bool isExistAsync(int licenseID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "SELECT ID FROM Licenses WHERE ID = @licenseID;";
                    using (SqlCommand command = new SqlCommand(Query, Connection))
                    {
                        command.Parameters.AddWithValue("@licenseID", licenseID);
                        Connection.Open();
                        object result = command.ExecuteScalar();
                        isFound = (result != null);
                    }
                }
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
            }
            return isFound;
        }
        public static async Task<int> GetActiveLicenseIDByPersonIDAsync(int PersonID, int LicenseClassID)
        {
            int LicenseID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string query = @"SELECT Licenses.ID FROM Licenses INNER JOIN
                        Drivers ON Licenses.DriverID = Drivers.ID 
                        WHERE LicenseClass = @LicenseClassID 
                        AND Drivers.PersonID = @PersonID
                        AND isActive = 1;";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                        connection.Open();
                        object result = await command.ExecuteScalarAsync();
                        if (result != null && int.TryParse(result.ToString(), out int returnedResult))
                        {
                            LicenseID = returnedResult;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return LicenseID;
        }
        public static async Task<bool> DeactivateLicenseAsync(int LicenseID)
        {
            int RowAffected = 0; 
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "UPDATE Licenses SET isActive = 0 WHERE ID = @LicenseID;";
                    using (SqlCommand command = new SqlCommand(Query, Connection))
                    {
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);

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
        public static async Task<bool> ActivateLicenseAsync(int LicenseID)
        {
            int RowAffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {

                    string Query = "UPDATE Licenses SET isActive = 1 WHERE ID = @LicenseID;";
                    using (SqlCommand command = new SqlCommand(Query, Connection))
                    {
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
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
    
    }
}
