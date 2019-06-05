using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WeixinApi.Models.Base;

namespace WeixinApi.Models.Test
{
    /// <summary>
    /// 数据验证测试类
    /// </summary>
    public class ModelValidate : BaseDtoReq
    {
        /// <summary>
        /// 表示必填
        /// </summary>
        [Required]
        public string Name { get; set; }


        /// <summary>
        /// 表示年纪在20-100
        /// </summary>
        [Range(20, 100)]
        public int Age { get; set; }

        /// <summary>
        /// 手机正则表达式
        /// </summary>
        [RegularExpression(@"^1(3|4|5|7|8)\d{9}",ErrorMessage = "手机号错误")]
        public string Mobile { get; set; }
    }
}