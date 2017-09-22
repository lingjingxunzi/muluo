using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.Sys
{
    public class DataBackups : ModelBase
    {
        public int DataBackupKey { get; set; }
        public string BackNumber { get; set; }
        public string BackStyle { get; set; }
        public string Cycle { get; set; }
        public string TableName { get; set; }
        public string BackupUrl { get; set; }
        public DateTime BackupTime { get; set; }

        public Enumerations EnumStyle { get; set; }
        public Enumerations EnumCycle { get; set; }


        public string FileFolder { get; set; }
        public string TableNameBack { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}
