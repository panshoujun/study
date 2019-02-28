using WeixinApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WeixinApi
{
    /// <summary>
    /// 注册全局过滤器
    /// </summary>
    public static class WebApiFilterConfig
    {
        /// <summary>
        /// 注册全局过滤器
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new AuthorizeTokenAttribute() { IsValidation = true });
            //config.Filters.Add(new ModelValidationAttribute() {  IsValidation=true});
        }
    }
}