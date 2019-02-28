using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WeixinApi.Areas.Client.Controllers
{
    /// <summary>
    /// 默认控制器
    /// </summary>
    public class DefaultController : ApiController
    {
        /// <summary>
        /// 获取通用ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Guid GetId()
        {
            return Guid.NewGuid();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetResult(string id)
        {
            return id;
        }
    }
}
