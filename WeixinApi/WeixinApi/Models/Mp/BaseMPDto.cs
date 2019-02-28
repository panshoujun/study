using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeixinApi.Models.Mp
{
    /// <summary>
    /// 微信公众号
    /// </summary>
    public class BaseMPDto
    {
        /// <summary>
        /// 微信ID
        /// </summary>
        public string MPID { get; set; }

        /// <summary>
        /// 调用接口凭证
        /// </summary>
        public string AccessToken { get; set; }
    }
}