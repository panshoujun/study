using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public  static class DateTimeExtension
    {
        public static DateTime DBNull = "1900-01-01 00:00:00".TryDateTime();

        /// <summary>
        /// 判断DateTime在数据库中是否存储为象征意义的null
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsDBNull(this DateTime dateTime)
        {
            return dateTime == DBNull;
        }

        /// <summary>
        /// 判断DateTime在数据库中是否存储为象征意义的null
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsDBNull(this DateTime? dateTime)
        {
            return dateTime == null || dateTime == DBNull;
        }

        /// <summary>
        /// 格式化为字符串
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string Format(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 获取当前周在当前年的顺序,从1开始
        /// </summary>
        /// <param name="Datetime"></param>
        /// <returns></returns>
        public static int WeekOfYear(this DateTime dtm, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            int iDayOfYear = dtm.DayOfYear;
            GregorianCalendar gc = new GregorianCalendar();
            return gc.GetWeekOfYear(dtm, CalendarWeekRule.FirstDay, firstDayOfWeek);
        }

        /// <summary>
        /// 格式化时间
        /// </summary>
        /// <param name="datetime">时间</param>
        /// <returns></returns>
        public static string FormatTime(this DateTime? datetime)
        {
            if (!datetime.HasValue) { return string.Empty; }

            return FormatTime(datetime.Value);

        }
        /// <summary>
        /// 格式化时间
        /// </summary>
        /// <param name="datetime">时间</param>
        /// <returns></returns>
        public static string FormatTime(this DateTime datetime)
        {
            DateTime nowTime = DateTime.Now;
            TimeSpan ts = nowTime - datetime;
            
            if (ts.Days == 0 && ts.Hours == 0)
            {
                if (ts.Minutes == 0) { return "1分钟前"; }
                return ts.Minutes + "分钟前";
            }
            else if (ts.Days == 0 && datetime.Date.Equals(nowTime.Date))
            {
                if(ts.Hours  == 1)
                {
                    return "1小时前";
                }
                return string.Format("今天{0}", datetime.ToString("HH:mm"));
            }
            else if (datetime.Date.Equals(nowTime.Date.AddDays(-1)))
            {
                return string.Format("昨天{0}", datetime.ToString("HH:mm"));

            }
            else if (datetime.Date.Equals(nowTime.Date.AddDays(-2)))
            {
                return string.Format("前天{0}", datetime.ToString("HH:mm"));
            }
            string timeFormat = nowTime.Year == datetime.Year ? "M月d日" : "yyyy年M月d日";
            return datetime.ToString(timeFormat);
        }


        /// <summary>
        /// 格式化时间+节气
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="solarTerm">节气</param>
        /// <returns></returns>
        public static string FormatTimeSolarTerm(this DateTime? datetime, string solarTerm = "")
        {
            if (!datetime.HasValue) { return string.Empty; }
            return FormatTimeSolarTerm(datetime.Value, solarTerm);

        }
        /// <summary>
        /// 格式化时间+节气
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="solarTerm">节气</param>
        /// <returns></returns>
        public static string FormatTimeSolarTerm(this DateTime datetime, string solarTerm = "")
        {
            DateTime nowTime = DateTime.Now;
            TimeSpan ts = nowTime - datetime;

            if (!string.IsNullOrEmpty(solarTerm))
            {
                solarTerm = "·" + solarTerm;
            }

            if (ts.Days == 0 && datetime.Date.Equals(nowTime.Date))
            {
                return string.Format("今天{0}", solarTerm);
            }
            else if (datetime.Date.Equals(nowTime.Date.AddDays(-1)))
            {
                return string.Format("昨天{0}", solarTerm);

            }
            else if (datetime.Date.Equals(nowTime.Date.AddDays(-2)))
            {
                return string.Format("前天{0}", solarTerm);
            }
            string timeFormat = nowTime.Year == datetime.Year ? "M月d日" : "yyyy年M月d日";
            return datetime.ToString(timeFormat) + solarTerm;
        }
    }
}
