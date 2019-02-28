using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Common
{
    #region DES加解密 一样
    ///// <summary>
    ///// DES3加解密
    ///// </summary>
    //public class DES3Helper : ICryptography
    //{
    //    private const string key = "12345678";

    //    /// <summary>
    //    /// 将字符串进行DES加密
    //    /// </summary>
    //    /// <param name="message"></param>
    //    /// <param name="key"></param>
    //    /// <returns></returns>
    //    public static string EncryptStatic(string message)
    //    {
    //        DES des = new DESCryptoServiceProvider();
    //        des.Key = Encoding.UTF8.GetBytes(key);
    //        des.IV = Encoding.UTF8.GetBytes(key);

    //        byte[] bytes = Encoding.UTF8.GetBytes(message);
    //        byte[] resultBytes = des.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);

    //        return Convert.ToBase64String(resultBytes);
    //    }

    //    /// <summary>
    //    /// DEC 解密过程
    //    /// </summary>
    //    /// <param name="pToDecrypt">被解密的字符串</param>
    //    /// <param name="sKey">密钥（只支持8个字节的密钥，同前面的加密密钥相同）</param>
    //    /// <returns>返回被解密的字符串</returns>
    //    public static string DecryptStatic(string pToDecrypt)
    //    {
    //        byte[] c = Convert.FromBase64String(pToDecrypt);
    //        DES des = new DESCryptoServiceProvider();
    //        des.Key = Encoding.UTF8.GetBytes(key);
    //        des.IV = Encoding.UTF8.GetBytes(key);
    //        byte[] resultBytes = des.CreateDecryptor().TransformFinalBlock(c, 0, c.Length);
    //        return Encoding.UTF8.GetString(resultBytes);
    //    }

    //    #region 接口实现
    //    public string Encrypt(string str)
    //    {
    //        return EncryptStatic(str);
    //    }

    //    public string Decrypt(string str)
    //    {
    //        return DecryptStatic(str);
    //    }
    //    #endregion
    //}
    #endregion

    #region DES3加解密(DES3比DES安全)
    /// <summary>
    /// DES3加解密
    /// </summary>
    public class DES3Helper : DES3Encrypt
    { 
    }

    /// <summary>
    /// DES3加解密
    /// </summary>
    public class DES3Encrypt: ICryptography
    {
        private const string KEY_64 = "ksax123";//"#CoolSh#";
        private const string IV_64 = "ksax123";//"#CoolSc#";
        public static string EncodeStatic(string pToEncrypt, string sKey = KEY_64)
        {
            pToEncrypt = HttpContext.Current.Server.UrlEncode(pToEncrypt);
            System.Security.Cryptography.DESCryptoServiceProvider dESCryptoServiceProvider = new System.Security.Cryptography.DESCryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(pToEncrypt);
            sKey = FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8);
            dESCryptoServiceProvider.Key = System.Text.Encoding.ASCII.GetBytes(sKey);
            dESCryptoServiceProvider.IV = System.Text.Encoding.ASCII.GetBytes(sKey);
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            byte[] array = memoryStream.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                byte b = array[i];
                stringBuilder.AppendFormat("{0:X2}", b);
            }
            stringBuilder.ToString();
            return stringBuilder.ToString();
        }
        public static string DecodeStatic(string pToDecrypt, string sKey = KEY_64)
        {
            System.Security.Cryptography.DESCryptoServiceProvider dESCryptoServiceProvider = new System.Security.Cryptography.DESCryptoServiceProvider();
            byte[] array = new byte[pToDecrypt.Length / 2];
            for (int i = 0; i < pToDecrypt.Length / 2; i++)
            {
                int num = System.Convert.ToInt32(pToDecrypt.Substring(i * 2, 2), 16);
                array[i] = (byte)num;
            }
            sKey = FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8);
            dESCryptoServiceProvider.Key = System.Text.Encoding.ASCII.GetBytes(sKey);
            dESCryptoServiceProvider.IV = System.Text.Encoding.ASCII.GetBytes(sKey);
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
            cryptoStream.Write(array, 0, array.Length);
            cryptoStream.FlushFinalBlock();
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            return HttpContext.Current.Server.UrlDecode(System.Text.Encoding.Default.GetString(memoryStream.ToArray()));
        }

        public string Encrypt(string str)
        {
            return EncodeStatic(str);
        }

        public string Decrypt(string str)
        {
            return DecodeStatic(str);
        }
    }
    #endregion
}
