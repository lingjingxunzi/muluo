using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.Model.Reports
{
    public class PassagewayDataModels
    {
        public string name { get; set; }
        public int counts { get; set; }
        public int key { get; set; }

        public SystemUsers SystemUsers { get; set; }

        public Enumerations EnumName { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }



        
    }
}
