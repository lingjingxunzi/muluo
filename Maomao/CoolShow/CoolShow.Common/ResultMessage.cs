using System;
using System.Collections.Generic;

namespace CoolShow.Common
{
    public class ResultMessage
    {
        #region 构造函数
        public ResultMessage()
        {
            this.IsOk = true;
            this.Errors = new Dictionary<string, string>();
        }
        #endregion

        #region 属性

        /// <summary>
        /// 结果:<remarks>当向Errors属性添加错误信息时，IsOk返回false，否则返回true。</remarks>
        /// </summary>
        private bool _isOk = true;
        public bool IsOk
        {
            get
            {
                _isOk = Errors.Count > 0 ? false : true;
                return _isOk;
            }
            protected set
            {
                _isOk = value;
            }
        }
        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 对应int数据类型主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 对应bigint数据类型主键
        /// </summary>
        public Int64 BigId { get; set; }

        

        public string IdStr { get; set; }

        /// <summary>
        /// 错误字典
        /// </summary>
        public IDictionary<string, string> Errors { get; set; }

        /// <summary>
        /// 影响行数。用于记录Update、Delete操作的影响行数。
        /// </summary>
        public int EffectRows { get; set; }

        #endregion
    }
}
