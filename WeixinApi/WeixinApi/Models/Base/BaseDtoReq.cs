using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeixinApi.Models.Base
{
    #region 基本请求数据传输对象
    /// <summary>
    /// 基本请求数据传输对象
    /// </summary>
    public class BaseDtoReq : BaseModel
    {
        #region 构造函数
        public BaseDtoReq()
        {
        }
        #endregion

        #region 参数验证
        ///// <summary>
        ///// 业务参数验证
        ///// </summary>
        //public virtual void Validate(HttpActionContext actionContext)
        //{
        //    if (ID == null)
        //    {
        //        ValidateHelper.Throw(actionContext, "未传入ID参数");
        //        return;
        //    }
        //    else if (ID < 1)
        //    {
        //        ValidateHelper.Throw(actionContext, "ID");
        //        return;
        //    }
        //}

        /// <summary>
        /// 业务参数验证
        /// </summary>
        public virtual Tuple<bool, string> Validate()
        {
            return new Tuple<bool, string>(true, "");
        }
        #endregion

        #region 系统级别参数
        public BaseSystemParamReq System { get; set; }

        public string Token { get; set; }
        #endregion

        #region 扩展
        public bool IsDeleted { get; set; }
        #endregion
    }
    #endregion

    #region 基本查询请求输传输对象
    /// <summary>
    /// 基本查询请求输传输对象
    /// </summary>
    public class BaseQueryDtoReq : BaseDtoReq
    {
        #region 当前页
        private int pageIndex = 1;

        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }
        #endregion

        #region 每页显示数目
        private int pageSize = 10;

        /// <summary>
        /// 每页显示数目
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
        #endregion

        #region 每页显示数目列表
        public static Dictionary<int, int> SizeList { get; set; }

        static BaseQueryDtoReq()
        {
            SizeList = new Dictionary<int, int>();
            SizeList.Add(1, 1);
            SizeList.Add(2, 2);
            SizeList.Add(3, 3);
            SizeList.Add(5, 5);
            SizeList.Add(10, 10);
            SizeList.Add(20, 20);
            SizeList.Add(50, 50);
            SizeList.Add(100, 100);
        }
        #endregion
    }
    #endregion
}
