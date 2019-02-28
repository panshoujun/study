using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    #region DES加解密 2个类效果相同
    /// <summary>
    /// DES加解密
    /// </summary>
    public class DESHelper : ICryptography
    {
        private static string key = "5C83B05C";

        /// <summary>
        /// 将字符串进行DES加密
        /// </summary>
        /// <param name="message"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string EncryptStatic(string message)
        {
            DES des = new DESCryptoServiceProvider();
            des.Key = Encoding.UTF8.GetBytes(key);
            des.IV = Encoding.UTF8.GetBytes(key);

            byte[] bytes = Encoding.UTF8.GetBytes(message);
            byte[] resultBytes = des.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
            
            return Convert.ToBase64String(resultBytes);
        }

        /// <summary>
        /// DEC 解密过程
        /// </summary>
        /// <param name="pToDecrypt">被解密的字符串</param>
        /// <param name="sKey">密钥（只支持8个字节的密钥，同前面的加密密钥相同）</param>
        /// <returns>返回被解密的字符串</returns>
        public static string DecryptStatic(string pToDecrypt)
        {
            byte[] c = Convert.FromBase64String(pToDecrypt);
            DES des = new DESCryptoServiceProvider();
            des.Key = Encoding.UTF8.GetBytes(key);
            des.IV = Encoding.UTF8.GetBytes(key);
            byte[] resultBytes = des.CreateDecryptor().TransformFinalBlock(c, 0, c.Length);
            return Encoding.UTF8.GetString(resultBytes);
        }

        #region 接口实现
        public string Encrypt(string str)
        {
            return EncryptStatic(str);
        }

        public string Decrypt(string str)
        {
            return DecryptStatic(str);
        }
        #endregion
    }

    /// <summary>
    /// DES加解密
    /// </summary>
    public class DESEncrypt : ICryptography
    {
        private const string KEY_64 = "5C83B05C";//"#CoolSh#";
        private const string IV_64 = "5C83B05C";//"#CoolSc#";
        public static string EncodeStatic(string data)
        {
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(KEY_64);
            byte[] bytes2 = System.Text.Encoding.ASCII.GetBytes(IV_64);
            System.Security.Cryptography.DESCryptoServiceProvider dESCryptoServiceProvider = new System.Security.Cryptography.DESCryptoServiceProvider();
            int keySize = dESCryptoServiceProvider.KeySize;
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, bytes2), System.Security.Cryptography.CryptoStreamMode.Write);
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(cryptoStream);
            streamWriter.Write(data);
            streamWriter.Flush();
            cryptoStream.FlushFinalBlock();
            streamWriter.Flush();
            return System.Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }
        public static string DecodeStatic(string data)
        {
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(KEY_64);
            byte[] bytes2 = System.Text.Encoding.ASCII.GetBytes(IV_64);
            byte[] buffer;
            string result;
            try
            {
                buffer = System.Convert.FromBase64String(data);
            }
            catch
            {
                result = null;
                return result;
            }
            System.Security.Cryptography.DESCryptoServiceProvider dESCryptoServiceProvider = new System.Security.Cryptography.DESCryptoServiceProvider();
            System.IO.MemoryStream stream = new System.IO.MemoryStream(buffer);
            System.Security.Cryptography.CryptoStream stream2 = new System.Security.Cryptography.CryptoStream(stream, dESCryptoServiceProvider.CreateDecryptor(bytes, bytes2), System.Security.Cryptography.CryptoStreamMode.Read);
            System.IO.StreamReader streamReader = new System.IO.StreamReader(stream2);
            result = streamReader.ReadToEnd();
            return result;
        }

        #region
        public string Encrypt(string str)
        {
            return EncodeStatic(str);
        }

        public string Decrypt(string str)
        {
            return DecodeStatic(str);
        }
        #endregion
    }
    #endregion
   
}
