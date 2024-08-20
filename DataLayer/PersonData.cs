using DTOs;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient; 

namespace DataLayer
{
    public static class PersonData
    {
        public static Person getPersonInfo(int PersonID)
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
                            while (Reader.Read())
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
                                    Reader.GetDateTime(Reader.GetOrdinal("BirthDate")),
                                    Reader.IsDBNull(Reader.GetOrdinal("ProfilePicture")) ? string.Empty : Reader.GetString(Reader.GetOrdinal("ProfilePicture")),
                                    Reader.GetString(Reader.GetOrdinal("Nationality")),
                                    Reader.GetBoolean(Reader.GetOrdinal("Gender")) ? "Male" : "Female",
                                    Reader.GetInt32(Reader.GetOrdinal("CreatedByUserID")),
                                    Reader.GetDateTime(Reader.GetOrdinal("CreationDate")),
                                    Reader.GetInt32(Reader.GetOrdinal("UpdateByUserID")),
                                    Reader.GetDateTime(Reader.GetOrdinal("UpdateDate"))
                                );
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            return null;
        }
        public static Person getPersonInfo(string NationalNum)
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
                            while (Reader.Read())
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
                                    Reader.GetDateTime(Reader.GetOrdinal("BirthDate")),
                                    Reader.IsDBNull(Reader.GetOrdinal("ProfilePicture")) ? string.Empty : Reader.GetString(Reader.GetOrdinal("ProfilePicture")),
                                    Reader.GetString(Reader.GetOrdinal("Nationality")),
                                    Reader.GetBoolean(Reader.GetOrdinal("Gender")) ? "Male" : "Female",
                                    Reader.GetInt32(Reader.GetOrdinal("CreatedByUserID")),
                                    Reader.GetDateTime(Reader.GetOrdinal("CreationDate")),
                                    Reader.GetInt32(Reader.GetOrdinal("UpdateByUserID")),
                                    Reader.GetDateTime(Reader.GetOrdinal("UpdateDate"))
                                );
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            return null;
        }
        public static int Add(Person person)
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
                        Command.Parameters.AddWithValue("@Birthdate", person.BirthDate);
                        Command.Parameters.AddWithValue("@Address", person.Address);
                        Command.Parameters.AddWithValue("@Nationality", person.Nationality);
                        Command.Parameters.AddWithValue("@ProfilePicture", person.PersonalPicture);
                        Command.Parameters.AddWithValue("@CreatedByUserID", person.CreatedByUserID);
                        Command.Parameters.AddWithValue("@CreationDate", person.CreationDate);

                        if (person.Gender == "Male")
                            Command.Parameters.AddWithValue("@Gender", 1);
                        else
                            Command.Parameters.AddWithValue("@Gender", 0);

                        if (person.UpdatedDate == DateTime.MinValue)
                            Command.Parameters.AddWithValue("@UpdateDate", DBNull.Value);
                        else
                            Command.Parameters.AddWithValue("@UpdateDate", person.UpdatedDate);

                        if (person.UpdatedByUserID == -1)
                            Command.Parameters.AddWithValue("@UpdateByUserID", DBNull.Value);
                        else
                            Command.Parameters.AddWithValue("@UpdateByUserID", person.UpdatedByUserID);


                        Connection.Open();
                        object result = Command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int LastID))
                        { newID = LastID; }
                    }
                }
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            return newID;
        }
        public static bool Update(Person person)
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
                        Command.Parameters.AddWithValue("@Birthdate", person.BirthDate);
                        Command.Parameters.AddWithValue("@ProfilePicture", person.PersonalPicture);
                        Command.Parameters.AddWithValue("@Address", person.Address);
                        Command.Parameters.AddWithValue("@Nationality", person.Nationality);
                        Command.Parameters.AddWithValue("@UpdateDate", person.UpdatedDate);
                        Command.Parameters.AddWithValue("@UpdateByUserID", person.UpdatedByUserID);

                        if (person.Gender == "Male")
                            Command.Parameters.AddWithValue("@Gender", 1);
                        else
                            Command.Parameters.AddWithValue("@Gender", 0);

                        if (person.CreatedByUserID == -1)
                            Command.Parameters.AddWithValue("@CreatedByUserID", DBNull.Value);
                        else
                            Command.Parameters.AddWithValue("@CreatedByUserID", person.CreatedByUserID);

                        if (person.CreationDate == DateTime.MinValue)
                            Command.Parameters.AddWithValue("@CreationDate", DBNull.Value);
                        else
                            Command.Parameters.AddWithValue("@CreationDate", person.CreationDate);

                        Connection.Open();
                        RowAffected = Command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }

            return RowAffected > 0;
        }
        public static bool Delete(int PersonID)
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
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }

            return RowAffected > 0;
        }
        public static bool Delete(string NationalNumber)
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
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            return RowAffected > 0;
        }
        public static bool isExist(int PersonID)
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
                        object result = command.ExecuteScalar();
                        isFound = (result != null);
                    }
                }
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
                //Console.WriteLine("Error: " + ex.Message);
            }
            return isFound;
        }
        public static bool isExist(string NationalNumber)
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
                        object result = command.ExecuteScalar();
                        isFound = (result != null);
                    }
                }
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            return isFound;
        }
        public static List<Person_View> List()
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
                            if (Reader.HasRows)
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
                                    Reader.GetDateTime(Reader.GetOrdinal("BirthDate")),
                                    Reader.GetString(Reader.GetOrdinal("Nationality")),
                                    Reader.GetBoolean(Reader.GetOrdinal("Gender")) ? "Male" : "Female")
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //DataSettings.StoreUsingEventLogs(ex.Message.ToString());
                Console.WriteLine("test" + ex.Message.ToString());
            }

            return peopleList;
        }

    }
}

