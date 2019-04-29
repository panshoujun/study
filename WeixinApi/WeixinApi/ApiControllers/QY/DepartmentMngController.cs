using DataConfig;
using Senparc.Weixin.Entities;
using Senparc.Weixin.Work.AdvancedAPIs;
using Senparc.Weixin.Work.AdvancedAPIs.MailList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeixinApi.Models.QY;

namespace WeixinApi.ApiControllers
{
    /// <summary>
    /// 企业号部门信息管理
    /// </summary>
    [RoutePrefix("DepartmentMng")]
    public class DepartmentMngController : ApiController
    {
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
            //dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
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
            //dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
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
            //dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
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
            //dto.AccessToken = GetAccessToken(QyConfig.CorpID, QyConfig.CorpSecret);
            var result = MailListApi.GetDepartmentList(dto.AccessToken, dto.ID);
            return result;
        }

        #endregion
    }
}
