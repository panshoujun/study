using DataConfig;
using Senparc.Weixin.Entities;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using Senparc.Weixin.MP.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeixinApi.Filters;
using WeixinApi.Models.Mp;

namespace WeixinApi.ApiControllers
{
    /// <summary>
    /// 公众号管理api
    /// </summary>
    [RoutePrefix("MP")] 
    //[ControllerGroup("管理员", "MP")]
    public class MPController : ApiController
    {
        #region 用户授权
        ///// <summary>
        ///// 发送模板消息
        ///// </summary>
        ///// <param name="dto"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("SendTemplateMessage")]
        //public SendTemplateMessageResult GetAuthorizeUrl(SendTemplateMessageDto dto)
        //{
        //    OAuthApi.GetAuthorizeUrl();
        //    dto.AccessToken = GetAccessToken(MPConfig.AppId, MPConfig.AppSecret);
        //    var result = TemplateApi.SendTemplateMessage(dto.AccessToken, dto);
        //    return result;
        //}

        #endregion

        #region  使用完整的应用凭证获取Token
        /// <summary>
        /// 使用完整的应用凭证获取Token
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <param name="getNewToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetAccessToken")]
        public string GetAccessToken(string appId, string appSecret, bool getNewToken = false)
        {
            var token = AccessTokenContainer.TryGetAccessToken(appId, appSecret);
            return token;
        }
        #endregion

        #region 消息发送
        /// <summary>
        /// 发送模板消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SendTemplateMessage")]
        public SendTemplateMessageResult SendTemplateMessage(SendTemplateMessageDto dto)
        {
            dto.AccessToken = GetAccessToken(MPConfig.AppId, MPConfig.AppSecret);
            var result = TemplateApi.SendTemplateMessage(dto.AccessToken, dto);
            return result;
        }

        /// <summary>
        /// 删除模板
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DelPrivateTemplate")]
        public WxJsonResult DelPrivateTemplate(DelPrivateTemplateDto dto)
        {
            dto.AccessToken = GetAccessToken(MPConfig.AppId, MPConfig.AppSecret);
            var result = TemplateApi.DelPrivateTemplate(dto.AccessToken, dto.template_id);
            return result;
        }

        /// <summary>
        /// 添加模板
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Addtemplate")]
        public WxJsonResult Addtemplate(AddtemplateDto dto)
        {
            dto.AccessToken = GetAccessToken(MPConfig.AppId, MPConfig.AppSecret);
            var result = TemplateApi.Addtemplate(dto.AccessToken, dto.template_id);
            return result;
        }

        /// <summary>
        /// 获取模板列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetPrivateTemplate")]
        public WxJsonResult GetPrivateTemplate(BaseMPDto dto)
        {
            dto.AccessToken = GetAccessToken(MPConfig.AppId, MPConfig.AppSecret);
            var result = TemplateApi.GetPrivateTemplate(dto.AccessToken);
            return result;
        }

        /// <summary>
        /// 设置的行业信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SetIndustry")]
        public WxJsonResult SetIndustry(SetIndustryDto dto)
        {
            dto.AccessToken = GetAccessToken(MPConfig.AppId, MPConfig.AppSecret);
            var result = TemplateApi.SetIndustry(dto.AccessToken, (Senparc.Weixin.MP.IndustryCode)dto.industry_id1,
                (Senparc.Weixin.MP.IndustryCode)dto.industry_id2);
            return result;
        }

        /// <summary>
        /// 获取设置的行业信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetIndustry")]
        public WxJsonResult GetIndustry(BaseMPDto dto)
        {
            dto.AccessToken = GetAccessToken(MPConfig.AppId, MPConfig.AppSecret);
            var result = TemplateApi.GetIndustry(dto.AccessToken);
            return result;
        }
        #endregion
    }
}
