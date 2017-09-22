using System;

namespace MONO.Distribution.Model.Sys
{
    public class SystemAccountLog:ModelBase
    {
        public Guid AccountLogKey { get; set; }
        public int CompanyAccountKey { get; set; }
        public string OperaType { get; set; }
        public decimal Integral { get; set; }
        public DateTime OperaDate { get; set; }
        public decimal BeforeIntegral { get; set; }
        public decimal AfterIntegral { get; set; }
        public string Seq { get; set; }

        public Enumerations EnumType { get; set; }

        public SystemAccount SystemAccount { get; set; }

        public string GetOperName
        {
            get
            {
                switch (OperaType)
                {
                    case "ZS":
                        return "赠送";
                        break;
                    case "XG":
                        return "修改";
                        break;
                    case "ZR":
                        return "转入";
                        break;
                    case "ZC":
                        return "转出";
                        break;
                    case "YS":
                        return "盈利";
                        break;
                    case "":
                        return "系统退回";
                }
                return "未知";
            }
            set { }
        }


        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
