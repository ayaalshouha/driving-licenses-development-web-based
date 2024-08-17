using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class DetainedLicenses_Data
    {
        public static bool getDetainedLicenseInfo(int DetainID, ref stDetainedLicenses license)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "select * from DetainedLicenses where ID = @DetainID";

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@licenseID", DetainID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    isFound = true;
                    license.ID = (int)reader["ID"];
                    license.LicenseID = (int)reader["LicenseID"];
                    license.DetainDate = (DateTime)reader["DetainDate"];
                    license.FineFees = (decimal)reader["FineFees"];
                    license.CreatedByUserID = (int)reader["CreatedByUserID"];

                    license.isReleased = (bool)reader["isReleased"];

                    license.ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["ReleaseDate"];
                    license.ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value ? 0 : (int)reader["ReleasedByUserID"];
                    license.ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value ? 0 : (int)reader["ReleaseApplicationID"]; ;
                  
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

        public static bool getDetainedInfoByLicenseID(int licenseID, ref stDetainedLicenses license)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "select * from DetainedLicenses where LicenseID = @licenseID";

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@licenseID", licenseID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    isFound = true;
                    license.ID = (int)reader["ID"];
                    license.LicenseID = (int)reader["LicenseID"];
                    license.DetainDate = (DateTime)reader["DetainDate"];
                    license.FineFees = (decimal)reader["FineFees"];
                    license.CreatedByUserID = (int)reader["CreatedByUserID"];

                    license.isReleased = (bool)reader["isReleased"];

                    license.ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["ReleaseDate"];
                    license.ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value ? 0 : (int)reader["ReleasedByUserID"];
                    license.ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value ? 0 : (int)reader["ReleaseApplicationID"]; ;

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
        public static int Add(stDetainedLicenses license)
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


                if (license.ReleaseDate == DateTime.MinValue)
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
        public static bool Update(stDetainedLicenses license)
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

                Command.Parameters.AddWithValue("@DetainID", license.ID);
                Command.Parameters.AddWithValue("@LicenseID", license.LicenseID);
                Command.Parameters.AddWithValue("@DetainDate", license.DetainDate);
                Command.Parameters.AddWithValue("@FineFees", license.FineFees);
                Command.Parameters.AddWithValue("@CreatedByUserID", license.CreatedByUserID);
                Command.Parameters.AddWithValue("@isReleased", license.isReleased);


                if (license.ReleaseDate == DateTime.MinValue)
                    Command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@ReleaseDate", license.ReleaseDate);


                if (license.ReleasedByUserID == -1)
                    Command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@ReleasedByUserID", license.ReleasedByUserID);


                if (license.ReleaseApplicationID == -1)
                    Command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@ReleaseApplicationID", license.ReleaseApplicationID);


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
        public static bool Delete(int licenseID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM DetainedLicenses WHERE ID = @licenseID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@licenseID", licenseID);
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
        public static bool isExist(int licenseID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM DetainedLicenses WHERE ID = @licenseID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@licenseID", licenseID);

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

        public static bool isLicenseDetained(int LicenseID)
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
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    Detained = Convert.ToBoolean(result); 
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
            return Detained;
        }

        public static DataTable DetainedLicesesList()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT *  FROM DetainedLicenses_View;";


                SqlCommand command = new SqlCommand(Query, Connection);

                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader); 
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
            return dt;
        }

    }
}
