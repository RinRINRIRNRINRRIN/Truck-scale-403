using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TSC403.Functions
{
    internal class AESEncrystion
    {
        private readonly byte[] key = Encoding.UTF8.GetBytes("12345678901234567890123456789012"); // 32 ตัวอักษร
        private readonly byte[] iv = Encoding.UTF8.GetBytes("1234567890123456"); // 16 ตัวอักษร


        /// <summary>
        /// เข้ารหัสในรูปแบบ AES และแปลงเป็น base64
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public string Encrypt(string plaintext)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Mode = CipherMode.CBC; // เลือกโหมด CBC
                aesAlg.Padding = PaddingMode.PKCS7; // เลือก Padding ที่ใช้

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(key, iv);
                byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
                byte[] ciphertext = encryptor.TransformFinalBlock(plaintextBytes, 0, plaintextBytes.Length);
                Console.WriteLine("Encrypt : " + Convert.ToBase64String(ciphertext));
                return Convert.ToBase64String(ciphertext); // แปลงเป็น Base64
            }
        }


        /// <summary>
        /// สำหรับถอดรหัส
        /// </summary>
        /// <param name="encryptedText">รหัส baes64 ที่ได้จาก api</param>
        /// <returns></returns>
        public string Decrypt(string encryptedText)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    //aes.Key = key;
                    //aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    //ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                    ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);
                    byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                    byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                    Console.WriteLine("Decryption : " + Encoding.UTF8.GetString(decryptedBytes));
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
