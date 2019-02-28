using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// MD5加解密
    /// </summary>
    public class MD5Helper : ICryptography
    {
        #region MD5解密
        public string Decrypt(string str)
        {
            return DecryptStatic(str);
        }
        public static string DecryptStatic(string str)
        {
            return "MD5";
        }
        #endregion

        #region MD5加密
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">待加密的明文</param>
        /// <returns>加密后的字符串</returns>
        public static string EncryptStatic(string str)
        {
            StringBuilder result = new StringBuilder();
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

            for (int i = 0; i < bytes.Length; i++)
            {
                string hex = bytes[i].ToString("X");
                if (hex.Length == 1)
                {
                    result.Append("0");
                }
                result.Append(hex);
            }
            return result.ToString();
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">待加密的明文</param>
        /// <returns>加密后的字符串</returns>
        public string Encrypt(string str)
        {
            return EncryptStatic(str);
        }
        #endregion
    }
}
