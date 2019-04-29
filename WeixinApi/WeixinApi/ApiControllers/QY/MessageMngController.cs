using DataConfig;
using Senparc.Weixin.Entities;
using Senparc.Weixin.Work.AdvancedAPIs;
using Senparc.Weixin.Work.AdvancedAPIs.Mass;
using Senparc.Weixin.Work.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeixinApi.Models.QY;

namespace WeixinApi.ApiControllers
{
    public class MessageMngController : ApiController
    {
        #region 消息MassApi(发送应用消息)
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MassApiSendText")]
        public MassResult MassApiSendText(SendTextDataDto dto)
        {
            //return new MassResult();
            //var token = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
            var result = MassApi.SendText(dto.AccessToken, dto);
            return result;
        }

        /// <summary>
        /// 发送图文消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MassApiSendNews")]
        public WorkJsonResult MassApiSendNews(SendNewsDataDto dto)
        {
            //var token = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
            dto.agentid = 91;
            //dto.news.articles.ForEach(p=> {
            //    p.description= striphtml(p.description.Replace("'", "”")).Replace("'", "”");
            //});
            var result = MassApi.SendNews(dto.AccessToken, dto);
            return result;
        }
        #endregion

        #region 消息LinkerCorpApi
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SendText")]
        public LinkedCorpMassResult SendText(SendTextData data)
        {
            var token = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
            var result = LinkerCorpApi.SendText(token, data);
            return result;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CorpID"></param>
        /// <param name="CorpSecret"></param>
        /// <param name="GetNewToken"></param>
        /// <returns></returns>
        private string GetAccessToken(string CorpID, string CorpSecret, bool GetNewToken = false)
        {
            var token = AccessTokenContainer.TryGetToken(CorpID, CorpSecret);
            return token;
        }
    }
}
