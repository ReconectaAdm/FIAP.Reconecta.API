using System.Security.Cryptography;
using System.Text;

namespace FIAP.Reconecta.Application.Extensions
{
    public static class CryptExtensions
    {
        private static readonly string Key = "9DVtgSzVGceAU7V3";

        public static string AESEncryptString(string content)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using MemoryStream memoryStream = new();
            using CryptoStream cryptoStream = new(memoryStream, encryptor, CryptoStreamMode.Write);
            using (StreamWriter streamWriter = new(cryptoStream))
            {
                streamWriter.Write(content);
            }

            array = memoryStream.ToArray();

            return Convert.ToBase64String(array);
        }

        public static string AESDecryptString(string encryptedHash)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(encryptedHash);

            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = iv;

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using MemoryStream memoryStream = new(buffer);
            using CryptoStream cryptoStream = new(memoryStream, decryptor, CryptoStreamMode.Read);
            using StreamReader streamReader = new(cryptoStream);

            return streamReader.ReadToEnd();
        }
    }
}
