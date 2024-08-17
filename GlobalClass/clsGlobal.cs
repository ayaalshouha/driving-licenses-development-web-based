using DVLD_Buissness;
using Microsoft.Win32;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD___Driving_Licenses_Managment
{
    public class Logger
    {
        public delegate bool LogAction (clsUser loggedInUser);
        private LogAction _LogAction; 

        public Logger(LogAction Action)
        {
            _LogAction = Action;
        }

        public bool Log(clsUser loggedInUser)
        {
            return _LogAction(loggedInUser);
        }
    }

    internal class clsGlobal
    {

        public static clsUser CurrentUser;

        public static string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD_config";
        public static string UsernameValueName = "username";
        public static string PasswordValueName = "password";
        public static string UsernameValueData = string.Empty;
        public static string PasswordValueData = string.Empty;
        // Key for AES encryption (128-bit key)
        private static string _Key = "1234567890123456";

        static string Encrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES encryption
                aesAlg.Key = Encoding.UTF8.GetBytes(_Key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create an encryptor
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


                // Encrypt the data
                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }


                    // Return the encrypted data as a Base64-encoded string
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }


        static string Decrypt(string cipherText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES decryption
                aesAlg.Key = Encoding.UTF8.GetBytes(_Key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create a decryptor
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


                // Decrypt the data
                using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                {
                    // Read the decrypted data from the StreamReader
                    return srDecrypt.ReadToEnd();
                }
            }
        }

        //save username and password using Windows Registry
        public static bool SaveUsingRegistry(string usernameValue ="", string passwordValue = "")
        {
            UsernameValueData = usernameValue;
            PasswordValueData = Encrypt(passwordValue);
            try
            {
                Registry.SetValue(KeyPath, UsernameValueName, UsernameValueData, RegistryValueKind.String);
                Registry.SetValue(KeyPath, PasswordValueName, PasswordValueData, RegistryValueKind.String);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
            }

            return false; 
        }

        public static bool getUsernamePasswordUsingRegistry(ref string usernameValue,ref string passwordValue)
        {
            try
            {
                string value1 =  Registry.GetValue(KeyPath, UsernameValueName , null) as string;
                string value2 = Registry.GetValue(KeyPath, PasswordValueName, null) as string;

                if(value1  == null && value2 == null)
                {
                    usernameValue = string.Empty; 
                    passwordValue = string.Empty;
                }
                else
                {
                    usernameValue = value1;
                    passwordValue = Decrypt(value2);
                }
                
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
            }

            return false;
        }

        //save the last username and password to a file 
        public static bool RememberUsernameAndPasswordUsingFiles(clsUser user = null)
        {
            string username, password;

            if (user == null)
            {
                username = "";
                password = "";

            }
            else
            {
                username = user.username; 
                password = user.password;
            }


            try
            {
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                string filePath = currentDirectory + "\\login.txt";

                if (username == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }

                string DataLine = username + "#//#" + password;
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(DataLine);
                    return true; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return false;
        }

        //get the stored username and password
        public static bool getStoredUsernameAndPasswordUsingFiles(ref string Username, ref string Password)
        {
            try
            {
                //get current directory 
                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

                //filePath 
                string FilePath = CurrentDirectory + "\\login.txt";

                if (File.Exists(FilePath))
                {
                    using (StreamReader reader = new StreamReader(FilePath))
                    {
                        string line;

                        while((line = reader.ReadLine()) != null) 
                        {
                            Console.WriteLine(line); 
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = result[0];
                            Password = result[1];
                        }
                        return true; 
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message); 
                
            }
            return false; 
        }

        //validate a number 
        public static bool ValidateInteger(string Number)
        {
            var pattern = "^[0-9].$";
            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }
        public static bool ValidateFloat(string Number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";
            var regex = new Regex(pattern);
            return regex.IsMatch(Number);
        }
        public static bool isNumber(string Number)
        {
            return ValidateFloat(Number) || ValidateInteger(Number); 
        }
        public static bool ValidateEmail(string email)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            var regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }
            return true;
        }
        public static string GenerateGUID()
        {
            return Guid.NewGuid().ToString();
        }
        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            FileInfo fileinfo = new FileInfo(sourceFile);
            string extn = fileinfo.Extension;
            return GenerateGUID() + extn;

        }
        public static bool CopyImageToProjectFolder(ref string SourceFile)
        {
            string DestinationFolder = @"C:\DVLD - Driving Licenses Managment-People-Images\"; 

            if (!CreateFolderIfDoesNotExist(DestinationFolder))
                return false;



            string DestinationFile = DestinationFolder + ReplaceFileNameWithGUID(SourceFile);
            try
            {
                File.Copy(SourceFile, DestinationFile, true);

            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            SourceFile = DestinationFile; 
            return true;
        }


        public static string ComputeHash(string input)
        {
            //SHA is Secutred Hash Algorithm.
            // Create an instance of the SHA-256 algorithm

            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));


                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }

}
