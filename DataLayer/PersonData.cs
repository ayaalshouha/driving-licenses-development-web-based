using Microsoft.Data.SqlClient; 
using DTOsLayer;
using System.Reflection.PortableExecutable;

namespace DataLayer
{
    public static class PersonData
    {
        public static async Task<Person> getPersonInfoAsync(int PersonID)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "select * from People where ID = @PersonID;";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@PersonID", PersonID);
                        Connection.Open();
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while (await Reader.ReadAsync())
                            {
                                return new Person(
                                    Reader.GetInt32(Reader.GetOrdinal("ID")),
                                    Reader.GetString(Reader.GetOrdinal("FirstName")),
                                    Reader.GetString(Reader.GetOrdinal("SecondName")),
                                    Reader.GetString(Reader.GetOrdinal("ThirdName")),
                                    Reader.GetString(Reader.GetOrdinal("LastName")),
                                    Reader.GetString(Reader.GetOrdinal("NationalID")),
                                    Reader.GetString(Reader.GetOrdinal("Address")),
                                    Reader.GetString(Reader.GetOrdinal("Email")),
                                    Reader.GetString(Reader.GetOrdinal("PhoneNumber")),
                                    DateOnly.FromDateTime(Reader.GetDateTime(Reader.GetOrdinal("BirthDate"))).ToString("yyyy-MM-dd"),
                                    Reader.IsDBNull(Reader.GetOrdinal("ProfilePicture")) ? string.Empty : Reader.GetString(Reader.GetOrdinal("ProfilePicture")),
                                    Reader.GetString(Reader.GetOrdinal("Nationality")),
                                    Reader.GetBoolean(Reader.GetOrdinal("Gender")) ? "Male" : "Female",

                                    Reader.GetInt32(Reader.GetOrdinal("CreatedByUserID")),

                                    Reader.IsDBNull(Reader.GetOrdinal("CreationDate")) ?DateTime.MinValue:
                                    Reader.GetDateTime(Reader.GetOrdinal("CreationDate")),

                                    Reader.IsDBNull(Reader.GetOrdinal("UpdateByUserID")) ? null
                                    : Reader.GetInt32(Reader.GetOrdinal("UpdateByUserID")),

                                    Reader.IsDBNull(Reader.GetOrdinal("UpdateDate")) ? null :
                                    Reader.GetDateTime(Reader.GetOrdinal("UpdateDate"))
                                );
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("test" + ex.Message.ToString());
            }
            return null;
        }
        public static async Task<Person> getPersonInfoAsync(string NationalNum)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "select * from People where NationalID = @NationalNum;";
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@NationalNum", NationalNum);
                        Connection.Open();
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while (await Reader.ReadAsync())
                            {
                                return new Person(
                                    Reader.GetInt32(Reader.GetOrdinal("ID")),
                                    Reader.GetString(Reader.GetOrdinal("FirstName")),
                                    Reader.GetString(Reader.GetOrdinal("SecondName")),
                                    Reader.GetString(Reader.GetOrdinal("ThirdName")),
                                    Reader.GetString(Reader.GetOrdinal("LastName")),
                                    Reader.GetString(Reader.GetOrdinal("NationalID")),
                                    Reader.GetString(Reader.GetOrdinal("Address")),
                                    Reader.GetString(Reader.GetOrdinal("Email")),
                                    Reader.GetString(Reader.GetOrdinal("PhoneNumber")),
                                     DateOnly.FromDateTime(Reader.GetDateTime(Reader.GetOrdinal("BirthDate"))).ToString("yyyy-MM-dd"),
                                    Reader.IsDBNull(Reader.GetOrdinal("ProfilePicture")) ? string.Empty : Reader.GetString(Reader.GetOrdinal("ProfilePicture")),
                                    Reader.GetString(Reader.GetOrdinal("Nationality")),
                                    Reader.GetBoolean(Reader.GetOrdinal("Gender")) ? "Male" : "Female",

                                     Reader.GetInt32(Reader.GetOrdinal("CreatedByUserID")),

                                    Reader.IsDBNull(Reader.GetOrdinal("CreationDate")) ? DateTime.MinValue
                                    : Reader.GetDateTime(Reader.GetOrdinal("CreationDate")), 

                                    Reader.IsDBNull(Reader.GetOrdinal("UpdateByUserID")) ? 0
                                    : Reader.GetInt32(Reader.GetOrdinal("UpdateByUserID")),

                                    Reader.IsDBNull(Reader.GetOrdinal("UpdateDate")) ? DateTime.MinValue
                                    : Reader.GetDateTime(Reader.GetOrdinal("UpdateDate"))
                                );
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("test" + ex.Message.ToString());
            }
            return null;
        }
        public static async Task<int> AddAsync(Person person)
        {
            int newID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = @"INSERT INTO  
                        People   (FirstName,SecondName,ThirdName,LastName,NationalID,Address,Birthdate,Email,Nationality,ProfilePicture,PhoneNumber,Gender, CreatedByUserID, CreationDate, UpdateDate, UpdateByUserID)
                        VALUES  (@FirstName, @SecondName, @ThirdName, @LastName, @NationalID, @Address, @Birthdate, @Email, @Nationality, @ProfilePicture, @PhoneNumber, @Gender, @CreatedByUserID, @CreationDate, @UpdateDate, @UpdateByUserID);
                          SELECT SCOPE_IDENTITY();";

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@FirstName", person.FirstName);
                        Command.Parameters.AddWithValue("@SecondName", person.SecondName);
                        Command.Parameters.AddWithValue("@ThirdName", person.ThirdName);
                        Command.Parameters.AddWithValue("@LastName", person.LastName);
                        Command.Parameters.AddWithValue("@NationalID", person.NationalNumber);
                        Command.Parameters.AddWithValue("@Email", person.Email);
                        Command.Parameters.AddWithValue("@PhoneNumber", person.PhoneNumber);
                        Command.Parameters.AddWithValue("@Birthdate", DateOnly.Parse(person.BirthDate));
                        Command.Parameters.AddWithValue("@Address", person.Address);
                        Command.Parameters.AddWithValue("@Nationality", person.Nationality);
                        Command.Parameters.AddWithValue("@ProfilePicture", person.PersonalPicture);
                        Command.Parameters.AddWithValue("@CreatedByUserID", person.CreatedByUserID);
                        Command.Parameters.AddWithValue("@CreationDate", person.CreationDate);

                        if (person.Gender == "Male" || person.Gender == "male")
                            Command.Parameters.AddWithValue("@Gender", 1);
                        else
                            Command.Parameters.AddWithValue("@Gender", 0);

                        if (person.UpdatedDate == null || person.UpdatedDate == DateTime.MinValue)
                            Command.Parameters.AddWithValue("@UpdateDate", DBNull.Value);
                        else
                            Command.Parameters.AddWithValue("@UpdateDate", person.UpdatedDate);

                        if (person.UpdatedByUserID == null || person.UpdatedByUserID == 0)
                            Command.Parameters.AddWithValue("@UpdateByUserID", DBNull.Value);
                        else
                            Command.Parameters.AddWithValue("@UpdateByUserID", person.UpdatedByUserID);


                        Connection.Open();
                        object result = await Command.ExecuteScalarAsync();

                        if (result != null && int.TryParse(result.ToString(), out int LastID))
                        { newID = LastID; }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("test" + ex.Message.ToString());
            }
            return newID;
        }
        public static async Task<bool> UpdateAsync(Person person)
        {
            int RowAffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = @"Update People
                    SET FirstName = @FirstName,
                        SecondName = @SecondName, 
                        ThirdName = @ThirdName, 
                        LastName = @LastName,
                        NationalID = @NationalID, 
                        Address = @Address,
                        Birthdate = @Birthdate,
                        Email = @Email,
                        Nationality = @Nationality, 
                        ProfilePicture = @ProfilePicture, 
                        PhoneNumber = @PhoneNumber, 
                        Gender = @Gender,
                        CreatedByUserID = @CreatedByUserID, 
                        CreationDate = @CreationDate, 
                        UpdateDate = @UpdateDate,
                        UpdateByUserID = @UpdateByUserID
                        WHERE ID = @PersonID;";

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@PersonID", person.ID);
                        Command.Parameters.AddWithValue("@FirstName", person.FirstName);
                        Command.Parameters.AddWithValue("@SecondName", person.SecondName);
                        Command.Parameters.AddWithValue("@ThirdName", person.ThirdName);
                        Command.Parameters.AddWithValue("@LastName", person.LastName);
                        Command.Parameters.AddWithValue("@NationalID", person.NationalNumber);
                        Command.Parameters.AddWithValue("@Email", person.Email);
                        Command.Parameters.AddWithValue("@PhoneNumber", person.PhoneNumber);
                        Command.Parameters.AddWithValue("@Birthdate", DateOnly.Parse(person.BirthDate));
                        Command.Parameters.AddWithValue("@ProfilePicture", person.PersonalPicture);
                        Command.Parameters.AddWithValue("@Address", person.Address);
                        Command.Parameters.AddWithValue("@Nationality", person.Nationality);
                        Command.Parameters.AddWithValue("@UpdateDate", person.UpdatedDate);
                        Command.Parameters.AddWithValue("@UpdateByUserID", person.UpdatedByUserID);

                        if (person.Gender == "Male")
                            Command.Parameters.AddWithValue("@Gender", 1);
                        else
                            Command.Parameters.AddWithValue("@Gender", 0);

                        if (person.CreatedByUserID == 0)
                            Command.Parameters.AddWithValue("@CreatedByUserID", DBNull.Value);
                        else
                            Command.Parameters.AddWithValue("@CreatedByUserID", person.CreatedByUserID);

                        if (person.CreationDate == DateTime.MinValue)
                            Command.Parameters.AddWithValue("@CreationDate", DBNull.Value);
                        else
                            Command.Parameters.AddWithValue("@CreationDate", person.CreationDate);

                        Connection.Open();
                        RowAffected = await Command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine("test" + ex.Message.ToString());
            }

            return RowAffected > 0;
        }
        public static async Task<bool> DeleteAsync(int PersonID)
        {
            int RowAffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "DELETE  FROM People WHERE ID = @PersonID;";
                    using (SqlCommand command = new SqlCommand(Query, Connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        Connection.Open();
                        RowAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("test" + ex.Message.ToString());
            }

            return RowAffected > 0;
        }
        public static async Task<bool> DeleteAsync(string NationalNumber)
        {
            int RowAffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "DELETE  FROM People WHERE NationalID = @NationalNumber;";
                    using (SqlCommand command = new SqlCommand(Query, Connection))
                    {
                        command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
                        Connection.Open();
                        RowAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                //DataSettings.LogError(ex.Message.ToString());
                Console.WriteLine("test" + ex.Message.ToString());
            }
            return RowAffected > 0;
        }
        public static async Task<bool> isExistAsync(int PersonID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "SELECT ID FROM People WHERE ID = @PersonID;";
                    using (SqlCommand command = new SqlCommand(Query, Connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        Connection.Open();
                        object result =await command.ExecuteScalarAsync();
                        isFound = (result != null);
                    }
                }
            }
            catch (Exception ex)
            {
                //DataSettings.LogError(ex.Message.ToString());
                Console.WriteLine("Error: " + ex.Message);
            }
            return isFound;
        }
        public static async Task<bool> isExistAsync(string NationalNumber)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "SELECT ID FROM People WHERE NationalID = @NationalNumber;";
                    using (SqlCommand command = new SqlCommand(Query, Connection))
                    {
                        command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
                        Connection.Open();
                        object result = await command.ExecuteScalarAsync();
                        isFound = (result != null);
                    }
                }
            }
            catch (Exception ex)
            {
                //DataSettings.LogError(ex.Message.ToString());
                Console.WriteLine("test" + ex.Message.ToString());
            }
            return isFound;
        }
        public static async Task<IEnumerable<Person_View>> ListAsync()
        {
            var peopleList = new List<Person_View>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString))
                {
                    string Query = "SELECT * FROM People_View;";
                    using (SqlCommand command = new SqlCommand(Query, Connection))
                    {
                        Connection.Open();
                        using (SqlDataReader Reader = command.ExecuteReader())
                        {
                            while (await Reader.ReadAsync())
                            {
                                peopleList.Add(new Person_View
                                (
                                    Reader.GetInt32(Reader.GetOrdinal("ID")),
                                    Reader.GetString(Reader.GetOrdinal("FirstName")),
                                    Reader.GetString(Reader.GetOrdinal("SecondName")),
                                    Reader.GetString(Reader.GetOrdinal("ThirdName")),
                                    Reader.GetString(Reader.GetOrdinal("LastName")),
                                    Reader.GetString(Reader.GetOrdinal("NationalID")),
                                    Reader.GetString(Reader.GetOrdinal("Email")),
                                    Reader.GetString(Reader.GetOrdinal("PhoneNumber")),
                                    DateOnly.FromDateTime(Reader.GetDateTime(Reader.GetOrdinal("BirthDate"))).ToString("yyyy-MM-dd"),
                                    Reader.GetString(Reader.GetOrdinal("Nationality")),
                                    Reader.GetString(Reader.GetOrdinal("Gender"))
                                    ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //DataSettings.LogError(ex.Message.ToString());
                Console.WriteLine("test" + ex.Message.ToString());
            }

            return peopleList;
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

