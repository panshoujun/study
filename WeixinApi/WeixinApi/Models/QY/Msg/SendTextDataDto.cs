using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeixinApi.Models.QY
{
    #region 文本消息
    /// <summary>
    /// 文本消息数据
    /// </summary>
    public class SendTextDataDto: BaseQYMsgDto
    {
        #region
        ///// <summary>
        ///// 成员ID列表（消息接收者，多个接收者用‘|’分隔，最多支持1000个）。特殊情况：指定为@all，则向该企业应用的全部成员发送
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
        #endregion

        /// <summary>
        /// 消息类型，此时固定为：text
        /// </summary>
        private string _msgtype= "text";

        /// <summary>
        /// 消息类型，此时固定为：text
        /// </summary>
        public string msgtype { get => _msgtype; }

        ///// <summary>
        ///// 企业应用的id，整型。可在应用的设置页面查看
        ///// </summary>
        //public int agentid { get; set; }

        /// <summary>
        /// 消息内容，最长不超过2048个字节
        /// </summary>
        public TextNew text { get; set; }

        ///// <summary>
        ///// 表示是否是保密消息，0表示否，1表示是，默认0
        ///// </summary>
        //public int safe { get; set; }

    }

    /// <summary>
    /// 消息内容，最长不超过2048个字节
    /// </summary>
    public class TextNew
    {
        /// <summary>
        /// 消息内容，最长不超过2048个字节
        /// </summary>
        public string content { get; set; }
    }

    #endregion
}