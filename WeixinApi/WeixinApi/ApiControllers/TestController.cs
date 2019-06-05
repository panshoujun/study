using Model;
using Senparc.Weixin.Work.AdvancedAPIs.MailList;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeixinApi.Filters;
using WeixinApi.Models.Base;
using WeixinApi.Models.QY;
using WeixinApi.Models.Test;

namespace WeixinApi.ApiControllers
{
    /// <summary>
    /// 测试
    /// </summary>
    [RoutePrefix("Test")]
    public class TestController : ApiController
    {
        /// <summary>
        /// 测试1
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Test1")]
        [AuthorizeToken(IsValidation = false)]
        public CreateDepartmentResult CreateDepartment(TestModel dto)
        {
            var result = new CreateDepartmentResult();
            return result;
        }

        /// <summary>
        /// 测试2
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Test2")]
        public CreateDepartmentResult CreateDepartment2(CreateDepartmentDto dto)
        {
            var result = new CreateDepartmentResult();
            return result;
        }

        /// <summary>
        /// 测试3
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Test3")]
        [AuthorizeToken(IsValidation = true)]
        public CreateDepartmentResult CreateDepartment3(CreateDepartmentDto dto)
        {
            var result = new CreateDepartmentResult();
            return result;
        }

        /// <summary>
        /// upload测试4
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Test4")]
        [AuthorizeToken(IsValidation = true)]
        public CreateDepartmentResult CreateDepartment4(CreateDepartmentDto dto)
        {
            var result = new CreateDepartmentResult();
            return result;
        }


        /// <summary>
        /// 查看API开发状态
        /// </summary>
        [HttpGet]
        [ApiAuthor(Name = "潘守军", Status = DevStatus.Wait, Time = "2018-11-15")]
        public void ApiStatus()
        {

        }


        [HttpPost]
        [ActionName("ModelValidate")]
        //[ModelValidation]
        public BaseDtoResp ModelValidate(ModelValidate req)
        {
            DateTime dateTime = new DateTime(2019, 2, 21);
            DateTime dateTime2 = new DateTime(2019, 5, 14);
            var ts = dateTime2 - dateTime;
            var days = ts.Days;
            //int a = int.Parse("a");
            return new BaseDtoResp();
        }

    }
}
