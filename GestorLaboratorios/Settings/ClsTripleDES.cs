using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GestorLaboratorios.Settings
{
    public class ClsTripleDES
    {
        /// <summary>
        /// define the local property arrays
        /// </summary>
        private byte[] m_key;
        private byte[] m_iv;

        /// <summary>
        /// Contrustor
        /// </summary>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        public ClsTripleDES(byte[] key, byte[] iv)
        {
            this.m_key = key;
            this.m_iv = iv;
        }

        /// <summary>
        /// Tranformar encryptacion y devolver string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string Encrypt(string text)
        {
            byte[] input = null;
            input = Encoding.UTF8.GetBytes(text);

            TripleDESCryptoServiceProvider symmetricKey = default(TripleDESCryptoServiceProvider);
            symmetricKey = new TripleDESCryptoServiceProvider();
            symmetricKey.Mode = CipherMode.CBC;

            MemoryStream memoryStream = default(MemoryStream);
            memoryStream = new MemoryStream();

            CryptoStream cryptoStream = default(CryptoStream);
            cryptoStream = new CryptoStream(memoryStream, symmetricKey.CreateEncryptor(m_key, m_iv), CryptoStreamMode.Write);

            cryptoStream.Write(input, 0, input.Length);
            cryptoStream.FlushFinalBlock();

            byte[] cipherTextBytes = null;
            cipherTextBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            return Convert.ToBase64String(cipherTextBytes);
        }

        /// <summary>
        /// Tranformar decepcritacion y devolver string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string Decrypt(string text)
        {
            TripleDESCryptoServiceProvider symmetricKey = default(TripleDESCryptoServiceProvider);
            symmetricKey = new TripleDESCryptoServiceProvider();

            symmetricKey.Mode = CipherMode.CBC;

            byte[] cipherTextBytes = null;
            cipherTextBytes = Convert.FromBase64String(text);

            MemoryStream memoryStream = default(MemoryStream);
            memoryStream = new MemoryStream(cipherTextBytes);

            CryptoStream cryptoStream = default(CryptoStream);
            cryptoStream = new CryptoStream(memoryStream, symmetricKey.CreateDecryptor(m_key, m_iv), CryptoStreamMode.Read);

            byte[] plainTextBytes = null;
            plainTextBytes = new byte[cipherTextBytes.Length + 1];

            int decryptedByteCount = 0;
            decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            memoryStream.Close();
            cryptoStream.Close();

            string plainText = null;
            plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

    }
}
