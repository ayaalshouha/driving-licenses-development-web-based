using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Data
{
    public class LicenseClassesData
    {
        public static bool getClassInfo(int ClassID, ref stLicenseClass Class_) 
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "select * from LicenseClasses where ID = @ClassID";

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ClassID", ClassID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    isFound = true;
                    Class_.ID = (int)reader["ID"];
                    Class_.ClassName = (string)reader["Class"];
                    Class_.Description = (string)reader["Description"];
                    Class_.Fees = (decimal)reader["Fees"];
                    Class_.ValidityYears = (byte)reader["ValidityYears"];
                    Class_.MinAgeAllowed = (byte)reader["MinimumAgeAllowed"];
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


        public static bool Update(stLicenseClass Class_)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);

            try
            {
                string Query = @"Update LicenseClasses
                                SET Fees = @Fees
                WHERE ID = @licenseID;";

                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@licenseID", Class_.ID);
                Command.Parameters.AddWithValue("@Fees", Class_.Fees);

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

        public static List<string> getAllClassesName()
        {
            List<string> list = new List<string>();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "select Class from LicenseClasses;";
                SqlCommand command = new SqlCommand(Query, Connection);

                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(reader["Class"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return list;
        }

    }
}
