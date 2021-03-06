﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeixinApi.Models.Mp
{
    /// <summary>
    /// 添加模板
    /// </summary>
    public class AddtemplateDto: BaseMPDto
    {
        /// <summary>
        /// 模板ID 模板库中模板的编号，有“TM**”和“OPENTMTM**”等形式
        /// </summary>
        public string template_id { get; set; }
    }
}