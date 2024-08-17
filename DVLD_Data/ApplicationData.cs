using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Data
{
    public class ApplicationData
    {
        public static bool getApplicationInfo(int ApplicationID,ref stApplication application )
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "select * from Applications where ID = @ID"; 

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ID", ApplicationID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    isFound = true;
                    application.ID = (int)reader["ID"];
                    application.PersonID = (int)reader["PersonID"];
                    application.Date = (DateTime)reader["Date"];
                    application.lastStatusDate = (DateTime)reader["LastStatusDate"];
                    application.PaidFees = (decimal)reader["PaidFees"];
                    application.CreatedByUserID = (int)reader["CreatedByUserID"];
                    application.Status = (enStatus)reader["Status"];
                    application.Type = (int)reader["ApplicationTypeID"];
                    
                }
                reader.Close();
            }
            catch(Exception e){

                DataSettings.StoreUsingEventLogs(e.Message.ToString());
                //Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
            return isFound; 
        }
        public static int Add(stApplication application)
        {
            int newID = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"INSERT INTO Applications 
                             VALUES (@Date, @PersonID,@Status,@PaidFees, @ApplicationTypeID, @CreatedByUserID, @LastStatusDate);
                        SELECT SCOPE_IDENTITY();";


                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@Date", application.Date);
                Command.Parameters.AddWithValue("@PersonID", application.PersonID); 
                Command.Parameters.AddWithValue("@Status", application.Status);
                Command.Parameters.AddWithValue("@PaidFees", application.PaidFees);
                Command.Parameters.AddWithValue("@ApplicationTypeID", application.Type);
                Command.Parameters.AddWithValue("@CreatedByUserID", application.CreatedByUserID);
                Command.Parameters.AddWithValue("@LastStatusDate", application.lastStatusDate);

                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int LastID))
                {
                    newID = LastID;
                }
            }
            catch (Exception e)
            {
                DataSettings.StoreUsingEventLogs(e.Message.ToString());
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return newID;
        }
        public static bool Update(stApplication application)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Update Applications
                SET PersonID = @PersonID,
                        Date = @Date, 
                        Status = @Status,
                        ApplicationTypeID = @Type,
                        PaidFees = @PaidFees,
                        CreatedByUserID = @CreatedByUserID,
                        LastStatusDate = @LastStatusDate
                WHERE ID = @ApplicationID;";

                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@ApplicationID", application.ID);
                Command.Parameters.AddWithValue("@PersonID", application.PersonID);
                Command.Parameters.AddWithValue("@Date", application.Date);
                Command.Parameters.AddWithValue("@Status", application.Status);
                Command.Parameters.AddWithValue("@Type", application.Type);
                Command.Parameters.AddWithValue("@PaidFees", application.PaidFees);
                Command.Parameters.AddWithValue("@CreatedByUserID", application.CreatedByUserID);
                Command.Parameters.AddWithValue("@LastStatusDate", application.lastStatusDate);

                Connection.Open();
                RowAffected = Command.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                DataSettings.StoreUsingEventLogs(e.Message.ToString());
               // Console.WriteLine("Error: " + ex.Message);
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
                string Query = "DELETE  FROM Applications WHERE ID = @ApplicationID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                Connection.Open();
                RowAffected = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                DataSettings.StoreUsingEventLogs(e.Message.ToString());
                //Console.WriteLine("Error: " + ex.Message);
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
                string Query = "SELECT ID FROM Applications WHERE ID = @ApplicationID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                Connection.Open();
                object result = command.ExecuteScalar();
                isFound = (result != null);
            }
            catch (Exception e)
            {
                DataSettings.StoreUsingEventLogs(e.Message.ToString());
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }


        public static bool isClassExist(int personID, int ClassID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT Applications.ID 
                            FROM Applications INNER JOIN LocalDrivingLicensesApplications 
                 ON Applications.ID = LocalDrivingLicensesApplications.ApplicationID
                WHERE LocalDrivingLicensesApplications.LicenseClassID = @ClassID and Applications.PersonID = @personID 
                        and Applications.Status != 2;";
                                
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@ClassID", ClassID);
                command.Parameters.AddWithValue("@personID", personID);
                Connection.Open();
                object result = command.ExecuteScalar();
                isFound = (result != null);
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


        public static int GetFees(int ApplicationID)
        {
            int fees = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT Fees From ApplicationTypes 
                                INNER JOIN Applications
                                ON ApplicationTypes.ID = Applications.ApplicationTypeID 
                        WHERE Applications.ID = @ApplicationID;"; 


                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int result_))
                {
                    fees = result_;
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

            return fees;

        }

        public static bool Cancel(int ApplicationID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "UPDATE Applications SET Status = 2 where ((ID = @ApplicationID) and (Status != 3));";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                Connection.Open();
                RowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return RowAffected > 0;
        }

        public static bool UpdateStatus(int ApplicationID, int StatusNumber)
        {
            int RowAffected = 0; 

            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Update Applications 
                                SET Status = @StatusNumber,
                               LastStatusDate = @LastStatusDate
                WHERE ID = @ApplicationID;";

                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@StatusNumber", StatusNumber);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now); 
                Connection.Open();
                RowAffected = command.ExecuteNonQuery();
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

            return (RowAffected > 0);
        }
        public static string GetFullNameOfApplicant(int personID)
        {
            string name = "";
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT Name From FullNames WHERE PersonID = @personID;";
                                
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@personID", personID);
                Connection.Open();

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    name=result.ToString();
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
            return name; 
        }


    }
}
