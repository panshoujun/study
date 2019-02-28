using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class IPHelper
    {
        //获取内网IP
        public static string GetLocalIP()
        {
            try
            {
                string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                return ip;
            }
            catch
            {
                return "";
            }
        }
        //获取外网IP
        public static string GetExternalIP()
        {
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)//代理服务器 IP
                return System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(new char[] { ',' })[0];//随机的 IP
            else
                return System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];// 代理服务器 IP
        }

        public static string GetClientIP()
        {
            string result = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (String.IsNullOrEmpty(result))
            {
                result = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (String.IsNullOrEmpty(result))
            {
                result = System.Web.HttpContext.Current.Request.UserHostAddress;
            }
            return result;

        }
    }
}
