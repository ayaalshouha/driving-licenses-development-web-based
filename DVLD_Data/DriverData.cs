using System;
using System.Data.SqlClient;
using System.Data;

namespace DVLD_Data
{
    public class DriverData
    {
        public static bool getDriverInfo_ByPersonID(int PersonID, ref stDriver driver)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT * from Drivers WHERE PersonID = @PersonID;";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@PersonID", PersonID);

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    isFound = true;
                    driver.ID = (int)Reader["ID"];
                    driver.PersonID = (int)Reader["PersonID"];
                    driver.CreatedByUserID = (int)Reader["CreatedByUserID"];
                    driver.CreationDate = (DateTime)Reader["CreationDate"];
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
               // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool getDriverInfo_ByID(int DriverID, ref stDriver driver)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT * from Drivers WHERE ID = @DriverID;";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@DriverID", DriverID);

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    isFound = true;
                    driver.ID = (int)Reader["ID"];
                    driver.PersonID = (int)Reader["PersonID"];
                    driver.CreatedByUserID = (int)Reader["CreatedByUserID"];
                    driver.CreationDate = (DateTime)Reader["CreationDate"];
                }
                Reader.Close();
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

        public static int Add(stDriver Driver)
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

        public static bool Update(stDriver driver)
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

        public static bool Delete(int DrvierID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM Drivers WHERE ID = @DrvierID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@DrvierID", DrvierID);
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


        public static bool isExist(int DriverID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM Drviers WHERE ID = @DriverID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@DriverID", DriverID);

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


        public static bool isExist_ByPersonID(int PersonID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM Drivers WHERE PersonID = @PersonID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
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


        public static DataTable List()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM Drivers_Views order by ID asc;";
                SqlCommand command = new SqlCommand(Query, Connection);

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }

        public static DataTable getActiveLicenses(int DriverID)
        {
            DataTable dt = new DataTable();
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
                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }

        public static DataTable getInternationalLicenses(int DriverID)
        {
            DataTable dt = new DataTable();
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
                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }
    }
}
