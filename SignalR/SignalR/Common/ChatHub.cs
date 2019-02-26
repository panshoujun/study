using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalR.Common
{
    public class ChatHub : Hub
    {
        protected static IList<QQModel> list = new List<QQModel>();

        public void Hello()
        {
            Clients.All.hello();
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
            //Clients.All.sendMessage(name, message);
            //return;
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