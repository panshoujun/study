using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int count = 51)
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public JsonResult GetSum(int count = 51, double init = 1)
        {
            double sum = 0;
            double temp = init;
            for (int i = 0; i < count; i++)
            {
                init *= 2;
                sum += init;
            }
            return Json(new
            {
                sum,
                init,
                pow = Math.Pow(2, count) * temp
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SendToAll()
        {
            return View();
        }

        public ActionResult SendToUser()
        {
            return View();
        }

        public ActionResult ScanQrCodeLogin()
        {
            ViewBag.CurrentUser = Guid.NewGuid().ToString();
            return View();
        }

    }
}
