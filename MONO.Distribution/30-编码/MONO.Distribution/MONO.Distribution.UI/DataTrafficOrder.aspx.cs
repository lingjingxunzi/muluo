using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using log4net;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.BaseInfo;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Model.AgentModel;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;
using MONO.FB.BLL.Sys;

namespace MONO.Distribution.UI
{
    public partial class DataTrafficOrder : System.Web.UI.Page
    {
        public DataTrafficOrder()
        {
            logMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _flowBaseInfoService = new FlowBaseInfoService();
            _systemFlowPacketsService = new SystemFlowPacketsService();
            _businessIpBindService = new FB_BusinessIPBindService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Sign = Request.Headers["QXCX-Signature"];
                Account = Request.Headers["QXCX-ACCOUNT"];
                ParamXml = GetJsonStr();
                ValidateRequestInfo();
            }
        }

        private void ValidateRequestInfo()
        {
            ValidateHeadInfo();
            ValidateParams();

        }

        private void ValidateParams()
        {
            if (string.IsNullOrEmpty(Account))
            {
                logMsg.Info("Account 为空！");
                throw new HttpException(400, "错误的请求");
            }
            if (string.IsNullOrEmpty(Sign))
            {
                logMsg.Info("Sign 为空！");
                throw new HttpException(400, "错误的请求");
            }
            accountInfoViewModels = new RequestAccountInfoViewModels();
            InitAccountToken(Account, accountInfoViewModels);
            orderAgentRequestViewModel = new OrderAgentRequestViewModel();
            InitParamInfo(ParamXml, orderAgentRequestViewModel);
            ValidateDateTime();
            var currentAccount = _systemUsersService.SelectByAccount(accountInfoViewModels.AppID);
            ValidateSign(currentAccount);
            ValidateIP(currentAccount);
            ValidateAccountInfo(currentAccount);
            ValidateFlowInfo(currentAccount);
        }

        private void ValidateIP(SystemUsers currentAccount)
        {
            var ip = GetIPHelper.GetIP();
            logMsg.Info("商户IP：" + ip);
            var ipInfo = _businessIpBindService.FindAll(new BusinessIPBind { SysUserKey = currentAccount.SysUserKey });
            if (ipInfo.Count > 0)
            {
                if (_businessIpBindService.GetCount(new BusinessIPBind { IP = ip, SysUserKey = currentAccount.SysUserKey }) == 0)
                {
                    logMsg.Info("IP已限制：" + ip + "非法");
                    throw new HttpException(400, "错误的请求");
                }
            }
        }

        private void ValidateSign(SystemUsers currentAccount)
        {
            var signStr = currentAccount.AgentSec + "||" + orderAgentRequestViewModel.ProductId + "||" + orderAgentRequestViewModel.DateTime + "||" + currentAccount.AgentSec;
            var signResult = CarrierCharManipulation.GetStrByMd5(signStr);
            if (!signResult.Substring(4, signResult.Length - 8).ToLower().Equals(Sign.ToLower()))
            {
                logMsg.Info("Sign不匹配：" + signResult + "!= " + Sign);
                throw new HttpException(400, "错误的请求");
            }
        }

        private void ValidateFlowInfo(SystemUsers currentAccount)
        {
            var flowInfo = _flowBaseInfoService.SelectFlowBaseInfoByFlowCode(orderAgentRequestViewModel.ProductId);
            if (flowInfo == null)
            {
                logMsg.Info("未找到对应的产品信息：" + orderAgentRequestViewModel.ProductId);
                throw new HttpException(400, "错误的请求");
            }
            if (flowInfo.Size == int.Parse(orderAgentRequestViewModel.Size))
            {
                logMsg.Info("产品信息和传入大小不匹配：" + orderAgentRequestViewModel.Size + "!= " + flowInfo.Size);
                throw new HttpException(400, "错误的请求");
            }
            var systemPackge = _systemFlowPacketsService.SelectSystemFlowPacketBySystemKey(new SystemFlowPackets { SysUserKey = currentAccount.SysUserKey, FlowPacketKey = flowInfo.FlowKey });
            if (systemPackge == null)
            {
                logMsg.Info("该用户没有该产品的权限：" + orderAgentRequestViewModel.ProductId + ":" + accountInfoViewModels.AppID);
                throw new HttpException(400, "错误的请求");
            }
            if (systemPackge.Status.Equals("N"))
            {
                logMsg.Info("该用户没有该产品的权限：" + orderAgentRequestViewModel.ProductId + ":" + accountInfoViewModels.AppID);
                requestResultViewModel.Code = "107";//该账户已冻结
                requestResultViewModel.Result = "该用户没有该产品的权限！";
                return;
            }
            var froms = GetPhoneFromsHandler.GetInstance().GetFroms(orderAgentRequestViewModel.MobilePhone);
            if (!froms.Equals(flowInfo.From))
            {
                logMsg.Info("该手机号码于产品不匹配：" + orderAgentRequestViewModel.MobilePhone + ":" + orderAgentRequestViewModel.MobilePhone);
                requestResultViewModel.Code = "104";//该账户已冻结
                requestResultViewModel.Result = "该手机号码于产品不匹配！";
                return;
            }
        }

        private void ValidateAccountInfo(SystemUsers currentAccount)
        {
            if (currentAccount == null)
            {
                logMsg.Info("未找到对应的商户信息：" + accountInfoViewModels.AppID);
                throw new HttpException(400, "错误的请求");
            }
            if (currentAccount.Flag == 1)
            {
                logMsg.Info("该账户已冻结：" + accountInfoViewModels.AppID);
                requestResultViewModel.Code = "101";//该账户已冻结
                requestResultViewModel.Result = "该账户已冻结,请联系渠道专员！";
                return;
            }
            if (currentAccount.SystemAccount == null)
            {
                logMsg.Info("该账户无账户信息：" + accountInfoViewModels.AppID);
                requestResultViewModel.Code = "999"; //该账户无账户信息
                requestResultViewModel.Result = "系统异常！";
                return;
            }
            if (currentAccount.SystemAccount.LeftAccount + currentAccount.SystemAccount.OverDraft <= 1000)
            {
                logMsg.Info("该账户余额不足：" + accountInfoViewModels.AppID);
                requestResultViewModel.Code = "108"; //该账户已冻结
                requestResultViewModel.Result = "账户余额不足！";
            }
        }

        private void ValidateDateTime()
        {
            if (!accountInfoViewModels.DateTime.Equals(orderAgentRequestViewModel.DateTime))
            {
                logMsg.Info("头部和参数里的时间不对称" + accountInfoViewModels.DateTime + "!=" + orderAgentRequestViewModel.DateTime);
                throw new HttpException(400, "错误的请求");
            }
            var timespan = DateTime.Now - DateTime.ParseExact(orderAgentRequestViewModel.DateTime, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture); ;
            if (timespan.TotalSeconds >= 180)
            {
                logMsg.Info("日期超时：" + accountInfoViewModels.DateTime + "!=" + DateTime.Now);
                throw new HttpException(400, "错误的请求");
            }
        }

        private void InitParamInfo(string str, OrderAgentRequestViewModel orderAgent)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(str);
            var selectSingleNode = xmlDoc.SelectSingleNode("//Request");
            if (selectSingleNode != null)
            {
                XmlNodeList xn0 = selectSingleNode.ChildNodes;
                foreach (XmlNode node in xn0)
                {
                    if (node.Name == "DateTime")
                    {
                        orderAgent.DateTime = node.InnerText;
                    }
                }
            }
            var selectChildNode = xmlDoc.SelectSingleNode("//Request//Authorization");
            if (selectSingleNode != null)
            {
                XmlNodeList xn0 = selectSingleNode.ChildNodes;
                foreach (XmlNode node in xn0)
                {
                    if (node.Name == "MobilePhone")
                    {
                        orderAgent.MobilePhone = node.InnerText;
                    }
                    if (node.Name == "ProductId")
                    {
                        orderAgent.ProductId = node.InnerText;
                    }
                    if (node.Name == "Size")
                    {
                        orderAgent.Size = node.InnerText;
                    }
                }
            }
        }

        public void InitAccountToken(string str, RequestAccountInfoViewModels account)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(str);
            var selectSingleNode = xmlDoc.SelectSingleNode("//Account//Data");
            if (selectSingleNode != null)
            {
                XmlNodeList xn0 = selectSingleNode.ChildNodes;
                foreach (XmlNode node in xn0)
                {
                    if (node.Name == "DateTime")
                    {
                        account.DateTime = node.InnerText;
                    }
                    if (node.Name == "AppID")
                    {
                        account.AppID = node.InnerText;
                    }
                }
            }
        }

        private void ValidateHeadInfo()
        {

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

        private string Account { get; set; }
        private string Sign { get; set; }
        private string ParamXml { get; set; }
        private RequestAccountInfoViewModels accountInfoViewModels { get; set; }
        private OrderAgentRequestViewModel orderAgentRequestViewModel { get; set; }
        private ILog logMsg;
        private RequestResultViewModel requestResultViewModel = new RequestResultViewModel();
        private ISystemUsersService _systemUsersService = new SystemUsersService();
        private IFlowBaseInfoService _flowBaseInfoService;
        private ISystemFlowPacketsService _systemFlowPacketsService;
        private IBusinessIPBindService _businessIpBindService;
    }
}