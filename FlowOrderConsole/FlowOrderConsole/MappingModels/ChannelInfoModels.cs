using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowOrderConsole.MappingModels
{
    public  class ChannelInfoModels
    {
        public static CM023 CM023 { get; set; }
        public static CM023_02 CM023_02 { get; set; }
        public static CM023_03 CM023_03 { get; set; }
        public static CM023_04 CM023_04 { get; set; }
        /// <summary>
        /// 联通
        /// </summary>
        public static CT023XmlModels Ct023All { get; set; } 
        public static CT023XmlModels Ct023Pro { get; set; }
    }
}
