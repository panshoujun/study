using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Filters;

namespace WeixinApi.Filters
{
    /// <summary>
    /// swagger 增加 AUTH 选项
    /// </summary>
    public class HttpAuthHeaderFilter : IOperationFilter
    {
        /// <summary>
        /// 应用
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="apiDescription"></param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)

        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();
            var filterPipeline = apiDescription.ActionDescriptor.GetFilterPipeline(); //判断是否添加权限过滤器
            //var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Instance).Any(filter => filter is BaseAuthorizeAttribute); //判断是否允许匿名方法 

            //是否存在IsValidation == false的过滤器
            var unAuthorized = filterPipeline.Select(filterInfo => filterInfo.Instance).Where(filter => filter is BaseAuthorizeAttribute).Any(p => ((BaseAuthorizeAttribute)p).IsValidation == false);

            //是否存在IsValidation == true的过滤器
            var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Instance).Where(filter => filter is BaseAuthorizeAttribute).Any(p => ((BaseAuthorizeAttribute)p).IsValidation);

            //是否存在AllowAnonymousAttribute过滤器
            var allowAnonymous = apiDescription.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();

            if (!unAuthorized && !allowAnonymous && isAuthorized)
            {
                operation.parameters.Add(new Parameter
                {
                    name = "Token",
                    @in = "header",
                    description = "安全认证",
                    required = false,
                    type = "string"
                });
            }
        }
    }
}