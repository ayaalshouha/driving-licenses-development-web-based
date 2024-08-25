using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using DTOsLayer;


namespace DataLayer
{
    public class ApplicationData
    {
        public static _Application getApplicationInfo(int ApplicationID)
        {
            return getApplicationInfoAsync(ApplicationID).GetAwaiter().GetResult();
        }
        public static async Task<_Application> getApplicationInfoAsync(int ApplicationID)
        {
            try
            {
                using (var connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "select * from Applications where ID = @ID";
                    using (var command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", ApplicationID);
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (await reader.ReadAsync())
                            {
                                return new _Application
                                    (
                                    reader.GetInt32(reader.GetOrdinal("ID")), 
                                    reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    Enum.IsDefined(typeof(enStatus), reader.GetInt32(reader.GetOrdinal("Status"))) ?
                                    (enStatus)reader.GetInt32(reader.GetOrdinal("Status")) : 0,                                
                                    reader.GetInt32(reader.GetOrdinal("ApplicationTypeID")),
                                    reader.IsDBNull(reader.GetOrdinal("Date")) ? DateOnly.MinValue
                                    : DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("Date"))),
                                    reader.GetDecimal(reader.GetOrdinal("PaidFees")),
                                    reader.IsDBNull(reader.GetOrdinal("LastStatusDate")) ? DateOnly.MinValue
                                    : DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("LastStatusDate"))),
                                    reader.GetInt32(reader.GetOrdinal("CreatedByUserID"))
                                    );
                            }
                        }
                    }
                }
            }
            catch(Exception e){
                DataSettings.LogError(e.Message.ToString());
                //Console.WriteLine("Error: " + e.Message);
            }
            return null; 
        }
        public static async Task<int> AddAsync(_Application application)
        {
            int newID = 0;
            try
            {
                using (var Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                        string Query = @"INSERT INTO Applications 
                                 VALUES (@Date, @PersonID,@Status,@PaidFees, @ApplicationTypeID, @CreatedByUserID, @LastStatusDate);
                            SELECT SCOPE_IDENTITY();";

                       using (var Command = new SqlCommand(Query, Connection))
                       {
                            Command.Parameters.AddWithValue("@PersonID", application.PersonID); 
                            Command.Parameters.AddWithValue("@Date", application.Date);
                            Command.Parameters.AddWithValue("@Status", application.Status);
                            Command.Parameters.AddWithValue("@PaidFees", application.PaidFees);
                            Command.Parameters.AddWithValue("@ApplicationTypeID", application.Type);
                            Command.Parameters.AddWithValue("@CreatedByUserID", application.CreatedByUserID);
                            Command.Parameters.AddWithValue("@LastStatusDate", application.lastStatusDate);
                            Connection.Open();

                            object result = await Command.ExecuteScalarAsync();

                            if (result != null && int.TryParse(result.ToString(), out int LastID))
                            {
                                newID = LastID;
                            }
                       }
                }
            }
            catch (Exception e)
            {
                DataSettings.LogError (e.Message.ToString());
                //Console.WriteLine("Error: " + ex.Message);
            }

            return newID;
        }
        public static async Task<bool> UpdateAsync(_Application application)
        {
            int RowAffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
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
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@ApplicationID", application.ID);
                        Command.Parameters.AddWithValue("@PersonID", application.PersonID);
                        Command.Parameters.AddWithValue("@Date", application.Date);
                        Command.Parameters.AddWithValue("@Status", application.Status);
                        Command.Parameters.AddWithValue("@Type", application.Type);
                        Command.Parameters.AddWithValue("@PaidFees", application.PaidFees);
                        Command.Parameters.AddWithValue("@CreatedByUserID", application.CreatedByUserID);
                        Command.Parameters.AddWithValue("@LastStatusDate", application.lastStatusDate);

                        Connection.Open();
                        RowAffected = await Command.ExecuteNonQueryAsync();

                    }
                }
            }
            catch (Exception e)
            {
                DataSettings.LogError(e.Message.ToString());
               // Console.WriteLine("Error: " + ex.Message);
            }

            return RowAffected > 0;
        }
        public static async Task<bool> DeleteAsync(int ApplicationID)
        {
            int RowAffected = 0;
            try
            {
                using (var Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "DELETE  FROM Applications WHERE ID = @ApplicationID;";
                    using (var command = new SqlCommand(Query, Connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        Connection.Open();
                        RowAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception e)
            {
                DataSettings.LogError(e.Message.ToString());
                //Console.WriteLine("Error: " + ex.Message);
            }
           
            return RowAffected > 0;
        }
        public static async Task<bool> isExistAsync(int ApplicationID)
        {
            bool isFound = false;
            try
            {
                using (var Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "SELECT ID FROM Applications WHERE ID = @ApplicationID;";
                    using (var command = new SqlCommand(Query, Connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        Connection.Open();
                        object result = await command.ExecuteScalarAsync();
                        isFound = (result != null);

                    }
                }
            }
            catch (Exception e)
            {
                DataSettings.LogError(e.Message.ToString());
                //Console.WriteLine("Error: " + ex.Message);
            }
           
            return isFound;
        }
        public static async Task<bool> isClassExistAsync(int personID, int ClassID)
        {
            bool isFound = false;
            try
            {
                using (var Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = @"SELECT Applications.ID 
                            FROM Applications INNER JOIN LocalDrivingLicensesApplications 
                     ON Applications.ID = LocalDrivingLicensesApplications.ApplicationID
                    WHERE LocalDrivingLicensesApplications.LicenseClassID = @ClassID and Applications.PersonID = @personID 
                        and Applications.Status != 2;";

                    using (var command = new SqlCommand(Query, Connection))
                    {
                        command.Parameters.AddWithValue("@ClassID", ClassID);
                        command.Parameters.AddWithValue("@personID", personID);
                        Connection.Open();
                        object result = await command.ExecuteScalarAsync();
                        isFound = (result != null);

                    }
                }
                                
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
                // Console.WriteLine("Error: " + ex.Message);
            }
            return isFound;
        }
        public static async Task<int> GetFeesAsync(int ApplicationID)
        {
            int fees = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = @"SELECT Fees From ApplicationTypes 
                                INNER JOIN Applications
                                ON ApplicationTypes.ID = Applications.ApplicationTypeID 
                        WHERE Applications.ID = @ApplicationID;";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                        Connection.Open();
                        object result = await Command.ExecuteScalarAsync();
                        if (result != null && int.TryParse(result.ToString(), out int result_))
                        {
                            fees = result_;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());

                //Console.WriteLine("Error: " + ex.Message);
            }
            return fees;
        }
        public static async Task<bool> CancelAsync(int ApplicationID)
        {
            int RowAffected = 0;
                try
                {
                    using (var Connection = new SqlConnection(DataSettings.ConnectionString))
                    {
                        string Query = "UPDATE Applications SET Status = 2 where ((ID = @ApplicationID) and (Status != 3));";
                        using (var command = new SqlCommand(Query, Connection))
                        {
                            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                            Connection.Open();
                            RowAffected = await command.ExecuteNonQueryAsync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                 return RowAffected > 0;
        }
        public static async Task<bool> UpdateStatusAsync(int ApplicationID, int StatusNumber)
        {
            int RowAffected = 0; 
            try
            {
                using (var Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = @"Update Applications 
                                SET Status = @StatusNumber,
                               LastStatusDate = @LastStatusDate
                    WHERE ID = @ApplicationID;";
                    using (var command = new SqlCommand(Query, Connection))
                    {
                        command.Parameters.AddWithValue("@StatusNumber", StatusNumber);
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now); 
                        Connection.Open();
                        RowAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
                // Console.WriteLine("Error: " + ex.Message);
            }
            return (RowAffected > 0);
        }
        public static async Task<string> GetFullNameOfApplicantAsync(int personID)
        {
            string name = "";
            try
            {
                using (var Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = @"SELECT Name From FullNames WHERE PersonID = @personID;";
                    using (var command = new SqlCommand(Query, Connection))
                    {
                        command.Parameters.AddWithValue("@personID", personID);
                        Connection.Open();
                        object result = await command.ExecuteScalarAsync();
                        if (result != null)
                        {
                            name = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DataSettings.LogError(ex.Message.ToString());
                //Console.WriteLine("Error: " + ex.Message);
            }
            return name; 
        }

    }
}
