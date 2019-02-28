using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConfig
{
    /// <summary>
    /// 企业微信配置
    /// </summary>
    public class QyConfig
    {
        private static string _corpID;
        private static string _corpSecret;
        private static string allowDoMain;
        private static string allowIP;

        /// <summary>
        /// 企业ID
        /// </summary>
        public static string CorpID { get => _corpID ?? (_corpID = ConfigurationManager.AppSettings["CorpID"] ?? string.Empty); }

        /// <summary>
        /// 企业密钥
        /// </summary>
        public static string CorpSecret { get => _corpSecret ?? (_corpSecret = ConfigurationManager.AppSettings["CorpSecret"] ?? string.Empty); }

        /// <summary>
        /// 允许访问QY的域名
        /// </summary>
        public static string AllowDoMain { get => allowDoMain ?? ConfigurationManager.AppSettings["AllowDoMain"] ?? string.Empty; }

        /// <summary>
        /// 允许访问QY的域名
        /// </summary>
        public static List<string> ArrAllowDoMain { get => string.IsNullOrEmpty(AllowDoMain) ? new List<string>() { "*" } : AllowDoMain.Split('|').ToList(); }

        /// <summary>
        /// 允许访问QY的IP
        /// </summary>
        public static string AllowIP { get => allowIP ?? ConfigurationManager.AppSettings["AllowIP"] ?? string.Empty; }

        /// <summary>
        /// 允许访问QY的IP数组
        /// </summary>
        public static List<string> ArrAllowIP { get => string.IsNullOrEmpty(AllowIP) ? new List<string>() { "*" } : AllowIP.Split('|').ToList(); }





    }
}
