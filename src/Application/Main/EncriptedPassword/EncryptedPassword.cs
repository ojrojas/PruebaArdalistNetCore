using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Main
{
    /// <summary>
    /// Encripted Password 
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>10/07/2021</date>
    public class EncryptedPassword : IEncryptedPassword
    {
        private readonly IConfiguration _configuration;

        public EncryptedPassword(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateEncryptedPasswordAsync(string password)
        {
            try
            {
                string passPhrase = _configuration["PassPhrase"];
                string saltValue = _configuration["SaltValue"];
                string hashAlgorithm = _configuration["HashAlgorithm"];
                int passwordIterations = 1;
                string initVector = _configuration["InitVector"]; ;
                int keySize = 128;

                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(password);

                PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
                byte[] keyBytes = passwordDeriveBytes.GetBytes(keySize / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged
                {
                    Mode = CipherMode.CBC
                };

                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();

                byte[] cipherTextBytes = memoryStream.ToArray();

                memoryStream.Close();
                cryptoStream.Close();

                string cipherText = Convert.ToBase64String(cipherTextBytes);
                await Task.CompletedTask;
                return cipherText;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }
    }
}
