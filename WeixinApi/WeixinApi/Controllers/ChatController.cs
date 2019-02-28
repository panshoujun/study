using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeixinApi.App_Start;

namespace WeixinApi.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 采用集线器类（Hub）+非自动生成代理模式
        /// 服务端与客户端分别定义的相对应的方法，
        /// 客户端通过代理对象调用服务端的方法，
        /// 服务端通过IHubConnectionContext回调客户端的方法，
        /// 客户端通过回调方法接收结果。
        /// </summary>
        /// <returns></returns>
        public ActionResult NotAgent()
        {
            ViewBag.ClientName = "聊客-" + Guid.NewGuid().ToString("N");
            var onLineUserList = MyChatHub.OnLineUsers.Select(u => new SelectListItem() { Text = u.Value, Value = u.Key }).ToList();
            onLineUserList.Insert(0, new SelectListItem() { Text = "-所有人-", Value = "" });
            ViewBag.OnLineUsers = onLineUserList;
            return View();
        }

        /// <summary>
        /// 采用集线器类（Hub）+自动生成代理模式
        /// </summary>
        /// <returns></returns>
        public ActionResult Agent()
        {
            ViewBag.ClientName = "聊客-" + Guid.NewGuid().ToString("N");
            var onLineUserList = MyChatHub.OnLineUsers.Select(u => new SelectListItem() { Text = u.Value, Value = u.Key }).ToList();
            onLineUserList.Insert(0, new SelectListItem() { Text = "-所有人-", Value = "" });
            ViewBag.OnLineUsers = onLineUserList;
            return View();
        }


        public ActionResult Persistent()
        {
            ViewBag.ClientName = "聊客-" + Guid.NewGuid().ToString("N");
            var onLineUserList = MyChatHub.OnLineUsers.Select(u => new SelectListItem() { Text = u.Value, Value = u.Key }).ToList();
            onLineUserList.Insert(0, new SelectListItem() { Text = "-所有人-", Value = "" });
            ViewBag.OnLineUsers = onLineUserList;
            return View();
        }

        public ActionResult PersistentEnter()
        {
            ViewBag.ClientName = "聊客-" + Guid.NewGuid().ToString("N");
            var onLineUserList = MyChatHub.OnLineUsers.Select(u => new SelectListItem() { Text = u.Value, Value = u.Key }).ToList();
            onLineUserList.Insert(0, new SelectListItem() { Text = "-所有人-", Value = "" });
            ViewBag.OnLineUsers = onLineUserList;
            return View();
        }
    }
}