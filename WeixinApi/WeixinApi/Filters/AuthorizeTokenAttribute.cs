using Common;
using Formula.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using WeixinApi.Models.Base;

namespace WeixinApi.Filters
{
    /// <summary>
    /// 权限认证过滤器
    /// </summary>
    public class AuthorizeTokenAttribute : BaseAuthorizeAttribute
    {

        /// <summary>
        /// IP认证
        /// </summary>
        /// <returns></returns>
        private BaseDtoResp AuthorizeIP()
        {
            if (DataConfig.QyConfig.AllowIP != "*")
            {
                string ip = IPHelper.GetClientIP();
                string ip2 = IPHelper.GetExternalIP();
                string ip3 = IPHelper.GetLocalIP();
                FileLog.AddLog(string.Format("ip={0},ip2={1},ip3={2}", ip, ip2, ip3));

                if (!DataConfig.QyConfig.AllowIP.Split('|').Contains(ip))
                    return new BaseDtoResp() { Msg = "IP认证不通过" };
            }
            return new BaseDtoResp() { IsSuccess = true };
        }

        /// <summary>
        /// 域名认证
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        private BaseDtoResp AuthorizeDoMain(HttpRequestMessage Request)
        {
            if (DataConfig.QyConfig.AllowDoMain != "*")
            {
                string host = Request.RequestUri.Host;
                if (!DataConfig.QyConfig.AllowDoMain.Split('|').Contains(host))
                    return new BaseDtoResp() { Msg = "域名认证不通过" };
            }
            return new BaseDtoResp() { IsSuccess = true };
        }

        /// <summary>
        /// Token认证
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        private BaseDtoResp AuthorizeToken(HttpRequestMessage Request)
        {
            if (Request.Headers.Contains("Token"))
            {
                var accessKey = Request.Headers.GetValues("Token").SingleOrDefault();
                if (accessKey != "123")
                    return new BaseDtoResp { Msg = "Token不正确。" };
            }
            else
                return new BaseDtoResp { Msg = "Token未传入。" };

            return new BaseDtoResp() { IsSuccess = true };
        }

        /// <summary>
        /// 创建返回信息
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private HttpResponseMessage MakeResponse(BaseDtoResp response)
        {
            HttpResponseMessage Response = new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(response), System.Text.Encoding.GetEncoding("UTF-8"), "application/json"),
                StatusCode = HttpStatusCode.Unauthorized
            };
            return Response;
        }

        #region 方式一
        /// <summary>
        /// 权限验证
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var request = actionContext.Request;

            //如果不尽心验证
            if (IsValidation == false)
                return true;

            if (request.Headers.Contains("Token"))
            {
                var accessKey = request.Headers.GetValues("Token").SingleOrDefault();
                //TODO 验证Key
                return accessKey == "123456789";
            }

            return false;
        }

        /// <summary>
        /// 处理未授权的请求
        /// </summary>
        /// <param name="actionContext"></param>
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var content = JsonConvert.SerializeObject(new { State = HttpStatusCode.Unauthorized });
            actionContext.Response = new HttpResponseMessage
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.Unauthorized
            };
        }
        #endregion

        #region 方式二 (如果写了方式二 方式一不走。如果没写方式二就会走方式一)
        /// <summary>
        /// 授权认证
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            BaseDtoResp resp = new BaseDtoResp();
            //如果用户方位的Action带有AllowAnonymousAttribute，则不进行授权验证   IsValidation=false也不进行验证

            var result = actionContext.ActionDescriptor.GetCustomAttributes<BaseAuthorizeAttribute>().Any(p => p.IsValidation == false);
            var result2 = actionContext.ActionDescriptor.GetCustomAttributes<BaseAuthorizeAttribute>().Any(p => p.IsValidation == true);

            //如果有AllowAnonymousAttribute不进行权限验证
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
            {
                return;
            }

            //如果有IsValidation == false不进行权限验证
            if (actionContext.ActionDescriptor.GetCustomAttributes<BaseAuthorizeAttribute>().Any(p => p.IsValidation == false))
            {
                return;
            }

            //域名认证
            resp = AuthorizeDoMain(actionContext.Request);
            if (!resp.IsSuccess)
                actionContext.Response = MakeResponse(resp);

            //IP认证
            resp = AuthorizeIP();
            if (!resp.IsSuccess)
                actionContext.Response = MakeResponse(resp);

            //Token认证
            resp = AuthorizeToken(actionContext.Request);
            if (!resp.IsSuccess)
                actionContext.Response = MakeResponse(resp);

            #region
            //var verifyResult = actionContext.Request.Headers.Authorization != null &&  //要求请求中需要带有Authorization头
            //                   actionContext.Request.Headers.Authorization.Parameter == "123456"; //并且Authorization参数为123456则验证通过

            //if (!verifyResult)
            //{
            //    //如果验证不通过，则返回401错误，并且Body中写入错误原因
            //    //actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, new HttpError("Token 不正确"));
            //}
            #endregion
        }
        #endregion
    }
}