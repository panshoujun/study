using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeixinApi.Models.QY
{
    /// <summary>
    /// 企业
    /// </summary>
    public class BaseQYDto
    {
        /// <summary>
        /// 企业ID
        /// </summary>
        public string QyID { get; set; }

        /// <summary>
        /// 调用接口凭证
        /// </summary>
        public string AccessToken { get; set; }
    }
}