using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public class SessionHelper
    {
        //自定义Session过期时间，默认20分钟
        private static readonly int CustomTimeOut = (System.Configuration.ConfigurationManager.AppSettings["CustomTimeOut"] ?? "20").TryInt();

        #region 添加Session
        /// <summary>  
        /// 添加Session  
        /// </summary>  
        /// <param name="strSessionName">Session对象名称</param>  
        /// <param name="strValue">Session值</param>  
        /// <param name="iExpires">调动有效期（分钟） 默认20</param>  
        public static void Add(string strSessionName, string strValue, int? iExpires = null)
        {
            HttpContext.Current.Session[strSessionName] = strValue;
            HttpContext.Current.Session.Timeout = iExpires.HasValue ? iExpires.Value : CustomTimeOut;
        }

        /// <summary>  
        /// 添加Session  
        /// </summary>  
        /// <param name="strSessionName">Session对象名称</param>  
        /// <param name="strValues">Session值数组</param>  
        /// <param name="iExpires">调动有效期（分钟） 默认20</param>  
        public static void Adds(string strSessionName, string[] strValues, int? iExpires = null)
        {
            HttpContext.Current.Session[strSessionName] = strValues;
            HttpContext.Current.Session.Timeout = iExpires.HasValue ? iExpires.Value : CustomTimeOut;
        }

        /// <summary>  
        /// 添加Session  
        /// </summary>  
        /// <param name="strSessionName">Session对象名称</param>  
        /// <param name="strValues">Session值数组</param>  
        /// <param name="iExpires">调动有效期（分钟） 默认20</param> 
        public static void AddObj(string strSessionName, object strValues, int? iExpires = null)
        {
            HttpContext.Current.Session[strSessionName] = strValues;
            HttpContext.Current.Session.Timeout = iExpires.HasValue ? iExpires.Value : CustomTimeOut;
        }
        #endregion

        #region 读取Session
        /// <summary>  
        /// 读取某个Session对象值  
        /// </summary>  
        /// <param name="strSessionName">Session对象名称</param>  
        /// <returns>Session对象值</returns>  
        public static string Get(string strSessionName)
        {
            if (HttpContext.Current.Session[strSessionName] == null)
            {
                return null;
            }
            else
            {
                return HttpContext.Current.Session[strSessionName].ToString();
            }
        }

        /// <summary>  
        /// 读取某个Session对象值数组  
        /// </summary>  
        /// <param name="strSessionName">Session对象名称</param>  
        /// <returns>Session对象值数组</returns>  
        public static string[] Gets(string strSessionName)
        {
            if (HttpContext.Current.Session[strSessionName] == null)
            {
                return null;
            }
            else
            {
                return (string[])HttpContext.Current.Session[strSessionName];
            }
        }

        /// <summary>  
        /// 读取某个Session对象值数组  
        /// </summary>  
        /// <param name="strSessionName">Session对象名称</param>  
        /// <returns>Session对象</returns>  
        public static object GetObj(string strSessionName)
        {
            if (HttpContext.Current.Session[strSessionName] == null)
            {
                return null;
            }
            else
            {
                return HttpContext.Current.Session[strSessionName];
            }
        }
        #endregion

        #region 删除Session
        /// <summary>  
        /// 删除某个Session对象  
        /// </summary>  
        /// <param name="strSessionName">Session对象名称</param>  
        public static void Del(string strSessionName)
        {
            HttpContext.Current.Session[strSessionName] = null;
        }

        /// <summary>  
        /// 删除所有的Session  
        /// </summary>  
        /// <returns></returns>  
        public static void RemoveAllSession(string name)
        {
            HttpContext.Current.Session.RemoveAll();
        }
        #endregion
    }
}
