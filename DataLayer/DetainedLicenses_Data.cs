using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;
using DTOsLayer;

namespace DataLayer
{
    public class DetainedLicenses_Data
    {
        public static async Task<DetainedLicense> getDetainedLicenseInfoAsync(int DetainID)
        {
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "select * from DetainedLicenses where ID = @DetainID";

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@licenseID", DetainID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    return new DetainedLicense(
                        reader.GetInt32(reader.GetOrdinal("ID")),
                        reader.IsDBNull(reader.GetOrdinal("ReleaseApplicationID")) ? 0 : reader.GetInt32(reader.GetOrdinal("ReleaseApplicationID")),
                        reader.GetInt32(reader.GetOrdinal("LicenseID")),
                        reader.IsDBNull(reader.GetOrdinal("ReleaseDate")) ? DateOnly.FromDateTime(DateTime.MinValue) 
                        : DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("ReleaseDate"))),
                        DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("DetainDate"))),
                        reader.GetBoolean(reader.GetOrdinal("isReleased")),
                        reader.GetDecimal(reader.GetOrdinal("FineFees")),
                        reader.IsDBNull(reader.GetOrdinal("ReleasedByUserID")) ? 0 : reader.GetInt32(reader.GetOrdinal("ReleasedByUserID")),
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
        public static async Task<DetainedLicense> getDetainedInfoByLicenseIDAsync(int licenseID)
        {
           
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "select * from DetainedLicenses where LicenseID = @licenseID";

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@licenseID", licenseID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    return new DetainedLicense(
                        reader.GetInt32(reader.GetOrdinal("ID")),
                        reader.IsDBNull(reader.GetOrdinal("ReleaseApplicationID")) ? 0 : reader.GetInt32(reader.GetOrdinal("ReleaseApplicationID")),
                        reader.GetInt32(reader.GetOrdinal("LicenseID")),
                        reader.IsDBNull(reader.GetOrdinal("ReleaseDate")) ? DateOnly.FromDateTime(DateTime.MinValue)
                        : DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("ReleaseDate"))),
                        DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("DetainDate"))),
                        reader.GetBoolean(reader.GetOrdinal("isReleased")),
                        reader.GetDecimal(reader.GetOrdinal("FineFees")),
                        reader.IsDBNull(reader.GetOrdinal("ReleasedByUserID")) ? 0 : reader.GetInt32(reader.GetOrdinal("ReleasedByUserID")),
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
        public static async Task<int> AddAsync(DetainedLicense license)
        {
            int newID = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"INSERT INTO DetainedLicenses 
                             VALUES (@LicenseID, @DetainDate,@FineFees,@CreatedByUserID, @isReleased, @ReleaseDate, @ReleasedByUserID,@ReleaseApplicationID);
                        SELECT SCOPE_IDENTITY();";


                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@LicenseID", license.LicenseID);
                Command.Parameters.AddWithValue("@DetainDate", license.DetainDate);
                Command.Parameters.AddWithValue("@FineFees", license.FineFees);
                Command.Parameters.AddWithValue("@CreatedByUserID", license.CreatedByUserID);
                Command.Parameters.AddWithValue("@isReleased", license.isReleased);


                if (license.ReleaseDate == DateOnly.FromDateTime(DateTime.MinValue))
                    Command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@ReleaseDate", license.ReleaseDate);


                if(license.ReleasedByUserID == -1)
                    Command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@ReleasedByUserID", license.ReleasedByUserID);


                if(license.ReleaseApplicationID == -1)
                    Command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@ReleaseApplicationID", license.ReleaseApplicationID);


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
        public static async Task<bool> UpdateAsync(DetainedLicense detain)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Update DetainedLicenses
                SET LicenseID = @LicenseID, DetainDate = @DetainDate, 
                        FineFees = @FineFees,CreatedByUserID = @CreatedByUserID,
                        isReleased = @isReleased,ReleaseDate = @ReleaseDate,
                        ReleasedByUserID = @ReleasedByUserID, ReleaseApplicationID = @ReleaseApplicationID
                WHERE ID = @DetainID;";

                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@DetainID", detain.ID);
                Command.Parameters.AddWithValue("@LicenseID", detain.LicenseID);
                Command.Parameters.AddWithValue("@DetainDate", detain.DetainDate);
                Command.Parameters.AddWithValue("@FineFees", detain.FineFees);
                Command.Parameters.AddWithValue("@CreatedByUserID", detain.CreatedByUserID);
                Command.Parameters.AddWithValue("@isReleased", detain.isReleased);

                if (detain.ReleaseDate == DateOnly.FromDateTime(DateTime.MinValue))
                    Command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@ReleaseDate", detain.ReleaseDate);

                if (detain.ReleasedByUserID == -1)
                    Command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@ReleasedByUserID", detain.ReleasedByUserID);


                if (detain.ReleaseApplicationID == -1)
                    Command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@ReleaseApplicationID", detain.ReleaseApplicationID);

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
        public static async Task<bool> DeleteAsync(int detainID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM DetainedLicenses WHERE ID = @detainID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@detainID", detainID);
                Connection.Open();
                RowAffected = await command.ExecuteNonQueryAsync();
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
        public static async Task<bool> isExistAsync(int detainID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM DetainedLicenses WHERE ID = @detainID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@detainID", detainID);

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
        public static async Task<bool> isLicenseDetainedAsync(int LicenseID)
        {
            bool Detained = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT isDetained = 1 FROM DetainedLicenses 
                                WHERE LicenseID = @licenseID and isReleased = 0;";


                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);

                Connection.Open();
                object result = await command.ExecuteScalarAsync();
                if (result != null)
                {
                    Detained = Convert.ToBoolean(result); 
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
            return Detained;
        }
        public static async Task<IEnumerable<DetainedLicense>> DetainedLicesesListAsync()
        {
            var dt = new List<DetainedLicense>();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT *  FROM DetainedLicenses_View;";


                SqlCommand command = new SqlCommand(Query, Connection);

                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (await reader.ReadAsync())
                {
                    dt.Add(new DetainedLicense(
                        reader.GetInt32(reader.GetOrdinal("ID")),
                        reader.IsDBNull(reader.GetOrdinal("ReleaseApplicationID")) ? 0 : reader.GetInt32(reader.GetOrdinal("ReleaseApplicationID")),
                        reader.GetInt32(reader.GetOrdinal("LicenseID")),
                        reader.IsDBNull(reader.GetOrdinal("ReleaseDate")) ? DateOnly.FromDateTime(DateTime.MinValue)
                        : DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("ReleaseDate"))),
                        DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("DetainDate"))),
                        reader.GetBoolean(reader.GetOrdinal("isReleased")),
                        reader.GetDecimal(reader.GetOrdinal("FineFees")),
                        reader.IsDBNull(reader.GetOrdinal("ReleasedByUserID")) ? 0 : reader.GetInt32(reader.GetOrdinal("ReleasedByUserID")),
                        reader.GetInt32(reader.GetOrdinal("CreatedByUserID"))
                        ));
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
            return dt;
        }

    }
}
