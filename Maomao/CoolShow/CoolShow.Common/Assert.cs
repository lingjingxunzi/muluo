using System;

namespace CoolShow.Common
{
    /// <summary>
    /// 断言辅助类
    /// </summary>
    public static class Assert
    {
        /// <summary>
        /// 断言对象是否为空
        /// </summary>
        /// <param name="source">待断言对象</param>
        /// <returns>断言对象为null时，返回false；否则为true</returns>
        public static bool IsNotNull(object source)
        {
            return source == null ? false : true;
        }

        /// <summary>
        /// 断言对象不允许为空
        /// </summary>
        /// <param name="source">待断言对象</param>
        public static void NotAllowNull(object source)
        {
            if (source == null)
            {
                throw new Exception("T对象不允许为null");
            }
        }
    }
}
