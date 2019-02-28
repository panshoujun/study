using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 简单加密方式
    /// </summary>
    public class SimpleSecurityHelper : ICryptography
    {
        private static byte[] Keys = new byte[]
		{
			18,
			52,
			86,
			120,
			144,
			171,
			205,
			239
		};

        private static string KeyValue = "#ovesho#";
        public static string EncryptStatic(string encryptString, string encryptKey)
        {
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            string result;
            try
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] keys = SimpleSecurityHelper.Keys;
                byte[] bytes2 = System.Text.Encoding.UTF8.GetBytes(encryptString);
                System.Security.Cryptography.DESCryptoServiceProvider dESCryptoServiceProvider = new System.Security.Cryptography.DESCryptoServiceProvider();
                System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, keys), System.Security.Cryptography.CryptoStreamMode.Write);
                cryptoStream.Write(bytes2, 0, bytes2.Length);
                cryptoStream.FlushFinalBlock();
                System.Text.Encoding uTF = System.Text.Encoding.UTF8;
                result = System.Convert.ToBase64String(uTF.GetBytes(System.Convert.ToBase64String(memoryStream.ToArray())));
            }
            catch
            {
                result = "Encrypt Failed!";
            }
            finally
            {
                memoryStream.Close();
            }
            return result;
        }
        public static string EncryptStatic(string encryptString)
        {
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            string result;
            try
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(SimpleSecurityHelper.KeyValue.Substring(0, 8));
                byte[] keys = SimpleSecurityHelper.Keys;
                byte[] bytes2 = System.Text.Encoding.UTF8.GetBytes(encryptString);
                System.Security.Cryptography.DESCryptoServiceProvider dESCryptoServiceProvider = new System.Security.Cryptography.DESCryptoServiceProvider();
                System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, keys), System.Security.Cryptography.CryptoStreamMode.Write);
                cryptoStream.Write(bytes2, 0, bytes2.Length);
                cryptoStream.FlushFinalBlock();
                System.Text.Encoding uTF = System.Text.Encoding.UTF8;
                result = System.Convert.ToBase64String(uTF.GetBytes(System.Convert.ToBase64String(memoryStream.ToArray())));
            }
            catch
            {
                result = "Encrypt Failed!";
            }
            finally
            {
                memoryStream.Close();
            }
            return result;
        }
        public static string DecryptStatic(string decryptString, string decryptKey)
        {
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            string result;
            try
            {
                System.Text.Encoding uTF = System.Text.Encoding.UTF8;
                decryptString = uTF.GetString(System.Convert.FromBase64String(decryptString));
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(decryptKey);
                byte[] keys = SimpleSecurityHelper.Keys;
                byte[] array = System.Convert.FromBase64String(decryptString);
                System.Security.Cryptography.DESCryptoServiceProvider dESCryptoServiceProvider = new System.Security.Cryptography.DESCryptoServiceProvider();
                System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(bytes, keys), System.Security.Cryptography.CryptoStreamMode.Write);
                cryptoStream.Write(array, 0, array.Length);
                cryptoStream.FlushFinalBlock();
                result = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            catch
            {
                result = "Decrypt Failed!";
            }
            finally
            {
                memoryStream.Close();
            }
            return result;
        }
        public static string DecryptStatic(string decryptString)
        {
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            string result;
            try
            {
                System.Text.Encoding uTF = System.Text.Encoding.UTF8;
                decryptString = uTF.GetString(System.Convert.FromBase64String(decryptString));
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(SimpleSecurityHelper.KeyValue);
                byte[] keys = SimpleSecurityHelper.Keys;
                byte[] array = System.Convert.FromBase64String(decryptString);
                System.Security.Cryptography.DESCryptoServiceProvider dESCryptoServiceProvider = new System.Security.Cryptography.DESCryptoServiceProvider();
                System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(bytes, keys), System.Security.Cryptography.CryptoStreamMode.Write);
                cryptoStream.Write(array, 0, array.Length);
                cryptoStream.FlushFinalBlock();
                result = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            catch
            {
                result = "Decrypt Failed!";
            }
            finally
            {
                memoryStream.Close();
            }
            return result;
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
}
