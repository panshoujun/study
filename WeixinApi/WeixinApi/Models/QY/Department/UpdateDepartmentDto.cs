using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeixinApi.Models.QY
{
    /// <summary>
    /// 修改组织
    /// </summary>
    public class UpdateDepartmentDto : BaseQYDto
    {
        private long _parentId;
        private int _order;

        #region 业务数据
        /// <summary>
        /// 部门名称。长度限制为1~64个字符
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父亲部门id。根部门id为1
        /// </summary>
        public long ParentId { get => _parentId; set => _parentId = value; }

        /// <summary>
        /// 在父部门中的次序。从1开始，数字越大排序越靠后
        /// </summary>
        public int Order { get => _order; set => _order = value; }

        /// <summary>
        /// 部门ID。用指定部门ID新建部门，不指定此参数时，则自动生成
        /// </summary>
        public long ID { get; set; }
        #endregion
    }
}