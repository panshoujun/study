using DataConfig;
using Senparc.Weixin.Work.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WeixinApi.ApiControllers.QY
{
    /// <summary>
    /// 企业号通用方法
    /// </summary>
    [RoutePrefix("Common")]
    public class CommonController : ApiController
    {
        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="CorpID"></param>
        /// <param name="CorpSecret"></param>
        /// <param name="GetNewToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetAccessToken")]
        public string GetAccessToken(string CorpID, string CorpSecret, bool GetNewToken = false)
        {
            var token = AccessTokenContainer.TryGetToken(QyConfig.CorpID, QyConfig.CorpSecret);
            return token;
        }
    }
}
