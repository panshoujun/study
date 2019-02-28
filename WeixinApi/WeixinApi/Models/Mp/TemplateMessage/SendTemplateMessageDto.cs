using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeixinApi.Models.Mp
{
    /// <summary>
    /// 发送模板消息
    /// </summary>
    public class SendTemplateMessageDto:BaseMPDto
    {
        /// <summary>
        /// 接收者openid
        /// </summary>
        public string touser { get; set; }

        /// <summary>
        /// 模板ID
        /// </summary>
        public string template_id { get; set; }

        /// <summary>
        /// 模板跳转链接
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 跳小程序所需数据，不需跳小程序可不用传该数据
        /// </summary>
        public Miniprogram miniprogram { get; set; }

        /// <summary>
        /// 模板数据
        /// </summary>
        public TemplateMessageData data { get; set; }
    }

    /// <summary>
    /// 小程序
    /// </summary>
    public class Miniprogram
    {
        /// <summary>
        /// 所需跳转到的小程序appid（该小程序appid必须与发模板消息的公众号是绑定关联关系，暂不支持小游戏）
        /// </summary>
        public string appid { get; set; }

        /// <summary>
        /// 所需跳转到小程序的具体页面路径，支持带参数,（示例index?foo=bar），暂不支持小游戏
        /// </summary>
        public string pagepath { get; set; }
    }

    /// <summary>
    /// 模板数据
    /// </summary>
    public class TemplateMessageData
    {
        /// <summary>
        /// 
        /// </summary>
        public TemplateMessageDataItem first { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TemplateMessageDataItem keyword1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TemplateMessageDataItem keyword2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TemplateMessageDataItem keyword3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TemplateMessageDataItem remark { get; set; }
    }

    /// <summary>
    /// 模板数据子项
    /// </summary>
    public class TemplateMessageDataItem
    {
        /// <summary>
        /// 值
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// 模板内容字体颜色，不填默认为黑色
        /// </summary>
        public string color { get; set; }
    }

}