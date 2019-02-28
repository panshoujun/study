using System;
using System.Configuration;

namespace Common
{
          
	/// <summary>
	/// web.config������
    /// ����ƽ
    /// 2004.8
	/// </summary>
	public sealed class ConfigHelper
	{
        /// <summary>
        /// ֧�ֵ���ʹ��
        /// </summary>
        public static readonly ConfigHelper Instance = new ConfigHelper();
        private string _appid;//΢�Ź��ں�AppId��Ӧ��ID��
        private string _smsPriKey;  //΢����Ȩ��ַ�ĵ�¼��Կ(�������֤)
        private string _secret;//΢�Ź��ں�AppSecret(Ӧ����Կ)
        private string _token;//΢�Ź��ں�token�����ƣ�
        private string _mobileUrl;  //�ֻ�����ַ
        private string _wxLoginUrl; //�û���¼��Ȩ��ַ
        private string _deskey; //�ַ�����Կ
        private string _shopweburl;//webվ��
        private string _jpushapp_key;// ��������app_key
        private string _jpushmaster_secret;// ��������master_secret
        private string _cusappid;//΢�Ź��ں�AppId��Ӧ��ID��(C��)
        private string _cussecret;//΢�Ź��ں�AppSecret(Ӧ����Կ)(C��)
        private string _CusHomeCardUrl;//C����ҳ���ƹ�ͼƬ
        private string _CusHomeCardUrlLink;//C����ҳ���ƹ�ͼƬ���ӵ�ַ
        private string _ShopMobileURL;//΢�Ŷ���ַ��ShopMobile��
        private string _apiurl;//api�ӿ�
        private string _FileURL;//�ļ���ַ
        /// <summary>
        /// C����ҳ���ƹ�ͼƬ���ӵ�ַ
        /// </summary>
        public string CusHomeCardUrlLink
        {
            get { return _CusHomeCardUrlLink ?? (_CusHomeCardUrlLink = ConfigurationManager.AppSettings["CusHomeCardUrlLink"] ?? string.Empty); }
        }
        /// <summary>
        /// C����ҳ���ƹ�ͼƬ
        /// </summary>
        public string ShopMobileURL
        {
            get { return _ShopMobileURL ?? (_ShopMobileURL = ConfigurationManager.AppSettings["ShopMobileURL"] ?? string.Empty); }
        }
        /// <summary>
        /// C����ҳ���ƹ�ͼƬ
        /// </summary>
        public string CusHomeCardUrl
        {
            get { return _CusHomeCardUrl ?? (_CusHomeCardUrl = ConfigurationManager.AppSettings["CusHomeCardUrl"] ?? string.Empty); }
        }

        /// <summary>
        /// ΢�Ź��ں�CusAppId��Ӧ��ID��(C��)
        /// </summary>
        public string CusAppId
        {
            get { return _cusappid ?? (_cusappid = ConfigurationManager.AppSettings["CusAppId"] ?? string.Empty); }
        }

        /// <summary>
        /// ΢�Ź��ں�CusSecret(Ӧ����Կ)(C��)
        /// </summary>
        public string CusSecret
        {
            get { return _cussecret ?? (_cussecret = ConfigurationManager.AppSettings["CusSecret"] ?? string.Empty); }
        }
        /// <summary>
        /// ΢�Ź��ں�AppId��Ӧ��ID��
        /// </summary>
        public string AppId
        {
            get { return _appid ?? (_appid = ConfigurationManager.AppSettings["AppId"] ?? string.Empty); }
        }
        /// <summary>
        /// ΢����Ȩ��ַ�ĵ�¼��Կ(�������֤)
        /// </summary>
        public string SMSPriKey
        {
            get { return _smsPriKey ?? (_smsPriKey = ConfigurationManager.AppSettings["SMSPriKey"] ?? string.Empty); }
        }

        /// <summary>
        /// ΢�Ź��ں�AppSecret(Ӧ����Կ)
        /// </summary>
        public string Secret
        {
            get { return _secret ?? (_secret = ConfigurationManager.AppSettings["Secret"] ?? string.Empty); }
        }
        /// <summary>
        /// ΢�Ź��ں�token�����ƣ�
        /// </summary>
        public string Token
        {
            get { return _token ?? (_token = ConfigurationManager.AppSettings["Token"] ?? string.Empty); }
        }
        /// <summary>
        /// �ļ���ַ
        /// </summary>
        public string FileURL
        {
            get { return _FileURL ?? (_FileURL = ConfigurationManager.AppSettings["FileURL"] ?? string.Empty); }
        }
        /// <summary>
        /// �ֻ�����ַ
        /// </summary>
        public string MobileUrl
        {
            get { return _mobileUrl ?? (_mobileUrl = ConfigurationManager.AppSettings["MobileUrl"] ?? string.Empty); }
        }

        /// <summary>
        /// �û���¼��Ȩ��ַ
        /// </summary>
        public string WxLoginUrl
        {
            get { return _wxLoginUrl ?? (_wxLoginUrl = ConfigurationManager.AppSettings["WxLoginUrl"] ?? string.Empty); }
        }
        /// <summary>
        /// ����������Կ
        /// </summary> 
        public string DESKey
        {
            get { return _deskey ?? (_deskey = ConfigurationManager.AppSettings["DESKey"] ?? string.Empty); }
        }
        /// <summary>
        /// webվ��
        /// </summary>
        public string ShopWebURL
        {
            get { return _shopweburl ?? (_shopweburl = ConfigurationManager.AppSettings["ShopWebURL"] ?? string.Empty); }
        }
        /// <summary>
        /// API�ӿ�
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
        /// jpush��ַ
        /// </summary>
        public string JPushMASTER_SECRET
        {
            get { return _jpushmaster_secret ?? (_jpushmaster_secret = ConfigurationManager.AppSettings["JPushMASTER_SECRET"] ?? string.Empty); }
        }
		/// <summary>
		/// �õ�AppSettings�е������ַ�����Ϣ
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
		/// �õ�AppSettings�е�����Bool��Ϣ
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
		/// �õ�AppSettings�е�����Decimal��Ϣ
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
		/// �õ�AppSettings�е�����int��Ϣ
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
