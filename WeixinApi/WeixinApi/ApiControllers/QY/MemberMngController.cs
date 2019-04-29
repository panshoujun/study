using DataConfig;
using Senparc.Weixin.Entities;
using Senparc.Weixin.Work.AdvancedAPIs;
using Senparc.Weixin.Work.AdvancedAPIs.MailList;
using Senparc.Weixin.Work.AdvancedAPIs.MailList.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeixinApi.Common;
using WeixinApi.Models.QY;

namespace WeixinApi.ApiControllers
{
    /// <summary>
    /// 企业号人员信息管理
    /// </summary>
    [RoutePrefix("MemberMng")]
    public class MemberMngController : ApiController
    {
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
            //dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
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
            //dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
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
            //dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
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
            //dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
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
            //dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
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
            //dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
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
            //dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
            var result = MailListApi.GetDepartmentMemberInfo(dto.AccessToken, dto.DepartmentId, dto.FetchChild);
            return result;
        }

        #endregion
    }
}
