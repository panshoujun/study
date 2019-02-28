using DataConfig;
using EmitMapper;
using Senparc.Weixin.Entities;
using Senparc.Weixin.Work.AdvancedAPIs;
using Senparc.Weixin.Work.AdvancedAPIs.MailList;
using Senparc.Weixin.Work.AdvancedAPIs.MailList.Member;
using Senparc.Weixin.Work.AdvancedAPIs.Mass;
using Senparc.Weixin.Work.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using WeixinApi.Common;
using WeixinApi.Filters;
using WeixinApi.Models.QY;

namespace WeixinApi.ApiControllers
{
    /// <summary>
    /// 企业号管理api
    /// </summary>
    [RoutePrefix("QY")]
    //[ControllerGroup("管理员", "QY")]
    public class QYController : ApiController
    {
        #region 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="QyID"></param>
        /// <param name="GetNewToken"></param>
        /// <returns></returns>
        private string GetAccessToken(string QyID, bool GetNewToken = false)
        {
            var token = "";
            return token;
        }

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
        #endregion

        #region 组织
        /// <summary>
        /// 创建组织
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateDepartment")]
        public CreateDepartmentResult CreateDepartment(CreateDepartmentDto dto)
        {
            dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
            var result = MailListApi.CreateDepartment(dto.AccessToken, dto.Name, dto.ParentId, dto.Order, dto.ID);
            return result;
        }

        /// <summary>
        /// 删除组织
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteDepartment")]
        public WorkJsonResult DeleteDepartment(DeleteDepartmentDto dto)
        {
            dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
            var result = MailListApi.DeleteDepartment(dto.AccessToken, dto.ID);
            return result;
        }

        /// <summary>
        /// 修改组织        
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateDepartment")]
        public WorkJsonResult UpdateDepartment(UpdateDepartmentDto dto)
        {
            dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
            var result = MailListApi.UpdateDepartment(dto.AccessToken, dto.ID, dto.Name, dto.ParentId, dto.Order);
            return result;
        }


        /// <summary>
        /// 获取组织
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetDepartmentList")]
        public GetDepartmentListResult GetDepartmentList(GetDepartmentListDto dto)
        {
            dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
            var result = MailListApi.GetDepartmentList(dto.AccessToken, dto.ID);
            return result;
        }

        #endregion

        #region 成员
        /// <summary>
        /// 创建成员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateMember")]
        public WorkJsonResult CreateMember(CreateMemberDto dto)
        {
            dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
            MemberCreateRequest req = EmitMapperHelper.ObjectMapper<CreateMemberDto, MemberCreateRequest>(dto);
            var result = MailListApi.CreateMember(dto.AccessToken, req);
            return result;
        }

        /// <summary>
        /// 删除成员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteMember")]
        public WorkJsonResult DeleteMember(DeleteMemberDto dto)
        {
            dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
            var result = MailListApi.DeleteMember(dto.AccessToken, dto.ID);
            return result;
        }

        /// <summary>
        /// 批量删除成员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("BatchDeleteMember")]
        public WorkJsonResult BatchDeleteMember(BatchDeleteMember dto)
        {
            dto.IDList = (GetDepartmentMember(new GetDepartmentMemberDto { FetchChild = 1, DepartmentId = 1 }) as GetDepartmentMemberResult).userlist.Select(p => p.userid).ToArray();
            dto.IDList = dto.IDList.Where(p => p != "da6dc622-0cd8-4d8b-be3f-8d6fc536dd6e").ToArray();
            dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
            var result = MailListApi.BatchDeleteMember(dto.AccessToken, dto.IDList);
            return result;
        }

        /// <summary>
        /// 修改成员        
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateMember")]
        public WorkJsonResult UpdateMember(UpdateMemberDto dto)
        {
            dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
            MemberUpdateRequest req = EmitMapperHelper.ObjectMapper<UpdateMemberDto, MemberUpdateRequest>(dto);
            var result = MailListApi.UpdateMember(dto.AccessToken, req);
            return result;
        }

        /// <summary>
        /// 获取成员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetMember")]
        public WorkJsonResult GetMember(GetMemberDto dto)
        {
            dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
            var result = MailListApi.GetMember(dto.AccessToken, dto.ID);
            return result;
        }

        /// <summary>
        /// 获取部门成员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetDepartmentMember")]
        public WorkJsonResult GetDepartmentMember(GetDepartmentMemberDto dto)
        {
            dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
            var result = MailListApi.GetDepartmentMember(dto.AccessToken, dto.DepartmentId, dto.FetchChild);
            return result;
        }

        /// <summary>
        /// 获取部门成员详情
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetDepartmentMemberInfo")]
        public WorkJsonResult GetDepartmentMemberInfo(GetDepartmentMemberInfoDto dto)
        {
            dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
            var result = MailListApi.GetDepartmentMemberInfo(dto.AccessToken, dto.DepartmentId, dto.FetchChild);
            return result;
        }

        #endregion

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
            var token = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
            var result = MassApi.SendText(token, dto);
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
            var token = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
            dto.agentid = 91;
            //dto.news.articles.ForEach(p=> {
            //    p.description= striphtml(p.description.Replace("'", "”")).Replace("'", "”");
            //});
            var result = MassApi.SendNews(token, dto);
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

        #region
        /// <summary>
        /// 去除HTML标记
        /// </summary>
        /// <param name="Htmlstring">包括HTML的源码 </param>
        /// <returns>已经去除后的文字</returns>
        public static string striphtml(string Htmlstring)
        {
            //删除脚本
            Htmlstring = Htmlstring.Replace("\r\n", "");
            Htmlstring = Regex.Replace(Htmlstring, @"<script.*?</script>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<style.*?</style>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<.*?>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring = Htmlstring.Replace("<", "");
            Htmlstring = Htmlstring.Replace(">", "");
            Htmlstring = Htmlstring.Replace("\r\n", "");
            if (Htmlstring.Length > 100)
                Htmlstring = Htmlstring.Substring(0, 100) + "...";
            return Htmlstring;
        }
        #endregion
    }
}
