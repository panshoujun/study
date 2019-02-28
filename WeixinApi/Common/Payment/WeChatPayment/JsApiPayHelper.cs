using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class JsApiPayHelper
    {
        //#region 业务方法

        //#region 报修统一下单接口（服务商支付）


        //public static WxPayData UnifiedWxPayAwaken(WxPayData inputObj)
        //{
        //    WxPayData result = new WxPayData();
        //    //string prepay_id = string.Empty;
        //    try
        //    {
        //        #region 验证接口参数有效性
        //        if (inputObj == null)
        //            throw new Exception("统一支付接口参数不能为空！");
        //        if (inputObj.GetValue("appid") == null || string.IsNullOrEmpty(inputObj.GetValue("appid").ToString()))
        //            inputObj.SetValue("appid", ConfigHelper.GetConfigString("AppId"));//公众账号ID
        //        if (inputObj.GetValue("mch_id") == null || string.IsNullOrEmpty(inputObj.GetValue("mch_id").ToString()))
        //            inputObj.SetValue("mch_id", ConfigHelper.GetConfigString("Mch_ID"));//商户号
        //        inputObj.SetValue("nonce_str", GenerateNonceStr()); ;//随机字符串
        //        inputObj.SetValue("spbill_create_ip", GetAddressIP());//APP和网页支付提交用户端ip	 
        //        //inputObj.SetValue("trade_type", "JSAPI");//JSAPI 取值如下：JSAPI，NATIVE，APP，WAP

        //        if (!inputObj.IsSet("notify_url"))
        //            inputObj.SetValue("notify_url", ConfigHelper.GetConfigString("Notify_URL"));//异步通知url

        //        string out_trade_no = inputObj.GetValue("out_trade_no").ToString();
        //        //inputObj.SetValue("out_trade_no", out_trade_no);

        //        string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";//统一下单接口url

        //        //检测必填参数
        //        if (!inputObj.IsSet("out_trade_no"))
        //            throw new Exception("缺少统一支付接口必填参数out_trade_no！");
        //        else if (!inputObj.IsSet("body"))
        //            throw new Exception("缺少统一支付接口必填参数body！");
        //        else if (!inputObj.IsSet("total_fee"))
        //            throw new Exception("缺少统一支付接口必填参数total_fee！");
        //        else if (!inputObj.IsSet("trade_type"))
        //            throw new Exception("缺少统一支付接口必填参数trade_type！");

        //        //关联参数
        //        if (inputObj.GetValue("trade_type").ToString() == "JSAPI" && !inputObj.IsSet("openid"))
        //            throw new Exception("统一支付接口中，缺少必填参数openid！");
        //        if (inputObj.GetValue("trade_type").ToString() == "NATIVE" && !inputObj.IsSet("product_id"))
        //            throw new Exception("统一支付接口中，缺少必填参数product_id！");
        //        inputObj.SetValue("sign", inputObj.MakeSign());//签名
        //        #endregion



        //        // 将接口参数转换为XML
        //        string xml = inputObj.ToXml();
        //        // 接口调用开始时间
        //        var start = DateTime.Now;
        //        // 调用统一下单接口
        //        string response = HttpService.Post(xml, url, false, 100);
        //        // 接口调用结束时间
        //        var end = DateTime.Now;
        //        // 计算接口调用所用时间差
        //        int timeCost = (int)((end - start).TotalMilliseconds);
        //        // 读取统一下单接口返回数据

        //        result.FromXml(response);
        //        // 判断调用统一下单接口通讯是否成功
        //        if (result.GetValue("return_code").ToString() != "SUCCESS")
        //            throw new Exception("调用统一下单接口失败！(" + result.GetValue("return_msg") + ")");
        //        // 判断调用统一下单接口返回是否成功
        //        if (result.GetValue("result_code").ToString() != "SUCCESS")
        //            throw new Exception("调用统一下单接口数据返回失败！(" + result.GetValue("err_code_des") + ")");
        //        // 判断是否成功返回微信订单号
        //        if (!result.IsSet("prepay_id"))
        //            throw new Exception("调用统一下单接口返回微信订单号失败！");


        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelp.AddErrLog("统一下单(fun:UnifiedWxPayAwaken)", true, "调用统一下单接口失败!错误原因：" + ex.Message);
        //        return null;
        //    }
        //    return result;
        //}

        ///// <summary>
        ///// 统一下单
        ///// </summary>
        ///// <param name="inputObj"></param>
        ///// <param name="timeOut"></param>
        ///// <returns>prepay_id(返回微信订单号，若为空表示失败!)</returns>
        //public static WxPayData UnifiedServiceRepairOrder(WxPayData inputObj, out int id, int timeOut = 6, int userId = 0, int useType = 0, int ScanType = 0, string orderno = "", bool isRecharge = false)
        //{
        //    id = 0;
        //    WxPayData result = new WxPayData();
        //    //string prepay_id = string.Empty;
        //    try
        //    {
        //        #region 验证接口参数有效性
        //        if (inputObj == null)
        //            throw new Exception("统一支付接口参数不能为空！");
        //        //if (inputObj.GetValue("appid") == null || string.IsNullOrEmpty(inputObj.GetValue("appid").ToString()))
        //        inputObj.SetValue("appid", ConfigHelper.GetConfigString("AppId"));//公众账号ID
        //        //if (inputObj.GetValue("mch_id") == null || string.IsNullOrEmpty(inputObj.GetValue("mch_id").ToString()))
        //        inputObj.SetValue("mch_id", ConfigHelper.GetConfigString("Mch_ID"));//商户号
        //        inputObj.SetValue("nonce_str", GenerateNonceStr()); ;//随机字符串
        //        inputObj.SetValue("spbill_create_ip", GetAddressIP());//APP和网页支付提交用户端ip	 
        //        //inputObj.SetValue("trade_type", "JSAPI");//JSAPI 取值如下：JSAPI，NATIVE，APP，WAP

        //        if (!inputObj.IsSet("notify_url"))
        //            inputObj.SetValue("notify_url", ConfigHelper.GetConfigString("Notify_URL"));//异步通知url

        //        string out_trade_no = inputObj.GetValue("out_trade_no").ToString();
        //        //inputObj.SetValue("out_trade_no", out_trade_no);

        //        string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";//统一下单接口url

        //        //检测必填参数
        //        if (!inputObj.IsSet("out_trade_no"))
        //            throw new Exception("缺少统一支付接口必填参数out_trade_no！");
        //        else if (!inputObj.IsSet("body"))
        //            throw new Exception("缺少统一支付接口必填参数body！");
        //        else if (!inputObj.IsSet("total_fee"))
        //            throw new Exception("缺少统一支付接口必填参数total_fee！");
        //        else if (!inputObj.IsSet("trade_type"))
        //            throw new Exception("缺少统一支付接口必填参数trade_type！");

        //        //关联参数
        //        if (inputObj.GetValue("trade_type").ToString() == "JSAPI" && !inputObj.IsSet("openid"))
        //            throw new Exception("统一支付接口中，缺少必填参数openid！");
        //        if (inputObj.GetValue("trade_type").ToString() == "NATIVE" && !inputObj.IsSet("product_id"))
        //            throw new Exception("统一支付接口中，缺少必填参数product_id！");
        //        inputObj.SetValue("sign", inputObj.MakeSign());//签名
        //        #endregion



        //        // 将接口参数转换为XML
        //        string xml = inputObj.ToXml();
        //        // 接口调用开始时间
        //        var start = DateTime.Now;
        //        // 调用统一下单接口
        //        string response = HttpService.Post(xml, url, false, 100);
        //        // 接口调用结束时间
        //        var end = DateTime.Now;
        //        // 计算接口调用所用时间差
        //        int timeCost = (int)((end - start).TotalMilliseconds);
        //        // 读取统一下单接口返回数据

        //        result.FromXml(response);
        //        // 判断调用统一下单接口通讯是否成功
        //        if (result.GetValue("return_code").ToString() != "SUCCESS")
        //            throw new Exception("调用统一下单接口失败！(" + result.GetValue("return_msg") + ")");
        //        // 判断调用统一下单接口返回是否成功
        //        if (result.GetValue("result_code").ToString() != "SUCCESS")
        //            throw new Exception("调用统一下单接口数据返回失败！(" + result.GetValue("err_code_des") + ")");
        //        // 判断是否成功返回微信订单号
        //        if (!result.IsSet("prepay_id"))
        //            throw new Exception("调用统一下单接口返回微信订单号失败！");
        //        // 微信订单号
        //        //prepay_id = result.GetValue("prepay_id").ToString();

        //        //Log.Debug("统一下单(fun:UnifiedOrder)", "调用统一下单接口成功!返回结果：" + result.ToJson());
        //        //LogHelp.AddErrLog("统一下单(fun:UnifiedOrder)1", false, "调用统一下单接口成功!返回结果：" + result.ToJson());

        //        #region 插入支付日志
        //        Model.RepairPayLogInfo model_PayLog = new Model.RepairPayLogInfo();
        //        model_PayLog.PayPrice = Convert.ToDecimal(inputObj.GetValue("total_fee")) / 100;


        //        model_PayLog.OrderNo = orderno;
        //        model_PayLog.PayNo = out_trade_no;

        //        model_PayLog.BankNo = result.GetValue("prepay_id").ToString();
        //        model_PayLog.PayType = 0;// 微信支付
        //        model_PayLog.Status = 0;// 未支付
        //        model_PayLog.UserID = userId;
        //        model_PayLog.ClientType = 0;
        //        model_PayLog.UseType = useType;
        //        model_PayLog.AccountType = 0;
        //        model_PayLog.ScanType = ScanType;
        //        if (inputObj.GetValue("trade_type").ToString() == "NATIVE")
        //            model_PayLog.Messages = result.GetValue("code_url").ToString();
        //        else
        //            model_PayLog.Messages = "下单成功";
        //        model_PayLog.AddTime = DateTime.Now;
        //        model_PayLog.EndTime = model_PayLog.AddTime.Value.AddHours(+2);
        //        new BLL.RepairPayLogInfo().DeleteList("PayNo='" + inputObj.GetValue("out_trade_no").ToString() + "'");
        //        new BLL.RepairPayLogInfo().Add(model_PayLog, out id);
        //        #endregion
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelp.AddErrLog("统一下单(fun:UnifiedServiceRepairOrder)", true, "调用统一下单接口失败!错误原因：" + ex.Message);
        //        return null;
        //    }
        //    return result;
        //}
        //#endregion


        //#region 报修统一下单接口

        ///// <summary>
        ///// 报修统一下单接口（APP）
        ///// </summary>
        ///// <param name="body">商品简要描述</param>
        ///// <param name="out_trade_no">商户订单号</param>
        ///// <param name="trade_type">支付类型(JSAPI，NATIVE，APP，WAP)</param>
        ///// <param name="total_fee">支付金额(分)</param>
        ///// <param name="openid">支付微信账号的openid</param>
        ///// <param name="paylogid">返回下单记录的ID</param>
        ///// <param name="userId">支付账号id</param>
        ///// <param name="useType">用途：0-上门费；1-服务费；</param>
        ///// <param name="out_order_no">订单编号</param>
        ///// <returns></returns>
        //public static string AppUnifiedRepairOrder(string appidstr, string body, string systemorderno, string trade_type, long total_fee, string openid, out int paylogid, long userId = 0, int useType = 0, string out_order_no = "")
        //{
        //    string prepay_id = string.Empty;
        //    paylogid = 0;//下单日志ID
        //    try
        //    {

        //        #region 验证接口参数有效性
        //        //验证调用传入参数
        //        if (string.IsNullOrEmpty(appidstr) ||
        //            string.IsNullOrEmpty(body) ||
        //            string.IsNullOrEmpty(systemorderno) ||
        //            string.IsNullOrEmpty(trade_type) ||
        //            total_fee <= 0)
        //        {
        //            return string.Empty;
        //        }
        //        string out_trade_no = systemorderno;//+ DateTime.Now.ToString("yyyyMMdd");// 支付订单号
        //        //验证配置参数
        //        string appid = appidstr;
        //        string mch_id = ConfigHelper.GetConfigString("Mch_ID");
        //        string nonce_str = GenerateNonceStr();
        //        string notify_url = ConfigHelper.GetConfigString("Notify_URL");
        //        string spbill_create_ip = GetAddressIP();
        //        if (string.IsNullOrEmpty(appid) ||
        //            string.IsNullOrEmpty(mch_id) ||
        //            string.IsNullOrEmpty(nonce_str) ||
        //            string.IsNullOrEmpty(notify_url))
        //        {
        //            return string.Empty;
        //        }
        //        string product_id = string.Empty;
        //        ////关联参数
        //        //if (trade_type == "JSAPI" && string.IsNullOrEmpty(openid))
        //        //    return string.Empty;
        //        //if (trade_type == "NATIVE" && !string.IsNullOrEmpty(product_id))
        //        //    return string.Empty;
        //        #endregion
        //        // 设置请求接口参数
        //        WxPayData inputObj = new WxPayData();
        //        inputObj.SetValue("appid", appid);//公众账号ID               
        //        inputObj.SetValue("mch_id", mch_id);//商户号
        //        inputObj.SetValue("nonce_str", nonce_str); ;//随机字符串
        //        inputObj.SetValue("spbill_create_ip", spbill_create_ip);//APP和网页支付提交用户端ip	 
        //        inputObj.SetValue("notify_url", notify_url);//异步通知url
        //        inputObj.SetValue("body", body);//简要描述
        //        inputObj.SetValue("out_trade_no", out_trade_no);//订单号
        //        inputObj.SetValue("trade_type", trade_type);//JSAPI 取值如下：JSAPI，NATIVE，APP，WAP
        //        inputObj.SetValue("total_fee", total_fee.ToString());//订单金额
        //        //inputObj.SetValue("openid", openid);
        //        inputObj.SetValue("sign", inputObj.MakeSign());//签名

        //        //统一下单接口url
        //        string apiurl = "https://api.mch.weixin.qq.com/pay/unifiedorder";
        //        // 将接口参数转换为XML
        //        string xml = inputObj.ToXml();
        //        // 接口调用开始时间
        //        var start = DateTime.Now;
        //        // 调用统一下单接口
        //        string response = HttpService.Post(xml, apiurl, false, 100);
        //        // 接口调用结束时间
        //        var end = DateTime.Now;
        //        // 计算接口调用所用时间差
        //        int timeCost = (int)((end - start).TotalMilliseconds);

        //        // 读取统一下单接口返回数据
        //        WxPayData result = new WxPayData();
        //        result.FromXml(response);
        //        // 判断调用统一下单接口通讯是否成功
        //        if (result.GetValue("return_code").ToString() != "SUCCESS")
        //        {
        //            LogHelp.AddErrLog("统一下单(" + out_trade_no + ")通讯失败", false, result.GetValue("return_msg").ToString());
        //            return string.Empty;
        //        }
        //        // 判断调用统一下单接口返回是否成功
        //        if (result.GetValue("result_code").ToString() != "SUCCESS")
        //        {
        //            LogHelp.AddErrLog("统一下单(" + out_trade_no + ")返回失败", false, result.GetValue("err_code_des").ToString());
        //            return string.Empty;
        //        }
        //        // 判断是否成功返回微信订单号
        //        if (!result.IsSet("prepay_id"))
        //        {
        //            LogHelp.AddErrLog("统一下单(" + out_trade_no + ")返回prepay_id失败", false, "");
        //            return string.Empty;
        //        }

        //        prepay_id = result.GetValue("prepay_id").ToString();

        //        #region 插入下单日志
        //        Model.RepairPayLogInfo model_PayLog = new Model.RepairPayLogInfo();
        //        model_PayLog.PayPrice = Convert.ToDecimal(inputObj.GetValue("total_fee")) / 100;
        //        model_PayLog.OrderNo = out_order_no;
        //        model_PayLog.PayNo = out_trade_no;
        //        model_PayLog.BankNo = result.GetValue("prepay_id").ToString();
        //        model_PayLog.PayType = 0;// 微信支付
        //        model_PayLog.Status = 0;// 未支付
        //        model_PayLog.UserID = userId;
        //        model_PayLog.ClientType = 1;
        //        model_PayLog.UseType = useType;
        //        model_PayLog.AccountType = 0;



        //        if (trade_type == "NATIVE")
        //        {
        //            if (result.IsSet("code_url"))
        //                model_PayLog.Messages = result.GetValue("code_url").ToString();
        //            else
        //                model_PayLog.Messages = string.Empty;
        //        }
        //        else
        //        { model_PayLog.Messages = body; }
        //        model_PayLog.AddTime = DateTime.Now;
        //        model_PayLog.EndTime = model_PayLog.AddTime.Value.AddHours(+2);

        //        new BLL.RepairPayLogInfo().DeleteList("PayNo='" + out_trade_no + "' ");

        //        new BLL.RepairPayLogInfo().Add(model_PayLog, out paylogid);
        //        #endregion

        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelp.AddErrLog("统一下单接口异常", true, ex.Message);
        //        return string.Empty;
        //    }
        //    return prepay_id;
        //}

        ///// <summary>
        ///// 报修统一下单（微信）
        ///// </summary>
        ///// <param name="inputObj"></param>
        ///// <param name="out_order_no">订单号</param>
        /////  <param name="userId">用户ID</param>
        ///// <param name="useType">用途：0-上门费；1-服务费；8-售后-维修费；</param>
        ///// <returns>prepay_id(返回微信订单号，若为空表示失败!)</returns>
        //public static WxPayData UnifiedRepairOrder(WxPayData inputObj, string out_order_no, int userId, int useType, out int id)
        //{
        //    id = 0;
        //    WxPayData result = new WxPayData();
        //    //string prepay_id = string.Empty;
        //    try
        //    {
        //        #region 验证接口参数有效性
        //        if (inputObj == null)
        //            throw new Exception("统一支付接口参数不能为空！");
        //        //if (inputObj.GetValue("appid") == null || string.IsNullOrEmpty(inputObj.GetValue("appid").ToString()))
        //        inputObj.SetValue("appid", ConfigHelper.GetConfigString("AppId"));//公众账号ID
        //        //if (inputObj.GetValue("mch_id") == null || string.IsNullOrEmpty(inputObj.GetValue("mch_id").ToString()))
        //        inputObj.SetValue("mch_id", ConfigHelper.GetConfigString("Mch_ID"));//商户号
        //        inputObj.SetValue("nonce_str", GenerateNonceStr()); //随机字符串
        //        inputObj.SetValue("spbill_create_ip", GetAddressIP());//APP和网页支付提交用户端ip	 
        //        //inputObj.SetValue("trade_type", "JSAPI");//JSAPI 取值如下：JSAPI，NATIVE，APP，WAP
        //        if (!inputObj.IsSet("notify_url"))
        //            inputObj.SetValue("notify_url", ConfigHelper.GetConfigString("Notify_URL"));//异步通知url
        //        string out_trade_no = inputObj.GetValue("out_trade_no").ToString();
        //        //inputObj.SetValue("out_trade_no", out_trade_no);
        //        string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";//统一下单接口url
        //        //检测必填参数
        //        if (!inputObj.IsSet("out_trade_no"))
        //            throw new Exception("缺少统一支付接口必填参数out_trade_no！");
        //        else if (!inputObj.IsSet("body"))
        //            throw new Exception("缺少统一支付接口必填参数body！");
        //        else if (!inputObj.IsSet("total_fee"))
        //            throw new Exception("缺少统一支付接口必填参数total_fee！");
        //        else if (!inputObj.IsSet("trade_type"))
        //            throw new Exception("缺少统一支付接口必填参数trade_type！");
        //        //关联参数
        //        if (inputObj.GetValue("trade_type").ToString() == "JSAPI" && !inputObj.IsSet("openid"))
        //            throw new Exception("统一支付接口中，缺少必填参数openid！");
        //        if (inputObj.GetValue("trade_type").ToString() == "NATIVE" && !inputObj.IsSet("product_id"))
        //            throw new Exception("统一支付接口中，缺少必填参数product_id！");
        //        inputObj.SetValue("sign", inputObj.MakeSign());//签名
        //        #endregion
        //        // 将接口参数转换为XML
        //        string xml = inputObj.ToXml();
        //        // 接口调用开始时间
        //        var start = DateTime.Now;
        //        // 调用统一下单接口
        //        string response = HttpService.Post(xml, url, false, 100);

        //        // 接口调用结束时间
        //        var end = DateTime.Now;
        //        // 计算接口调用所用时间差
        //        int timeCost = (int)((end - start).TotalMilliseconds);
        //        // 读取统一下单接口返回数据
        //        result.FromXml(response);
        //        // 判断调用统一下单接口通讯是否成功
        //        if (result.GetValue("return_code").ToString() != "SUCCESS")
        //            throw new Exception("调用统一下单接口失败！(" + result.GetValue("return_msg") + ")");
        //        // 判断调用统一下单接口返回是否成功
        //        if (result.GetValue("result_code").ToString() != "SUCCESS")
        //            throw new Exception("调用统一下单接口数据返回失败！(" + result.GetValue("err_code_des") + ")");
        //        // 判断是否成功返回微信订单号
        //        if (!result.IsSet("prepay_id"))
        //            throw new Exception("调用统一下单接口返回微信订单号失败！");
        //        // 微信订单号
        //        //prepay_id = result.GetValue("prepay_id").ToString();
        //        //Log.Debug("统一下单(fun:UnifiedOrder)", "调用统一下单接口成功!返回结果：" + result.ToJson());
        //        //LogHelp.AddErrLog("统一下单(fun:UnifiedOrder)1", false, "调用统一下单接口成功!返回结果：" + result.ToJson());
        //        #region 插入支付日志
        //        Model.RepairPayLogInfo model_PayLog = new Model.RepairPayLogInfo();
        //        model_PayLog.PayPrice = Convert.ToDecimal(inputObj.GetValue("total_fee")) / 100;
        //        model_PayLog.OrderNo = out_order_no;
        //        model_PayLog.PayNo = out_trade_no;
        //        model_PayLog.BankNo = result.GetValue("prepay_id").ToString();
        //        model_PayLog.PayType = 0;// 微信支付
        //        model_PayLog.Status = 0;// 未支付
        //        model_PayLog.UserID = userId;
        //        model_PayLog.ClientType = 0;
        //        model_PayLog.UseType = useType;
        //        model_PayLog.AccountType = 0;
        //        if (inputObj.GetValue("trade_type").ToString() == "NATIVE")
        //            model_PayLog.Messages = result.GetValue("code_url").ToString();
        //        else
        //            model_PayLog.Messages = "下单成功";
        //        model_PayLog.AddTime = DateTime.Now;
        //        model_PayLog.EndTime = model_PayLog.AddTime.Value.AddHours(+2);
        //        new BLL.RepairPayLogInfo().DeleteList("PayNo='" + inputObj.GetValue("out_trade_no").ToString() + "'");
        //        new BLL.RepairPayLogInfo().Add(model_PayLog, out id);
        //        #endregion
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelp.AddErrLog("统一下单(fun:UnifiedRepairOrder)", true, "调用统一下单接口失败!错误原因：" + ex.Message);
        //        return null;
        //    }
        //    return result;
        //}
        //#endregion

        //#region 统一下单接口
        ///// <summary>
        ///// 统一下单
        ///// </summary>
        ///// <param name="inputObj"></param>
        ///// <param name="timeOut"></param>
        ///// <returns>prepay_id(返回微信订单号，若为空表示失败!)</returns>
        //public static WxPayData UnifiedOrder(WxPayData inputObj, out int id, int timeOut = 6, int userId = 0, int userType = 0, bool isRecharge = false)
        //{
        //    id = 0;
        //    WxPayData result = new WxPayData();
        //    //string prepay_id = string.Empty;
        //    try
        //    {
        //        #region 验证接口参数有效性
        //        if (inputObj == null)
        //            throw new Exception("统一支付接口参数不能为空！");
        //        if (inputObj.GetValue("appid") == null || string.IsNullOrEmpty(inputObj.GetValue("appid").ToString()))
        //            inputObj.SetValue("appid", ConfigHelper.GetConfigString("AppId"));//公众账号ID
        //        if (inputObj.GetValue("mch_id") == null || string.IsNullOrEmpty(inputObj.GetValue("mch_id").ToString()))
        //            inputObj.SetValue("mch_id", ConfigHelper.GetConfigString("Mch_ID"));//商户号
        //        inputObj.SetValue("nonce_str", GenerateNonceStr()); ;//随机字符串
        //        inputObj.SetValue("spbill_create_ip", GetAddressIP());//APP和网页支付提交用户端ip	 
        //        //inputObj.SetValue("trade_type", "JSAPI");//JSAPI 取值如下：JSAPI，NATIVE，APP，WAP

        //        if (!inputObj.IsSet("notify_url"))
        //            inputObj.SetValue("notify_url", ConfigHelper.GetConfigString("Notify_URL"));//异步通知url

        //        string out_trade_no = inputObj.GetValue("out_trade_no").ToString();
        //        //inputObj.SetValue("out_trade_no", out_trade_no);

        //        string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";//统一下单接口url

        //        //检测必填参数
        //        if (!inputObj.IsSet("out_trade_no"))
        //            throw new Exception("缺少统一支付接口必填参数out_trade_no！");
        //        else if (!inputObj.IsSet("body"))
        //            throw new Exception("缺少统一支付接口必填参数body！");
        //        else if (!inputObj.IsSet("total_fee"))
        //            throw new Exception("缺少统一支付接口必填参数total_fee！");
        //        else if (!inputObj.IsSet("trade_type"))
        //            throw new Exception("缺少统一支付接口必填参数trade_type！");

        //        //关联参数
        //        if (inputObj.GetValue("trade_type").ToString() == "JSAPI" && !inputObj.IsSet("openid"))
        //            throw new Exception("统一支付接口中，缺少必填参数openid！");
        //        if (inputObj.GetValue("trade_type").ToString() == "NATIVE" && !inputObj.IsSet("product_id"))
        //            throw new Exception("统一支付接口中，缺少必填参数product_id！");
        //        inputObj.SetValue("sign", inputObj.MakeSign());//签名
        //        #endregion



        //        // 将接口参数转换为XML
        //        string xml = inputObj.ToXml();
        //        // 接口调用开始时间
        //        var start = DateTime.Now;
        //        // 调用统一下单接口
        //        string response = HttpService.Post(xml, url, false, 100);
        //        // 接口调用结束时间
        //        var end = DateTime.Now;
        //        // 计算接口调用所用时间差
        //        int timeCost = (int)((end - start).TotalMilliseconds);
        //        // 读取统一下单接口返回数据

        //        result.FromXml(response);
        //        // 判断调用统一下单接口通讯是否成功
        //        if (result.GetValue("return_code").ToString() != "SUCCESS")
        //            throw new Exception("调用统一下单接口失败！(" + result.GetValue("return_msg") + ")");
        //        // 判断调用统一下单接口返回是否成功
        //        if (result.GetValue("result_code").ToString() != "SUCCESS")
        //            throw new Exception("调用统一下单接口数据返回失败！(" + result.GetValue("err_code_des") + ")");
        //        // 判断是否成功返回微信订单号
        //        if (!result.IsSet("prepay_id"))
        //            throw new Exception("调用统一下单接口返回微信订单号失败！");
        //        // 微信订单号
        //        //prepay_id = result.GetValue("prepay_id").ToString();

        //        //Log.Debug("统一下单(fun:UnifiedOrder)", "调用统一下单接口成功!返回结果：" + result.ToJson());
        //        //LogHelp.AddErrLog("统一下单(fun:UnifiedOrder)1", false, "调用统一下单接口成功!返回结果：" + result.ToJson());

        //        #region 插入支付日志
        //        Model.PayLog model_PayLog = new Model.PayLog();
        //        model_PayLog.PayPrice = Convert.ToDecimal(inputObj.GetValue("total_fee")) / 100;
        //        model_PayLog.PayNo = out_trade_no;
        //        model_PayLog.BankNo = result.GetValue("prepay_id").ToString();
        //        model_PayLog.SystemOrderNo = "";
        //        model_PayLog.PayType = 0;// 微信支付
        //        model_PayLog.Status = 0;// 未支付
        //        model_PayLog.UserID = userId;
        //        model_PayLog.IsRecharge = isRecharge;
        //        model_PayLog.ClientType = 0;
        //        if (inputObj.GetValue("trade_type").ToString() == "NATIVE")
        //            model_PayLog.Messages = result.GetValue("code_url").ToString();
        //        else
        //            model_PayLog.Messages = "下单成功";
        //        model_PayLog.AddTime = DateTime.Now;
        //        model_PayLog.EndTime = model_PayLog.AddTime.Value.AddHours(+2);

        //        new BLL.PayLog().DeleteList("PayNo='" + inputObj.GetValue("out_trade_no").ToString() + "'");

        //        new BLL.PayLog().Add(model_PayLog, out id);

        //        #endregion
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelp.AddErrLog("统一下单(fun:UnifiedOrder)", true, "调用统一下单接口失败!错误原因：" + ex.Message);
        //        return null;
        //    }
        //    return result;
        //}
        //#endregion

        //#region 统一下单接口（升级）
        ///// <summary>
        ///// 统一下单接口
        ///// </summary>
        ///// <param name="body">商品简要描述</param>
        ///// <param name="out_trade_no">商户订单号</param>
        ///// <param name="trade_type">支付类型(JSAPI，NATIVE，APP，WAP)</param>
        ///// <param name="total_fee">支付金额(分)</param>
        ///// <param name="openid">支付微信账号的openid</param>
        ///// <param name="paylogid">返回下单记录的ID</param>
        ///// <param name="userId">支付账号id</param>
        ///// <param name="userType">支付账号类型(0经销商1工程师2用户)</param>
        ///// <param name="isRecharge">是否充值(true,false)</param>
        ///// <param name="ordertype">订单类型：0-系统订单；1-延保订单</param>
        ///// <returns></returns>
        //public static string AppUnifiedOrder(string appidstr, string body, string systemorderno, string trade_type, long total_fee, string openid, out int paylogid, long userId = 0, int userType = 0, bool isRecharge = false, int ordertype = 0)
        //{
        //    string prepay_id = string.Empty;
        //    paylogid = 0;//下单日志ID
        //    try
        //    {

        //        #region 验证接口参数有效性
        //        //验证调用传入参数
        //        if (string.IsNullOrEmpty(appidstr) ||
        //            string.IsNullOrEmpty(body) ||
        //            string.IsNullOrEmpty(systemorderno) ||
        //            string.IsNullOrEmpty(trade_type) ||
        //            total_fee <= 0)
        //        {
        //            return string.Empty;
        //        }
        //        string out_trade_no = systemorderno;//+ DateTime.Now.ToString("yyyyMMdd");// 支付订单号
        //        //验证配置参数
        //        string appid = appidstr;
        //        string mch_id = ConfigHelper.GetConfigString("Mch_ID");
        //        string nonce_str = GenerateNonceStr();
        //        string notify_url = ConfigHelper.GetConfigString("Notify_URL");
        //        string spbill_create_ip = GetAddressIP();
        //        if (string.IsNullOrEmpty(appid) ||
        //            string.IsNullOrEmpty(mch_id) ||
        //            string.IsNullOrEmpty(nonce_str) ||
        //            string.IsNullOrEmpty(notify_url))
        //        {
        //            return string.Empty;
        //        }
        //        string product_id = string.Empty;
        //        ////关联参数
        //        //if (trade_type == "JSAPI" && string.IsNullOrEmpty(openid))
        //        //    return string.Empty;
        //        //if (trade_type == "NATIVE" && !string.IsNullOrEmpty(product_id))
        //        //    return string.Empty;
        //        #endregion
        //        // 设置请求接口参数
        //        WxPayData inputObj = new WxPayData();
        //        inputObj.SetValue("appid", appid);//公众账号ID
        //        inputObj.SetValue("mch_id", mch_id);//商户号
        //        inputObj.SetValue("nonce_str", nonce_str); ;//随机字符串
        //        inputObj.SetValue("spbill_create_ip", spbill_create_ip);//APP和网页支付提交用户端ip	 
        //        inputObj.SetValue("notify_url", notify_url);//异步通知url
        //        inputObj.SetValue("body", body);//简要描述
        //        inputObj.SetValue("out_trade_no", out_trade_no);//订单号
        //        inputObj.SetValue("trade_type", trade_type);//JSAPI 取值如下：JSAPI，NATIVE，APP，WAP
        //        inputObj.SetValue("total_fee", total_fee.ToString());//订单金额
        //        //inputObj.SetValue("openid", openid);
        //        inputObj.SetValue("sign", inputObj.MakeSign());//签名

        //        //统一下单接口url
        //        string apiurl = "https://api.mch.weixin.qq.com/pay/unifiedorder";
        //        // 将接口参数转换为XML
        //        string xml = inputObj.ToXml();
        //        // 接口调用开始时间
        //        var start = DateTime.Now;
        //        // 调用统一下单接口
        //        string response = HttpService.Post(xml, apiurl, false, 100);
        //        // 接口调用结束时间
        //        var end = DateTime.Now;
        //        // 计算接口调用所用时间差
        //        int timeCost = (int)((end - start).TotalMilliseconds);

        //        // 读取统一下单接口返回数据
        //        WxPayData result = new WxPayData();
        //        result.FromXml(response);
        //        // 判断调用统一下单接口通讯是否成功
        //        if (result.GetValue("return_code").ToString() != "SUCCESS")
        //        {
        //            LogHelp.AddErrLog("统一下单(" + out_trade_no + ")通讯失败", false, result.GetValue("return_msg").ToString());
        //            return string.Empty;
        //        }
        //        // 判断调用统一下单接口返回是否成功
        //        if (result.GetValue("result_code").ToString() != "SUCCESS")
        //        {
        //            LogHelp.AddErrLog("统一下单(" + out_trade_no + ")返回失败", false, result.GetValue("err_code_des").ToString());
        //            return string.Empty;
        //        }
        //        // 判断是否成功返回微信订单号
        //        if (!result.IsSet("prepay_id"))
        //        {
        //            LogHelp.AddErrLog("统一下单(" + out_trade_no + ")返回prepay_id失败", false, "");
        //            return string.Empty;
        //        }

        //        prepay_id = result.GetValue("prepay_id").ToString();

        //        #region 插入下单日志
        //        Model.PayLog model_PayLog = new Model.PayLog();
        //        model_PayLog.PayPrice = Convert.ToDecimal((double)total_fee / 100);
        //        model_PayLog.PayNo = out_trade_no;
        //        model_PayLog.BankNo = prepay_id;
        //        model_PayLog.SystemOrderNo = systemorderno;
        //        model_PayLog.ClientType = 1;
        //        model_PayLog.PayType = 0;// 微信支付
        //        model_PayLog.Status = 0;// 未支付
        //        model_PayLog.UserID = userId;
        //        //model_PayLog.UserType = userType;
        //        model_PayLog.IsRecharge = isRecharge;
        //        //model_PayLog.OrderType = ordertype;
        //        if (trade_type == "NATIVE")
        //        {
        //            if (result.IsSet("code_url"))
        //                model_PayLog.Messages = result.GetValue("code_url").ToString();
        //            else
        //                model_PayLog.Messages = string.Empty;
        //        }
        //        else
        //        { model_PayLog.Messages = body; }
        //        model_PayLog.AddTime = DateTime.Now;
        //        model_PayLog.EndTime = model_PayLog.AddTime.Value.AddHours(+2);

        //        new BLL.PayLog().DeleteList("PayNo='" + out_trade_no + "' ");

        //        new BLL.PayLog().Add(model_PayLog, out paylogid);
        //        #endregion

        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelp.AddErrLog("统一下单接口异常", true, ex.Message);
        //        return string.Empty;
        //    }
        //    return prepay_id;
        //}
        //public static string AppUnifiedSafeOrder(string appidstr, string body, string systemorderno, string trade_type, long total_fee, string notify_url, string openid, out int paylogid, long userId = 0, int userType = 0, bool isRecharge = false, int ordertype = 0)
        //{
        //    string prepay_id = string.Empty;
        //    paylogid = 0;//下单日志ID
        //    try
        //    {

        //        #region 验证接口参数有效性
        //        //验证调用传入参数
        //        if (string.IsNullOrEmpty(appidstr) ||
        //            string.IsNullOrEmpty(body) ||
        //            string.IsNullOrEmpty(systemorderno) ||
        //            string.IsNullOrEmpty(trade_type) ||
        //            total_fee <= 0)
        //        {
        //            return string.Empty;
        //        }
        //        string out_trade_no = systemorderno;// 支付订单号
        //        //验证配置参数
        //        string appid = appidstr;
        //        string mch_id = ConfigHelper.GetConfigString("Mch_ID");
        //        string nonce_str = GenerateNonceStr();
        //        //string notify_url = ConfigHelper.Instance.Notify_URL;
        //        string spbill_create_ip = GetAddressIP();
        //        if (string.IsNullOrEmpty(appid) ||
        //            string.IsNullOrEmpty(mch_id) ||
        //            string.IsNullOrEmpty(nonce_str) ||
        //            string.IsNullOrEmpty(notify_url))
        //        {
        //            return string.Empty;
        //        }
        //        string product_id = string.Empty;
        //        #endregion
        //        // 设置请求接口参数
        //        WxPayData inputObj = new WxPayData();
        //        inputObj.SetValue("appid", appid);//公众账号ID
        //        inputObj.SetValue("mch_id", mch_id);//商户号
        //        inputObj.SetValue("nonce_str", nonce_str); ;//随机字符串
        //        inputObj.SetValue("spbill_create_ip", spbill_create_ip);//APP和网页支付提交用户端ip	 
        //        inputObj.SetValue("notify_url", notify_url);//异步通知url
        //        inputObj.SetValue("body", body);//简要描述
        //        inputObj.SetValue("out_trade_no", out_trade_no);//订单号
        //        inputObj.SetValue("trade_type", trade_type);//JSAPI 取值如下：JSAPI，NATIVE，APP，WAP
        //        inputObj.SetValue("total_fee", total_fee.ToString());//订单金额
        //        inputObj.SetValue("sign", inputObj.MakeSign());//签名

        //        //统一下单接口url
        //        string apiurl = "https://api.mch.weixin.qq.com/pay/unifiedorder";
        //        // 将接口参数转换为XML
        //        string xml = inputObj.ToXml();
        //        // 接口调用开始时间
        //        var start = DateTime.Now;
        //        // 调用统一下单接口
        //        string response = HttpService.Post(xml, apiurl, false, 100);
        //        // 接口调用结束时间
        //        var end = DateTime.Now;
        //        // 计算接口调用所用时间差
        //        int timeCost = (int)((end - start).TotalMilliseconds);

        //        // 读取统一下单接口返回数据
        //        WxPayData result = new WxPayData();
        //        result.FromXml(response);
        //        // 判断调用统一下单接口通讯是否成功
        //        if (result.GetValue("return_code").ToString() != "SUCCESS")
        //        {
        //            LogHelp.AddErrLog("统一下单(" + out_trade_no + ")通讯失败", false, result.GetValue("return_msg").ToString());
        //            return string.Empty;
        //        }
        //        // 判断调用统一下单接口返回是否成功
        //        if (result.GetValue("result_code").ToString() != "SUCCESS")
        //        {
        //            LogHelp.AddErrLog("统一下单(" + out_trade_no + ")返回失败", false, result.GetValue("err_code_des").ToString());
        //            return string.Empty;
        //        }
        //        // 判断是否成功返回微信订单号
        //        if (!result.IsSet("prepay_id"))
        //        {
        //            LogHelp.AddErrLog("统一下单(" + out_trade_no + ")返回prepay_id失败", false, "");
        //            return string.Empty;
        //        }

        //        prepay_id = result.GetValue("prepay_id").ToString();

        //        #region 插入下单日志
        //        Model.PayLog model_PayLog = new Model.PayLog();
        //        model_PayLog.PayPrice = Convert.ToDecimal((double)total_fee / 100);
        //        model_PayLog.PayNo = out_trade_no;
        //        model_PayLog.BankNo = prepay_id;
        //        model_PayLog.SystemOrderNo = systemorderno;
        //        model_PayLog.ClientType = 1;
        //        model_PayLog.PayType = 0;// 微信支付
        //        model_PayLog.Status = 0;// 未支付
        //        model_PayLog.UserID = userId;
        //        //model_PayLog.UserType = userType;
        //        model_PayLog.IsRecharge = isRecharge;
        //        //model_PayLog.OrderType = ordertype;
        //        if (trade_type == "NATIVE")
        //        {
        //            if (result.IsSet("code_url"))
        //                model_PayLog.Messages = result.GetValue("code_url").ToString();
        //            else
        //                model_PayLog.Messages = string.Empty;
        //        }
        //        else
        //        { model_PayLog.Messages = "统一下单成功"; }
        //        model_PayLog.AddTime = DateTime.Now;
        //        model_PayLog.EndTime = model_PayLog.AddTime.Value.AddHours(+2);

        //        new BLL.PayLog().DeleteList("PayNo='" + out_trade_no + "' AND OrderType=" + ordertype);

        //        new BLL.PayLog().Add(model_PayLog, out paylogid);
        //        #endregion

        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelp.AddErrLog("统一下单接口异常", true, ex.Message);
        //        return string.Empty;
        //    }
        //    return prepay_id;
        //}
        //#endregion

        //#region 生成调起jsapi支付参数
        ///// <summary>
        ///// 从统一下单成功返回的数据中获取微信浏览器调起jsapi支付所需的参数，
        ///// </summary>
        ///// <param name="prepay_id"></param>
        ///// <returns>parameters(返回支付参数json字符串，为空则为失败)</returns>
        //public static string GetJsApiParameters(Object prepay_id)
        //{
        //    string parameters = string.Empty;
        //    try
        //    {
        //        if (prepay_id == null)
        //            throw new Exception("微信订单号参数为空!");
        //        // 生成支付参数
        //        WxPayData jsApiParam = new WxPayData();
        //        jsApiParam.SetValue("appId", ConfigHelper.GetConfigString("AppId"));
        //        jsApiParam.SetValue("timeStamp", GenerateTimeStamp());
        //        jsApiParam.SetValue("nonceStr", GenerateNonceStr());
        //        jsApiParam.SetValue("package", "prepay_id=" + prepay_id.ToString());
        //        jsApiParam.SetValue("signType", "MD5");
        //        jsApiParam.SetValue("paySign", jsApiParam.MakeSign());

        //        parameters = jsApiParam.ToJson();

        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelp.AddErrLog("统一下单(fun:GetJsApiParameters)", false, "生成调用JSAPI支付参数失败！错误原因：" + ex.Message);
        //    }
        //    return parameters;
        //}
        //#endregion

        //#region 支付结果通知参数读取
        ///// <summary>
        ///// 接收从微信支付后台发送过来的数据并验证签名
        ///// </summary>
        ///// <returns>微信支付后台返回的数据</returns>
        //public static WxPayData GetNotifyData(System.Web.UI.Page page)
        //{
        //    //接收从微信后台POST过来的数据
        //    System.IO.Stream s = page.Request.InputStream;
        //    int count = 0;
        //    byte[] buffer = new byte[1024];
        //    StringBuilder builder = new StringBuilder();
        //    while ((count = s.Read(buffer, 0, 1024)) > 0)
        //    {
        //        builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
        //    }
        //    LogHelp.AddErrLog("微信支付回调开始", false, "微信返回:" + builder.ToString());
        //    s.Flush();
        //    s.Close();
        //    s.Dispose();
        //    //转换数据格式并验证签名
        //    WxPayData data = new WxPayData();
        //    try
        //    {
        //        data.FromXml(builder.ToString());
        //        if (!data.IsSet("transaction_id") && !data.IsSet("out_trade_no"))
        //            throw new Exception("支付结果中缺少transaction_id或out_trade_no！");
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelp.AddErrLog("统一支付回调(fun:GetNotifyData)", false, "接收微信支付结果通知失败！错误原因:" + ex.Message);
        //        //若签名错误，则立即返回结果给微信支付后台
        //        WxPayData res = new WxPayData();
        //        res.SetValue("return_code", "FAIL");
        //        res.SetValue("return_msg", ex.Message);
        //        page.Response.Write(res.ToXml());
        //        page.Response.End();
        //    }
        //    return data;
        //}
        //#endregion

        //#region 查询支付结果
        ///// <summary>
        ///// 查询支付结果
        ///// </summary>
        ///// <param name="inputObj"></param>
        ///// <returns>WxPayData</returns>
        //public static WxPayData OrderQuery(WxPayData inputObj)
        //{
        //    WxPayData returnResult = new WxPayData();
        //    try
        //    {
        //        #region 接口参数校验
        //        if (inputObj == null)
        //            throw new Exception("订单查询结果参数不能为空!");
        //        if (!inputObj.IsSet("transaction_id") && !inputObj.IsSet("out_trade_no"))
        //            throw new Exception("订单查询接口中，缺少必填参数transaction_id或out_trade_no！");

        //        inputObj.SetValue("appid", ConfigHelper.GetConfigString("AppId"));//公众账号ID
        //        inputObj.SetValue("mch_id", ConfigHelper.GetConfigString("Mch_ID"));//商户号
        //        inputObj.SetValue("nonce_str", GenerateNonceStr()); ;//随机字符串
        //        inputObj.SetValue("sign", inputObj.MakeSign());//签名
        //        #endregion
        //        string url = "https://api.mch.weixin.qq.com/pay/orderquery";//订单查询接口
        //        string xml = inputObj.ToXml();
        //        var start = DateTime.Now;
        //        // 执行查询方法
        //        string response = HttpService.Post(xml, url, false, 100);
        //        var end = DateTime.Now;
        //        int timeCost = (int)((end - start).TotalMilliseconds);
        //        WxPayData result = new WxPayData();
        //        result.FromXml(response);

        //        // 判断调用订单查询接口通讯是否成功
        //        if (result.GetValue("return_code").ToString() != "SUCCESS")
        //            throw new Exception("调用订单查询接口失败！(" + result.GetValue("return_msg") + ")");
        //        // 判断调用订单查询接口返回是否成功
        //        if (result.GetValue("result_code").ToString() != "SUCCESS")
        //            throw new Exception("调用订单查询接口数据返回失败！(" + result.GetValue("err_code_des") + ")");

        //        // 判断所查询订单的支付状态
        //        if (!result.IsSet("trade_state"))
        //            throw new Exception("调用订单查询接口返回支付状态失败！");

        //        // 查询结果
        //        returnResult.SetValue("return_code", result.GetValue("trade_state").ToString());
        //        returnResult.SetValue("return_msg", result.GetValue("trade_state_desc"));
        //        if (result.IsSet("out_trade_no"))
        //            returnResult.SetValue("out_trade_no", result.GetValue("out_trade_no").ToString());

        //        //LogHelp.AddErrLog("订单查询(fun:OrderQuery)", false,"调用订单查询接口成功!返回结果：" + returnResult.ToJson());
        //    }
        //    catch (Exception ex)
        //    {
        //        returnResult.SetValue("return_code", "FAIL");
        //        returnResult.SetValue("return_msg", ex.Message);
        //        LogHelp.AddErrLog("订单查询(fun:OrderQuery)", false, "调用订单查询接口失败!错误原因：" + ex.Message);
        //    }
        //    return returnResult;
        //}
        //public static WxPayData AppOrderQuery(WxPayData inputObj)
        //{
        //    WxPayData returnResult = new WxPayData();
        //    try
        //    {
        //        #region 接口参数校验
        //        if (inputObj == null)
        //            throw new Exception("订单查询结果参数不能为空!");
        //        if (!inputObj.IsSet("transaction_id") && !inputObj.IsSet("out_trade_no"))
        //            throw new Exception("订单查询接口中，缺少必填参数transaction_id或out_trade_no！");
        //        inputObj.SetValue("appid", ConfigHelper.GetConfigString("AppAppId"));//公众账号ID
        //        inputObj.SetValue("mch_id", ConfigHelper.GetConfigString("AppMch_ID"));//商户号
        //        inputObj.SetValue("nonce_str", GenerateNonceStr()); ;//随机字符串
        //        inputObj.SetValue("sign", inputObj.MakeSign());//签名
        //        #endregion
        //        string url = "https://api.mch.weixin.qq.com/pay/orderquery";//订单查询接口
        //        string xml = inputObj.ToXml();
        //        var start = DateTime.Now;
        //        // 执行查询方法
        //        string response = HttpService.Post(xml, url, false, 100);
        //        var end = DateTime.Now;
        //        int timeCost = (int)((end - start).TotalMilliseconds);
        //        WxPayData result = new WxPayData();
        //        result.FromXml(response);

        //        // 判断调用订单查询接口通讯是否成功
        //        if (result.GetValue("return_code").ToString() != "SUCCESS")
        //            throw new Exception("调用订单查询接口失败！(" + result.GetValue("return_msg") + ")");
        //        // 判断调用订单查询接口返回是否成功
        //        if (result.GetValue("result_code").ToString() != "SUCCESS")
        //            throw new Exception("调用订单查询接口数据返回失败！(" + result.GetValue("err_code_des") + ")");

        //        // 判断所查询订单的支付状态
        //        if (!result.IsSet("trade_state"))
        //            throw new Exception("调用订单查询接口返回支付状态失败！");

        //        // 查询结果
        //        returnResult.SetValue("return_code", result.GetValue("trade_state").ToString());
        //        returnResult.SetValue("return_msg", result.GetValue("trade_state_desc"));
        //        if (result.IsSet("out_trade_no"))
        //            returnResult.SetValue("out_trade_no", result.GetValue("out_trade_no").ToString());

        //        //LogHelp.AddErrLog("订单查询(fun:OrderQuery)", false,"调用订单查询接口成功!返回结果：" + returnResult.ToJson());
        //    }
        //    catch (Exception ex)
        //    {
        //        returnResult.SetValue("return_code", "FAIL");
        //        returnResult.SetValue("return_msg", ex.Message);
        //        LogHelp.AddErrLog("订单查询(fun:APPOrderQuery)", false, "调用订单查询接口失败!错误原因：" + ex.Source + "|" + ex.Message);
        //    }
        //    return returnResult;
        //}

        //public static WxPayData AppOrderQuery(WxPayData inputObj, string appid, string mch_id)
        //{
        //    WxPayData returnResult = new WxPayData();
        //    try
        //    {
        //        #region 接口参数校验
        //        if (inputObj == null)
        //            throw new Exception("订单查询结果参数不能为空!");
        //        if (!inputObj.IsSet("transaction_id") && !inputObj.IsSet("out_trade_no"))
        //            throw new Exception("订单查询接口中，缺少必填参数transaction_id或out_trade_no！");
        //        inputObj.SetValue("appid", appid);//公众账号ID
        //        inputObj.SetValue("mch_id", mch_id);//商户号
        //        inputObj.SetValue("nonce_str", GenerateNonceStr()); ;//随机字符串
        //        inputObj.SetValue("sign", inputObj.MakeSign());//签名
        //        #endregion
        //        string url = "https://api.mch.weixin.qq.com/pay/orderquery";//订单查询接口
        //        string xml = inputObj.ToXml();
        //        var start = DateTime.Now;
        //        // 执行查询方法
        //        string response = HttpService.Post(xml, url, false, 100);
        //        var end = DateTime.Now;
        //        int timeCost = (int)((end - start).TotalMilliseconds);
        //        WxPayData result = new WxPayData();
        //        result.FromXml(response);

        //        // 判断调用订单查询接口通讯是否成功
        //        if (result.GetValue("return_code").ToString() != "SUCCESS")
        //            throw new Exception("调用订单查询接口失败！(" + result.GetValue("return_msg") + ")");
        //        // 判断调用订单查询接口返回是否成功
        //        if (result.GetValue("result_code").ToString() != "SUCCESS")
        //            throw new Exception("调用订单查询接口数据返回失败！(" + result.GetValue("err_code_des") + ")");

        //        // 判断所查询订单的支付状态
        //        if (!result.IsSet("trade_state"))
        //            throw new Exception("调用订单查询接口返回支付状态失败！");

        //        // 查询结果
        //        returnResult.SetValue("return_code", result.GetValue("trade_state").ToString());
        //        returnResult.SetValue("return_msg", result.GetValue("trade_state_desc"));
        //        if (result.IsSet("out_trade_no"))
        //            returnResult.SetValue("out_trade_no", result.GetValue("out_trade_no").ToString());

        //        //LogHelp.AddErrLog("订单查询(fun:OrderQuery)", false,"调用订单查询接口成功!返回结果：" + returnResult.ToJson());
        //    }
        //    catch (Exception ex)
        //    {
        //        returnResult.SetValue("return_code", "FAIL");
        //        returnResult.SetValue("return_msg", ex.Message);
        //        LogHelp.AddErrLog("订单查询(fun:APPOrderQuery)", false, "调用订单查询接口失败!错误原因：" + ex.Source + "|" + ex.Message);
        //    }
        //    return returnResult;
        //}
        //#endregion

        //#region 申请退款接口
        ///// <summary>
        ///// 申请退款
        ///// </summary>
        ///// <param name="inputObj"></param>
        ///// <param name="timeOut"></param>
        ///// <returns>refund_id(退款单号)</returns>
        //public static string Refund(WxPayData inputObj, int timeOut = 6)
        //{
        //    string refund_id = string.Empty;
        //    try
        //    {
        //        #region 退款接口参数校验
        //        if (inputObj == null)
        //        {
        //            //LogHelp.AddErrLog("退款接口参数不能为空", false, "退款接口参数不能为空");
        //            return "";
        //        }
        //        inputObj.SetValue("appid", ConfigHelper.GetConfigString("AppId"));//公众账号ID

        //        inputObj.SetValue("mch_id", ConfigHelper.GetConfigString("Mch_ID"));//商户号

        //        inputObj.SetValue("nonce_str", GenerateNonceStr()); ;//随机字符串

        //        inputObj.SetValue("op_user_id", ConfigHelper.GetConfigString("Mch_ID"));//操作员

        //        string url = "https://api.mch.weixin.qq.com/secapi/pay/refund";//退款接口url
        //        //检测必填参数
        //        if (!inputObj.IsSet("out_trade_no"))
        //        {
        //            LogHelp.AddErrLog("缺少退款接口必填参数out_trade_no", false, "缺少退款接口必填参数out_trade_no！");
        //            return "";
        //        }
        //        if (!inputObj.IsSet("out_refund_no"))
        //        {
        //            LogHelp.AddErrLog("缺少退款接口必填参数out_refund_no", false, "缺少退款接口必填参数out_refund_no！");
        //            return "";
        //        }

        //        if (!inputObj.IsSet("total_fee"))
        //        {
        //            LogHelp.AddErrLog("缺少退款接口必填参数total_fee", false, "缺少退款接口必填参数total_fee！");
        //            return "";
        //        }

        //        if (!inputObj.IsSet("refund_fee"))
        //        {
        //            LogHelp.AddErrLog("缺少退款接口必填参数refund_fee", false, "缺少退款接口必填参数refund_fee！");
        //            return "";
        //        }
        //        inputObj.SetValue("sign", inputObj.MakeSign());//签名

        //        #endregion

        //        string xml = inputObj.ToXml();

        //        var start = DateTime.Now;
        //        //LogHelp.AddErrLog("申请退款POST请求开始", false, "");
        //        string response = HttpService.Post(xml, url, true, 100);
        //        //LogHelp.AddErrLog("申请退款POST请求response", false, response);
        //        var end = DateTime.Now;
        //        int timeCost = (int)((end - start).TotalMilliseconds);
        //        WxPayData result = new WxPayData();
        //        result.FromXml(response);

        //        // 判断调用退款接口通讯是否成功
        //        if (result.GetValue("return_code").ToString() != "SUCCESS")
        //        {
        //            LogHelp.AddErrLog("调用退款接口失败", false, result.GetValue("return_msg").ToString());
        //            return "";
        //        }
        //        // 判断调用退款接口返回是否成功
        //        if (result.GetValue("result_code").ToString() != "SUCCESS")
        //        {
        //            LogHelp.AddErrLog("调用退款接口数据返回失败", false, result.GetValue("err_code_des").ToString());
        //            return "";
        //        }
        //        // 判断是否成功返回微信订单号
        //        if (!result.IsSet("refund_id"))
        //        {
        //            LogHelp.AddErrLog("调用退款接口返回微信退款单号失败", false, "");
        //            return "";
        //        }

        //        refund_id = result.GetValue("refund_id").ToString();
        //        //LogHelp.AddErrLog("退款申请:" + inputObj.GetValue("out_trade_no"), false, refund_id);
        //        //LogHelp.AddErrLog("申请退款(fun:Refund)", false, "调用退款接口成功!返回结果：" + result.ToJson());

        //        // 支付日志
        //        //#region 插入支付日志
        //        //BLL.PayLog bll_PayLog = new BLL.PayLog();
        //        //Model.PayLog model_PayLog = new Model.PayLog();
        //        //model_PayLog.PayPrice = Convert.ToDecimal(inputObj.GetValue("total_fee")) / 100;
        //        //model_PayLog.PayNo = inputObj.GetValue("out_trade_no").ToString();
        //        //model_PayLog.BankNo = result.GetValue("prepay_id").ToString();
        //        //model_PayLog.PayType = 0;// 微信支付
        //        //model_PayLog.Status = 0;// 未支付
        //        //model_PayLog.Messages = "";
        //        //model_PayLog.AddTime = DateTime.Now;
        //        //model_PayLog.EndTime = model_PayLog.AddTime.Value.AddHours(+2);
        //        //if (bll_PayLog.Add(model_PayLog) > 0)
        //        //    Log.Debug("PayLog", "支付日志：订单" + model_PayLog.PayNo + "统一下单成功,返回微信单号" + model_PayLog.BankNo);
        //        //#endregion
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelp.AddErrLog("申请退款(fun:Refund)", false, "调用退款接口失败!错误原因：" + ex.Message);
        //    }
        //    return refund_id;
        //}
        //#endregion

        //#region 查询退款接口
        ///// <summary>
        ///// 查询退款结果
        ///// </summary>
        ///// <param name="inputObj"></param>
        ///// <param name="timeOut"></param>
        ///// <returns></returns>
        //public static WxPayData RefundQuery(WxPayData inputObj, int timeOut = 6)
        //{
        //    WxPayData returnResult = new WxPayData();
        //    try
        //    {
        //        #region  参数校验
        //        if (inputObj == null)
        //            throw new Exception("退款结果查询接口参数不能为空！");
        //        inputObj.SetValue("appid", ConfigHelper.GetConfigString("AppId"));//公众账号ID
        //        inputObj.SetValue("mch_id", ConfigHelper.GetConfigString("Mch_ID"));//商户号
        //        inputObj.SetValue("nonce_str", GenerateNonceStr()); ;//随机字符串
        //        string url = "https://api.mch.weixin.qq.com/pay/refundquery";//退款接口url
        //        //检测必填参数
        //        if (!inputObj.IsSet("out_trade_no") && !inputObj.IsSet("transaction_id") && !inputObj.IsSet("out_refund_no") && !inputObj.IsSet("refund_id"))
        //            throw new Exception("缺少退款结果查询接口必填参数out_trade_no或transaction_id或out_refund_no或refund_id");
        //        inputObj.SetValue("sign", inputObj.MakeSign());//签名
        //        #endregion

        //        string xml = inputObj.ToXml();
        //        var start = DateTime.Now;
        //        string response = HttpService.Post(xml, url, false, 100);
        //        var end = DateTime.Now;
        //        int timeCost = (int)((end - start).TotalMilliseconds);
        //        WxPayData result = new WxPayData();
        //        result.FromXml(response);

        //        // 判断调用退款结果查询接口通讯是否成功
        //        if (result.GetValue("return_code").ToString() != "SUCCESS")
        //            throw new Exception("调用退款查询接口失败！(" + result.GetValue("return_msg") + ")");
        //        // 判断调用退款结果查询接口返回是否成功
        //        if (result.GetValue("result_code").ToString() != "SUCCESS")
        //            throw new Exception("调用退款查询接口数据返回失败！(" + result.GetValue("err_code_des") + ")");

        //        // 判断所查询订单的退款状态
        //        if (!result.IsSet("refund_status_0"))
        //            throw new Exception("调用订单查询接口返回支付状态失败！");

        //        // 查询结果
        //        returnResult.SetValue("return_code", result.GetValue("refund_status_0").ToString());
        //        returnResult.SetValue("return_msg", "");
        //        if (result.IsSet("out_trade_no"))
        //            returnResult.SetValue("out_trade_no", result.GetValue("out_trade_no").ToString());
        //        //LogHelp.AddErrLog("退款查询(fun:RefundQuery)", false, "调用退款查询接口成功!返回结果：" + returnResult.ToJson());
        //        //Log.Debug("退款查询(fun:RefundQuery)", "调用退款查询接口成功!返回结果：" + returnResult.ToJson());
        //    }
        //    catch (Exception ex)
        //    {
        //        returnResult.SetValue("return_code", "FAIL");
        //        returnResult.SetValue("return_msg", ex.Message);
        //        LogHelp.AddErrLog("订单查询(fun:RefundQuery)", false, "调用退款查询接口失败!错误原因：" + returnResult.ToJson());
        //        //Log.Debug("订单查询(fun:RefundQuery)", "调用退款查询接口失败!错误原因：" + ex.Message);
        //    }
        //    return returnResult;
        //}
        //#endregion

        //#region 关闭订单
        ///// <summary>
        ///// 关闭订单（适用于支付超时或者异常情况）
        ///// </summary>
        ///// <param name="inputObj"></param>
        ///// <param name="timeOut"></param>
        ///// <returns>""为删除成功,如果失败，则返回失败原因</returns>
        //public static bool CloseOrder(string out_trade_no, string appid, int ordertype)
        //{

        //    try
        //    {
        //        //验证调用传入参数
        //        if (string.IsNullOrEmpty(out_trade_no))
        //        {
        //            return false;
        //        }
        //        // 设置请求接口参数
        //        WxPayData inputObj = new WxPayData();

        //        if (inputObj == null)
        //            throw new Exception("关闭订单参数不能为空！");
        //        inputObj.SetValue("appid", appid);//公众账号ID
        //        inputObj.SetValue("mch_id", ConfigHelper.GetConfigString("Mch_ID"));//商户号
        //        inputObj.SetValue("out_trade_no", out_trade_no);
        //        //商户订单号
        //        inputObj.SetValue("nonce_str", GenerateNonceStr()); ;//随机字符串
        //        string url = "https://api.mch.weixin.qq.com/pay/closeorder ";//关闭订单接口url
        //        //检测必填参数
        //        if (!inputObj.IsSet("out_trade_no"))
        //            throw new Exception("缺少关闭订单接口必填参数out_trade_no！");
        //        inputObj.SetValue("sign", inputObj.MakeSign());//签名
        //        string xml = inputObj.ToXml();
        //        var start = DateTime.Now;
        //        WxPayData result = new WxPayData();
        //        LogHelp.AddErrLog("关闭订单(fun:CloseOrder)", false, "关闭订单失败！结果：" + inputObj.ToJson());

        //        string response = HttpService.Post(xml, url, false, 100);
        //        var end = DateTime.Now;
        //        int timeCost = (int)((end - start).TotalMilliseconds);
        //        result.FromXml(response);
        //        if (result.GetValue("return_code").ToString() == "SUCCESS")
        //        {
        //            LogHelp.AddErrLog("关闭订单(fun:CloseOrder)", false, "关闭订单成功！结果：" + result.ToJson());
        //            // 支付日志
        //            #region 删除支付日志
        //            BLL.PayLog bll_PayLog = new BLL.PayLog();
        //            bll_PayLog.DeleteList(string.Format("PayNo='{0}' and ordertype=" + ordertype, inputObj.GetValue("out_trade_no").ToString()));
        //            #endregion
        //            return true;
        //        }
        //        else
        //        {
        //            if (result.IsSet("err_code") && result.IsSet("err_code_des"))
        //            {
        //                LogHelp.AddErrLog("关闭订单(fun:CloseOrder)", false, "关闭订单失败！结果：" + result.ToJson());
        //            }
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelp.AddErrLog("关闭订单(fun:CloseOrder)", true, "关闭订单异常！" + ex.Message);
        //        return false;
        //    }
        //}
        //#endregion
        //#endregion

        ///// <summary>
        ///// 统一下单
        ///// </summary>
        ///// <param name="inputObj"></param>
        ///// <param name="timeOut"></param>
        ///// <returns>prepay_id(返回微信订单号，若为空表示失败!)</returns>
        //public static WxPayData UnifiedServiceRepairOrder(WxPayData inputObj, out int id, int timeOut = 6, int userId = 0, int useType = 0, int ScanType = 0, string orderno = "", bool isRecharge = false)
        //{
        //    id = 0;
        //    WxPayData result = new WxPayData();
        //    //string prepay_id = string.Empty;
        //    try
        //    {
        //        #region 验证接口参数有效性
        //        if (inputObj == null)
        //            throw new Exception("统一支付接口参数不能为空！");
        //        //if (inputObj.GetValue("appid") == null || string.IsNullOrEmpty(inputObj.GetValue("appid").ToString()))
        //        inputObj.SetValue("appid", ConfigHelper.GetConfigString("AppId"));//公众账号ID
        //        //if (inputObj.GetValue("mch_id") == null || string.IsNullOrEmpty(inputObj.GetValue("mch_id").ToString()))
        //        inputObj.SetValue("mch_id", ConfigHelper.GetConfigString("Mch_ID"));//商户号
        //        inputObj.SetValue("nonce_str", GenerateNonceStr()); ;//随机字符串
        //        inputObj.SetValue("spbill_create_ip", GetAddressIP());//APP和网页支付提交用户端ip	 
        //        //inputObj.SetValue("trade_type", "JSAPI");//JSAPI 取值如下：JSAPI，NATIVE，APP，WAP

        //        if (!inputObj.IsSet("notify_url"))
        //            inputObj.SetValue("notify_url", ConfigHelper.GetConfigString("Notify_URL"));//异步通知url

        //        string out_trade_no = inputObj.GetValue("out_trade_no").ToString();
        //        //inputObj.SetValue("out_trade_no", out_trade_no);

        //        string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";//统一下单接口url

        //        //检测必填参数
        //        if (!inputObj.IsSet("out_trade_no"))
        //            throw new Exception("缺少统一支付接口必填参数out_trade_no！");
        //        else if (!inputObj.IsSet("body"))
        //            throw new Exception("缺少统一支付接口必填参数body！");
        //        else if (!inputObj.IsSet("total_fee"))
        //            throw new Exception("缺少统一支付接口必填参数total_fee！");
        //        else if (!inputObj.IsSet("trade_type"))
        //            throw new Exception("缺少统一支付接口必填参数trade_type！");

        //        //关联参数
        //        if (inputObj.GetValue("trade_type").ToString() == "JSAPI" && !inputObj.IsSet("openid"))
        //            throw new Exception("统一支付接口中，缺少必填参数openid！");
        //        if (inputObj.GetValue("trade_type").ToString() == "NATIVE" && !inputObj.IsSet("product_id"))
        //            throw new Exception("统一支付接口中，缺少必填参数product_id！");
        //        inputObj.SetValue("sign", inputObj.MakeSign());//签名
        //        #endregion



        //        // 将接口参数转换为XML
        //        string xml = inputObj.ToXml();
        //        // 接口调用开始时间
        //        var start = DateTime.Now;
        //        // 调用统一下单接口
        //        string response = HttpService.Post(xml, url, false, 100);
        //        // 接口调用结束时间
        //        var end = DateTime.Now;
        //        // 计算接口调用所用时间差
        //        int timeCost = (int)((end - start).TotalMilliseconds);
        //        // 读取统一下单接口返回数据

        //        result.FromXml(response);
        //        // 判断调用统一下单接口通讯是否成功
        //        if (result.GetValue("return_code").ToString() != "SUCCESS")
        //            throw new Exception("调用统一下单接口失败！(" + result.GetValue("return_msg") + ")");
        //        // 判断调用统一下单接口返回是否成功
        //        if (result.GetValue("result_code").ToString() != "SUCCESS")
        //            throw new Exception("调用统一下单接口数据返回失败！(" + result.GetValue("err_code_des") + ")");
        //        // 判断是否成功返回微信订单号
        //        if (!result.IsSet("prepay_id"))
        //            throw new Exception("调用统一下单接口返回微信订单号失败！");
        //        // 微信订单号
        //        //prepay_id = result.GetValue("prepay_id").ToString();

        //        //Log.Debug("统一下单(fun:UnifiedOrder)", "调用统一下单接口成功!返回结果：" + result.ToJson());
        //        //LogHelp.AddErrLog("统一下单(fun:UnifiedOrder)1", false, "调用统一下单接口成功!返回结果：" + result.ToJson());

        //        #region 插入支付日志
        //        Model.RepairPayLogInfo model_PayLog = new Model.RepairPayLogInfo();
        //        model_PayLog.PayPrice = Convert.ToDecimal(inputObj.GetValue("total_fee")) / 100;


        //        model_PayLog.OrderNo = orderno;
        //        model_PayLog.PayNo = out_trade_no;

        //        model_PayLog.BankNo = result.GetValue("prepay_id").ToString();
        //        model_PayLog.PayType = 0;// 微信支付
        //        model_PayLog.Status = 0;// 未支付
        //        model_PayLog.UserID = userId;
        //        model_PayLog.ClientType = 0;
        //        model_PayLog.UseType = useType;
        //        model_PayLog.AccountType = 0;
        //        model_PayLog.ScanType = ScanType;
        //        if (inputObj.GetValue("trade_type").ToString() == "NATIVE")
        //            model_PayLog.Messages = result.GetValue("code_url").ToString();
        //        else
        //            model_PayLog.Messages = "下单成功";
        //        model_PayLog.AddTime = DateTime.Now;
        //        model_PayLog.EndTime = model_PayLog.AddTime.Value.AddHours(+2);
        //        new BLL.RepairPayLogInfo().DeleteList("PayNo='" + inputObj.GetValue("out_trade_no").ToString() + "'");
        //        new BLL.RepairPayLogInfo().Add(model_PayLog, out id);
        //        #endregion
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelp.AddErrLog("统一下单(fun:UnifiedServiceRepairOrder)", true, "调用统一下单接口失败!错误原因：" + ex.Message);
        //        return null;
        //    }
        //    return result;
        //}

        #region 辅助方法
        #region 生成时间戳
        /**
        * 生成时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数
         * @return 时间戳
        */
        public static string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        #endregion

        #region 生成随机串，随机串包含字母或数字
        /**
        * 生成随机串，随机串包含字母或数字
        * @return 随机串
        */
        public static string GenerateNonceStr()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
        #endregion

        #region 测速上报
        /**
	    * 
	    * 测速上报
	    * @param string interface_url 接口URL
	    * @param int timeCost 接口耗时
	    * @param WxPayData inputObj参数数组
	    */
        private static void ReportCostTime(string interface_url, int timeCost, WxPayData inputObj)
        {
            Boolean isTr = false;
            //如果不需要进行上报
            if (isTr)
            {
                return;
            }

            //如果仅失败上报
            if (isTr && inputObj.IsSet("return_code") && inputObj.GetValue("return_code").ToString() == "SUCCESS" &&
             inputObj.IsSet("result_code") && inputObj.GetValue("result_code").ToString() == "SUCCESS")
            {
                return;
            }

            //if (WxPayConfig.REPORT_LEVENL == 0)
            //{
            //    return;
            //}

            ////如果仅失败上报
            //if (WxPayConfig.REPORT_LEVENL == 1 && inputObj.IsSet("return_code") && inputObj.GetValue("return_code").ToString() == "SUCCESS" &&
            // inputObj.IsSet("result_code") && inputObj.GetValue("result_code").ToString() == "SUCCESS")
            //{
            //    return;
            //}

            //上报逻辑
            WxPayData data = new WxPayData();
            data.SetValue("interface_url", interface_url);
            data.SetValue("execute_time_", timeCost);
            //返回状态码
            if (inputObj.IsSet("return_code"))
            {
                data.SetValue("return_code", inputObj.GetValue("return_code"));
            }
            //返回信息
            if (inputObj.IsSet("return_msg"))
            {
                data.SetValue("return_msg", inputObj.GetValue("return_msg"));
            }
            //业务结果
            if (inputObj.IsSet("result_code"))
            {
                data.SetValue("result_code", inputObj.GetValue("result_code"));
            }
            //错误代码
            if (inputObj.IsSet("err_code"))
            {
                data.SetValue("err_code", inputObj.GetValue("err_code"));
            }
            //错误代码描述
            if (inputObj.IsSet("err_code_des"))
            {
                data.SetValue("err_code_des", inputObj.GetValue("err_code_des"));
            }
            //商户订单号
            if (inputObj.IsSet("out_trade_no"))
            {
                data.SetValue("out_trade_no", inputObj.GetValue("out_trade_no"));
            }
            //设备号
            if (inputObj.IsSet("device_info"))
            {
                data.SetValue("device_info", inputObj.GetValue("device_info"));
            }

            try
            {
                Report(data);
            }
            catch (Exception ex)
            {
                //不做任何处理
            }
        }
        #endregion

        #region  测速上报接口实现
        /**
	    * 
	    * 测速上报接口实现
	    * @param WxPayData inputObj 提交给测速上报接口的参数
	    * @param int timeOut 测速上报接口超时时间
	    * @throws WxPayException
	    * @return 成功时返回测速上报接口返回的结果，其他抛异常
	    */
        public static WxPayData Report(WxPayData inputObj, int timeOut = 1)
        {
            string url = "https://api.mch.weixin.qq.com/payitil/report";
            //检测必填参数
            if (!inputObj.IsSet("interface_url"))
            {
                throw new Exception("接口URL，缺少必填参数interface_url！");
            }
            if (!inputObj.IsSet("return_code"))
            {
                throw new Exception("返回状态码，缺少必填参数return_code！");
            }
            if (!inputObj.IsSet("result_code"))
            {
                throw new Exception("业务结果，缺少必填参数result_code！");
            }
            if (!inputObj.IsSet("user_ip"))
            {
                throw new Exception("访问接口IP，缺少必填参数user_ip！");
            }
            if (!inputObj.IsSet("execute_time_"))
            {
                throw new Exception("接口耗时，缺少必填参数execute_time_！");
            }

            inputObj.SetValue("appid", ConfigHelper.GetConfigString("AppId"));//公众账号ID
            inputObj.SetValue("mch_id", "");//商户号
            inputObj.SetValue("user_ip", "");//终端ip
            inputObj.SetValue("time", DateTime.Now.ToString("yyyyMMddHHmmss"));//商户上报时间	 
            inputObj.SetValue("nonce_str", GenerateNonceStr());//随机字符串
            inputObj.SetValue("sign", inputObj.MakeSign());//签名
            string xml = inputObj.ToXml();

            //Log.Info("WxPayApi", "Report request : " + xml);

            string response = HttpService.Post(xml, url, false, timeOut);

            //Log.Info("WxPayApi", "Report response : " + response);

            WxPayData result = new WxPayData();
            result.FromXml(response);
            return result;
        }
        #endregion
        public static string GetAddressIP()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }
        #endregion

        #region
        /// <summary>
        /// 统一下单
        /// </summary>
        /// <param name="inputObj"></param>
        /// <param name="timeOut"></param>
        /// <returns>prepay_id(返回微信订单号，若为空表示失败!)</returns>
        public static WxPayData UnifiedServiceRepairOrder(WxPayData inputObj, out int id, int timeOut = 6, int userId = 0, int useType = 0, int ScanType = 0, string orderno = "", bool isRecharge = false)
        {
            id = 0;
            WxPayData result = new WxPayData();
            //string prepay_id = string.Empty;
            try
            {
                #region 验证接口参数有效性
                if (inputObj == null)
                    throw new Exception("统一支付接口参数不能为空！");
                //if (inputObj.GetValue("appid") == null || string.IsNullOrEmpty(inputObj.GetValue("appid").ToString()))
                inputObj.SetValue("appid", ConfigHelper.GetConfigString("AppId"));//公众账号ID
                //if (inputObj.GetValue("mch_id") == null || string.IsNullOrEmpty(inputObj.GetValue("mch_id").ToString()))
                inputObj.SetValue("mch_id", ConfigHelper.GetConfigString("Mch_ID"));//商户号
                inputObj.SetValue("nonce_str", JsApiPayHelper.GenerateNonceStr()); ;//随机字符串
                inputObj.SetValue("spbill_create_ip", JsApiPayHelper.GetAddressIP());//APP和网页支付提交用户端ip	 
                //inputObj.SetValue("trade_type", "JSAPI");//JSAPI 取值如下：JSAPI，NATIVE，APP，WAP

                if (!inputObj.IsSet("notify_url"))
                    inputObj.SetValue("notify_url", ConfigHelper.GetConfigString("Notify_URL"));//异步通知url

                string out_trade_no = inputObj.GetValue("out_trade_no").ToString();
                //inputObj.SetValue("out_trade_no", out_trade_no);

                string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";//统一下单接口url

                //检测必填参数
                if (!inputObj.IsSet("out_trade_no"))
                    throw new Exception("缺少统一支付接口必填参数out_trade_no！");
                else if (!inputObj.IsSet("body"))
                    throw new Exception("缺少统一支付接口必填参数body！");
                else if (!inputObj.IsSet("total_fee"))
                    throw new Exception("缺少统一支付接口必填参数total_fee！");
                else if (!inputObj.IsSet("trade_type"))
                    throw new Exception("缺少统一支付接口必填参数trade_type！");

                //关联参数
                if (inputObj.GetValue("trade_type").ToString() == "JSAPI" && !inputObj.IsSet("openid"))
                    throw new Exception("统一支付接口中，缺少必填参数openid！");
                if (inputObj.GetValue("trade_type").ToString() == "NATIVE" && !inputObj.IsSet("product_id"))
                    throw new Exception("统一支付接口中，缺少必填参数product_id！");
                inputObj.SetValue("sign", inputObj.MakeSign());//签名
                #endregion



                // 将接口参数转换为XML
                string xml = inputObj.ToXml();
                // 接口调用开始时间
                var start = DateTime.Now;
                // 调用统一下单接口
                string response = HttpService.Post(xml, url, false, 100);
                // 接口调用结束时间
                var end = DateTime.Now;
                // 计算接口调用所用时间差
                int timeCost = (int)((end - start).TotalMilliseconds);
                // 读取统一下单接口返回数据

                result.FromXml(response);
                // 判断调用统一下单接口通讯是否成功
                if (result.GetValue("return_code").ToString() != "SUCCESS")
                    throw new Exception("调用统一下单接口失败！(" + result.GetValue("return_msg") + ")");
                // 判断调用统一下单接口返回是否成功
                if (result.GetValue("result_code").ToString() != "SUCCESS")
                    throw new Exception("调用统一下单接口数据返回失败！(" + result.GetValue("err_code_des") + ")");
                // 判断是否成功返回微信订单号
                if (!result.IsSet("prepay_id"))
                    throw new Exception("调用统一下单接口返回微信订单号失败！");
                // 微信订单号
                //prepay_id = result.GetValue("prepay_id").ToString();

                //Log.Debug("统一下单(fun:UnifiedOrder)", "调用统一下单接口成功!返回结果：" + result.ToJson());
                //LogHelp.AddErrLog("统一下单(fun:UnifiedOrder)1", false, "调用统一下单接口成功!返回结果：" + result.ToJson());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion

        #region 生成调起jsapi支付参数
        /// <summary>
        /// 从统一下单成功返回的数据中获取微信浏览器调起jsapi支付所需的参数，
        /// </summary>
        /// <param name="prepay_id"></param>
        /// <returns>parameters(返回支付参数json字符串，为空则为失败)</returns>
        public static string GetJsApiParameters(Object prepay_id)
        {
            string parameters = string.Empty;
            try
            {
                if (prepay_id == null)
                    throw new Exception("微信订单号参数为空!");
                // 生成支付参数
                WxPayData jsApiParam = new WxPayData();
                jsApiParam.SetValue("appId", ConfigHelper.GetConfigString("AppId"));
                jsApiParam.SetValue("timeStamp", GenerateTimeStamp());
                jsApiParam.SetValue("nonceStr", GenerateNonceStr());
                jsApiParam.SetValue("package", "prepay_id=" + prepay_id.ToString());
                jsApiParam.SetValue("signType", "MD5");
                jsApiParam.SetValue("paySign", jsApiParam.MakeSign());

                parameters = jsApiParam.ToJson();

            }
            catch (Exception ex)
            {
                //LogHelp.AddErrLog("统一下单(fun:GetJsApiParameters)", false, "生成调用JSAPI支付参数失败！错误原因：" + ex.Message);
            }
            return parameters;
        }
        #endregion
    }
}
