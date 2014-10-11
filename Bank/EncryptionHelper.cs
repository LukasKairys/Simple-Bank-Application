using System;
using System.Security.Cryptography;

namespace Bank
{
    class EncryptionHelper
    {
        private static string key = "asdfghjklpoiuytreqwzxcvbnmlkjhff";
        private static string IV = "wieurytudidkekri";

        public static string Encrypt(string name)
        {
            byte[] nameInBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(name);

            AesCryptoServiceProvider aes = CreateAesProvider();

            ICryptoTransform crypto = aes.CreateEncryptor(aes.Key, aes.IV);

            byte[] encrypted = crypto.TransformFinalBlock(nameInBytes, 0, nameInBytes.Length);

            crypto.Dispose();

            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string encrypted)
        {
            byte[] encryptedInBytes = Convert.FromBase64String(encrypted);

            AesCryptoServiceProvider aes = CreateAesProvider();

            ICryptoTransform crypto = aes.CreateDecryptor(aes.Key, aes.IV);

            byte[] nameInBytes = crypto.TransformFinalBlock(encryptedInBytes, 0, encryptedInBytes.Length);
            crypto.Dispose();

            string result = System.Text.ASCIIEncoding.ASCII.GetString(nameInBytes);

            return result;

        }

        private static AesCryptoServiceProvider CreateAesProvider()
        {
            
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();

            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            aes.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;

            return aes;
        }
    }
}
