using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeixinApi.Models.Mp
{
    /// <summary>
    /// 设置所属行业
    /// </summary>
    public class SetIndustryDto : BaseMPDto
    {
        /// <summary>
        /// 公众号模板消息所属行业编号
        /// </summary>
        public int industry_id1 { get; set; }

        /// <summary>
        /// 公众号模板消息所属行业编号
        /// </summary>

        public int industry_id2 { get; set; }
    }
}