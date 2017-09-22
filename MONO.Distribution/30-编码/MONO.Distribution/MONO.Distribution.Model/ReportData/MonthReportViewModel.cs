using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.ReportData
{
    public class MonthReportViewModel
    {
        public string Nick { get; set; }
        public IList<decimal> OrderPrice { get; set; } 
    }
}
