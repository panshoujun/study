using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalR.Common
{
    /// <summary>
    /// 采用持久化连接类
    /// </summary>
    public class MyConnection : PersistentConnection
    {
        private static List<string> monitoringIdList = new List<string>();


        /// <summary>
        /// 链接
        /// </summary>
        /// <param name="request"></param>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            bool IsMonitoring = (request.QueryString["Monitoring"] ?? "").ToString() == "Y";
            if (IsMonitoring)
            {
                if (!monitoringIdList.Contains(connectionId))
                {
                    monitoringIdList.Add(connectionId);
                }
                return Connection.Send(connectionId, "ready");
            }
            else
            {
                if (monitoringIdList.Count > 0)
                {
                    return Connection.Send(monitoringIdList, "in_" + connectionId);
                }
                else
                {
                    return Connection.Send(connectionId, "nobody");
                }
            }
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            if (monitoringIdList.Contains(connectionId))
            {
                return Connection.Send(data, "pass");
            }
            return null;
        }

        /// <summary>
        /// 断开链接
        /// </summary>
        /// <param name="request"></param>
        /// <param name="connectionId"></param>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
        {
            if (!monitoringIdList.Contains(connectionId))
            {
                return Connection.Send(monitoringIdList, "out_" + connectionId);
            }
            return null;
        }
    }
}