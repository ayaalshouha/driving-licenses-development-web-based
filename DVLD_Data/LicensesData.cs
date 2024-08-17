using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Data
{
    public class LicensesData
    {
        public static bool getLicenseInfo(int licenseID, ref stLicenses license)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "select * from Licenses where ID = @licenseID";

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@licenseID", licenseID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    isFound = true;
                    license.ID = (int)reader["ID"];
                    license.isActive = (bool)reader["isActive"];
                    license.ApplicationID = (int)reader["ApplicationID"];
                    license.DriverID = (int)reader["DriverID"];
                    license.LicenseClass = (int)reader["LicenseClass"];
                    license.CreatedByUserID = (int)reader["CreateByUserID"];
                    license.ExpDate = (DateTime)reader["ExpirationDate"];
                    license.PaidFees = (decimal)reader["PaidFees"];
                    license.IssueReason = (int)reader["IssueReason"];
                    license.IssueDate = (DateTime)reader["IssueDate"];
                    license.Notes = reader["Notes"] == DBNull.Value ? "" : (string)reader["Notes"];

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
        public static int Add(stLicenses license)
        {
            int newID = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"INSERT INTO Licenses 
                             VALUES (@ApplicationID, @LicenseClass,@IssueDate,@ExpirationDate, @Notes, @PaidFees, @isActive,@IssueReason, @DriverID,@CreatedByUserID);
                        SELECT SCOPE_IDENTITY();";


                SqlCommand Command = new SqlCommand(Query, Connection);

                if (string.IsNullOrEmpty(license.Notes))
                {
                    Command.Parameters.AddWithValue("@Notes", DBNull.Value);
                }
                else
                {
                    Command.Parameters.AddWithValue("@Notes", license.Notes);
                }

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
        public static bool Update(stLicenses license)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);

            try
            {
                string Query = @"Update Licenses
                SET ApplicationID = @ApplicationID, LicenseClass = @LicenseClass, 
                        IssueDate = @IssueDate,ExpirationDate = @ExpirationDate,
                        Notes = @Notes,PaidFees = @PaidFees,
                        isActive = @isActive, IssueReason = @IssueReason, DriverID = @DriverID, 
                        CreatedByUserID = @CreatedByUserID
                WHERE ID = @licenseID;";

                SqlCommand Command = new SqlCommand(Query, Connection);

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
        public static bool Delete(int licenseID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM Licenses WHERE ID = @licenseID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@licenseID", licenseID);
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
        public static bool isExist(int licenseID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM Licenses WHERE ID = @licenseID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@licenseID", licenseID);

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

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);

            try
            {
                string query = @"SELECT Licenses.ID FROM Licenses INNER JOIN
                        Drivers ON Licenses.DriverID = Drivers.ID 
                    WHERE LicenseClass = @LicenseClassID 
                        AND Drivers.PersonID = @PersonID
                        AND isActive = 1;";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int returnedResult))
                {
                    LicenseID = returnedResult;
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
            return LicenseID;
        }

        public static bool DeactivateLicense(int LicenseID)
        {
            int RowAffected = 0; 
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "UPDATE Licenses SET isActive = 0 WHERE ID = @LicenseID;";

                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        public static bool ActivateLicense(int LicenseID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "UPDATE Licenses SET isActive = 1 WHERE ID = @LicenseID;";

                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);

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
    }
}
