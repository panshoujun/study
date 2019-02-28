using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeixinApi.Models.QY
{
    /// <summary>
    /// 删除组织
    /// </summary>
    public class DeleteDepartmentDto: BaseQYDto
    {
        /// <summary>
        /// 组织ID
        /// </summary>
        public long ID { get; set; }
    }
}