using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeixinApi.Models.QY
{
    /// <summary>
    /// 查询组织
    /// </summary>
    public class GetDepartmentListDto : BaseQYDto
    {
        /// <summary>
        /// 组织ID
        /// </summary>
        public long ID { get; set; }
    }
}