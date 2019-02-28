using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;

namespace Common
{
    public class SMSSend
    {
        public SMSSend()
        { }
        private static string apikey = "c0cab25ae62238a89e68a43885c21c14";
        private static string marketingapikey = "acca5ee4185ede0170fe2033a4d5e2fc";
        /**
         * 服务http地址
         */
        private static string BASE_URI = "http://yunpian.com";
        /**
        * 服务版本号
        */
        private static string VERSION = "v1";
        /**
        * 查账户信息的http地址
        */
        private static string URI_GET_USER_INFO = BASE_URI + "/" + VERSION + "/user/get.json";
        /**
        * 通用接口发短信的http地址
        */
        private static string URI_SEND_SMS = BASE_URI + "/" + VERSION + "/sms/send.json";
        /**
        * 模板接口短信接口的http地址
        */
        private static string URI_TPL_SEND_SMS = BASE_URI + "/" + VERSION + "/sms/tpl_send.json";

        /**
        * 取账户信息
        * @return json格式字符串
        */
        public static string getUserInfo()
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI_GET_USER_INFO + "?apikey=" + apikey);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        /**
        * 通用接口发短信
        * @param text　短信内容　
        * @param mobile　接受的手机号
        * @return json格式字符串
        */
        public static string sendSms(string contents, string mobile)
        {
            //注意：参数必须进行Uri.EscapeDataString编码。以免&#%=等特殊符号无法正常提交
            string parameter = "apikey=" + apikey + "&text=" + Uri.EscapeDataString(contents) + "&mobile=" + mobile;
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI_SEND_SMS);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(parameter);//这里编码设置为utf8
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();
            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        /**
       * 营销短信通用接口发短信
       * @param text　短信内容　
       * @param mobile　接受的手机号
       * @return json格式字符串
       */
        public static string sendSmsMarketing(string contents, string mobile)
        {
            //注意：参数必须进行Uri.EscapeDataString编码。以免&#%=等特殊符号无法正常提交
            string parameter = "apikey=" + apikey + "&text=" + Uri.EscapeDataString(contents) + "&mobile=" + mobile;
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI_SEND_SMS);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(parameter);//这里编码设置为utf8
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();
            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
        /// <summary>
        /// 订单物流信息通知
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static string sendSmsOrderExpress(string mobile, string realName, string expressName, string expressNO)
        {
            if (!string.IsNullOrEmpty(mobile))
            {
                string tpl_value = HttpUtility.UrlEncode(
               HttpUtility.UrlEncode("#RealName#", Encoding.UTF8) + "=" +
               HttpUtility.UrlEncode(realName, Encoding.UTF8) + "&" +
               HttpUtility.UrlEncode("#ExpressName#", Encoding.UTF8) + "=" +
               HttpUtility.UrlEncode(expressName, Encoding.UTF8) + "&" +
               HttpUtility.UrlEncode("#ExpressNO#", Encoding.UTF8) + "=" +
               HttpUtility.UrlEncode(expressNO, Encoding.UTF8), Encoding.UTF8);
                return SMSSend.tplSendSms(2105024, tpl_value, mobile);
            }
            return "";
        }
        /**
        * 模板接口发短信
        * @param tpl_id 模板id
        * @param tpl_value 模板变量值
        * @param mobile　接受的手机号
        * @return json格式字符串
        */
        public static string tplSendSms(long tpl_id, string tpl_value, string mobile)
        {
            string encodedTplValue = Uri.EscapeDataString(tpl_value);
            string parameter = "apikey=" + apikey + "&mobile=" + mobile + "&tpl_id=" + tpl_id.ToString() + "&tpl_value=" + tpl_value;
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI_TPL_SEND_SMS);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(parameter);//这里编码设置为utf8
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();
            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }


    }
}
