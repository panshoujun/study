using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface ICryptography
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str">加密字符串</param>
        /// <returns></returns>
        string Encrypt(string str);


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="str">解密字符串</param>
        /// <returns></returns>
        string Decrypt(string str);
    }
}
