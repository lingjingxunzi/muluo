using System.Collections.Generic;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.Model.BaseInfo
{
    public class FlowBaseInfo : ModelBase
    {
        public virtual string Name { get; set; }
        public virtual int FlowKey { get; set; }
        public virtual string From { get; set; }
        public virtual int Size { get; set; }
        public virtual decimal StandardPrice { get; set; }
        public virtual string Range { get; set; }
        public virtual string PlatformCode { get; set; }
        public virtual string Status { get; set; }
        public virtual string GRange { get; set; }
        /// <summary>
        /// 是否并行处理（重庆移动使用）“Y”为并行处理，分文件存储，“N”或者为空时不并行处理
        /// </summary>
        public string IsInterParallel { get; set; }
        /// <summary>
        /// 是否循环“Y”为循环。“N”或者为空是不循环
        /// </summary>
        public string IsRecyle { get; set; }

        public virtual string ChannelStatus { get; set; }
        public Enumerations EnumFrom { get; set; }
        public Enumerations EnumRange { get; set; }

        public Enumerations EnumGRange { get; set; }



        public string FlowName
        {
            get { return Name; }
            set { }
        }

        public string FlowNameWithPrice
        {
            get { return Name + " 标准价：" + StandardPrice + "积分"; }
            set { }
        }


        public IList<int> FlowkeyListForQuery { get; set; }
    }
}
