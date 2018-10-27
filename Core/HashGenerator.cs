using System;
using System.Security.Cryptography;
using System.Text;

namespace bookshop.Core
{
    public class HashGenerator
    {

        public const int SaltSize = 32;
        public static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();
            
            byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
                plainTextWithSaltBytes[i] = plainText[i];
            
            for (int i = 0; i < salt.Length; i++)
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            
            return algorithm.ComputeHash(plainTextWithSaltBytes);            
        }

        public static bool Compare(byte[] first, byte[] second ){
            if (first.Length != second.Length)
                return false;

            for (int i = 0; i < first.Length; i++){
                if (first[i]  != second[i])
                    return false;
            }

            return true;
        }

        public static string ByteArrayToString(byte[] byteArray)
        {
            return Convert.ToBase64String(byteArray);
        }

        public static byte[] StringToByteArray(string str)
        {
            return Convert.FromBase64String(str);
        }

        public static byte[] EncodedStringToByteArray(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        

        public static byte[] GenerateSaltBytes(){
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] s = new byte[SaltSize];
            rng.GetBytes(s);
            return s;
        }
    }
}