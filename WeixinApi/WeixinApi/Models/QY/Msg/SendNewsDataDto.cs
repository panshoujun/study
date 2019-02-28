using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeixinApi.Models.QY
{
    #region 图文消息
    /// <summary>
    /// 图文消息
    /// </summary>
    public class SendNewsDataDto: BaseQYMsgDto
    {
        ///// <summary>
        ///// 成员ID列表（消息接收者，多个接收者用‘|’分隔，最多支持1000个）。特殊情况：指定为@all，则向关注该企业应用的全部成员发送
        ///// </summary>
        //public string[] touser { get; set; }

        ///// <summary>
        ///// 部门ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数
        ///// </summary>
        //public string[] toparty { get; set; }

        ///// <summary>
        ///// 标签ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数
        ///// </summary>
        //public string[] totag { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public int toall { get; set; }

        /// <summary>
        /// 消息类型，此时固定为：news
        /// </summary>
        private string _msgtype= "news";

        /// <summary>
        /// 消息类型，此时固定为：news
        /// </summary>
        public string msgtype { get => _msgtype; }

        ///// <summary>
        ///// 企业应用的id，整型。可在应用的设置页面查看
        ///// </summary>
        //public int agentid { get; set; }

        /// <summary>
        /// 图文消息
        /// </summary>
        public News news { get; set; }

    }

    /// <summary>
    /// 图文消息
    /// </summary>
    public class News
    {
        /// <summary>
        /// 图文消息，一个图文消息支持1到8条图文
        /// </summary>
        public List<LinkedArticle> articles { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class LinkedArticle
    {
        /// <summary>
        /// 标题，不超过128个字节，超过会自动截断
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 描述，不超过512个字节，超过会自动截断
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// 点击后跳转的链接。
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 图文消息的图片链接，支持JPG、PNG格式，较好的效果为大图 640x320，小图80x80。
        /// </summary>
        public string picurl { get; set; }

        /// <summary>
        /// 按钮文字，仅在图文数为1条时才生效。 默认为“阅读全文”， 不超过4个文字，
        /// 超过自动截断。该设置只在企业微信上生效，微工作台（原企业号）上不生效。
        /// </summary>
        public string btntxt { get; set; }
    }
    #endregion
}