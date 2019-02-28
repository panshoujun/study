using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeixinApi.Models.Base
{
    /// <summary>
    /// 系统级别参数
    /// </summary>
    public class BaseSystemParamReq
    {
        //#region 系统级属性
        ///// <summary>
        ///// 版本号
        ///// </summary>
        //public string Version = "0.0.1";
        ///// <summary>
        ///// AppKey
        ///// </summary>
        //public string AppKey { get; set; }
        ///// <summary>
        ///// 时间戳
        ///// </summary>
        //public string TimeStamp { get; set; }
        ///// <summary>
        ///// 签名
        ///// </summary>
        //public string Sign { get; set; }
        //#endregion

        //#region 业务逻辑级属性
        //public string Token { get; set; }
        //#endregion

        //#region 为了获取Sign的相关方法


        ///// <summary>
        ///// 根据AppKey获取AppSecret
        ///// </summary>
        ///// <returns></returns>
        //public string GetAppSecret(string appKey)
        //{
        //    string secret = "39ea5cfd426946d7a1b4429d7b243a2c";
        //    return secret;
        //}

        ///// <summary>
        ///// 获取appkey
        ///// </summary>
        ///// <returns></returns>
        //public string GetAppKey()
        //{
        //    return "1035541";
        //}



        ///// <summary>
        ///// 获取系统参数字典
        ///// </summary>
        //public Dictionary<string, string> GetSysParamDic()
        //{
        //    Dictionary<string, string> dic = new Dictionary<string, string>();
        //    dic.Add("Version", Version);
        //    dic.Add("AppKey", AppKey);
        //    dic.Add("TimeStamp", TimeStamp);
        //    return dic;
        //}

        ///// <summary>
        ///// 生成sign
        ///// </summary>
        ///// <param name="dic"></param>
        ///// <param name="appSecret"></param>
        ///// <returns></returns>
        //public string MakeSignData(Dictionary<string, string> dic, string appSecret)
        //{
        //    // 第一步：把字典按Key的字母顺序排序
        //    IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(dic);
        //    IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

        //    // 第二步：把所有参数名和参数值串在一起
        //    StringBuilder query = new StringBuilder(appSecret);
        //    while (dem.MoveNext())
        //    {
        //        string key = dem.Current.Key;
        //        string value = dem.Current.Value;
        //        if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
        //        {
        //            query.Append(key).Append(value);
        //        }
        //    }

        //    //第三步：使用MD5加密
        //    var result = MD5Helper.EncryptStatic(query.ToString()); ;
        //    return result;
        //}
        //#endregion

        ///// <summary>
        ///// Sign签名验证
        ///// </summary>
        ///// <returns></returns>
        //public bool CheckSign()
        //{
        //    return this.Sign == MakeSignData(GetSysParamDic(), GetAppSecret(this.AppKey));
        //}

        //public string GetDesToken()
        //{
        //    return DES3Encrypt.DecodeStatic(this.Token);
        //}

        ///// <summary>
        ///// 验证Token
        ///// </summary>
        ///// <returns></returns>
        //public bool CheckToken()
        //{
        //    if (this.Token.IsNullOrEmpty())
        //    {
        //        return false;
        //    }
        //    var user = RedisCacheHelper.Get<EnterpriseUser>(GetDesToken());
        //    if (user != null && user.ID != null)
        //        return true;
        //    return false;
        //}
    }
}
