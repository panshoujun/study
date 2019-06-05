using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using WeixinApi.Models.Base;

namespace WeixinApi.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
    public class ModelValidationAttribute : ActionFilterAttribute
    {
        #region 创建返回信息
        /// <summary>
        /// 创建返回信息
        /// </summary>
        /// <param name="Msg"></param>
        /// <returns></returns>
        private HttpResponseMessage MakeResponse(string Msg)
        {
            BaseDtoResp response = new BaseDtoResp() { Msg = Msg };
            HttpResponseMessage Response = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(JsonConvert.SerializeObject(response), System.Text.Encoding.GetEncoding("UTF-8"), "application/json")//, "application/json"
            };
            return Response;
        }
        #endregion

        #region Sign签名验证
        /// <summary>
        /// Sign签名验证
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public bool Validate(BaseDtoReq req)
        {
            //bool result = false;
            //if (req.AppKey.IsNullOrEmpty())
            //{
            //    return result;
            //}
            //string appSecret = req.GetAppSecret(); //StaticParam.dicAppKey[req.AppKey];
            //result = req.Sign == req.MakeSignData(req.GetSysParamDic(), appSecret);
            //return result;

            return true;
        }
        #endregion

        #region Action执行
        #region Action执行之前
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            #region 获取请求数据
            //方法1
            //Stream stream = actionContext.Request.Content.ReadAsStreamAsync().Result;
            //string requestDataStr = "";
            //if (stream != null && stream.Length > 0)
            //{
            //    stream.Position = 0; //当你读取完之后必须把stream的读取位置设为开始
            //    using (StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8))
            //    {
            //        requestDataStr = reader.ReadToEnd().ToString();
            //    }
            //}

            //方法2
            //var temp =actionContext.ControllerContext.Request.Content.ReadAsStringAsync().Result;
            //LogHelper.Info("Request:" + temp);
            #endregion

            if (actionContext.ActionArguments.Count <= 0 || actionContext.ActionArguments.First().Value == null)
            {
                actionContext.Response = MakeResponse("请求参数为空");
                return;
            }

            BaseDtoReq requ = actionContext.ActionArguments.First().Value as BaseDtoReq;
            if (requ == null)
            {
                actionContext.Response = MakeResponse("请求参数不匹配");
                return;
            }

            string requString = JsonConvert.SerializeObject(requ);
            LogHelper.Info("请求地址:" + actionContext.Request.RequestUri.AbsoluteUri + "请求参数:" + requString);

            bool result = Validate(requ);

            if (!Validate(requ))
            {
                actionContext.Response = MakeResponse("Sign签名验证失败");
                return;
            }

            #region  数据验证
            var modelState = actionContext.ModelState;
            if (!modelState.IsValid)
            {
                string error = string.Empty;
                foreach (var key in modelState.Keys)
                {
                    var state = modelState[key];
                    if (state.Errors.Any())
                    {
                        error = state.Errors.First().ErrorMessage;
                        break;
                    }
                }
                actionContext.Response = MakeResponse(error);
            }
            #endregion
        }
        #endregion

        #region Action执行之后
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            string responseDataStr = actionExecutedContext.Response.Content.ReadAsStringAsync().Result;
            LogHelper.Info("请求地址:" + actionExecutedContext.Request.RequestUri.AbsoluteUri + "返回参数:" + responseDataStr);
        }
        #endregion
        #endregion

    }
}