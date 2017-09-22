using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowOrderConsole.Models
{
    public class BackupViewModel
    {
        public string DataBackupKey { get; set; }
        public string BackNumber { get; set; }
        public string BackStyle { get; set; }
        public string BackupTime { get; set; }
        public string BackupUrl { get; set; }
        public string Cycle { get; set; }
        public string TableName { get; set; }

        public string Style { get; set; }

        public DateTime BackupNextDate { get; set; }
    }
}
