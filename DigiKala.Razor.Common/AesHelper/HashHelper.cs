using System;
using System.Security.Cryptography;
using System.Text;

namespace DigiKala.Razor.Common.AesHelper
{
    public static class HashHelper
    {
        public static string MD5Encoding(string password)
        {
            Byte[] mainBytes;
            Byte[] encodeBytes;
            MD5 md5;
            md5 = new MD5CryptoServiceProvider();
            mainBytes = ASCIIEncoding.Default.GetBytes(password);
            encodeBytes = md5.ComputeHash(mainBytes);
            return BitConverter.ToString(encodeBytes);
        }
    }
}