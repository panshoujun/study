using System;
using System.Configuration;

namespace Common
{
          
	/// <summary>
	/// web.config操作类
    /// 李天平
    /// 2004.8
	/// </summary>
	public sealed class ConfigHelper
	{
        /// <summary>
        /// 支持单例使用
        /// </summary>
        public static readonly ConfigHelper Instance = new ConfigHelper();
        private string _appid;//微信公众号AppId（应用ID）
        private string _smsPriKey;  //微信授权网址的登录密钥(服务端验证)
        private string _secret;//微信公众号AppSecret(应用密钥)
        private string _token;//微信公众号token（令牌）
        private string _mobileUrl;  //手机端网址
        private string _wxLoginUrl; //用户登录授权网址
        private string _deskey; //字符串密钥
        private string _shopweburl;//web站点
        private string _jpushapp_key;// 极光推送app_key
        private string _jpushmaster_secret;// 极光推送master_secret
        private string _cusappid;//微信公众号AppId（应用ID）(C端)
        private string _cussecret;//微信公众号AppSecret(应用密钥)(C端)
        private string _CusHomeCardUrl;//C端首页卡推广图片
        private string _CusHomeCardUrlLink;//C端首页卡推广图片链接地址
        private string _ShopMobileURL;//微信端网址（ShopMobile）
        private string _apiurl;//api接口
        private string _FileURL;//文件地址
        /// <summary>
        /// C端首页卡推广图片链接地址
        /// </summary>
        public string CusHomeCardUrlLink
        {
            get { return _CusHomeCardUrlLink ?? (_CusHomeCardUrlLink = ConfigurationManager.AppSettings["CusHomeCardUrlLink"] ?? string.Empty); }
        }
        /// <summary>
        /// C端首页卡推广图片
        /// </summary>
        public string ShopMobileURL
        {
            get { return _ShopMobileURL ?? (_ShopMobileURL = ConfigurationManager.AppSettings["ShopMobileURL"] ?? string.Empty); }
        }
        /// <summary>
        /// C端首页卡推广图片
        /// </summary>
        public string CusHomeCardUrl
        {
            get { return _CusHomeCardUrl ?? (_CusHomeCardUrl = ConfigurationManager.AppSettings["CusHomeCardUrl"] ?? string.Empty); }
        }

        /// <summary>
        /// 微信公众号CusAppId（应用ID）(C端)
        /// </summary>
        public string CusAppId
        {
            get { return _cusappid ?? (_cusappid = ConfigurationManager.AppSettings["CusAppId"] ?? string.Empty); }
        }

        /// <summary>
        /// 微信公众号CusSecret(应用密钥)(C端)
        /// </summary>
        public string CusSecret
        {
            get { return _cussecret ?? (_cussecret = ConfigurationManager.AppSettings["CusSecret"] ?? string.Empty); }
        }
        /// <summary>
        /// 微信公众号AppId（应用ID）
        /// </summary>
        public string AppId
        {
            get { return _appid ?? (_appid = ConfigurationManager.AppSettings["AppId"] ?? string.Empty); }
        }
        /// <summary>
        /// 微信授权网址的登录密钥(服务端验证)
        /// </summary>
        public string SMSPriKey
        {
            get { return _smsPriKey ?? (_smsPriKey = ConfigurationManager.AppSettings["SMSPriKey"] ?? string.Empty); }
        }

        /// <summary>
        /// 微信公众号AppSecret(应用密钥)
        /// </summary>
        public string Secret
        {
            get { return _secret ?? (_secret = ConfigurationManager.AppSettings["Secret"] ?? string.Empty); }
        }
        /// <summary>
        /// 微信公众号token（令牌）
        /// </summary>
        public string Token
        {
            get { return _token ?? (_token = ConfigurationManager.AppSettings["Token"] ?? string.Empty); }
        }
        /// <summary>
        /// 文件地址
        /// </summary>
        public string FileURL
        {
            get { return _FileURL ?? (_FileURL = ConfigurationManager.AppSettings["FileURL"] ?? string.Empty); }
        }
        /// <summary>
        /// 手机端网址
        /// </summary>
        public string MobileUrl
        {
            get { return _mobileUrl ?? (_mobileUrl = ConfigurationManager.AppSettings["MobileUrl"] ?? string.Empty); }
        }

        /// <summary>
        /// 用户登录授权网址
        /// </summary>
        public string WxLoginUrl
        {
            get { return _wxLoginUrl ?? (_wxLoginUrl = ConfigurationManager.AppSettings["WxLoginUrl"] ?? string.Empty); }
        }
        /// <summary>
        /// 数据请求密钥
        /// </summary> 
        public string DESKey
        {
            get { return _deskey ?? (_deskey = ConfigurationManager.AppSettings["DESKey"] ?? string.Empty); }
        }
        /// <summary>
        /// web站点
        /// </summary>
        public string ShopWebURL
        {
            get { return _shopweburl ?? (_shopweburl = ConfigurationManager.AppSettings["ShopWebURL"] ?? string.Empty); }
        }
        /// <summary>
        /// API接口
        /// </summary>
        public string APIURL
        {
            get { return _apiurl ?? (_apiurl = ConfigurationManager.AppSettings["APIURL"] ?? string.Empty); }
        }
        /// <summary>
        /// jpushapp_key
        /// </summary>
        public string JPushAPP_KEY
        {
            get { return _jpushapp_key ?? (_jpushapp_key = ConfigurationManager.AppSettings["JPushAPP_KEY"] ?? string.Empty); }
        }

        /// <summary>
        /// jpush地址
        /// </summary>
        public string JPushMASTER_SECRET
        {
            get { return _jpushmaster_secret ?? (_jpushmaster_secret = ConfigurationManager.AppSettings["JPushMASTER_SECRET"] ?? string.Empty); }
        }
		/// <summary>
		/// 得到AppSettings中的配置字符串信息
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string GetConfigString(string key)
		{
            string CacheKey = "AppSettings-" + key;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = ConfigurationManager.AppSettings[key]; 
                    if (objModel != null)
                    {                        
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(180), TimeSpan.Zero);
                    }
                }
                catch
                { }
            }
            return objModel.ToString();
		}

		/// <summary>
		/// 得到AppSettings中的配置Bool信息
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static bool GetConfigBool(string key)
		{
			bool result = false;
			string cfgVal = GetConfigString(key);
			if(null != cfgVal && string.Empty != cfgVal)
			{
				try
				{
					result = bool.Parse(cfgVal);
				}
				catch(FormatException)
				{
					// Ignore format exceptions.
				}
			}
			return result;
		}
		/// <summary>
		/// 得到AppSettings中的配置Decimal信息
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static decimal GetConfigDecimal(string key)
		{
			decimal result = 0;
			string cfgVal = GetConfigString(key);
			if(null != cfgVal && string.Empty != cfgVal)
			{
				try
				{
					result = decimal.Parse(cfgVal);
				}
				catch(FormatException)
				{
					// Ignore format exceptions.
				}
			}

			return result;
		}
		/// <summary>
		/// 得到AppSettings中的配置int信息
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static int GetConfigInt(string key)
		{
			int result = 0;
			string cfgVal = GetConfigString(key);
			if(null != cfgVal && string.Empty != cfgVal)
			{
				try
				{
					result = int.Parse(cfgVal);
				}
				catch(FormatException)
				{
					// Ignore format exceptions.
				}
			}

			return result;
		}
	}
}
