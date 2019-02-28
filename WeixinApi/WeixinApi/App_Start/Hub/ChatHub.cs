using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WeixinApi.App_Start
{
    public class ChatHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        /// <summary>
          /// 供客户端调用的服务器端代码
          /// </summary>
          /// <param name="message"></param>
        public void Send(string message)
        {
            var name = Guid.NewGuid().ToString().ToUpper();
            // 调用所有客户端的sendMessage方法
            Clients.All.sendMessage(name, message);
        }

        ///// <summary>
        //  /// 客户端连接的时候调用
        //  /// </summary>
        //  /// <returns></returns>
        //public override Task OnConnected()
        //{
        //    Trace.WriteLine("客户端连接成功");
        //    return base.OnConnected();
        //}
    }

    public class BaseHub : Hub
    {
        public static IList<QQModel> list = new List<QQModel>();

        public void Hello()
        {
            Clients.All.hello();
        }

        /// <summary>
        /// 获取客户端连接ID
        /// </summary>
        public void GetConnectionId()
        {
            try
            {
                string connectionId = Context.ConnectionId;//客户端ID
                Clients.Client(connectionId).getConnectionId(connectionId);//获取客户端连接ID
            }
            catch (Exception exception)
            {

            }
        }

        /// <summary>
        /// 自定义上线
        /// </summary>
        /// <param name="name"></param>
        public void Online(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            name = Uri.EscapeDataString(name);//编码一下
            string connId = Context.ConnectionId;

            if (!list.Any(p => p.Name == name))
            {
                list.Add(new QQModel
                {
                    ConnectionId = connId,
                    Name = name
                });

                //把客户连接ID返回给客户端
                Clients.Client(connId).showConnectionId(connId);
            }
        }

        /// <summary>
        /// 供客户端调用的服务器端代码
        /// </summary>
        /// <param name="message"></param>
        public void Send(string message)
        {
            var name = Guid.NewGuid().ToString().ToUpper();
            // 调用所有客户端的sendMessage方法
            Clients.All.sendMessage(name, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        public void SendToUser(string name, string message)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            string connId = Context.ConnectionId;
            name = Uri.EscapeDataString(name);//编码一下
            var userInfo = list.Where(p => p.Name == name).FirstOrDefault();
            if (userInfo != null)
            {
                // 调用所有客户端的sendMessage方法
                Clients.Client(userInfo.ConnectionId).sendMessage(name, message);
            }
        }

        ///// <summary>
        ///// 客户端连接的时候调用
        ///// </summary>
        ///// <returns></returns>
        //public override Task OnConnected()
        //{
        //    return base.OnConnected();
        //}

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="connectionId"></param>
        public void Login(string connectionId)
        {
            if (!string.IsNullOrWhiteSpace(connectionId))
            {
                var userInfo = list.Where(p => p.ConnectionId == connectionId).FirstOrDefault();
                if (userInfo != null)
                {
                    string msg = $"恭喜你{userInfo.Name}扫码登入成功!<br />链接ID={userInfo.ConnectionId}<br />OpenId={userInfo.OtherData.openid}";
                    // 调用所有客户端的sendMessage方法
                    Clients.Client(connectionId).loginCallBack(msg, userInfo.OtherData.headimgurl);
                }
            }
        }

    }

    public class QQModel
    {
        /// <summary>
        /// 链接ID
        /// </summary>
        public string ConnectionId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 组名
        /// </summary>
        public string GroupName { get; set; }


        /// <summary>
        /// 其他数据
        /// </summary>
        public dynamic OtherData { get; set; }
    }
}