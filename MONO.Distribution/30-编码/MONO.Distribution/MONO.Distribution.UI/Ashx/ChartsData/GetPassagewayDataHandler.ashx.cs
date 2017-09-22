using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using MONO.Distribution.BLL.Interface.Reports;
using MONO.Distribution.BLL.Reports;
using MONO.Distribution.Model.Reports;
using MONO.Distribution.Model.ViewModel;

namespace MONO.Distribution.UI.Ashx.ChartsData
{
    /// <summary>
    /// GetPassagewayDataHandler 的摘要说明
    /// </summary>
    public class GetPassagewayDataHandler : IHttpHandler
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
            var passList = _passagewayDataModelsService.GetPassagewayDatas(new PassagewayDataModels { name = name });
            var itemList = new List<ChartSeriesViewModel>();
            if (passList.Count == 1 && passList.Sum(m => m.counts) == 0)
            {
                itemList.Add(new ChartSeriesViewModel { name = "暂无", y = 100 });

            }
            else
            {
                foreach (var item in passList)
                {
                    itemList.Add(new ChartSeriesViewModel { name = item.name, y = (item.counts * 100) / passList.Sum(m => m.counts) });
                }
            }
            return new JavaScriptSerializer().Serialize(itemList); ;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private IPassagewayDataModelsService _passagewayDataModelsService = new PassagewayDataModelsService();
    }
}