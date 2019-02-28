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
    /// swagger�ĵ�����
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
        /// �ĵ�ע��
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        #region �ĵ�˵��
                        //�ĵ�˵��
                        //c.SingleApiVersion("v1", "WeixinApi�����ĵ�");

                        //�ĵ�˵��
                        c.MultipleApiVersions(ResolveAreasSupportByRouteConstraint, (vc) =>
                        {
                            //vc.Version("Admin", "���ĺ�̨ API").Description("������ڲ���һ�±�ע��Ϣ").TermsOfService("www.baidu.com").License(
                            //    x =>
                            //    {
                            //        x.Name("jian����");
                            //        x.Url("www.baidu.2333");
                            //    })
                            //    .Contact(x =>
                            //    {
                            //        x.Name("2017").Email("jianxuanhuo1@126.com").Url("www.baidu.xxxx");
                            //    });

                            vc.Version("v1", "������API",true);
                            vc.Version("Admin", "����API-��̨���");                            
                            vc.Version("Client", "����API-�˿����");
                        });
                        #endregion

                        #region ������
                        //��֤������
                        c.OperationFilter<HttpAuthHeaderFilter>();
                        //�ļ��ϴ�������
                        c.OperationFilter<UploadFilter>();
                        //�����ĵ�������
                        c.DocumentFilter<SwaggerAreasSupportDocumentFilter>();
                        #endregion

                        //ͬ���Ľӿ��� �����˲�ͬ����
                        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                        #region api xml�ĵ���Ϣ
                        //����api xml ���ĵ�
                        if (System.IO.File.Exists(GetAPIXmlCommentsPath())) { c.IncludeXmlComments(GetAPIXmlCommentsPath()); }
                        //����model xml���ĵ�
                        if (System.IO.File.Exists(GetModelXmlCommentsPath())) { c.IncludeXmlComments(GetModelXmlCommentsPath()); }
                        #endregion

                        //����
                        //c.CustomProvider((defaultProvider) => new SwaggerControllerDescProvider(defaultProvider, GetAPIXmlCommentsPath()));

                        //�������������
                        //c.GroupActionsBy(apiDesc => apiDesc.GetControllerAndActionAttributes<ControllerGroupAttribute>().Any() ?
                        //apiDesc.GetControllerAndActionAttributes<ControllerGroupAttribute>().First().GroupName + "_" +
                        //apiDesc.GetControllerAndActionAttributes<ControllerGroupAttribute>().First().Useage : "��ģ�����");

                        //��ʾAPI����״̬
                        c.ShowDeveloperInfo();
                    })
                .EnableSwaggerUi(c =>
                    {
                        //����
                        //c.InjectJavaScript(thisAssembly, "WeixinApi.Scripts.SwaggerControllerDescProvider.js");

                        //��ʽ
                        c.InjectStylesheet(typeof(SwaggerConfig).Assembly, "WeixinApi.Swagger.theme-flattop.css");

                        //����
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
