﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using System.Web.Http.Dispatcher;
using Swashbuckle.Swagger;

namespace WeixinApi.Filters
{
    /// <summary>
    /// Swagger区域文档过滤器
    /// </summary>
    public class SwaggerAreasSupportDocumentFilter : IDocumentFilter
    {
        /// <summary>
        /// 申请处理
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="apiExplorer"></param>
        public void Apply1(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            IDictionary<string, PathItem> replacePaths = new ConcurrentDictionary<string, PathItem>();
            foreach (var item in swaggerDoc.paths)
            {
                string key = item.Key;
                var value = item.Value;
                var keys = key.Split('/');

                if (keys[3].IndexOf('.') != -1)
                {
                    // 区域路径
                    string areasName = keys[2];
                    string namespaceFullName = keys[3];
                    var directoryNames = namespaceFullName.Split('.');
                    string namespaceName = directoryNames[2];
                    if (areasName.Equals(namespaceName, StringComparison.OrdinalIgnoreCase))
                    {
                        string controllerName = directoryNames[5];
                        replacePaths.Add(
                            item.Key.Replace(namespaceFullName,
                                controllerName.Substring(0,
                                    controllerName.Length - DefaultHttpControllerSelector.ControllerSuffix.Length)),
                            value);
                    }
                }
                else if (keys[2].IndexOf('.') != -1)
                {
                    // 基础路径
                    string namespaceFullName = keys[2];
                    var directoryNames = namespaceFullName.Split('.');
                    bool isControllers = directoryNames[2].Equals("Controllers", StringComparison.OrdinalIgnoreCase);
                    string controllerName = directoryNames[2];
                    if (isControllers)
                    {
                        replacePaths.Add(
                        item.Key.Replace(namespaceFullName,
                            controllerName.Substring(0,
                                controllerName.Length - DefaultHttpControllerSelector.ControllerSuffix.Length)), value);
                    }
                }
            }
            swaggerDoc.paths = replacePaths;
        }

        /// <summary>
        /// 申请处理
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="apiExplorer"></param>
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            IDictionary<string, PathItem> replacePaths = new ConcurrentDictionary<string, PathItem>();
            var nplen = 1; //程序集的命名空间用.分隔之后数组长度 应用程序的命名空间（如WeixinApi表示1   WeixinApi.Swagger表示2）
            foreach (var item in swaggerDoc.paths)
            {
                string key = item.Key;
                var value = item.Value;
                var keys = key.Split('/');

                if (keys[3].IndexOf('.') != -1)
                {
                    // 区域路径
                    string areasName = keys[2];
                    string namespaceFullName = keys[3];
                    var directoryNames = namespaceFullName.Split('.');
                    string namespaceName = directoryNames[nplen + 1];
                    if (areasName.Equals(namespaceName, StringComparison.OrdinalIgnoreCase))
                    {
                        string controllerName = directoryNames[nplen + 3];
                        replacePaths.Add(
                            item.Key.Replace(namespaceFullName,
                                controllerName.Substring(0,
                                    controllerName.Length - DefaultHttpControllerSelector.ControllerSuffix.Length)),
                            value);
                    }
                }
                else if (keys[2].IndexOf('.') != -1)
                {
                    // 基础路径
                    string namespaceFullName = keys[2];
                    var directoryNames = namespaceFullName.Split('.');
                    bool isControllers = directoryNames[nplen].Equals("ApiControllers", StringComparison.OrdinalIgnoreCase);
                    string controllerName = directoryNames[nplen + 1];
                    if (isControllers)
                    {
                        if (controllerName.Contains(DefaultHttpControllerSelector.ControllerSuffix))
                        {
                            replacePaths.Add(item.Key.Replace(namespaceFullName,
                                                        controllerName.Substring(0,
                                                            controllerName.Length - DefaultHttpControllerSelector.ControllerSuffix.Length)), value);
                        }
                        else
                        {
                            replacePaths.Add(controllerName, value);
                        }

                    }
                }
            }
            swaggerDoc.paths = replacePaths;
        }
    }
}