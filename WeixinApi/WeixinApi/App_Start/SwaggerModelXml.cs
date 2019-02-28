using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace WeixinApi.App_Start
{
    /// <summary>
    /// 合并Model层的XML文件
    /// </summary>
    public class SwaggerModelXml
    {
        public static void AppendModelToCurrentXml()
        {            
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(AppDomain.CurrentDomain.BaseDirectory + @"/bin/Model.XML");
            var membersNode = xmlDocument.GetElementsByTagName("members")[0]; //Model层Members节点
            xmlDocument.Load(AppDomain.CurrentDomain.BaseDirectory + @"/bin/WeixinApi.XML");
            var currentMembersNode = xmlDocument.GetElementsByTagName("members")[0];  //API层Members节点
            for (int i = 0; i < membersNode.ChildNodes.Count; i++)
            {
                var memberNode = membersNode.ChildNodes[i];
                currentMembersNode.AppendChild(memberNode.Clone());
                if (memberNode.HasChildNodes)
                {
                    memberNode.AppendChild(memberNode.ChildNodes[0]);
                }
            }
            xmlDocument.Save(AppDomain.CurrentDomain.BaseDirectory + @"/bin/WeixinApi.XML");
        }

    }
}