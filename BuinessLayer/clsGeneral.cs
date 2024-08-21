using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    public static class clsGeneral
    {
        // Key for AES encryption (128-bit key)
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("1234567890123456");
        private static readonly byte[] IV = new byte[16]; // AES block size is 16 bytes
        public static string Encrypt(string plainText)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;
                    aesAlg.Padding = PaddingMode.PKCS7;

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }

                        // Return the encrypted data as a Base64-encoded string
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new ApplicationException("Encryption failed.", ex);
            }
        }
        public static string Decrypt(string cipherText)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;
                    aesAlg.Padding = PaddingMode.PKCS7; // Ensure padding is set correctly

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(cipherText);
                        }

                        // Return the encrypted data as a Base64-encoded string
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new ApplicationException("Encryption failed.", ex);
            }
        }
    
    }
}
