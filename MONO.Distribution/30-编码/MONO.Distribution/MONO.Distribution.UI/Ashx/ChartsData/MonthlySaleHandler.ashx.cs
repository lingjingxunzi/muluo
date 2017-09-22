using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using MONO.Distribution.BLL.BaseInfo;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.BLL.Interface.Reports;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Reports;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.Model.ReportData;
using MONO.Distribution.Model.Reports;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Model.ViewModel;

namespace MONO.Distribution.UI.Ashx.ChartsData
{
    /// <summary>
    /// MonthlySaleHandler 的摘要说明
    /// </summary>
    public class MonthlySaleHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json;charset=UTF-8";
            context.Response.CacheControl = "no-cache";
            context.Response.Expires = 0;
            context.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
            context.Response.Write(GetData(context));
        }


        private string GetData(HttpContext context)
        {
            var name = context.Request["name"];
            var date = context.Request["dates"];
            var userList = _systemUsersService.SelectSystemUserListForMonthReport(new SystemUsers { QueryDate = date });
            IList<MonthReportViewModel> list = new List<MonthReportViewModel>();
            foreach (var us in userList)
            {
                var mr = new MonthReportViewModel();
                IList<decimal> usCount = _systemUsersService.SelectSystemUserListForMonthList(new SystemUsers() { QueryName = name, QueryDate = date, SysUserKey = us.SysUserKey });
                mr.Nick = us.Nick;
                mr.OrderPrice = usCount;
                //mr.OrderPrice = new List<decimal> { (decimal)7851.16, (decimal)7851.16, (decimal)7851.16, (decimal)7851.16, (decimal)7851.16, (decimal)7851.16, (decimal)7851.16 };
                list.Add(mr);
            }

            return new JavaScriptSerializer().Serialize(list); ;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private ISystemUsersService _systemUsersService = new SystemUsersService();
        private IFlowBaseInfoService _flowBaseInfoService = new FlowBaseInfoService();
        private IPassagewayDataModelsService _passagewayDataModelsService = new PassagewayDataModelsService();
    }
}