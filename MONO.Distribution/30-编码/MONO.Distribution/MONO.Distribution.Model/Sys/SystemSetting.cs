using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.Sys
{
    public class SystemSetting : ModelBase
    {
        public int SystemSettingKey { get; set; }
        public int SysUserKey { get; set; }
        public string IsDefaultProvnice { get; set; }
        public string IsSendMsg { get; set; }
        public string IsAfterFaildToSave { get; set; }
    }
}
