using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.BaseInfo;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.UIProcess;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.AgentApplication
{
    public partial class FlowBrowseBatch : ListPageBase
    {
        public FlowBrowseBatch()
        {
            _systemFlowPacketsService = new SystemFlowPacketsService();
            _flowDistributionRecordsService = new FlowDistributionRecordsService();
            _flowCodeService = new FlowCodeService();
            _systemAccountService = new SystemAccountService();
            _systemSettingDao = new SystemSettingService();
            _mobileAreaService = new MobileAreaService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hfAuth.Value = Request.Cookies[FormsAuthentication.FormsCookieName] == null ? string.Empty : Request.Cookies[FormsAuthentication.FormsCookieName].Value;
                this.hfAspSessID.Value = Session.SessionID;
                this.hfExcelAuth.Value = Request.Cookies[FormsAuthentication.FormsCookieName] == null ? string.Empty : Request.Cookies[FormsAuthentication.FormsCookieName].Value;
                this.hfExcelSessid.Value = Session.SessionID;
                BindData();
            }
        }

        private void BindData()
        {
            var flowsAll = _systemFlowPacketsService.FindAll(new SystemFlowPackets { SysUserKey = CurrentUser.SysUserKey });
            var dxflows = from m in flowsAll
                          where m.FlowBaseInfo.From.Equals("CT")
                          select m;
            BindDdlData(ddlDxFlows, dxflows.ToList());
            var ydflows = from m in flowsAll
                          where m.FlowBaseInfo.From.Equals("CM")
                          select m;
            BindDdlData(ddlYdFlows, ydflows.ToList());
            var ltflows = from m in flowsAll
                          where m.FlowBaseInfo.From.Equals("CU")
                          select m;
            BindDdlData(ddlLtFlows, ltflows.ToList());
        }



        private void BindDdlData(DropDownList ddl, IList<SystemFlowPackets> dxflows)
        {
            foreach (var fb in dxflows)
            {
                ddl.Items.Add(new ListItem(fb.FlowBaseInfo.Name + " 消费：" + fb.Price.ToString("N0") + "积分 人民币：" + (Convert.ToDecimal(fb.Price) / 100).ToString("N2") + "RMB", fb.SystemFlowPacketKey.ToString()));
            }
            ddl.Items.Insert(0, new ListItem("请选择", "0"));
        }


        private ISystemFlowPacketsService _systemFlowPacketsService;

        protected void btnDistribution_OnClick(object sender, EventArgs e)
        {
            lblAccountLess.Visible = false;
            if (ValidateInfo()) return;
            var batchNo = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var phoneText = txtPhone.Text.Trim();
            var phoneArr = phoneText.Split(';');
            foreach (var item in phoneArr)
            {
                var froms = GetPhoneFromsHandler.GetInstance().GetFroms(item);
                var flowId = 0;
                switch (froms)
                {
                    case "CU":
                        flowId = int.Parse(ddlLtFlows.SelectedValue);
                        break;
                    case "CM":
                        flowId = int.Parse(ddlYdFlows.SelectedValue);
                        break;
                    case "CT":
                        flowId = int.Parse(ddlDxFlows.SelectedValue);
                        break;
                }
                var record = new FlowDistributionRecords
            {
                BatchNo = batchNo,
                SysUserKey = CurrentUser.SysUserKey,
                DistributionRecordKey = Guid.NewGuid().ToString(),
                CompanyFlowPacketKey = flowId,
                MobilePhone = item,
                DistributionType = "Orders",
                OrderStatus = "OrderCommit"
            };
                var flowCodeInfo = GetFlowCode(flowId);
                record.Carrier = flowCodeInfo.Carrier;
                record.Code = flowCodeInfo.ProductCode;
                var result = _flowDistributionRecordsService.Insert(record);
                WriteLog("流量赠送", "流量批量赠送-批次号" + batchNo, "");
            }
            ResetCurrentInfo();
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script language=javascript>this.parent.window.document.getElementById('topFrame').contentWindow.updateAccount();</script>");
            Response.Redirect("FlowBestowedBatchCommit.aspx?transNo=" + batchNo);
        }

        private bool ValidateInfo()
        {
            var account = _systemAccountService.SelectSystemAccountByUserKey(CurrentUser.SysUserKey);
            decimal totalPrice = 0;
            var phoneText = txtPhone.Text.Trim();
            var phoneArr = phoneText.Split(';');
            foreach (var item in phoneArr)
            {
                var froms = GetPhoneFromsHandler.GetInstance().GetFroms(item);
                var flowId = 0;
                switch (froms)
                {
                    case "CU":
                        flowId = int.Parse(ddlLtFlows.SelectedValue);
                        break;
                    case "CM":
                        flowId = int.Parse(ddlYdFlows.SelectedValue);
                        break;
                    case "CT":
                        flowId = int.Parse(ddlDxFlows.SelectedValue);
                        break;
                }

                var flowInfo = _systemFlowPacketsService.FindById(flowId);
                totalPrice = totalPrice + flowInfo.Price;
            }
            if (account.LeftAccount < totalPrice)
            {
                lblAccountLess.Text = "*账户余额不足！";
                lblAccountLess.Visible = true;
                return true;
            }
            return false;
        }


        private FlowCode GetFlowCode(int flowKey)
        {
            var systemFlow = _systemFlowPacketsService.FindById(flowKey);
            var settingInfo = _systemSettingDao.SelectSystemSettingBySysUserKey(systemFlow.SysUserKey);
            var condition = new FlowCode
            {
                AreaStr = new List<string> { "0" },
                FlowKey = systemFlow.FlowPacketKey,
                FromRanges = settingInfo.IsDefaultProvnice.Equals("Y") ? "" : "-1"
            };
            var areas = _mobileAreaService.FindAll(new MobileArea { MobileHead = txtPhone.Text.Trim().Substring(0, 7) });
            if (areas != null && areas.Count > 0 && areas.Any())
            {
                condition.AreaStr.Add(areas.First().AreaKey);
            }
            var flowCodes = _flowCodeService.FindAll(condition).OrderBy(m => m.Priority);
            if (flowCodes.Any()) return flowCodes.First();
            return new FlowCode();
        }

        private IFlowCodeService _flowCodeService;
        private IFlowDistributionRecordsService _flowDistributionRecordsService;
        private ISystemAccountService _systemAccountService;
        private ISystemSettingService _systemSettingDao;
        private IMobileAreaService _mobileAreaService;
    }
}