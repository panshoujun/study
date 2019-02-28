using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Base64加解密
    /// </summary>
    public class Base64Helper : ICryptography
    {
        #region 接口实现
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str">加密字符串</param>
        /// <returns></returns>
        public string Encrypt(string str)
        {
            return EncodeBase64(str);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="str">解密字符串</param>
        /// <returns></returns>
        public string Decrypt(string str)
        {
            return DecodeBase64(str);
        }
        #endregion

        #region Base64加密
        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="str">待加密的明文</param>
        /// <param name="type">加密采用的编码方式</param>
        /// <returns>加密后的字符串</returns>
        public static string EncodeBase64(string str, string type = "UTF-8")
        {
            string encode = "";
            byte[] bytes = Encoding.GetEncoding(type).GetBytes(str);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = str;
            }
            return encode;
        }

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="str">待加密的明文</param>
        /// <returns>加密后的字符串</returns>
        public static string EncodeBase64(string str)
        {
            return EncodeBase64(str, Encoding.UTF8);
        }

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="str">待加密的明文</param>
        /// <param name="encode">加密采用的编码方式</param>
        /// <returns>加密后的字符串</returns>
        public static string EncodeBase64(string str, Encoding encode)
        {
            string result = "";
            byte[] bytes = encode.GetBytes(str);
            try
            {
                result = Convert.ToBase64String(bytes);
            }
            catch
            {
                result = str;
            }
            return result;
        }
        #endregion

        #region Base64解密
        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="str">待加密的明文</param>
        /// <param name="type">加密采用的编码方式</param>
        /// <returns>解密后的字符串</returns>
        public static string DecodeBase64(string str, string type = "UTF-8")
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(str);
            try
            {
                decode = Encoding.GetEncoding(type).GetString(bytes);
            }
            catch
            {
                decode = str;
            }
            return decode;
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="str">待加密的明文</param>
        /// <returns></returns>
        public static string DecodeBase64(string str)
        {
            return DecodeBase64(str, Encoding.UTF8);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="str">待加密的明文</param>
        /// <param name="encode">加密采用的编码方式</param>
        /// <returns>加密采用的编码方式</returns>
        public static string DecodeBase64(string str, Encoding encode)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(str);
            try
            {
                decode = encode.GetString(bytes);
            }
            catch
            {
                decode = str;
            }
            return decode;
        }
        #endregion
    }

    public sealed class Base64Security
    {
        public static string EncodeBase64(string code)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.GetEncoding(System.Text.Encoding.UTF8.CodePage).GetBytes(code));
        }
        public static string DecodeBase64(string code)
        {
            string result;
            try
            {
                byte[] bytes = System.Convert.FromBase64String(code);
                result = System.Text.Encoding.GetEncoding(System.Text.Encoding.UTF8.CodePage).GetString(bytes);
            }
            catch
            {
                result = code;
            }
            return result;
        }
    }
}
