using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WeixinApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            config.Services.Replace(typeof(System.Web.Http.Dispatcher.IHttpControllerSelector), new Filters.NamespaceHttpControllerSelector(config));
            // Web API 路由
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "AdminApi",
                routeTemplate: "api/Admin/{controller}/{action}/{id}",
                defaults: new { action = RouteParameter.Optional, id = RouteParameter.Optional });//, namespaces = new string[] { "SwashbuckleEx.WebApiTest.Areas.Admin.Controllers" }
            config.Routes.MapHttpRoute(
                name: "ClientApi",
                routeTemplate: "api/Client/{controller}/{action}/{id}",
                defaults: new { action = RouteParameter.Optional, id = RouteParameter.Optional });//, namespaces = new string[] { "SwashbuckleEx.WebApiTest.Areas.Client.Controllers" }

            config.Routes.MapHttpRoute(
                name: "CommonApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = RouteParameter.Optional, id = RouteParameter.Optional }//, namespaces = new string[] { "SwashbuckleEx.WebApiTest.Controllers" }
            );
        }
    }
}
