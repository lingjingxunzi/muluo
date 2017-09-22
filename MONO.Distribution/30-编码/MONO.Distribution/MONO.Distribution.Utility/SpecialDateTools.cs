using System;

namespace MONO.Distribution.Utility
{
    public class SpecialDateTools
    {
        /// <summary>  
        /// 获取指定月份最后一天  
        /// </summary>  
        /// <param name="dateTime"></param>  
        /// <returns></returns>  
        public static DateTime GetDateTimeMonthLastDay(DateTime dateTime)
        {
            int day = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);

            return new DateTime(dateTime.Year, dateTime.Month, day,23,59,59);
        } 
    }
}
