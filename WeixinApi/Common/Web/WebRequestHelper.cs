using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Common
{
    public static class WebRequestHelper
    {
        public enum Method { GET, POST };

        /// <summary>
        /// 发起web请求
        /// </summary>
        /// <param name="method">请求方式：GET，POST</param>
        /// <param name="url">请求地址</param>
        /// <param name="contentType"></param>
        /// <param name="postData">请求方式为POST时，传入请求数据</param>
        /// <param name="cookie">如果需要cookie则传入，否则传入null即可</param>
        /// <returns></returns>
        public static string Request(Method method, string url, string contentType = null, string postData = null, Cookie cookie = null)
        {

            HttpWebRequest webRequest = null;


            string responseData = "";

            webRequest = HttpWebRequest.CreateHttp(url);

            webRequest.Method = method.ToString();
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.KeepAlive = true;


            if (cookie != null)
            {
                webRequest.CookieContainer = new CookieContainer();
                webRequest.CookieContainer.Add(cookie);
            }

            if (method == Method.POST)
            {
                if (string.IsNullOrEmpty(contentType))
                {
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                }
                else
                {
                    webRequest.ContentType = contentType;
                }

                if (!string.IsNullOrEmpty(postData))
                {
                    StreamWriter requestWriter = null;

                    requestWriter = new StreamWriter(webRequest.GetRequestStream());

                    try
                    {
                    
                        requestWriter.Write(postData);

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        requestWriter.Close();
                        requestWriter = null;
                    }
                }
            }

            #region 请求头加入信息
            //webRequest.Headers.Add("staffid", "staffid1111"); //当前请求用户StaffId
            //webRequest.Headers.Add("timestamp", "timeStamp222"); //发起请求时的时间戳（单位：毫秒）
            //webRequest.Headers.Add("nonce", "nonce333"); //发起请求时的时间戳（单位：毫秒）
            //webRequest.Headers.Add("sign", "sign444"); //当前请求内容的数字签名
            #endregion
            responseData = WebResponseGet(webRequest);
            webRequest = null;

            return responseData;
        }

        private static string WebResponseGet(HttpWebRequest webRequest)
        {
            StreamReader responseReader = null;
            string responseData = "";

            try
            {

                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();

            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                if (responseReader != null)
                {
                    responseReader.Close();
                    responseReader = null;
                }
            }

            return responseData;
        }

        /// <summary>
        /// 处理Get或Post通用需求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static Stream ProcessUrl2(Method method, string url, string contentType = null, string postData = null, Cookie cookie = null)
        {

            try
            {

            var httpClient = new HttpClient();
            var taskG = httpClient.PostAsync(url, new StringContent(postData));//GET

            HttpResponseMessage rmG = taskG.Result;

            var responseContent = rmG.Content;

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));

            return responseContent.ReadAsStreamAsync().Result;
                 
            }
            catch (Exception ex)
            {
                LogHelper.Error("ProcessUrl2", ex);
              //  LogHelper.ErrorLog(ex);
                //return ex;
                return null;
            }
        }

        #region 新加没弄完代码
        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="requestUrl">请求url</param>
        /// <param name="responseText">响应</param>
        /// <returns></returns>
        public static string Upload(string requestUrl, Stream param)
        {

            byte[] fileBytes = new byte[param.Length];
            param.Read(fileBytes, 0, fileBytes.Length);
            param.Close();
            param.Dispose();

            string responseText = "";
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "multipart/form-data;" );

            byte[] responseBytes;
            byte[] bytes = fileBytes;

            try
            {
                responseBytes = webClient.UploadData(requestUrl, bytes);
                responseText = System.Text.Encoding.UTF8.GetString(responseBytes);
                return responseText;
            }
            catch (WebException ex)
            {
                Stream responseStream = ex.Response.GetResponseStream();
                responseBytes = new byte[ex.Response.ContentLength];
                responseStream.Read(responseBytes, 0, responseBytes.Length);
            }
            responseText = System.Text.Encoding.UTF8.GetString(responseBytes);
            return responseText;
        }

        public static string Request(Method method, string url, string contentType = null, Stream postData = null, Cookie cookie = null)
        {
            HttpWebRequest webRequest = null;


            string responseData = "";

            webRequest = HttpWebRequest.CreateHttp(url);

            webRequest.Method = method.ToString();
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.KeepAlive = true;


            if (cookie != null)
            {
                webRequest.CookieContainer = new CookieContainer();
                webRequest.CookieContainer.Add(cookie);
            }

            if (method == Method.POST)
            {
                if (string.IsNullOrEmpty(contentType))
                {
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                }
                else
                {
                    webRequest.ContentType = contentType;
                }

                if (postData != null)
                {
                    StreamWriter requestWriter = null;

                    requestWriter = new StreamWriter(postData);

                    try
                    {

                        requestWriter.Write(postData);

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        requestWriter.Close();
                        requestWriter = null;
                    }
                }
            }

            #region 请求头加入信息
            //webRequest.Headers.Add("staffid", "staffid1111"); //当前请求用户StaffId
            //webRequest.Headers.Add("timestamp", "timeStamp222"); //发起请求时的时间戳（单位：毫秒）
            //webRequest.Headers.Add("nonce", "nonce333"); //发起请求时的时间戳（单位：毫秒）
            //webRequest.Headers.Add("sign", "sign444"); //当前请求内容的数字签名
            #endregion
            responseData = WebResponseGet(webRequest);
            webRequest = null;

            return responseData;
        }
        #endregion


    }
}
