using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeixinApi.Models.QY
{
    /// <summary>
    /// 获取成员
    /// </summary>
    public class GetMemberDto : BaseQYDto
    {
        /// <summary>
        /// 成员ID
        /// </summary>
        public string ID { get; set; }
    }
}