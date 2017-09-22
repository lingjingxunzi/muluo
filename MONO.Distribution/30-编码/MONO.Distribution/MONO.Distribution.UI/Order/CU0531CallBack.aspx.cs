using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;

namespace MONO.Distribution.UI.Order
{
    public partial class CU0531CallBack : Page
    {
        public CU0531CallBack()
        {
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _flowActiveHistoriesService = new FlowActiveHistoriesService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LogMsg.Info(Request.Url);
                var orderId = Request.QueryString["serialNo"];
                var result = Request.QueryString["result"];
                var msg = Request.QueryString["msg"];
                if (string.IsNullOrEmpty(orderId)) return;
                var hisInfo = _flowActiveHistoriesService.SelectFlowActiveHistoriesByOrderId(orderId);
                try
                {

                    if (hisInfo == null) return;
                    if (!hisInfo.FlowStatus.Equals("0001")) return;
                    hisInfo.Orders = orderId;
                    hisInfo.FlowStatus = result;
                    hisInfo.Results = msg;
                    _flowActiveHistoriesService.Update(hisInfo);
                }
                catch (Exception ex)
                {
                    LogMsg.Error("返回执行错误！");
                    LogMsg.Error(ex.Message);
                }

            }
        }
        

        private IFlowActiveHistoriesService _flowActiveHistoriesService;
        private ILog LogMsg;
    }
}