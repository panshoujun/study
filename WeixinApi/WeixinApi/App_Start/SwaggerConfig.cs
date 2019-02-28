using System.Web.Http;
using WebActivatorEx;
using WeixinApi;
using Swashbuckle.Application;
using System.Linq;
using WeixinApi.App_Start;
using WeixinApi.Filters;
using Swashbuckle.Swagger;
using System.Web.Http.Description;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WeixinApi
{
    /// <summary>
    /// swagger文档管理
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// api xml
        /// </summary>
        /// <returns></returns>
        private static string GetAPIXmlCommentsPath()
        {
            return string.Format("{0}/bin/WeixinApi.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }

        /// <summary>
        /// model xml
        /// </summary>
        /// <returns></returns>
        private static string GetModelXmlCommentsPath()
        {
            return string.Format("{0}/bin/Model.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }

        /// <summary>
        /// 文档注册
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        #region 文档说明
                        //文档说明
                        //c.SingleApiVersion("v1", "WeixinApi在线文档");

                        //文档说明
                        c.MultipleApiVersions(ResolveAreasSupportByRouteConstraint, (vc) =>
                        {
                            //vc.Version("Admin", "中文后台 API").Description("这个用于测试一下备注信息").TermsOfService("www.baidu.com").License(
                            //    x =>
                            //    {
                            //        x.Name("jian玄冰");
                            //        x.Url("www.baidu.2333");
                            //    })
                            //    .Contact(x =>
                            //    {
                            //        x.Name("2017").Email("jianxuanhuo1@126.com").Url("www.baidu.xxxx");
                            //    });

                            vc.Version("v1", "非区域API",true);
                            vc.Version("Admin", "区域API-后台相关");                            
                            vc.Version("Client", "区域API-顾客相关");
                        });
                        #endregion

                        #region 过滤器
                        //认证过滤器
                        c.OperationFilter<HttpAuthHeaderFilter>();
                        //文件上传过滤器
                        c.OperationFilter<UploadFilter>();
                        //区域文档过滤器
                        c.DocumentFilter<SwaggerAreasSupportDocumentFilter>();
                        #endregion

                        //同样的接口名 传递了不同参数
                        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                        #region api xml文档信息
                        //包含api xml 的文档
                        if (System.IO.File.Exists(GetAPIXmlCommentsPath())) { c.IncludeXmlComments(GetAPIXmlCommentsPath()); }
                        //包含model xml的文档
                        if (System.IO.File.Exists(GetModelXmlCommentsPath())) { c.IncludeXmlComments(GetModelXmlCommentsPath()); }
                        #endregion

                        //汉化
                        //c.CustomProvider((defaultProvider) => new SwaggerControllerDescProvider(defaultProvider, GetAPIXmlCommentsPath()));

                        //控制器分组管理
                        //c.GroupActionsBy(apiDesc => apiDesc.GetControllerAndActionAttributes<ControllerGroupAttribute>().Any() ?
                        //apiDesc.GetControllerAndActionAttributes<ControllerGroupAttribute>().First().GroupName + "_" +
                        //apiDesc.GetControllerAndActionAttributes<ControllerGroupAttribute>().First().Useage : "无模块归类");

                        //显示API开发状态
                        c.ShowDeveloperInfo();
                    })
                .EnableSwaggerUi(c =>
                    {
                        //汉化
                        //c.InjectJavaScript(thisAssembly, "WeixinApi.Scripts.SwaggerControllerDescProvider.js");

                        //样式
                        c.InjectStylesheet(typeof(SwaggerConfig).Assembly, "WeixinApi.Swagger.theme-flattop.css");

                        //汉化
                        //c.InjectJavaScript(typeof(SwaggerConfig).Assembly, "WeixinApi.Swagger.translator.js");
                    });
        }

        private static bool ResolveAreasSupportByRouteConstraint(ApiDescription apiDescription, string targetApiVersion)
        {
            if (targetApiVersion == "v1")
            {
                return apiDescription.Route.RouteTemplate.StartsWith("api/{controller}");
            }
            var routeTemplateStart = "api/" + targetApiVersion;
            return apiDescription.Route.RouteTemplate.StartsWith(routeTemplateStart);
        }
    }
}
