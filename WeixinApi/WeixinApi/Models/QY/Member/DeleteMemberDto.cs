using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeixinApi.Models.QY
{
    /// <summary>
    /// 删除成员
    /// </summary>
    public class DeleteMemberDto : BaseQYDto
    {
        /// <summary>
        /// 成员ID
        /// </summary>
        public string ID { get; set; }
    }

    /// <summary>
    /// 批量删除成员
    /// </summary>
    public class BatchDeleteMember : BaseQYDto
    {
        /// <summary>
        /// 成员ID
        /// </summary>
        public string[] IDList { get; set; }
    }
}