using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI;
using log4net;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Model.FlowAgentViewModels;

namespace MONO.Distribution.UI.Order
{
    public partial class JTCallBack : Page
    {
        public JTCallBack()
        {
            _flowActiveHistoriesService = new FlowActiveHistoriesService();
            _flowActiveRecordService = new FlowDistributionRecordsService();
            logMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            logMsg.Info(Request.Url);
            logMsg.Info(Request.Url);
            if (!IsPostBack)
            {
                logMsg.Info("JTCallBack start");
                var result = new JTCallBackModel
                {
                    FlowKey = Request.QueryString["FlowKey"],
                    FailReason = Request.QueryString["FailReason"],
                    OrderStatus = Request.QueryString["OrderStatus"],
                    OrderKey = Request.QueryString["OrderKey"]
                };
                logMsg.Info("JTCallBack end");
                logMsg.Info(result);
                CallBackMethod(result);
            }
        }

        private void CallBackMethod(JTCallBackModel resutl)
        {
            try
            {
                logMsg.Info("JT get Start");
                logMsg.Info("orderstatus：" + resutl.OrderStatus);
                var status = resutl.OrderStatus.Equals("Success") ? "0" : resutl.OrderStatus;
                logMsg.Info("FlowKey：" + resutl.FlowKey);
                var info = new FlowActiveHistories();
                info = _flowActiveHistoriesService.FindById(resutl.FlowKey);
                if (info == null) return;
                if (!info.FlowStatus.Equals("0001")) return;
                logMsg.Info("FlowKey:" + resutl.FlowKey);
                logMsg.Info("status:" + status);
                logMsg.Info("OrderKey:" + resutl.OrderKey);
                logMsg.Info("FailReason:" + resutl.FailReason);
                info.Orders = resutl.OrderKey;
                info.FlowStatus = status;
                info.Results = resutl.FailReason;
                _flowActiveHistoriesService.Update(info);
            }
            catch (Exception ex)
            {
                logMsg.Error("返回执行错误！");
                logMsg.Error(ex.Message);
            }
        }



        private string GetJsonStr()
        {
            string result = "";
            string jsonStr = "", line;
            try
            {
                logMsg.Info("GetJsonStr Start");
                var streamResponse = Request.InputStream;
                var streamRead = new StreamReader(streamResponse, Encoding.UTF8);

                while ((line = streamRead.ReadLine()) != null)
                {
                    logMsg.Info(line);
                    jsonStr += line;
                }
                streamResponse.Close();
                streamRead.Close();
                logMsg.Info(jsonStr);
                result = jsonStr;
            }
            catch (Exception ex)
            {
                result = "msg-数据发布（In）异常：" + ex.Message;
                logMsg.Info(result);
            }
            return result;
        }

        private ILog logMsg;
        private readonly IFlowDistributionRecordsService _flowActiveRecordService;
        private readonly IFlowActiveHistoriesService _flowActiveHistoriesService;

        private string _title;
    }
}