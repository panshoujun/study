using Common;
using Common.Log;
using DataConfig;
using Newtonsoft.Json;
using Senparc.Weixin.MP.AdvancedAPIs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeixinApi.App_Start;

namespace WeixinApi.Controllers
{

    public class HomeController : Controller
    {
        string openid = "oaTJ91VFhBiK24MFwFMLAhFvBEWE";
        public ActionResult Index()
        {
            string name = "张三";
            string panshoujun = $"我的名字叫:{name}";
            //FileLog.AddLog("aasdf");
            //return Redirect("/swagger/ui/index");
            //ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult ScanQrCodeLogin()
        {
            ViewBag.CurrentUser = Guid.NewGuid().ToString();
            return View();
        }

        public ActionResult Authorize(string CurrentUser, string ConnectionId)
        {

            string url = OAuthApi.GetAuthorizeUrl(MPConfig.AppId,
                "http://www.webpsj.com/home/backurl?CurrentUser=" + CurrentUser + "&ConnectionId=" + ConnectionId
                , "STATE", Senparc.Weixin.MP.OAuthScope.snsapi_userinfo);
            FileLog.AddLog(url);
            return Redirect(url);
        }

        public ActionResult BackUrl(string code, string CurrentUser, string ConnectionId)
        {
            FileLog.AddLog("code=" + code + "CurrentUser=" + CurrentUser + "ConnectionId=" + ConnectionId);
            string url = OAuthApi.GetAuthorizeUrl(MPConfig.AppId,
                "http://www.webpsj.com/home/backurl?CurrentUser=" + CurrentUser + "&ConnectionId=" + ConnectionId,
                "STATE", Senparc.Weixin.MP.OAuthScope.snsapi_userinfo);
            FileLog.AddLog("url=" + url);
            var tokenResult = OAuthApi.GetAccessToken(MPConfig.AppId, MPConfig.AppSecret, code);
            FileLog.AddLog("tokenResult=" + JsonConvert.SerializeObject(tokenResult));
            var userInfo = OAuthApi.GetUserInfo(tokenResult.access_token, tokenResult.openid);
            FileLog.AddLog("userInfo=" + JsonConvert.SerializeObject(userInfo));
            dynamic expando = new System.Dynamic.ExpandoObject();
            expando.url = url;
            expando.code = code;
            expando.tokenResult = tokenResult;
            expando.userInfo = userInfo;

            FileLog.AddLog("expando=" + JsonConvert.SerializeObject(expando));

            var item = BaseHub.list.Where(p => p.ConnectionId == ConnectionId).FirstOrDefault();
            if (item != null)
            {
                item.Name = userInfo.nickname;
                item.OtherData = userInfo;
            }
            
            ViewBag.CurrentUser = CurrentUser;
            ViewBag.ConnectionId = ConnectionId;
            //return Json(expando, JsonRequestBehavior.AllowGet);
            return View(userInfo);
        }


        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <returns></returns>
        public ActionResult ImageQrCodeEncode()
        {
            MemoryStream ms = new MemoryStream();
            string code = "http://www.webpsj.com/home/Authorize";
            //Server.MapPath("~/");  //this.Server.MapPath("~/"); //System.Web.Hosting.HostingEnvironment.MapPath("~/"); 获取根目录的方法
            //string filePath = @"D:\MyWork\MyWebApi\MyWebApi\Content\img\1.png";
            //Image centerImage = Image.FromFile(System.Web.Hosting.HostingEnvironment.MapPath("~/") + "Content/img/1.png");
            Bitmap qr = QrCodeHelper.Encode(code);
            qr.Save(ms, ImageFormat.Jpeg);
            byte[] buffurPic = ms.ToArray();
            return File(buffurPic, "image/jpeg");
        }
    }
}
