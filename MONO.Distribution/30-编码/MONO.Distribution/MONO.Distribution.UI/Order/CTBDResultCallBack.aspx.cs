using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.BaseInfo;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.Model.FlowAgentViewModels;

namespace MONO.Distribution.UI.Order
{
    public partial class CTBDResultCallBack : System.Web.UI.Page
    {

        public CTBDResultCallBack()
        {
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _flowDistributionRecordsService = new FlowDistributionRecordsService();
            _flowActiveHistoriesService = new FlowActiveHistoriesService();
            _flowCodeService = new FlowCodeService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LogMsg.Info(Request.Url);
                if (GetQueryString() != "200")
                {
                    Response.Write("403");
                    return;
                }
                Response.Write(UpdateStatus());
            }
        }

        private string UpdateStatus()
        {
            if (CT023_PModels.GetResult().Equals("-10013"))
            {
                return "200";
            }
            if (!historiesKey.Equals(CT023_PModels.GetOrders()))
            {
                historiesKey = CT023_PModels.GetOrders();
            }
            var historiesInfo = _flowActiveHistoriesService.FindById(historiesKey);
            if (historiesInfo == null)
                return "200";
            if (!historiesInfo.FlowStatus.Equals("0001"))
                return "200";
            var result = CT023_PModels.GetResult();
            LogMsg.Info(result);
            historiesInfo.UpdateTime = DateTime.Now;
            historiesInfo.FlowStatus = result;
            historiesInfo.Orders = CT023_PModels.GetTransNo();
            historiesInfo.Results = result;
            LogMsg.Info(historiesInfo.Results);
            if (!result.Equals("0001"))
            {
                _flowActiveHistoriesService.Update(historiesInfo);
            }
            else
            {
                _flowActiveHistoriesService.UpdateHistoryStatus(historiesInfo);
                var disInfo = _flowDistributionRecordsService.FindById(historiesInfo.DistributionRecordKey);
                if (disInfo != null)
                {
                    disInfo.OrderStatus = "WaitCallBack";
                    _flowDistributionRecordsService.Update(disInfo);
                }
            }
            return "200";
        }



        private string GetQueryString()
        {
            LogMsg.Info(Request.Params["data"]);
            historiesKey = Request.Params["TransKey"];
            try
            {
                CT023_PModels = new JavaScriptSerializer().Deserialize<CT023BDResultModels>(Request.Params["data"]);
            }
            catch (Exception ex)
            {
                LogMsg.Error(ex.Message + "字符串：" + Request.Params["data"]);
            }
            return "200";

        }

        private VatResultBase _vatResultBase = new VatResultBase();
        private IFlowActiveHistoriesService _flowActiveHistoriesService;
        private IFlowDistributionRecordsService _flowDistributionRecordsService;
        private IFlowCodeService _flowCodeService;
        private CT023BDResultModels CT023_PModels;
        private ILog LogMsg;
        private string historiesKey;
    }
}