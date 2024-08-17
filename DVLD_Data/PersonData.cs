using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_Data
{
    public static class PersonData
    {
       public static bool getPersonInfo(int PersonID,ref stPerson person)
       {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);

            try
            {
                string Query = "select * from People where ID = @PersonID;";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@PersonID", PersonID);

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    isFound = true;
                    person.ID = (int)Reader["ID"];
                    person.NationalNumber = (string)Reader["NationalID"];
                    person.FirstName = (string)Reader["FirstName"];
                    person.SecondName = (string)Reader["SecondName"];
                    person.ThirdName = (string)Reader["ThirdName"];
                    person.LastName = (string)Reader["LastName"];
                    person.Email = (string)Reader["Email"];
                    person.PhoneNumber = (string)Reader["PhoneNumber"];
                    person.Address = (string)Reader["Address"];
                    person.Nationality = (string)Reader["Nationality"];
                    person.BirthDate = (DateTime)Reader["BirthDate"];
                    person.Gender = Convert.ToBoolean(Reader["Gender"]) ? "Male" : "Female";
                    person.PersonalPicture = (Reader["ProfilePicture"] == DBNull.Value) ? string.Empty : (string)Reader["ProfilePicture"];
                    person.CreatedByUserID = (int)Reader["CreatedByUserID"];
                    person.CreationDate = (DateTime)Reader["CreationDate"];
                    person.UpdatedDate = (DateTime)Reader["UpdateDate"];
                    person.UpdatedByUserID = (int)Reader["UpdateByUserID"];

                }

                Reader.Close();
            }

            catch(Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }

            return isFound; 
       }

        public static bool getPersonInfo(string NationalNumber, ref stPerson person)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);

            try
            {
                string Query = "select * from People where NationalID = @NationalNumber;";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    isFound = true;
                    person.ID = (int)Reader["ID"];
                    person.FirstName = (string)Reader["FirstName"];
                    person.SecondName = (string)Reader["SecondName"];
                    person.ThirdName = (string)Reader["ThirdName"];
                    person.NationalNumber = (string)Reader["NationalID"]; 
                    person.LastName = (string)Reader["LastName"];
                    person.Email = (string)Reader["Email"];
                    person.PhoneNumber = (string)Reader["PhoneNumber"];
                    person.Address = (string)Reader["Address"];
                    person.Nationality = (string)Reader["Nationality"];
                    person.BirthDate = (DateTime)Reader["BirthDate"];
                    person.Gender = Convert.ToBoolean(Reader["Gender"]) ? "Male" : "Female";
                    person.PersonalPicture = (Reader["ProfilePicture"] == DBNull.Value) ? string.Empty : (string)Reader["ProfilePicture"];
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

        public static int Add(stPerson person)
        {
            int newID = -1;

            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"INSERT INTO  
                        People   (FirstName,SecondName,ThirdName,LastName,NationalID,Address,Birthdate,Email,Nationality,ProfilePicture,PhoneNumber,Gender, CreatedByUserID, CreationDate, UpdateDate, UpdateByUserID)
                        VALUES  (@FirstName, @SecondName, @ThirdName, @LastName, @NationalID, @Address, @Birthdate, @Email, @Nationality, @ProfilePicture, @PhoneNumber, @Gender, @CreatedByUserID, @CreationDate, @UpdateDate, @UpdateByUserID);
                          SELECT SCOPE_IDENTITY();";

                SqlCommand Command = new SqlCommand(Query, Connection);

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

        public static bool Update(stPerson person)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
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
                    

                SqlCommand Command = new SqlCommand(Query, Connection);
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


                if(person.CreatedByUserID == -1)
                    Command.Parameters.AddWithValue("@CreatedByUserID", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@CreatedByUserID", person.CreatedByUserID);


                if(person.CreationDate == DateTime.MinValue)
                    Command.Parameters.AddWithValue("@CreationDate", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@CreationDate", person.CreationDate);



                Connection.Open();
                RowAffected =  Command.ExecuteNonQuery();
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

        public static bool Delete(int PersonID) 
        {
            int RowAffected = 0; 
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM People WHERE ID = @PersonID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
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

        public static bool Delete(string NationalNumber)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM People WHERE NationalID = @NationalNumber;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
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

        public static bool isExist(int PersonID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM People WHERE ID = @PersonID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
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

        public static bool isExist(string NationalNumber)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM People WHERE NationalID = @NationalNumber;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
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
                string Query = "SELECT * FROM People_View;";
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
    }
}
