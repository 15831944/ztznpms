using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace ztznpms.Common
{
    class MD5Encrypt
    {
        public static string GetMD5Password(string str)
        {
            string strMD5Password = String.Empty;
            MD5 md5 = MD5.Create();
            byte[] byteArray = md5.ComputeHash(Encoding.Unicode.GetBytes(str));
            for (int i = 0; i < byteArray.Length; i++)
            {
                strMD5Password += byteArray[i].ToString("x");
            }
            return strMD5Password;
        }
    }
}
