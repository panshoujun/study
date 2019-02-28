using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConfig
{
    /// <summary>
    /// 微信公众号配置
    /// </summary>
    public class MPConfig
    {
        static string appId = ConfigurationManager.AppSettings["AppId"];
        static string appSecret = ConfigurationManager.AppSettings["AppSecret"];

        /// <summary>
        /// 开发者ID
        /// </summary>
        public static string AppId { get => appId; }

        /// <summary>
        /// 开发者密码
        /// </summary>
        public static string AppSecret { get => appSecret;}
    }
}
