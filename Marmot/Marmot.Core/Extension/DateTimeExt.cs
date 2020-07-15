using System;

namespace Marmot.Core.Extension
{
    /// <summary>
    /// 日期扩展类
    /// </summary>
    public static class DateTimeExt
    {
        /// <summary>
        /// 日期扩展方法
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ToTimeStamp(this DateTime time)
        {
            DateTime starTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(TimeZoneInfo.ConvertTimeToUtc(time) - starTime).TotalMilliseconds;
        }

        /// <summary>
        /// DateTime转时间戳(秒)
        /// </summary>
        /// <param name="time"> DateTime时间格式</param>
        /// <returns>Unix时间戳格式</returns>
        public static long ToTimeStampSecond(this DateTime time)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (long)(time - startTime).TotalSeconds;
        }

        /// <summary>
        /// 时间戳(毫秒)转DateTime
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this long timeStamp)
        {
            if (timeStamp <= 0) return new DateTime(1970, 1, 1);
            try
            {
                DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                return startTime.AddMilliseconds(timeStamp);
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// GetMondayDateTime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime GetMondayDateTime(this DateTime time)
        {
            int i = time.DayOfWeek - DayOfWeek.Monday;
            if (i == -1) i = 6;// i值 > = 0 ，因为枚举原因，Sunday排在最前，此时Sunday-Monday=-1，必须+7=6。 
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return time.Subtract(ts);
        }

        /// <summary>
        /// GetMondayDate
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime GetMondayDate(this DateTime time)
        {
            return time.GetMondayDateTime().Date;
        }

        /// <summary>
        /// GetSundayDateTime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime GetSundayDateTime(this DateTime time)
        {
            int i = time.DayOfWeek - DayOfWeek.Sunday;
            if (i != 0) i = 7 - i;// 因为枚举原因，Sunday排在最前，相减间隔要被7减。 
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return time.Add(ts);
        }

        /// <summary>
        /// GetSundayDate
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime GetSundayDate(this DateTime time)
        {
            return time.GetSundayDateTime().Date;
        }
    }
}
