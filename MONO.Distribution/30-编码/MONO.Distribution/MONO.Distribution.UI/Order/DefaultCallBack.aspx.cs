using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.Order
{
    public partial class DefaultCallBack : Page
    {
        public DefaultCallBack()
        {
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _flowActiveRecordService = new FlowActiveHistoriesService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LogMsg.Info(Request.Url);
                try
                {
                    LogMsg.Info("参数个数:" + Request.Form.Count);
                    LogMsg.Info("serialNo:" + Request.QueryString["serialNo"]);
                    LogMsg.Info("result:" + Request.QueryString["result"]);
                    LogMsg.Info("msg:" + Request.QueryString["msg"]);
                    LogMsg.Info("passParm:" + Request.QueryString["passParm"]);
                    _orderId = GetPostGetParamer("serialNo");
                    _transNo = GetPostGetParamer("passParm");
                    _result = GetPostGetParamer("result");
                    _msg = GetPostGetParamer("msg");
                    CallbackMethod();
                }
                catch (Exception ex)
                {
                    LogMsg.Info(ex.Message);
                }
            }
        }


        public void CallbackMethod()
        {
            try
            {
                var status = _result.Equals("0") ? "0" : _result;
                var info = _flowActiveRecordService.FindById(_transNo);
                if (info == null) return;
                if (!info.FlowStatus.Equals("0001")) return;
                info.Orders = _orderId;
                info.FlowStatus = status;
                info.Results = _msg;
                _flowActiveRecordService.Update(info);
            }
            catch (Exception ex)
            {
                LogMsg.Error("返回执行错误！");
                LogMsg.Error(ex.Message);
            }
        }

         
        public String Base64ToString(string str)
        {
            byte[] bpath = Convert.FromBase64String(str);
            return ASCIIEncoding.Default.GetString(bpath);
        }

        public string StringToBase64(string str)
        {
            Encoding encode = Encoding.ASCII;
            byte[] bytedata = encode.GetBytes(str);
            return Convert.ToBase64String(bytedata, 0, bytedata.Length);
        }

        public string GetPostGetParamer(string name)
        {
            return Request.Params[name];
        }


        private string _content = "";
        private string sussecc = "您激活的流量包（{0}M/{1}/{2}）已激活{3}!";
        public string _transNo;
        private string _result;
        private string _orderId;
        private string Title = "您的流量包激活{0}";
        private string _title = "";
        private string _msg;
        private ResultMessage _resultMessage;


        private readonly IFlowActiveHistoriesService _flowActiveRecordService;

        private ILog LogMsg;
    }
}