using EmitMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeixinApi.Common
{
    /// <summary>
    /// 对象映射帮助类
    /// </summary>
    public class EmitMapperHelper
    {
        /// <summary>
        /// 对象映射
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="t"></param>
        public static R ObjectMapper<T, R>(T t)
            where T : class, new()
            where R : class, new()
        {
            R r = new R();
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<T, R>();
            mapper.Map(t, r);

            return r;
        }
    }
}