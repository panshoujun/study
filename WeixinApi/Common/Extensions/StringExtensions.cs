using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Common
{
    /// <summary>
    /// String扩展方法
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 兼容null的Trim方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string TryTrim(this string input)
        {
            if (input == null)
            {
                return null;
            }
            else
            {
                return input.Trim();
            }
        }

        /// <summary>
        /// 判断字段串是否是null，空，或纯空格
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string input)
        {
            if (input == null)
            {
                return true;
            }
            if (input.Trim() == string.Empty)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 去除结尾的0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string DecimalToString(this decimal? value)
        {
            var val = value.ToString().Trim('0');
            val = (val.IndexOf('.') + 1) == val.Length ? val.Substring(0, val.IndexOf('.')) : val;
            return val;
        }
    }
}
