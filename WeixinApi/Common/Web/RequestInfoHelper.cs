using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public class RequestInfoHelper
    {
        /// <summary>
        /// 获取客户端平台
        /// </summary>
        /// <returns></returns>
        public static string GetPlatform()
        {
            return System.Web.HttpContext.Current.Request.Browser.ToString().Substring(0,30);
        }

        /// <summary>
        /// 判断是否移动设备
        /// </summary>
        /// <returns></returns>
        public static bool IsMobileDevice()
        {
            return System.Web.HttpContext.Current.Request.Browser.IsMobileDevice;
        }

        /// <summary>
        /// 获取移动设备的型号
        /// </summary>
        /// <returns></returns>
        public static string GetMobileDeviceModel()
        {
            return System.Web.HttpContext.Current.Request.Browser.MobileDeviceModel;
        }

        /// <summary>
        /// 获取设备信息
        /// </summary>
        /// <returns></returns>
        public static string GetDevice()
        {
            return IsMobileDevice() ? GetMobileDeviceModel() : GetPlatform();
        }

        /// <summary>
        /// 获取浏览器信息
        /// </summary>
        /// <returns></returns>
        public static string GetBrowser()
        {
            return System.Web.HttpContext.Current.Request.Browser.Browser + System.Web.HttpContext.Current.Request.Browser.Version;
        }

        /// <summary>
        /// 获取post请求参数转换成dic
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetRequestPost(HttpRequestBase Request)
        {
            int i = 0;
            Dictionary<string, string> sArray = new Dictionary<string, string>();
            NameValueCollection coll;
            coll = Request.Form;
            String[] requestItem = coll.AllKeys;
            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }
            return sArray;
        }

        /// <summary>
        /// 获取get请求参数转换成dic
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetRequestGet(HttpRequestBase Request)
        {
            int i = 0;
            Dictionary<string, string> sArray = new Dictionary<string, string>();
            NameValueCollection coll;
            //coll = Request.Form;
            coll = Request.QueryString;
            String[] requestItem = coll.AllKeys;
            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.QueryString[requestItem[i]]);
            }
            return sArray;
        }


        /// <summary>
        /// 获取请求参数
        /// </summary>
        /// <param name="Request"></param>
        /// <param name="IsPost">是否是post</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetRequest(HttpRequestBase Request, bool IsPost)
        {
            if (IsPost)
            {
                return GetRequestPost(Request);
            }
            else
            {
                return GetRequestGet(Request);
            }
        }

        /// <summary>
        /// 获取域名(用户图片上传时，添加全路径，包含域名)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="_cookiename"></param>
        /// <param name="autoLogin"></param>
        public static string GetHost(string FilePath)
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                if (FilePath.IndexOf("http://") < 0)
                {
                    int port = HttpContext.Current.Request.Url.Port;
                    string url = "http://" + HttpContext.Current.Request.Url.Host + (port == 80 ? "" : ":" + port + "");
                    FilePath = url + FilePath;

                }
            }
            return FilePath;
        }
    }
}
