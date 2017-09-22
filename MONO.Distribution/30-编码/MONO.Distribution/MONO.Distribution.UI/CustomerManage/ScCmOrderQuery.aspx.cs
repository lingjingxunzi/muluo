using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using log4net;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.UIProcess;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.CustomerManage
{
    public partial class ScCmOrderQuery : ListPageBase
    {
        public ScCmOrderQuery()
        {
            _enumerationService = new EnumerationService();
            _systemUsersService = new SystemUsersService();
            _flowDistributionRecordsService = new FlowDistributionRecordsService();
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _flowActiveHistoriesService = new FlowActiveHistoriesService();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void gvDisList_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            var key = e.CommandArgument.ToString();
            var disInfo = _flowDistributionRecordsService.FindById(key);
            if (disInfo.OrderStatus.Equals("WaitCallBack"))
            {
                var hisInfo = _flowActiveHistoriesService.FindAll(new FlowActiveHistories(){DistributionRecordKey = key});
                if (hisInfo != null && hisInfo.Count > 0)
                {
                   var his = hisInfo.First();
                   var url = "https://sc.4ggogo.com/web-in/chargeResult/" + his.FlowActiveHistoryKey + ".html";
                   var sign = CarrierCharManipulation.SHA256(ConfigurationSettings.AppSettings["scCMSec"]);
                    GetToken();
                    var xmlStr = HttpGet(url, Token, sign);
                    var result = InitResult(xmlStr);
                    var defaultUrl = "http://113.207.124.143/Order/SxdCallBack.aspx?" + "passParm=" + his.FlowActiveHistoryKey + result;
                    HttpWebRequestTools.GetRequestByHttpWebDefault(defaultUrl);
                }
                BindData();
            }


        }

        public string InitResult(string str)
        {
            var serialNum = "";
            var systemNum = "";
            var msg = "";
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(str);
            var selectSingleNode = xmlDoc.SelectSingleNode("//Response//Records//Record");
            if (selectSingleNode != null)
            {
                XmlNodeList xn0 = selectSingleNode.ChildNodes;
                foreach (XmlNode node in xn0)
                {
                    if (node.Name == "Status")
                    {
                        serialNum = (node.InnerText.Equals("3")?"0":node.InnerText);
                    }
                    if (node.Name == "EnterpriseId")
                    {
                        systemNum = node.InnerText;
                    }
                    if (node.Name == "Description")
                    {
                        msg = node.InnerText;
                    }
                }
            }
            return "&serianlNo=" + systemNum + "&result=" + serialNum + "&msg=" + msg;
        }

        private string GetToken()
        {
            try
            {
                var App = ConfigurationSettings.AppSettings["scCMApp"];
                var AppSec = ConfigurationSettings.AppSettings["scCMSec"];
                var time = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fff") + "+08:00";
                var authUrl = "https://sc.4ggogo.com/web-in/auth.html";
                var sign = CarrierCharManipulation.SHA256(App + time + AppSec);
                var paramStr = "<Request>"
                    + "<Datetime>" + time + "</Datetime>"
                    + "<Authorization><AppKey>" + App + "</AppKey>"
                    + "<Sign>" + sign + "</Sign>"
                    + "</Authorization></Request>";
                var authJson = HttpWebRequestTools.CM023NewAuthHttpPost(authUrl, paramStr);
                InitToken(authJson);
               
                return Token;
            }
            catch (Exception ex)
            {
                
            }
            return "";
        }

        public void InitToken(string str)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(str);
            var selectSingleNode = xmlDoc.SelectSingleNode("//Response//Authorization");

            if (selectSingleNode != null)
            {
                XmlNodeList xn0 = selectSingleNode.ChildNodes;

                foreach (XmlNode node in xn0)
                {
                    if (node.Name == "Token")
                    {
                        this.Token = node.InnerText;
                    }
                }
            }
        }

        private string Token { get; set; }


         

        protected void btnPage_Click(object sender, EventArgs e)
        {
            PageHelper.SetPageIndex(int.Parse(hidePage.Value));
            BindData();
        }

        private void BindData()
        {
            var condtion = GetQueryCondition();
            SetPager(_flowDistributionRecordsService.GetCount(condtion), 10);
            var list = _flowDistributionRecordsService.FindAll(condtion);
            this.gvDisList.DataSource = list;
            this.gvDisList.DataBind();
        }

        private FlowDistributionRecords GetQueryCondition()
        {
            return new FlowDistributionRecords
            {
                IsStartPager = true,
                StartRecordIndex = PageHelper.GetStartIndex(),
                EndRecordIndex = PageHelper.GetEndIndex() < PageHelper.GetPageTotal()
                        ? PageHelper.GetPageTotal()
                        : PageHelper.GetEndIndex(),
                OrderStatus = "WaitCallBack",
                Carrier = "CM028",
                MobilePhone = txtMobilePhone.Text
                
            };
        }


        public static string HttpGet(string Url, string token, string sign)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            request.Headers["4GGOGO-Auth-Token"] = token;
            request.Headers["HTTP-X-4GGOGO-Signature"] = sign;
            request.ContentType = "text/html;charset=UTF-8";
            request.ProtocolVersion = HttpVersion.Version10;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        private IEnumerationService _enumerationService;
        private ISystemUsersService _systemUsersService;
        private IFlowDistributionRecordsService _flowDistributionRecordsService;
        private ILog LogMsg;
        private IFlowActiveHistoriesService _flowActiveHistoriesService;
    }
}