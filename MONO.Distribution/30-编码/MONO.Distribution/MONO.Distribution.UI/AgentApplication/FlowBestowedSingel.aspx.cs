using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Web;
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
    public partial class FlowBestowedSingel : EditPageBase
    {
        public FlowBestowedSingel()
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
                BindData();
            }
        }

        protected void btnSend_OnClick(object sender, EventArgs e)
        {
            this.lblError.Visible = false;
            if (ValidateInfo()) return;
            var record = new FlowDistributionRecords
            {
                BatchNo = DateTime.Now.ToString("yyyyMMddHHmmss"),
                SysUserKey = CurrentUser.SysUserKey,
                DistributionRecordKey = Guid.NewGuid().ToString(),
                CompanyFlowPacketKey = int.Parse(ddlFlow.SelectedValue),
                MobilePhone = txtPhone.Text.Trim(),
                DistributionType = "Platform",
                OrderStatus = "OrderCommit",
                OrderType = "Platform"
            };
            var flowCodeInfo = GetFlowCode();
            record.Carrier = flowCodeInfo.Carrier;
            record.Code = flowCodeInfo.ProductCode;
            var result = _flowDistributionRecordsService.Insert(record);
            WriteLog("流量赠送", "赠送流量包-" + ddlFlow.SelectedItem.Text, "");
            if (!result.IsOk)
            {
                record.OrderStatus = "SB";
                foreach (var item in result.Errors)
                {
                    record.ResultMsg = item.Value;
                }
                _flowDistributionRecordsService.Update(record);
            }
            ResetCurrentInfo();
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script language=javascript>this.parent.window.document.getElementById('topFrame').contentWindow.updateAccount();</script>");
            if (result.IsOk)
            {
                Response.Redirect("FlowBestowedBatchCommit.aspx?transNo=" + record.BatchNo);
            }
            else
            {
                Response.Redirect("FlowCommitFaild.aspx?transNo=" + record.BatchNo);
            }
        }

        private bool ValidateInfo()
        {
            if (string.IsNullOrEmpty(txtPhone.Text) || txtPhone.Text.Length != 11)
            {
                lblError.Text = "未输入电话号码！";
                this.lblError.Visible = true;
                return true;
            }

            if (ddlFlow.SelectedValue.Equals("0"))
            {
                lblError.Text = "未选择激活流量包！";
                this.lblError.Visible = true;
                return true;
            }
            var account = _systemAccountService.SelectSystemAccountByUserKey(CurrentUser.SysUserKey);
            var flow = _systemFlowPacketsService.FindById(int.Parse(ddlFlow.SelectedValue));
            if (account != null && account.LeftAccount > flow.Price)
            {
                return false;
            }
            else
            {
                this.lblError.Text = "账户余额不足！";
                this.lblError.Visible = true;
                return true;
            }
        }

        private FlowCode GetFlowCode()
        {
            var systemFlow = _systemFlowPacketsService.FindById(int.Parse(ddlFlow.SelectedValue));
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

        protected void txtPhone_OnTextChanged(object sender, EventArgs e)
        {
            if (txtPhone.Text.Length != 11) return;
            _froms = GetPhoneFromsHandler.GetInstance().GetFroms(txtPhone.Text);
            BindData();
        }



        private void BindData()
        {
            ddlFlow.Items.Clear();
            var condition = GetQueryCondtion();
            var list = _systemFlowPacketsService.FindAll(condition);
            foreach (var item in list.Where(m => m.FlowBaseInfo.From == _froms))
            {
                this.ddlFlow.Items.Add(new ListItem(item.FlowBaseInfo.FlowNameWithPrice + " 折后价：" + item.Price + "积分", item.SystemFlowPacketKey.ToString()));
            }
            this.ddlFlow.Items.Insert(0, new ListItem("请选择", "0"));

            var account = _systemAccountService.SelectSystemAccountByUserKey(CurrentUser.SysUserKey);
            lblInter.InnerText = account != null ? account.LeftAccount.ToString() : "0";
        }

        private SystemFlowPackets GetQueryCondtion()
        {
            return new SystemFlowPackets
            {
                Froms = _froms,
                SysUserKey = CurrentUser.SysUserKey
            };
        }

        private ISystemFlowPacketsService _systemFlowPacketsService;
        private IFlowDistributionRecordsService _flowDistributionRecordsService;
        private IFlowCodeService _flowCodeService;
        private string _froms;
        private ISystemSettingService _systemSettingDao;
        private ISystemAccountService _systemAccountService;
        private IMobileAreaService _mobileAreaService;
    }
}