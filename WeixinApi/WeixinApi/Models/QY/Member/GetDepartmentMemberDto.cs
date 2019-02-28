using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeixinApi.Models.QY
{
    /// <summary>
    /// 获取部门成员
    /// </summary>
    public class GetDepartmentMemberDto : BaseQYDto
    {
        /// <summary>
        /// 部门id
        /// </summary>
        public long DepartmentId { get; set; }

        /// <summary>
        /// 1/0：是否递归获取子部门下面的成员
        /// </summary>
        public int FetchChild { get; set; }
    }
}