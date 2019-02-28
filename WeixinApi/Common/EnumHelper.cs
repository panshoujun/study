using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common
{
    public class EnumHelper
    {

        #region ppg
        /// <summary>
        /// 获取某个枚举类型的数据源，数据源是描述和值的组合，返回字段是 Key(description)/Value(int)
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <returns>集合</returns>
        public static List<System.Collections.DictionaryEntry> GetBindData<TEnum>()
        {
            var obj = ResolveEnum<TEnum>();

            return obj;
        }

        static List<System.Collections.DictionaryEntry> ResolveEnum<TEnum>()
        {
            Type type = typeof(TEnum);

            if (!type.IsEnum)
            {
                throw new ArgumentException("TEnum requires a Enum", "TEnum");
            }

            FieldInfo[] fields = type.GetFields();

            List<System.Collections.DictionaryEntry> col = new List<System.Collections.DictionaryEntry>();

            foreach (FieldInfo field in fields)
            {
                object[] objs = field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);

                if (objs != null && objs.Length > 0)
                {
                    System.ComponentModel.DescriptionAttribute attr = objs[0] as System.ComponentModel.DescriptionAttribute;

                    col.Add(new System.Collections.DictionaryEntry(attr.Description, ((int)Enum.Parse(type, field.Name)).ToString()));
                }

            }

            return col;
        }
        #endregion

        #region 融创
        /// <summary>
        /// 把枚举转换成key=value value=Description(描述) 的字典
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Dictionary<int, string> EnumToDicByDescription(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("传入的参数必须是枚举类型！", "enumType");
            }
            Dictionary<int, string> enumDic = new Dictionary<int, string>();
            //Array enumValues = Enum.GetValues(enumType);
            //foreach (Enum enumValue in enumValues)
            //{
            //    int key = Convert.ToInt32(enumValue);
            //    string value = Description(enumValue);
            //    enumDic.Add(key, value);
            //}
            foreach (Enum value in Enum.GetValues(enumType))
            {
                enumDic.Add(Convert.ToInt32(value), Description(value));
            }
            return enumDic;
        }

        /// <summary>
        /// 把枚举转换成key=value value=Description(描述) 的字典
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Dictionary<int, string> EnumToDicByDescription(Enum item)
        {
            return EnumToDicByDescription(item.GetType());
        }

        /// <summary>
        /// 把枚举转换成key=key value=value 的字典
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Dictionary<string, int> EnumToDic(Enum item)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            string[] keys = Enum.GetNames(item.GetType());
            Array values = Enum.GetValues(item.GetType());

            for (int i = 0; i < keys.Length; i++)
            {
                dic.Add(keys[i], (int)values.GetValue(i));
            }

            return dic;
        }

        /// <summary>
        /// 把枚举转换成key=key value=value 的字典
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Dictionary<string, int> EnumToDic(Type  item)
        {
            if (!item.IsEnum)
            {
                throw new ArgumentException("传入的参数必须是枚举类型！", "item");
            }

            Dictionary<string, int> dic = new Dictionary<string, int>();

            //string[] keys = Enum.GetNames(item);
            //Array values = Enum.GetValues(item);

            //for (int i = 0; i < keys.Length; i++)
            //{
            //    dic.Add(keys[i], (int)values.GetValue(i));
            //}

            foreach (int value in Enum.GetValues(item))
            {
                dic.Add(Enum.GetName(item,value), value);
            }

            return dic;
        }
        #endregion



        /// <summary>
        /// 获取枚举值对应的描述（Description属性）
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Description(Enum value)
        {
            if (value==null)
            {
                return "";
            }
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi == null)
                return value.ToString();
            DescriptionAttribute[] attributes =
                  (DescriptionAttribute[])fi.GetCustomAttributes(
                  typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }


        /// <summary>
        /// 还未完成
        /// </summary>
        /// <param name="value"></param>
        /// <param name="attr"></param>
        /// <returns></returns>
        public static string Description(Enum value,Attribute attr)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi == null)
                return value.ToString();
            DescriptionAttribute[] attributes =
                  (DescriptionAttribute[])fi.GetCustomAttributes(
                  typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }




    }
}
