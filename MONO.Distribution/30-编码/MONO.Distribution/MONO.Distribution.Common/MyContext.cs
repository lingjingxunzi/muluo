
using System.Threading;

namespace MONO.Distribution.Common
{
    /// <summary>
    /// 自定义上下文信息
    /// </summary>
    public class MyContext
    {
        public string USER = "User";
        public string USER_ID = "UserId";
        public string USER_NAME = "UserName";
        public string Enter_Type = "Enter";

        private MyContext()
        {

        }

        public static MyContext Instance
        {
            get
            {
                return new MyContext();
            }
        }

        /// <summary>
        /// 当前登录用户
        /// </summary>
        public object CurrentUser
        {
            set
            {
                Thread.SetData(Thread.GetNamedDataSlot(USER), value);
            }
            get
            {
                return Thread.GetData(Thread.GetNamedDataSlot(USER));
            }
        }

        /// <summary>
        /// 当前登录用户
        /// </summary>
        public int UserId
        {
            set { Thread.SetData(Thread.GetNamedDataSlot(USER_ID), value); }
            get
            {
                return Thread.GetData(Thread.GetNamedDataSlot(USER_ID)) is int
                           ? (int) Thread.GetData(Thread.GetNamedDataSlot(USER_ID))
                           : 0;
            }
        }


        /// <summary>
        /// 当前登录用户
        /// </summary>
        public string UserName
        {
            set { Thread.SetData(Thread.GetNamedDataSlot(USER_NAME), value); }
            get
            {
                return Thread.GetData(Thread.GetNamedDataSlot(USER_NAME)) is string
                           ? (string)Thread.GetData(Thread.GetNamedDataSlot(USER_NAME))
                           : "";
            }
        }

        /// <summary>
        /// 当前登录用户
        /// </summary>
        public string EnterType
        {
            set { Thread.SetData(Thread.GetNamedDataSlot(Enter_Type), value); }
            get
            {
                return Thread.GetData(Thread.GetNamedDataSlot(Enter_Type)) is string
                           ? (string)Thread.GetData(Thread.GetNamedDataSlot(Enter_Type))
                           : "";
            }
        }

        /// <summary>
        /// 释放线程数据
        /// </summary>
        /// <param name="name"></param>
        public void FreeThreadDate(string name)
        {
            Thread.FreeNamedDataSlot(name);
        }
    }
}
