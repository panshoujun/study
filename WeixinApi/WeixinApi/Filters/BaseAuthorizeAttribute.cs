using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WeixinApi.Filters
{
    /// <summary>
    /// 权限认证基础类
    /// </summary>
    public class BaseAuthorizeAttribute: AuthorizeAttribute
    {
        /// <summary>
        /// 是否参数验证
        /// </summary>
        public bool IsValidation { get; set; }
    }
}