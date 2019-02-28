using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;

using System.Net;
using System.Net.Mail;
using System.IO;
using NPOI.SS.Formula.Functions;


namespace Common
{
    public class WCommon
    {
        public WCommon() { }

        #region 删除一个html语言
        public static string NoHTML(string Htmlstring)
        {

            if (!string.IsNullOrEmpty(Htmlstring))
            {
                //删除脚本

                Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", " ", RegexOptions.IgnoreCase);

                //删除HTML

                Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", " ", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", " ", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"-->", " ", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", " ", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(laquo);", "«", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(raquo);", "»", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(lsquo);", "‘", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(rsquo);", "’", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(sbquo);", "‚", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(ldquo);", "“", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(rdquo);", "”", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(ndash);", "–", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(amp);", "&", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);

                Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", " ", RegexOptions.IgnoreCase);

                Htmlstring.Replace("<", " ");

                Htmlstring.Replace(">", " ");

                Htmlstring.Replace("\r\n", " ");

                Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            }
            else
            {
                return "";
            }
            return Htmlstring;
        }
        #endregion

        #region "文件类别"
        public string filetype(String ext)
        {
            switch (ext.ToLower())
            {
                case ".jpg":
                case ".bmp":
                case ".png":
                case ".gif":
                case ".jpeg":
                    return "jpg";
                /*  case "rar":
                  case "zip":
                      icon = "rar.jpg";
                      break;
                 */
                case ".rar":
                case ".zip":
                    return "rar";
                case ".pdf":
                    return "pdf";
                default:
                    return "undefined";
            }
        }
        #endregion
        #region "文本替换"
        /// <summary>
        /// 将文本中的换行符替换成br
        /// </summary>
        /// <param name="str">传递进来的字符</param>
        /// <example>
        /// <code>
        /// Response.Write(RepTextarea(str))
        /// </code>
        /// </example>
        /// <returns></returns>
        public string RepTextarea(string str)
        {
            str = str.Replace("\n\r", "<br/>");
            str = str.Replace("\n", "<br/>");
            str = str.Replace("\r", "<br/>");
            return str;
        }

        #endregion
        #region "javascript脚本提示"
        public static void Openwin(string url)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>window.open('" + url + "');</script>");
            // System.Web.HttpContext.Current.Response.End();
        }
        public static void Alert(string str)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('" + str + "');</script>");
        }
        /// <summary>
        /// 弹出一个对话框
        /// </summary>
        /// <param name="str">呈现在对话框中的文本</param>
        /// <param name="isEnd">是否停止 ASP.NET 页的执行</param>
        public static void Alert(string str, bool isEnd)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('" + str + "');</script>");
            if (isEnd) System.Web.HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 在客户端呈现一个焦点对话框，并终止 asp.net 页的执行，并自动返回上一页状态。
        /// </summary>
        /// <param name="str"></param>
        public static void AlertBack(string str)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('" + str + "');history.back();</script>");
            System.Web.HttpContext.Current.Response.End();
        }
        public static void AlertJump(string str, string url)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('" + str + "');self.location='" + url + "';</script>");
            System.Web.HttpContext.Current.Response.End();
        }
        public static void Jump(string url)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>top.location='" + url + "';</script>");
            System.Web.HttpContext.Current.Response.End();
        }
        public static void AlertClose(string str)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('" + str + "');window.close();window.opener=null;</script>");
            System.Web.HttpContext.Current.Response.End();
        }
        public static void Confirm(string str, string url)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>if (confirm('" + str + "')){top.location='" + url + "'}else{history.back();}</script>");
            System.Web.HttpContext.Current.Response.End();
        }
        #endregion
        #region "格式化获取页面参数"
      
        public static string Querystringend(string str)
        {
            string s = System.Web.HttpContext.Current.Request.QueryString[str];
            if (IsSafestring(s))
            {
                if (s == null) s = "";
                return s;
            }
            else
            {
                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.Write("参数含有特殊字符!");
                System.Web.HttpContext.Current.Response.End();
                return "";
            }
        }
        public static int Queryintzero(string str)
        {
            string s = System.Web.HttpContext.Current.Request.QueryString[str];
            if (IsInterger(s))
            {
                return Convert.ToInt32(s);
            }
            else
            {
                return 0;
            }
        }
        public static int Formintzero(string str)
        {
            string s = System.Web.HttpContext.Current.Request.Form[str];
            if (IsInterger(s))
            {
                return Convert.ToInt32(s);
            }
            else
            {
                return 0;
            }
        }
        public static int Queryintend(string str)
        {
            string s = System.Web.HttpContext.Current.Request.QueryString[str];
            if (IsInterger(s))
            {
                return Convert.ToInt32(s);
            }
            else
            {
                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.Write("非法参数!");
                System.Web.HttpContext.Current.Response.End();
                return -1;
            }
        }
        #endregion

        #region "历史地址"
        public static void SetBackUrl()
        {
            SetCookies("Backurl_", System.Web.HttpContext.Current.Request.RawUrl, 1);
        }
        public static string GetBackUrl(string defaulturl)
        {
            string backurl = GetCookies("Backurl_");
            //if (backurl.ToLower().IndexOf(defaulturl.ToLower()) < 0)
            //{
            //    return defaulturl;
            //}
            //else
            //{
            return backurl;
            //}
        }
        public static void SetWebBackUrl()
        {
            string url = System.Web.HttpContext.Current.Request.RawUrl;
            if (url.ToLower().IndexOf("login.aspx") < 1)
            {
                SetCookies("WebBackurl_", url, 1);
            }
        }
        public static string GetWebBackUrl(string defaulturl)
        {
            string backurl = GetCookies("WebBackurl_");
            //if (backurl.ToLower().IndexOf(defaulturl.ToLower()) < 0)
            //{
            //    return defaulturl;
            //}
            //else
            //{
            return backurl;
            //}
        }

        public static bool Navchange(object o)
        {
            string p = System.Web.HttpContext.Current.Request.Url.LocalPath.ToLower();
            string tmp = o.ToString().ToLower();
            if (p.IndexOf(tmp) > -1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public static void GotoBackUrl(string defaulturl)
        {
            Redirect(GetBackUrl(defaulturl));
        }

        public static void Redirect(string url)
        {
            System.Web.HttpContext.Current.Response.Redirect(url);
            System.Web.HttpContext.Current.Response.End();
        }

        public static void Transfer(string url)
        {
            System.Web.HttpContext.Current.Server.Transfer(url);
            System.Web.HttpContext.Current.Response.End();
        }


        #endregion

        #region "Cookie处理"
        /*    cName    : Cookie的名称
                   cValue   : Cookie的值
                   cExpires : Cookie的过期日
                */



        public static void SetCookies(string cName, string cValue, Int64 cExp)
        {
            if (cValue == null || cValue.Length < 1) cValue = "";
            if (ChkCookies(cName))
            {
                HttpCookie cookie = new HttpCookie(cName);
                string cvalue;
                cvalue = System.Web.HttpContext.Current.Server.UrlEncode(cValue);
                cookie.Value = cvalue;
                if (cExp != 0) cookie.Expires = DateTime.Now.AddDays(cExp);
                System.Web.HttpContext.Current.Response.Cookies.Set(cookie);
            }
            else
            {
                AddCookies(cName, cValue, cExp);
            }
        }

        public static void AddCookies(string cName, string cValue, Int64 cExp)
        {

            HttpCookie cookie = new HttpCookie(cName);
            string cvalue;
            cvalue = System.Web.HttpContext.Current.Server.UrlEncode(cValue);
            cookie.Value = cvalue;
            if (cExp > 0) cookie.Expires = DateTime.Now.AddDays(cExp);
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void DeleteCookies(string cName)
        {
            HttpCookie cookie = new HttpCookie(cName);
            cookie.Value = "";
            cookie.Expires = DateTime.Now.AddDays(-365);
            System.Web.HttpContext.Current.Response.Cookies.Set(cookie);
        }
        public static string SeachCookies(string cName)
        {
            Int32 i;
            HttpCookieCollection cookies = System.Web.HttpContext.Current.Request.Cookies;
            for (i = 0; i < cookies.Count; i++)
            {
                HttpCookie cookie = cookies.Get(i);
                if (cookie.Name == cName)
                {
                    return System.Web.HttpContext.Current.Server.UrlDecode(cookie.Value);
                }
            }
            return "";
        }
        public static string GetCookies(string cName)
        {
            if (cName.Length == 0) return "";
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies.Get(cName);
            if (cookie == null) return "";
            return System.Web.HttpContext.Current.Server.UrlDecode(cookie.Value);
        }
        public static bool ChkCookies(string cName)
        {
            Int32 i;
            HttpCookieCollection cookies = System.Web.HttpContext.Current.Request.Cookies;
            for (i = 0; i < cookies.Count; i++)
            {
                HttpCookie cookie = cookies.Get(i);
                if (cookie.Name == cName)
                {
                    return true;
                }
            }
            return false;
        }
        public static void ShowCookies()
        {
            Int16 i;
            HttpCookieCollection cookies = System.Web.HttpContext.Current.Request.Cookies;
            for (i = 0; i < cookies.Count; i++)
            {
                HttpCookie cookie = cookies.Get(i);
                System.Web.HttpContext.Current.Response.Write("Cookie名称: " + cookie.Name + "<br/>");
                System.Web.HttpContext.Current.Response.Write("值=: " + cookie.Value + "<br/>");
                System.Web.HttpContext.Current.Response.Write("Expires期限: " + cookie.Expires.ToString() + "<br/>");
                System.Web.HttpContext.Current.Response.Write("<hr/>");
                // System.Web.HttpContext.Current.Response.Write ("Domain网域:" + cookie.Domain  + "<br/>");
                // System.Web.HttpContext.Current.Response.Write ("Path路径:" + cookie.Path + "<br/>");
                //System.Web.HttpContext.Current.Response.Write ("Secure保密:" + cookie.Secure + "<br/>");
            }
            System.Web.HttpContext.Current.Response.Write("共有 " + cookies.Count + " 个Cookie<br/>");
        }
        public static void DeleteAllCookies()
        {
            Int16 i;
            HttpCookieCollection cookies = System.Web.HttpContext.Current.Request.Cookies;
            for (i = 0; i < cookies.Count; i++)
            {
                HttpCookie cookie = cookies.Get(i);
                cookie.Value = "";
                cookie.Expires = DateTime.Now.AddDays(-365);
                System.Web.HttpContext.Current.Response.Cookies.Set(cookie);

            }
            System.Web.HttpContext.Current.Response.Write("共有 " + cookies.Count + " 个Cookie被删除<br/>");

            /* cookies.Clear(); */
        }
        public static void ClearAllCookies()
        {
            Int16 i;
            HttpCookieCollection cookies = System.Web.HttpContext.Current.Request.Cookies;
            for (i = 0; i < cookies.Count; i++)
            {
                HttpCookie cookie = cookies.Get(i);
                cookie.Value = "";
                System.Web.HttpContext.Current.Response.Cookies.Set(cookie);
            }
            System.Web.HttpContext.Current.Response.Write("共有 " + cookies.Count + " 个Cookie被清空<br/>");
        }
        #endregion
        #region "格式化类别显示"
        public static string treestr(int depth)
        {

            string str = "";
            for (int i = 2; i <= depth; i++)
            {
                str = str + "─";
            }
            if (depth > 0) str = "├" + str + "┴";
            return str;
        }
        public static string showtree(int depth, string classname)
        {

            string str = treestr(depth) + classname;
            return str;

        }
        #endregion
        #region "ip地址"
        public static string Getip()
        {
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                return System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(new char[] { ',' })[0];
            else
                return System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        #endregion
        #region 字符串的长度
        /// <summary>
        /// 字符串的长度
        /// </summary>
        protected virtual int Len(string str)
        {
            return Encoding.GetEncoding(936).GetByteCount(str);
        }
        #endregion

        #region 字符串分函数
        /// <summary>
        /// 字符串分函数
        /// </summary>
        /// <param name="str">要分解的字符串</param>
        /// <param name="str1">对比的字符串</param>
        /// <param name="splitstr">分割符,可以为string类型</param>
        /// <returns></returns>
        public static bool StringSplit(string str, string str1, string splitstr)
        {
            //if (splitstr == null || splitstr.Length < 1) splitstr = ",";
            //if (str == null || str1 == null) return false;
            string[] s = str.Split(char.Parse(splitstr));
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Trim() == str1.Trim())
                    return true;
            }
            return false;
        }
        #endregion

        /// <summary>
        /// APP显示，ShopMobile路径下的图片
        /// </summary>
        /// <param name="StringFiles"></param>
        /// <returns></returns>
        public static string CheckFilePath(string StringFiles)
        {
            if (!string.IsNullOrEmpty(StringFiles) && StringFiles.Length > 0)
            {
                if (!StringFiles.ToLower().StartsWith("http://") && !StringFiles.ToLower().StartsWith("https://"))
                    StringFiles = ConfigHelper.Instance.FileURL + StringFiles;
                System.Web.UI.Page page = new Page();
                return StringFiles;

            }
            else
            {
                return "";
            }
        }

        /// <summary>  
        /// DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name=”time”></param>  
        /// <returns></returns>  
        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
        /// <summary>
        /// 时间戳
        /// </summary>       
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMinutes).ToString();

        }
        public static string ParseTags(string HTMLStr)
        {
            if (HTMLStr == null) HTMLStr = "";
            return System.Text.RegularExpressions.Regex.Replace(HTMLStr, "<[^>]*>", "");

        }


        #region 默认图片
        public static string CheckImages(string StringFiles)
        {
            if (StringFiles.Length > 0)
            {
                System.Web.UI.Page page = new Page();
                if (System.IO.File.Exists(page.Server.MapPath("../" + StringFiles)) == false)
                {
                    return "../Images/none.jpg";
                }
                else
                {
                    return "../" + StringFiles;
                }
            }
            else
            {
                return "../Images/none.jpg";
            }
        }


        public static string CheckImages2(string StringFiles)
        {
            if (!string.IsNullOrEmpty(StringFiles) && StringFiles.Length > 0)
            {
                if (StringFiles.IndexOf("http://") < 0)
                    StringFiles = ConfigHelper.Instance.ShopWebURL + StringFiles;
                System.Web.UI.Page page = new Page();
                return StringFiles;

            }
            else
            {
                return ConfigHelper.Instance.ShopWebURL + "/images/no.jpg";
            }
        }
        /// <summary>
        /// APP显示，ShopMobile路径下的图片
        /// </summary>
        /// <param name="StringFiles"></param>
        /// <returns></returns>
        public static string CheckImages3(string StringFiles)
        {
            if (!string.IsNullOrEmpty(StringFiles) && StringFiles.Length > 0)
            {
                if (StringFiles.IndexOf("http://") < 0)
                    StringFiles = ConfigHelper.Instance.ShopMobileURL + StringFiles;
                System.Web.UI.Page page = new Page();
                return StringFiles;

            }
            else
            {
                return "";
            }
        }
        #endregion

        public static string CheckHeadPhotoImg(string StringFiles)
        {
            if (!string.IsNullOrEmpty(StringFiles) && StringFiles.Length > 0)
            {
                if (StringFiles.IndexOf("http://") < 0)
                    StringFiles = ConfigHelper.Instance.ShopWebURL + StringFiles;
                System.Web.UI.Page page = new Page();
                return StringFiles;

            }
            else
            {
                return ConfigHelper.Instance.ShopWebURL + "/images/headphoto.png";
            }
        }

        public static string CheckHeadPhotoImg(string StringFiles, string sex)
        {
            if (!string.IsNullOrEmpty(StringFiles) && StringFiles.Length > 0)
            {
                if (StringFiles.IndexOf("http://") < 0)
                    StringFiles = ConfigHelper.Instance.ShopWebURL + StringFiles;
                System.Web.UI.Page page = new Page();
                return StringFiles;
            }
            else
            {
                if (sex == "女" || sex == "2")
                {
                    return ConfigHelper.Instance.ShopWebURL + "/images/femalephoto.png";
                }
                else
                {
                    return ConfigHelper.Instance.ShopWebURL + "/images/headphoto.png";
                }
            }
        }

        public static string Filename(string StringFiles)
        {
            if (StringFiles[0] == '/')
            {
                string[] arr = StringFiles.Split('/');
                return arr[arr.Length];
            }
            else
            {
                return "";
            }
        }

        public static string ThumbFilename(string StringFiles)
        {
            if (StringFiles.IndexOf('.') > 0)
            {
                string[] arr = StringFiles.Split('.');
                return arr[0] + "_s." + arr[1];
            }
            else
            {
                return "";
            }
        }


        public static string PicUrl(object surl)
        {
            string url = surl.ToString();
            if (url == null || url == "")
            {
                return "/images/no.jpg";
            }
            if (url.IndexOf(':') > 0)
            {
                return url;
            }
            else
            {
                if (url.ToLower().IndexOf(".jpg") > 0 || url.ToLower().IndexOf(".jpeg") > 0 || url.ToLower().IndexOf(".gif") > 0 || url.ToLower().IndexOf(".bmp") > 0 || url.ToLower().IndexOf(".png") > 0)
                {
                    if (url.Substring(0, 1) == "/")
                    {
                        return (url);
                    }
                    else
                    {
                        return ("/" + url);
                    }
                }
                else
                {
                    return "/images/no.jpg";
                }

            }
        }
        public static string PicUrl(object surl, string defaultpic)
        {
            if (defaultpic.Length < 1) defaultpic = "/images/no.jpg";
            string url = surl.ToString();
            if (url == null || url == "")
            {
                return defaultpic;
            }
            if (url.IndexOf(':') > 0)
            {
                return url;
            }
            else
            {
                if (url.ToLower().IndexOf(".jpg") > 0 || url.ToLower().IndexOf(".jpeg") > 0 || url.ToLower().IndexOf(".gif") > 0 || url.ToLower().IndexOf(".bmp") > 0 || url.ToLower().IndexOf(".png") > 0)
                {
                    if (url.Substring(0, 1) == "/")
                    {
                        return (url);
                    }
                    else
                    {
                        return ("/" + url);
                    }
                }
                else
                {
                    return defaultpic;
                }

            }
        }
        public static bool isPic(object surl)
        {
            string url = surl.ToString();
            if (url == null || url == "")
            {
                return false;
            }
            string[] aurl = url.Split('.');
            string ext = aurl[(aurl.Length - 1)].ToLower();
            if (ext == "jpg" || ext == "jpeg" || ext == "gif" || ext == ".bmp" || ext == "png")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string UrlExt(object surl)
        {
            string url = surl.ToString();
            if (url == null || url == "")
            {
                return "";
            }
            string[] aurl = url.Split('.');
            string ext = aurl[(aurl.Length - 1)].ToLower();
            return ext;
        }



        public static string Seturl(string o)
        {
            string pageurl = HttpContext.Current.Request.Url.PathAndQuery;
            string url = pageurl;
            if (url.IndexOf('?') > 0)
            {
                if (url.LastIndexOf('?') == 0)
                {
                    url = url + o.Trim();
                }
                else
                {
                    url = url + "&" + o.Trim();
                }
            }
            else
            {
                url = url + "?" + o.Trim();
            }
            return url;
        }
        private char[] constant = 
{ 
'0','1','2','3','4','5','6','7','8','9', 'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' 
};
        private string GenerateRandom(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(36);
            Random rd = new Random();// 

            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(36)]);
            }
            return newRandom.ToString();
        }
        private string GenerateRandom(int Length, int Ini)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(36);
            Random rnd = new Random();
            int r1 = rnd.Next(11, 14);
            Random rd = new Random(r1 * unchecked((int)DateTime.Now.Ticks) + Ini);// 

            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(36)]);
            }
            return newRandom.ToString();
        }
        public static void Loadascx(string path, PlaceHolder p, Page tmp)
        {
            p.Controls.Clear();
            Control control = tmp.LoadControl(path);
            p.Controls.Add(control);
        }

        public static bool IsNumber(string strNumber)
        {
            if (strNumber == null) return false;
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            string strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            string strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

            return !objNotNumberPattern.IsMatch(strNumber) &&
                   !objTwoDotPattern.IsMatch(strNumber) &&
                   !objTwoMinusPattern.IsMatch(strNumber) &&
                   objNumberPattern.IsMatch(strNumber);
        }

        public static bool IsInterger(string strNumber)
        {
            if (strNumber == null) return false;
            string strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex(strValidIntegerPattern);

            return objNumberPattern.IsMatch(strNumber);
        }
        public static bool IsSafestring(string str)
        {
            if (str == null) return true;
            string strValidIntegerPattern = "^\\w+$";
            Regex objNumberPattern = new Regex(strValidIntegerPattern);

            return objNumberPattern.IsMatch(str);
        }

        public static bool Checkedin(string str, string allstr)
        {
            if (str == null || allstr == null || str.Length < 1 || allstr.Length < 1) return false;
            string[] tmparr = allstr.Split(',');
            for (int i = 0; i < tmparr.Length; i++)
            {
                if (str.Trim() == tmparr[i].Trim()) return true;
            }
            return false;

        }

        #region 文本文件操作
        public static void Writefile(string msg, string path)
        {
            HttpContext ht = HttpContext.Current;
            string filepath = ht.Server.MapPath(path);
            if (!File.Exists(filepath))
            {
                Stream fsc = File.Create(filepath);
                fsc.Close();
            }

            Stream fs = File.Open(filepath, FileMode.Create);
            TextWriter tw = new StreamWriter(fs, Encoding.GetEncoding("gb2312"));
            tw.WriteLine(msg);
            tw.Close();
            fs.Close();
        }
        public static void Writefileappend(string msg, string path)
        {
            HttpContext ht = HttpContext.Current;
            string filepath = ht.Server.MapPath(path);
            if (!File.Exists(filepath))
            {
                Stream fsc = File.Create(filepath);
                fsc.Close();
            }

            Stream fs = File.Open(filepath, FileMode.Append);
            TextWriter tw = new StreamWriter(fs, Encoding.GetEncoding("gb2312"));
            tw.WriteLine(msg);
            tw.Close();
            fs.Close();
        }

        public static string Readfile(string file)
        {
            string filepath = System.Web.HttpContext.Current.Server.MapPath(file);
            string fileContent = "";
            StreamReader SR = new StreamReader(filepath, Encoding.GetEncoding("gb2312"));
            fileContent = SR.ReadToEnd();
            SR.Close();
            return fileContent;
        }
        public static string Readfile(string file, string gb)
        {
            string filepath = System.Web.HttpContext.Current.Server.MapPath(file);
            string fileContent = "";
            StreamReader SR = new StreamReader(filepath, Encoding.GetEncoding(gb));
            fileContent = SR.ReadToEnd();
            SR.Close();
            return fileContent;
        }
        #endregion

        /// <summary>
        /// 将DataReader 转为 DataTable
        /// </summary>
        /// <param name="DataReader">DataReader</param>
        public static DataTable ConvertDataReaderToDataTable(SqlDataReader dataReader)
        {
            DataTable datatable = new DataTable();
            DataTable schemaTable = dataReader.GetSchemaTable();
            //动态添加列
            try
            {

                foreach (DataRow myRow in schemaTable.Rows)
                {
                    DataColumn myDataColumn = new DataColumn();
                    myDataColumn.DataType = myRow.GetType();
                    myDataColumn.ColumnName = myRow[0].ToString();
                    datatable.Columns.Add(myDataColumn);
                }
                //添加数据
                while (dataReader.Read())
                {
                    DataRow myDataRow = datatable.NewRow();
                    for (int i = 0; i < schemaTable.Rows.Count; i++)
                    {
                        myDataRow[i] = dataReader[i].ToString();
                    }
                    datatable.Rows.Add(myDataRow);
                    myDataRow = null;
                }
                schemaTable = null;
                dataReader.Close();
                return datatable;
            }
            catch (Exception ex)
            {
                ///抛出类型转换错误
                throw new Exception("转换出错出错!", ex);
            }

        }


        /// <summary>
        /// 获取客户端IP
        /// </summary>
        public static string GetClientIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (String.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (String.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            return result;

        }

        /// <summary>
        /// 将英文的星期几转为中文
        /// </summary>	
        public static string ConvertDayOfWeekToZh(System.DayOfWeek dw)
        {
            string DayOfWeekZh = "";
            switch (dw.ToString("D"))
            {
                case "0":
                    DayOfWeekZh = "日";
                    break;
                case "1":
                    DayOfWeekZh = "一";
                    break;
                case "2":
                    DayOfWeekZh = "二";
                    break;
                case "3":
                    DayOfWeekZh = "三";
                    break;
                case "4":
                    DayOfWeekZh = "四";
                    break;
                case "5":
                    DayOfWeekZh = "五";
                    break;
                case "6":
                    DayOfWeekZh = "六";
                    break;
            }

            return DayOfWeekZh;
        }
        /// <summary>
        /// 获得两个日期的间隔
        /// </summary>
        /// <param name="DateTime1">日期一。</param>
        /// <param name="DateTime2">日期二。</param>
        /// <returns>日期间隔TimeSpan。</returns>
        public TimeSpan DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            return ts;
        }
        /// <summary>
        /// 检查一个字符串是否是纯数字构成的，一般用于查询字符串参数的有效性验证。
        /// </summary>
        /// <param name="_value">需验证的字符串。。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool IsNumberId(string _value)
        {
            return QuickValidate("^[1-9]*[0-9]*$", _value);
        }

        /// <summary>
        /// 检查一个字符串是否是纯字母和数字构成的，一般用于查询字符串参数的有效性验证。
        /// </summary>
        /// <param name="_value">需验证的字符串。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool IsLetterOrNumber(string _value)
        {
            return QuickValidate("^[a-zA-Z0-9_]*$", _value);
        }


        /// <summary>
        /// 恢复回车换行。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string NewLineToHtml(string str)
        {
            if (str != null)
            {
                string c = ((char)32).ToString();
                str = str.Replace("\r\n", "<br>");
                str = str.Replace(c + c, "&nbsp;&nbsp;&nbsp;&nbsp;");
                return str;
            }
            return string.Empty;
        }

        /// <summary>
        /// 快速验证一个字符串是否符合指定的正则表达式。
        /// </summary>
        /// <param name="_express">正则表达式的内容。</param>
        /// <param name="_value">需验证的字符串。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool QuickValidate(string _express, string _value)
        {
            System.Text.RegularExpressions.Regex myRegex = new System.Text.RegularExpressions.Regex(_express);
            if (_value.Length == 0)
            {
                return false;
            }
            return myRegex.IsMatch(_value);
        }

        /// <summary>
        /// 把未知类型值强制转换到 int 类型。如此值不是 int，将返回 0。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt32(object value)
        {
            if (value == null) return 0;
            int result;
            if (int.TryParse(value.ToString(), out result))
            {
                return result;
            }
            return 0;
        }

        /// <summary>
        /// 把未知类型值强制转换到 long 类型。如此值不是 long，将返回 0。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToInt64(object value)
        {
            if (value == null) return 0;
            long result;
            if (long.TryParse(value.ToString(), out result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        /// 把未知类型值强制转换到 decimal 类型。如此值不是 decimal，将返回 0。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object value)
        {
            if (value == null) return 0;
            decimal result;
            if (decimal.TryParse(value.ToString(), out result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        /// 把未知类型值强制转换到 double 类型。如此值不是 double，将返回 0。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ToDouble(object value)
        {
            if (value == null) return 0;
            double result;
            if (double.TryParse(value.ToString(), out result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        /// 获取 URL 参数的值,并转换为 int 类型。
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <returns></returns>
        public static int GetURLParamInt32(string name)
        {
            return ToInt32(HttpContext.Current.Request.QueryString[name]);
        }

        /// <summary>
        /// 获取 URL 参数的值,并转换为 long 类型。
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <returns></returns>
        public static long GetURLParamInt64(string name)
        {
            return ToInt64(HttpContext.Current.Request.QueryString[name]);
        }

        /// <summary>
        /// 从全文件物理路径中查找文件所在目录或目录的父目录是否存在，若不存在，将创建它。
        /// </summary>
        /// <param name="fullname">文件存储物理路径。</param>
        /// <returns>如目录创建成功，将返回 true，否则为 false。</returns>
        public static bool CreateDirectory(string fullname)
        {
            try
            {
                string dirPath = Path.GetDirectoryName(fullname);
                if (!Directory.Exists(dirPath))
                    Directory.CreateDirectory(dirPath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 分析一个带文件名和路径，然后在文件和路径之间插入用户自定义的字符。
        /// </summary>
        /// <![CDATA[
        /// 示例：
        /// 调用：PathSplitInsert("/www/my/photo/20080203847.jpg","/big/")
        /// 返回：/www/my/photo/big/20080203847.jpg
        /// 说明：“/big/”被插入到路径“/www/my/photo”和文件名“20080203847.jpg”之间了。
        /// ]]>
        /// <param name="path">要分析的路径。</param>
        /// <param name="dir">被插入在目录路径和文件名之间的字符，以“/”（或“\”）开头，再以“\”（或“/”）结束。</param>
        /// <returns></returns>
        public static string PathInsert(string path, string dir)
        {
            if (path.IndexOf(dir) > -1)
            {
                return path;
            }
            else
            {
                if (String.IsNullOrEmpty(path))
                {
                    return "";
                }
                if (path.IndexOf("http://") < 0)
                {
                    string baseDir = Path.GetDirectoryName(path);
                    if (path.Contains("/"))
                        baseDir = baseDir.Replace('\\', '/');
                    return baseDir + dir + Path.GetFileName(path);
                }
                else
                {
                    string newpath = path.Replace("http://", "");
                    string baseDir = Path.GetDirectoryName(newpath);
                    if (path.Contains("/"))
                        baseDir = baseDir.Replace('\\', '/');
                    return  "http://"+ baseDir + dir + Path.GetFileName(path);
                }
            }
        }

        /// <summary>
        /// 以分钟为单位转为“XX天XX时XX分XX秒”这样的格式显示
        /// </summary>
        /// <param name="value">秒数</param>
        /// <returns></returns>
        public static string TimeUnitConvert(double value)
        {
            string showspan = "";
            double day = 0, hour = 0, minute = 0, second = 0;
            if (value < 60)
            {
                second = Math.Round(value);
            }
            else if (value >= 60 && value < 3600)
            {
                minute = Math.Floor(value / 60);
                second = Math.Round(value % 60);
            }
            else if (value >= 3600 && value < 86400)
            {
                hour = Math.Floor(value / 3600);
                minute = Math.Floor(value % 3600 / 60);
                second = Math.Round(value % 3600 % 60);
            }
            else if (value >= 86400)
            {
                day = Math.Floor(value / 86400);
                hour = Math.Floor(value % 86400 / 3600);
                minute = Math.Floor(value % 86400 % 3600 / 60);
                second = Math.Round(value % 86400 % 3600 % 60);
            }
            if (day > 0)
            {
                showspan = day + "天";
            }
            if (hour > 0)
            {
                showspan += (showspan == "") ? hour + "小时" : hour + "小时";
            }
            if (minute > 0)
            {
                showspan += (showspan == "") ? minute + "分" : minute + "分";
            }
            if (second > 0)
            {
                showspan += (showspan == "") ? second + "秒" : second + "秒";
            }
            return showspan;
        }


        /// <summary>
        /// 截取传入的字符串中左侧第 N 个返回.
        /// </summary>
        /// <param name="str">要截取的字符串。</param>
        /// <param name="count">从左侧数起，截取的字符个数。</param>
        /// <param name="append">当传入的字符数长于截取字符数是，在已截取字符串加上此字符（如“...”）</param>
        /// <returns></returns>
        public static string LeftString(string str, int count, string append)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            if (str.Length > count)
                //当字符个数大于载取的字符数时，截取 count 个返回
                return str.Substring(0, count) + append;
            else
                //否则返回原字符串
                return str;
        }

        /// <summary>
        /// 截取传入的字符串中左侧第 N 个返回.
        /// </summary>
        /// <param name="str">要截取的字符串。</param>
        /// <param name="count">从左侧数起，截取的字符个数。</param>
        /// <returns></returns>
        public static string LeftString(string str, int count)
        {
            return LeftString(str, count, string.Empty);
        }

        /// <summary>
        /// 字节单位转换：KB>MB
        /// </summary>
        /// <param name="size">传入的节节数值，单位：KB</param>
        /// <returns></returns>
        public static string KByteUnitConversion(decimal size)
        {
            decimal sixefs = size;
            string showsize = sixefs.ToString() + " KB";
            if (sixefs <= 1)
            {
                showsize = (sixefs * 1024).ToString("0") + " Byte";
            }
            if (sixefs >= 1024)
            {
                sixefs = (sixefs / 1024);
                showsize = sixefs.ToString("00") + " MB";
            }
            if (sixefs >= 1024)
            {
                sixefs = (sixefs / 1024);
                showsize = sixefs.ToString("00") + " GB";
            }
            return showsize;
        }
        /// <summary>
        /// 对应脚本escape方法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static String escape(String s)
        {
            StringBuilder sbuf = new StringBuilder();
            int len = s.Length;
            for (int i = 0; i < len; i++)
            {
                int ch = s[i];
                /*if (ch == ' ') {                        // space : map to '+'
                    sbuf.Append("+");
                } else*/
                if ('A' <= ch && ch <= 'Z')
                {    // 'A'..'Z' : as it was
                    sbuf.Append((char)ch);
                }
                else if ('a' <= ch && ch <= 'z')
                {    // 'a'..'z' : as it was
                    sbuf.Append((char)ch);
                }
                else if ('0' <= ch && ch <= '9')
                {    // '0'..'9' : as it was
                    sbuf.Append((char)ch);
                }
                else if (ch == '-' || ch == '_'       // unreserved : as it was
                  || ch == '.' || ch == '!'
                  || ch == '~' || ch == '*'
                  || ch == '\'' || ch == '('
                  || ch == ')')
                {
                    sbuf.Append((char)ch);
                }
                else if (ch <= 0x007F)
                {              // other ASCII : map to %XX
                    sbuf.Append('%');
                    sbuf.Append(hex[ch]);
                }
                else
                {                                // unicode : map to %uXXXX
                    sbuf.Append('%');
                    sbuf.Append('u');
                    int cht = ch;
                    sbuf.Append(hex[(ch >>= 8)]);
                    sbuf.Append(hex[(0x00FF & cht)]);
                }
            }
            return sbuf.ToString();
        }
        /// <summary>
        /// 获取随机字符串邀请码
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string getStringRandom(int length)
        {

            string val = "";
            Random random = new Random();

            //参数length，表示生成几位随机数  
            for (int i = 0; i < length; )
            {

                string charOrNum = random.Next(2) % 2 == 0 ? "char" : "num";
                //输出字母还是数字  
                if ("char".Equals(charOrNum))
                {
                    //输出是大写字母还是小写字母  
                    int temp = random.Next(2) % 2 == 0 ? 65 : 97;
                    if ((char)(random.Next(26) + 65) != 'O')
                    {
                        val += (char)(random.Next(26) + 65);
                        i++;
                    }
                }
                else if ("num".Equals(charOrNum))
                {
                    val += random.Next(1, 9).ToString();
                    i++;
                }
            }
            return val;
        }

        /// <summary>
        /// 对应脚本unescape方法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static String unescape(String s)
        {
            StringBuilder sbuf = new StringBuilder();
            int i = 0;
            int len = s.Length;
            while (i < len)
            {
                int ch = s[i];
                /*if (ch == '+') {                        // + : map to ' '
                    sbuf.Append(' ');
                } else*/
                if ('A' <= ch && ch <= 'Z')
                {    // 'A'..'Z' : as it was
                    sbuf.Append((char)ch);
                }
                else if ('a' <= ch && ch <= 'z')
                {    // 'a'..'z' : as it was
                    sbuf.Append((char)ch);
                }
                else if ('0' <= ch && ch <= '9')
                {    // '0'..'9' : as it was
                    sbuf.Append((char)ch);
                }
                else if (ch == '-' || ch == '_'       // unreserved : as it was
                  || ch == '.' || ch == '!'
                  || ch == '~' || ch == '*'
                  || ch == '\'' || ch == '('
                  || ch == ')')
                {
                    sbuf.Append((char)ch);
                }
                else if (ch == '%')
                {
                    int cint = 0;
                    if ('u' != s[i + 1])
                    {         // %XX : map to ascii(XX)
                        cint = (cint << 4) | val[s[i + 1]];
                        cint = (cint << 4) | val[s[i + 2]];
                        i += 2;
                    }
                    else
                    {                            // %uXXXX : map to unicode(XXXX)
                        cint = (cint << 4) | val[s[i + 2]];
                        cint = (cint << 4) | val[s[i + 3]];
                        cint = (cint << 4) | val[s[i + 4]];
                        cint = (cint << 4) | val[s[i + 5]];
                        i += 5;
                    }
                    sbuf.Append((char)cint);
                }
                i++;
            }
            return sbuf.ToString();
        }
        private static String[] hex = {
        "00","01","02","03","04","05","06","07","08","09","0A","0B","0C","0D","0E","0F",
        "10","11","12","13","14","15","16","17","18","19","1A","1B","1C","1D","1E","1F",
        "20","21","22","23","24","25","26","27","28","29","2A","2B","2C","2D","2E","2F",
        "30","31","32","33","34","35","36","37","38","39","3A","3B","3C","3D","3E","3F",
        "40","41","42","43","44","45","46","47","48","49","4A","4B","4C","4D","4E","4F",
        "50","51","52","53","54","55","56","57","58","59","5A","5B","5C","5D","5E","5F",
        "60","61","62","63","64","65","66","67","68","69","6A","6B","6C","6D","6E","6F",
        "70","71","72","73","74","75","76","77","78","79","7A","7B","7C","7D","7E","7F",
        "80","81","82","83","84","85","86","87","88","89","8A","8B","8C","8D","8E","8F",
        "90","91","92","93","94","95","96","97","98","99","9A","9B","9C","9D","9E","9F",
        "A0","A1","A2","A3","A4","A5","A6","A7","A8","A9","AA","AB","AC","AD","AE","AF",
        "B0","B1","B2","B3","B4","B5","B6","B7","B8","B9","BA","BB","BC","BD","BE","BF",
        "C0","C1","C2","C3","C4","C5","C6","C7","C8","C9","CA","CB","CC","CD","CE","CF",
        "D0","D1","D2","D3","D4","D5","D6","D7","D8","D9","DA","DB","DC","DD","DE","DF",
        "E0","E1","E2","E3","E4","E5","E6","E7","E8","E9","EA","EB","EC","ED","EE","EF",
        "F0","F1","F2","F3","F4","F5","F6","F7","F8","F9","FA","FB","FC","FD","FE","FF"
    };
        private static byte[] val = {
        0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,
        0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,
        0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,
        0x00,0x01,0x02,0x03,0x04,0x05,0x06,0x07,0x08,0x09,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,
        0x3F,0x0A,0x0B,0x0C,0x0D,0x0E,0x0F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,
        0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,
        0x3F,0x0A,0x0B,0x0C,0x0D,0x0E,0x0F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,
        0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,
        0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,
        0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,
        0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,
        0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,
        0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,
        0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,
        0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,
        0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F,0x3F
    };
        /// <summary>
        /// 获取随机字母
        /// </summary>
        /// <param name="len">位数</param>
        public static string GetRandomLetter(int len)
        {

            Random rd = new Random();
            string str = "abcdefghijklmnpqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ";
            string result = "";
            for (int i = 0; i < len; i++)
            {
                result += str[rd.Next(str.Length)];
            }
            return result;
        }
    }


}
