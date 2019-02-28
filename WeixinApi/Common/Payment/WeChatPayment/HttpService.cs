using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// http连接基础类，负责底层的http通信
    /// </summary>
    public class HttpService
    {

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            //直接确认，否则打不开    
            return true;
        }

        public static string Post(string xml, string url, bool isUseCert, int timeout)
        {
            System.GC.Collect();//垃圾回收，回收没有正常关闭的http连接
            string result = "";//返回结果
            HttpWebRequest request = null;
            HttpWebResponse response = null;

            Stream reqStream = null;
            try
            {
                //设置最大连接数
                ServicePointManager.DefaultConnectionLimit = 200;
                //设置https验证方式
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback =
                            new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                /***************************************************************
                * 下面设置HttpWebRequest的相关属性
                * ************************************************************/
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Timeout = timeout * 1000;

                //设置代理服务器
                //WebProxy proxy = new WebProxy();                          //定义一个网关对象
                ////proxy.Address = new Uri(WxPayConfig.PROXY_URL);              //网关服务器端口:端口
                ////proxy.Address = new Uri("");              //网关服务器端口:端口
                //request.Proxy = proxy;

                //设置POST的数据类型和长度
                request.ContentType = "text/xml";
                byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
                request.ContentLength = data.Length;
                //LogHelp.AddErrLog("准备使用证书", false, "查找证书");
                //是否使用证书
                if (isUseCert)
                {
                    // string path = HttpContext.Current.Request.PhysicalApplicationPath;
                    //LogHelp.AddErrLog("申请退款证书path", false, ConfigHelper.Instance.SSLCERT_PATH);

                    //LogHelp.AddErrLog("申请退款证书索引", false,WCommon.ToInt32(ConfigHelper.Instance.CertIndex).ToString());
                    X509Store store = new X509Store("My", StoreLocation.LocalMachine);
                    store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

                    System.Security.Cryptography.X509Certificates.X509Certificate2 cert =
                      store.Certificates.Find(X509FindType.FindBySubjectName, "快手阿修信息科技(上海)有限公司", false)[ConfigHelper.GetConfigString("CertIndex").TryInt()];

                    request.ClientCertificates.Add(cert);
                    //LogHelp.AddErrLog("申请退款证书cert", false, "");
                }
                //LogHelp.AddErrLog("往服务器写入数据开始", false, "");
                //往服务器写入数据

                reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
                //LogHelp.AddErrLog("往服务器写入数据结束", false, "");
                //获取服务端返回
                response = (HttpWebResponse)request.GetResponse();
                //LogHelp.AddErrLog("获取服务端返回", false, "");
                //获取服务端返回数据
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = sr.ReadToEnd().Trim();
                //LogHelp.AddErrLog("申请退款result", false, result);
                sr.Close();
            }
            catch (System.Threading.ThreadAbortException e)
            {
                //LogHelp.AddErrLog("HttpService:Post", true, "HTTP请求发生异常!(" + e.Message + ")");
                //// Log.Error("HttpService:Post", "HTTP请求发生异常!(" + e.Message + ")");
                System.Threading.Thread.ResetAbort();
            }
            catch (WebException e)
            {

                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    ////LogHelp.AddErrLog("HttpService:Post", true, "HTTP请求发生异常!(StatusCode : " + ((HttpWebResponse)e.Response).StatusCode + ")");
                    //LogHelp.AddErrLog("HttpService:Post", true, "HTTP请求发生异常!(StatusDescription : " + ((HttpWebResponse)e.Response).StatusDescription + ")");
                }
                throw new Exception(e.ToString());
            }
            catch (Exception e)
            {
                //LogHelp.AddErrLog("HttpService:Post", true, "HTTP请求发生异常!(" + e.ToString() + ")");
                throw new Exception(e.ToString());
            }
            finally
            {
                //关闭连接和流
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return result;
        }
        /// <summary>
        /// 执行POST操作
        /// </summary>
        /// <param name="dt">数据字符串</param>
        /// <param name="datatype">0xml  1json</param>
        /// <param name="url"></param>
        /// <param name="isUseCert"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static string Post(string dt, int datatype, string url, bool isUseCert, int timeout)
        {
            System.GC.Collect();//垃圾回收，回收没有正常关闭的http连接
            string result = "";//返回结果
            HttpWebRequest request = null;
            HttpWebResponse response = null;

            Stream reqStream = null;
            try
            {
                //设置最大连接数
                ServicePointManager.DefaultConnectionLimit = 200;
                //设置https验证方式
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback =
                            new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                /***************************************************************
                * 下面设置HttpWebRequest的相关属性
                * ************************************************************/
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Timeout = timeout * 1000;

                //设置代理服务器
                //WebProxy proxy = new WebProxy();                          //定义一个网关对象
                ////proxy.Address = new Uri(WxPayConfig.PROXY_URL);              //网关服务器端口:端口
                ////proxy.Address = new Uri("");              //网关服务器端口:端口
                //request.Proxy = proxy;

                //设置POST的数据类型和长度
                if (datatype == 0)
                    request.ContentType = "text/xml";
                else if (datatype == 1)
                    request.ContentType = "text/json";
                byte[] data = System.Text.Encoding.UTF8.GetBytes(dt);
                request.ContentLength = data.Length;
                //LogHelp.AddErrLog("准备使用证书", false, "查找证书");
                //是否使用证书
                if (isUseCert)
                {
                    // string path = HttpContext.Current.Request.PhysicalApplicationPath;
                    //LogHelp.AddErrLog("申请退款证书path", false, ConfigHelper.Instance.SSLCERT_PATH);

                    //LogHelp.AddErrLog("申请退款证书索引", false,WCommon.ToInt32(ConfigHelper.Instance.CertIndex).ToString());
                    X509Store store = new X509Store("My", StoreLocation.LocalMachine);
                    store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

                    System.Security.Cryptography.X509Certificates.X509Certificate2 cert =
                      store.Certificates.Find(X509FindType.FindBySubjectName, "快手阿修信息科技(上海)有限公司", false)[ConfigHelper.GetConfigString("CertIndex").TryInt()];

                    request.ClientCertificates.Add(cert);
                    //LogHelp.AddErrLog("申请退款证书cert", false, "");
                }
                //LogHelp.AddErrLog("往服务器写入数据开始", false, "");
                //往服务器写入数据

                reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
                //LogHelp.AddErrLog("往服务器写入数据结束", false, "");
                //获取服务端返回
                response = (HttpWebResponse)request.GetResponse();
                //LogHelp.AddErrLog("获取服务端返回", false, "");
                //获取服务端返回数据
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = sr.ReadToEnd().Trim();
                //LogHelp.AddErrLog("申请退款result", false, result);
                sr.Close();
            }
            catch (System.Threading.ThreadAbortException e)
            {
                //LogHelp.AddErrLog("HttpService:Post", true, "HTTP请求发生异常!(" + e.Message + ")");
                // Log.Error("HttpService:Post", "HTTP请求发生异常!(" + e.Message + ")");
                System.Threading.Thread.ResetAbort();
            }
            catch (WebException e)
            {

                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    //LogHelp.AddErrLog("HttpService:Post", true, "HTTP请求发生异常!(StatusCode : " + ((HttpWebResponse)e.Response).StatusCode + ")");
                    //LogHelp.AddErrLog("HttpService:Post", true, "HTTP请求发生异常!(StatusDescription : " + ((HttpWebResponse)e.Response).StatusDescription + ")");
                }
                throw new Exception(e.ToString());
            }
            catch (Exception e)
            {
                //LogHelp.AddErrLog("HttpService:Post", true, "HTTP请求发生异常!(" + e.ToString() + ")");
                throw new Exception(e.ToString());
            }
            finally
            {
                //关闭连接和流
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return result;
        }

        /// <summary>
        /// 处理http GET请求，返回数据
        /// </summary>
        /// <param name="url">请求的url地址</param>
        /// <returns>http GET成功后返回的数据，失败抛WebException异常</returns>
        public static string Get(string url)
        {
            System.GC.Collect();
            string result = "";

            HttpWebRequest request = null;
            HttpWebResponse response = null;

            //请求url以获取数据
            try
            {
                //设置最大连接数
                ServicePointManager.DefaultConnectionLimit = 200;
                //设置https验证方式
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback =
                            new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                /***************************************************************
                * 下面设置HttpWebRequest的相关属性
                * ************************************************************/
                request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "GET";

                ////设置代理
                //WebProxy proxy = new WebProxy();
                ////proxy.Address = new Uri(WxPayConfig.PROXY_URL);
                //proxy.Address = new Uri("");
                //request.Proxy = proxy;

                //获取服务器返回
                response = (HttpWebResponse)request.GetResponse();

                //获取HTTP返回数据
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = sr.ReadToEnd().Trim();
                sr.Close();
            }
            catch (System.Threading.ThreadAbortException e)
            {
                //Log.Error("HttpService", "Thread - caught ThreadAbortException - resetting.");
                //Log.Error("Exception message: {0}", e.Message);
                System.Threading.Thread.ResetAbort();
            }
            catch (Exception e)
            {
                //Log.Error("HttpService", e.ToString());
                //if (e.Status == WebExceptionStatus.ProtocolError)
                //{
                //    //Log.Error("HttpService", "StatusCode : " + ((HttpWebResponse)e.Response).StatusCode);
                //    //Log.Error("HttpService", "StatusDescription : " + ((HttpWebResponse)e.Response).StatusDescription);
                //}
                throw new Exception(e.ToString());
            }
            //catch (Exception e)
            //{
            //    //Log.Error("HttpService", e.ToString());
            //    throw new Exception(e.ToString());
            //}
            finally
            {
                //关闭连接和流
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return result;
        }
        /// <summary>
        /// 读取文件流
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static HttpWebResponse GetUrlResponse(string url)
        {
            System.GC.Collect();
            string result = "";

            HttpWebRequest request = null;
            HttpWebResponse response = null;

            //请求url以获取数据
            try
            {
                //设置最大连接数
                ServicePointManager.DefaultConnectionLimit = 200;
                //设置https验证方式
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback =
                            new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                /***************************************************************
                * 下面设置HttpWebRequest的相关属性
                * ************************************************************/
                request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "GET";

                ////设置代理
                //WebProxy proxy = new WebProxy();
                ////proxy.Address = new Uri(WxPayConfig.PROXY_URL);
                //proxy.Address = new Uri("");
                //request.Proxy = proxy;

                //获取服务器返回
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (System.Threading.ThreadAbortException e)
            {
                //Log.Error("HttpService", "Thread - caught ThreadAbortException - resetting.");
                //Log.Error("Exception message: {0}", e.Message);
                System.Threading.Thread.ResetAbort();
            }
            catch (Exception e)
            {
                //Log.Error("HttpService", e.ToString());
                //if (e.Status == WebExceptionStatus.ProtocolError)
                //{
                //    //Log.Error("HttpService", "StatusCode : " + ((HttpWebResponse)e.Response).StatusCode);
                //    //Log.Error("HttpService", "StatusDescription : " + ((HttpWebResponse)e.Response).StatusDescription);
                //}
                throw new Exception(e.ToString());
            }
            //catch (Exception e)
            //{
            //    //Log.Error("HttpService", e.ToString());
            //    throw new Exception(e.ToString());
            //}
            finally
            {
                //关闭连接和流
                //if (response != null)
                //{
                //    response.Close();
                //}
                //if (request != null)
                //{
                //    request.Abort();
                //}
            }
            return response;
        }
        /// <summary>
        /// httppost请求
        /// </summary>
        /// <param name="postUrl"></param>
        /// <param name="paramData"></param>
        /// <param name="dataEncode"></param>
        /// <returns></returns>
        public static string PostWebRequest(string postUrl, string paramData, Encoding dataEncode)
        {
            string ret = string.Empty;
            try
            {
                byte[] byteArray = dataEncode.GetBytes(paramData); //转化
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Method = "POST";
                webReq.ContentType = "application/text";

                webReq.ContentLength = byteArray.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            return ret;
        }

        /// <summary>
        /// httpget请求
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public static string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
        /// <summary>
        /// httppost请求
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public static string HttpPost(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postDataStr.Length;
            StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
            writer.Write(postDataStr);
            writer.Flush();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            string retString = reader.ReadToEnd();
            return retString;
        }
    }
}
