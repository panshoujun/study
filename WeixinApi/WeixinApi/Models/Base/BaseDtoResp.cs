using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeixinApi.Models.Base
{
    #region 基本返回数据传输对象
    /// <summary>
    /// 基本返回数据传输对象
    /// </summary>
    public class BaseDtoResp : BaseModel
    {
        ///// <summary>
        ///// 是否成功
        ///// </summary>
        //public bool IsSuccess { get { return ErrCode == null && string.IsNullOrEmpty(ErrMsg); } }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 返回的提示信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 业务编码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        public int ErrCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg { get; set; }
    }
    #endregion

    #region 基本通用返回数据传输对象(泛型)
    /// <summary>
    /// 基本通用返回数据传输对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseDtoResp<T> : BaseDtoResp where T : new()
    {
        public T Data { get; set; }
    }
    #endregion

    #region 基本返回查询数据传输对象
    /// <summary>
    /// 基本返回查询数据传输对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BasePageDtoResp<T> : BaseDtoResp where T : new()
    {
        #region 返回列表
        public T Data { get; set; }
        #endregion

        #region 当前页
        /// <summary>
        /// 获取或设置当前页索引。
        /// </summary>
        public int CurrentPageIndex { get; set; }

        public int PageIndex { get { return CurrentPageIndex; } }
        #endregion

        #region 每页显示数目
        /// <summary>
        /// 获取或设置为每个数据页显示的数据项的数目。
        /// </summary>
        public int PageSize { get; set; }
        #endregion

        #region 总记录数和总页数
        /// <summary>
        /// 获取或设置可用于分页的总记录数。
        /// </summary>
        public int TotalItemCount { get; set; }

        /// <summary>
        /// 获取或设置可用于分页的数据项的总数。
        /// </summary>
        public int TotalPageCount { get { return (int)Math.Ceiling(((double)TotalItemCount / (double)PageSize)); } }
        #endregion
    }

    /// <summary>
    /// 基本返回查询数据传输对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BasePageListDtoResp<T> : BaseDtoResp where T : new()
    {
        #region 返回列表
        /// <summary>
        /// 返回列表
        /// </summary>
        public IEnumerable<T> Data { get; set; }
        #endregion

        #region 当前页
        /// <summary>
        /// 获取或设置当前页索引。
        /// </summary>
        public int CurrentPageIndex { get; set; }

        public int PageIndex { get { return CurrentPageIndex; } }
        #endregion

        #region 每页显示数目
        /// <summary>
        /// 获取或设置为每个数据页显示的数据项的数目。
        /// </summary>
        public int PageSize { get; set; }
        #endregion

        #region 总记录数和总页数
        /// <summary>
        /// 获取或设置可用于分页的总记录数。
        /// </summary>
        public int TotalItemCount { get; set; }

        /// <summary>
        /// 获取或设置可用于分页的数据项的总数。
        /// </summary>
        public int TotalPageCount { get { return (int)Math.Ceiling(((double)TotalItemCount / (double)PageSize)); } }
        #endregion
    }
    #endregion
}
