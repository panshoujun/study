using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 序列化和反序列化
    /// </summary>
    public class SerializationHelp
    {
        /// <summary>
        /// 静态对象
        /// </summary>
        static IsoDateTimeConverter IsoDateTimeConverter = new IsoDateTimeConverter
        {
            DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
        };
        static JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            //获取或设置空值的序列化和反序列化期间处理。
            NullValueHandling = NullValueHandling.Ignore,// 忽略null
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            //设置参数为Formatting.Indented可输出格式化后的json
            Formatting = Formatting.Indented,
        };

        /// <summary>
        /// 
        /// </summary>
        static SerializationHelp()
        {
            JsonSerializerSettings.Converters.Add(IsoDateTimeConverter);
        }

        #region 对象序列化和反序列化
        /// <summary>
        ///  转换对象为json格式字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJSON(object obj, IsoDateTimeConverter timeConverter = null)
        {
            // 设置参数为Formatting.Indented可输出格式化后的json
            //SInner 2015-12-24 采用默认序列化设置
            if (timeConverter != null)
            {
                /* 设置参数为Formatting.Indented可输出格式化后的json
                * 避免污染 JsonSerializerSettings 全局默认设置
                * 采用构造新对象
                */
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
                {
                    //获取或设置空值的序列化和反序列化期间处理。
                    NullValueHandling = NullValueHandling.Ignore,// 忽略null
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    //设置参数为Formatting.Indented可输出格式化后的json
                    Formatting = Formatting.Indented,
                };
                jsonSerializerSettings.Converters.Add(timeConverter);
                return JsonConvert.SerializeObject(obj, jsonSerializerSettings);
            }
            else
            {

                return JsonConvert.SerializeObject(obj, Formatting.None, JsonSerializerSettings);
            }
        }

        //public static string ToJSON(object obj, IsoDateTimeConverter converter)
        //{
        //    /* 设置参数为Formatting.Indented可输出格式化后的json
        //     * 避免污染 JsonSerializerSettings 全局默认设置
        //     * 采用构造新对象
        //     */
        //    JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        //    {
        //        NullValueHandling = NullValueHandling.Ignore,
        //        ContractResolver = new CamelCasePropertyNamesContractResolver()
        //    };
        //    jsonSerializerSettings.Converters.Add(converter);
        //    return JsonConvert.SerializeObject(obj, jsonSerializerSettings);
        //}

        /// <summary>
        /// OBJECT -> JSON
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToJson(object obj, IsoDateTimeConverter timeConverter = null)
        {
            //设置参数为Formatting.Indented可输出格式化后的json
            //JsonConvert.SerializeObject(obj);
            if (timeConverter == null)
            {
                //timeConverter = new IsoDateTimeConverter();
                //timeConverter.DateTimeFormat = "yyyy-MM-dd";
                timeConverter = IsoDateTimeConverter;
            }
            return JsonConvert.SerializeObject(obj, Formatting.Indented, timeConverter);
        }

        /// <summary>
        /// JSON -> OBJECT
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string jsonData) where T : class, new()
        {
            return JsonConvert.DeserializeObject<T>(jsonData);
        }

        /// <summary>
        /// JSON -> OBJECT
        /// </summary>
        /// <param name="jsonData"></param>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public static object JsonToObject(string jsonData, Type objectType)
        {
            try
            {
                return JsonConvert.DeserializeObject(jsonData, objectType);
            }
            catch
            {
                throw new Exception(string.Format("Json deserialize object(Type:{0}) has occurrence exception !", objectType.FullName));
            }
        }
        #endregion

        #region 文件序列化和反序列化
        /// <summary>
        /// OBJECT -> JSON
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static void ObjectToJsonFile(object obj, string filePath)
        {
            //JsonConvert.SerializeObject(obj);
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
            timeConverter.DateTimeFormat = "yyyy-MM-dd";
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented, timeConverter);
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// JSON -> OBJECT
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public static T JsonFileToObject<T>(string filePath) where T : class, new()
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }
        #endregion

    }
}
