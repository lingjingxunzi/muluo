using System;

namespace CoolShow.Model
{
    /// <summary>
    /// 实体模型基类
    /// </summary>
    [Serializable]
    public class ModelBase
    {
        /// <summary>
        /// 是否统计记录数
        /// </summary>
        public bool IsCount { get; set; }
        /// <summary>
        /// 记录数
        /// </summary>
        public int Rows { get; set; }
        /// <summary>
        /// 是否启动分页
        /// </summary>
        public bool IsStartPager { get; set; }
        /// <summary>
        /// 起始记录索引
        /// </summary>
        public int StartRecordIndex { get; set; }
        /// <summary>
        /// 结束记录索引
        /// </summary>
        public int EndRecordIndex { get; set; }

       // public QueryTypeEnum QueryType { get; set; }
    }
}
