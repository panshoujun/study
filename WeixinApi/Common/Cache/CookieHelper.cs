﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LibraryHelp
{
    /// <summary>
    /// 一个cookie对应一个键值对
    /// </summary>
    public class CookieHelper
    {
        #region 清除指定Cookie
        /// <summary>
        /// 清除指定Cookie
        /// </summary>
        /// <param name="cookiename">cookiename</param>
        public static void ClearCookie(string cookiename)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-3);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        #endregion

        #region 获取指定Cookie值
        /// <summary>
        /// 获取指定Cookie值
        /// </summary>
        /// <param name="cookiename">cookiename</param>
        /// <returns></returns>
        public static string GetCookieValue(string cookiename)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            string str = string.Empty;
            if (cookie != null)
            {
                str = cookie.Value;
            }
            return str;
        }
        #endregion

        #region 添加一个Cookie
        /// <summary>
        /// 添加一个Cookie（24小时过期）
        /// </summary>
        /// <param name="cookiename"></param>
        /// <param name="cookievalue"></param>
        public static void SetCookie(string cookiename, string cookievalue)
        {
            SetCookie(cookiename, cookievalue, DateTime.Now.AddDays(1.0));
        }

        /// <summary>
        /// 添加一个Cookie
        /// </summary>
        /// <param name="cookiename">cookie名</param>
        /// <param name="cookievalue">cookie值</param>
        /// <param name="expires">过期时间 DateTime</param>
        public static void SetCookie(string cookiename, string cookievalue, DateTime expires)
        {
            HttpCookie cookie = new HttpCookie(cookiename)
            {
                Value = cookievalue,
                Expires = expires
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        #endregion
    }

    /// <summary>
    /// 一个cookie可以对应多个键值对
    /// </summary>
    public class CookiesHelper
    {
        #region 获取Cookie
        /// <summary>
        /// 获得Cookie的值
        /// </summary>
        /// <param name="cookieName"></param>
        /// <returns></returns>
        public static string GetCookieValue(string cookieName)
        {
            return GetCookieValue(cookieName, null);
        }
        /// <summary>
        /// 获得Cookie的值
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCookieValue(string cookieName,string key)
        {
            HttpRequest request = HttpContext.Current.Request;
            if (request != null)
                return GetCookieValue(request.Cookies[cookieName], key);
            return "";
        }
        /// <summary>
        /// 获得Cookie的子键值
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCookieValue(HttpCookie cookie, string key)
        {
            if (cookie != null)
            {
                if (!string.IsNullOrEmpty(key) && cookie.HasKeys)
                    return cookie.Values[key];
                else
                    return cookie.Value;
            }
            return "";
        }
        /// <summary>
        /// 获得Cookie
        /// </summary>
        /// <param name="cookieName"></param>
        /// <returns></returns>
        public static HttpCookie GetCookie(string cookieName)
        {
            HttpRequest request = HttpContext.Current.Request;
            if (request != null)
                return request.Cookies[cookieName];
            return null;
        }
        #endregion

        #region 删除Cookie
        /// <summary>
        /// 删除Cookie
        /// </summary>
        /// <param name="cookieName"></param>
        public static void RemoveCookie(string cookieName)
        {
            RemoveCookie(cookieName,null);
        }
        /// <summary>
        /// 删除Cookie的子键
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        public static void RemoveCookie(string cookieName,string key)
        {
            HttpResponse response = HttpContext.Current.Response;
            if (response != null)
            {
                HttpCookie cookie = response.Cookies[cookieName];
                if (cookie != null)
                {
                    if (!string.IsNullOrEmpty(key) && cookie.HasKeys)
                        cookie.Values.Remove(key);
                    else
                        response.Cookies.Remove(cookieName);
                }
            }
        }
        #endregion

        #region 设置/修改Cookie
        /// <summary>
        /// 设置Cookie子键的值
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetCookie(string cookieName, string key, string value)
        {
            SetCookie(cookieName, key, value, null);
        }
        /// <summary>
        /// 设置Cookie值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetCookie(string key, string value)
        {
            SetCookie(key, null, value, null);
        }
        /// <summary>
        /// 设置Cookie值和过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expires"></param>
        public static void SetCookie(string key, string value, DateTime expires)
        {
            SetCookie(key, null, value, expires);
        }
        /// <summary>
        /// 设置Cookie过期时间
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="expires"></param>
        public static void SetCookie(string cookieName, DateTime expires)
        {
            SetCookie(cookieName, null, null, expires);
        }
        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expires"></param>
        public static void SetCookie(string cookieName, string key, string value, DateTime? expires)
        {
            HttpResponse response = HttpContext.Current.Response;
            if (response != null)
            {
                HttpCookie cookie = response.Cookies[cookieName];
                if (cookie != null)
                {
                    if (!string.IsNullOrEmpty(key) && cookie.HasKeys)
                        cookie.Values.Set(key, value);
                    else
                        if (!string.IsNullOrEmpty(value))
                            cookie.Value = value;
                    if (expires != null)
                        cookie.Expires = expires.Value;
                    response.SetCookie(cookie);
                }
            }
           
        }
        #endregion

        #region 添加Cookie
        /// <summary>
        /// 添加Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddCookie(string key, string value)
        {
            AddCookie(new HttpCookie(key, value));
        }
        /// <summary>
        /// 添加Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expires"></param>
        public static void AddCookie(string key, string value, DateTime expires)
        {
            HttpCookie cookie = new HttpCookie(key, value);
            cookie.Expires = expires;
            AddCookie(cookie);
        }
        /// <summary>
        /// 添加为Cookie.Values集合
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddCookie(string cookieName,string key, string value)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Values.Add(key, value);
            AddCookie(cookie);
        }
        /// <summary>
        /// 添加为Cookie集合
        /// </summary>
        /// <param name="cookieName">Cookie名称</param>
        /// <param name="expires">过期时间</param>
        public static void AddCookie(string cookieName, DateTime expires)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Expires = expires;
            AddCookie(cookie);
        }
        /// <summary>
        /// 添加为Cookie.Values集合
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expires"></param>
        public static void AddCookie(string cookieName, string key, string value, DateTime expires)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Expires = expires;
            cookie.Values.Add(key, value);
            AddCookie(cookie);
        }
        /// <summary>
        /// 添加Cookie
        /// </summary>
        /// <param name="cookie"></param>
        public static void AddCookie(HttpCookie cookie)
        {
            HttpResponse response = HttpContext.Current.Response;
            if (response != null)
            {
                //指定客户端脚本是否可以访问[默认为false]
                cookie.HttpOnly = true;        
                //指定统一的Path，比便能通存通取
                cookie.Path = "/";
                //设置跨域,这样在其它二级域名下就都可以访问到了
                //cookie.Domain = "chinesecoo.com";
                response.AppendCookie(cookie);
            }
        }
        #endregion
    }

}
