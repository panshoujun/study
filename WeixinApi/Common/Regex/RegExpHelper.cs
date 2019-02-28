using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public class RegExpHelper
    {
        #region 表达式常量
        public const string EmailPattern = @"^\w+([-+.]\w+)*@(\w)+(\.)(com|com\.cn|net|cn|net\.cn|org|biz|info|gov|gov\.cn|edu|edu\.cn)$";
        public const string MobilePattern = @"^1\d{10}$";
        public const string FormatParam = @"{\d}";
        public const string NamePattern = @"^[\u4e00-\u9fa5]{2,5}";
        #endregion

        #region 表达式验证
        /// <summary>
        /// 判断是否是邮箱
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmail(string value)
        {
            Regex regex = new Regex(EmailPattern);
            return regex.IsMatch(value);
        }

        /// <summary>
        /// 判断是否是手机
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsMobile(string value)
        {
            Regex regex = new Regex(MobilePattern);
            return regex.IsMatch(value);
        }

        /// <summary>
        /// 判断是否是手机
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsName(string value)
        {
            Regex regex = new Regex(NamePattern);
            return regex.IsMatch(value);
        }

        /// <summary>
        /// 判断是否包含一个格式化字符串的参数  如{0}
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsFormatParam(string value)
        {
            Regex regex = new Regex(MobilePattern);
            return regex.IsMatch(value);
        }
        #endregion

        #region 通用
        /// <summary>
        /// 获取匹配结果
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static List<string> GetMatchCollection(string input, string pattern)
        {
            List<string> list = new List<string>();
            MatchCollection mc = Regex.Matches(input, pattern);
            foreach (Match m in mc)
            {
                list.Add(m.Value);
            }
            return list;
        }

        /// <summary>
        /// 值和表达式是否匹配
        /// </summary>
        /// <param name="pattern">表达式</param>
        /// <param name="value">要验证的值</param>
        /// <returns>是否符合表达式</returns>
        public static bool IsMatch(string pattern, string value)
        {
            Regex regex = new Regex(pattern);
            return regex.IsMatch(value);
        }

        /// <summary>  
        /// 验证字符串是否匹配正则表达式描述的规则  
        /// </summary>  
        /// <param name="inputStr">待验证的字符串</param>  
        /// <param name="patternStr">正则表达式字符串</param>  
        /// <param name="ifIgnoreCase">匹配时是否不区分大小写</param>  
        /// <param name="ifValidateWhiteSpace">是否验证空白字符串</param>  
        /// <returns>是否匹配</returns>  
        public static bool IsMatch(string inputStr, string patternStr, bool ifIgnoreCase = false, bool ifValidateWhiteSpace = false)
        {
            if (!ifValidateWhiteSpace && string.IsNullOrWhiteSpace(inputStr))
                return false;//如果不要求验证空白字符串而此时传入的待验证字符串为空白字符串，则不匹配  
            Regex regex = null;
            if (ifIgnoreCase)
                regex = new Regex(patternStr, RegexOptions.IgnoreCase);//指定不区分大小写的匹配  
            else
                regex = new Regex(patternStr);
            return regex.IsMatch(inputStr);
        } 
        #endregion
    }
}
