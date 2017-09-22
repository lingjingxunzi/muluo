using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.Model.FlowAgentViewModels;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.Order
{
    public partial class XytdCallBack : System.Web.UI.Page
    {
        public XytdCallBack()
        {
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _flowActiveRecordService = new FlowDistributionRecordsService();
            _flowActiveHistoriesService = new FlowActiveHistoriesService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LogMsg.Info(Request.Url);
                var str = GetJsonStr();
                LogMsg.Info(str);
                LogMsg.Info(str.TrimStart('[').TrimEnd(']'));
                var model = new JavaScriptSerializer().Deserialize<XYCallBackModels>(str.TrimStart('[').TrimEnd(']'));
                if (model.o_id.Contains("L-"))
                {
                    LogMsg.Info("跳转至流吧平台");
                    var url = "http://www.5liuba.net/ActiveInterface/XytdCallBack.aspx?status=" + model.status + "&o_id=" + model.o_id + "&msg=" + model.msg + "&xy_order=" + model.xy_order;
                    LogMsg.Info(url);
                    HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                    return;
                }
                
                CallBackMethod(model);
                Response.Expires = -1;
                Response.Clear();
                Response.ContentEncoding = Encoding.UTF8;
                Response.ContentType = "application/json";
                Response.Write("0000");
                Response.End();
            }
        }

        private void CallBackMethod(XYCallBackModels model)
        {
            try
            {
                var status = model.status.Equals("0000") ? "0" : model.status;
                var info = _flowActiveHistoriesService.FindById(model.o_id);
                LogMsg.Info("hisInfo:"+info);
                if (info == null) return;
                LogMsg.Info(info.FlowStatus);
                LogMsg.Info(!string.IsNullOrEmpty(info.FlowStatus));
                if (string.IsNullOrEmpty(info.FlowStatus)) return;
                info.Orders = model.o_id;
                info.FlowStatus = status;
                info.Results = model.msg;
                _flowActiveHistoriesService.Update(info);
            }
            catch (Exception ex)
            {
                LogMsg.Error("返回执行错误！");
                LogMsg.Error(ex.Message);
            }

        }



        private string GetJsonStr()
        {
            string result = "";
            string jsonStr = "", line;
            try
            {
                var streamResponse = Request.InputStream;
                var streamRead = new StreamReader(streamResponse, Encoding.UTF8);
                while ((line = streamRead.ReadLine()) != null)
                {
                    jsonStr += line;
                }
                streamResponse.Close();
                streamRead.Close();
                result = jsonStr;
            }
            catch (Exception ex)
            {
                result = "msg-数据发布（In）异常：" + ex.Message;
            }
            return result;
        }



        private ILog LogMsg;
        private readonly IFlowDistributionRecordsService _flowActiveRecordService;
        private readonly IFlowActiveHistoriesService _flowActiveHistoriesService;

    }
}