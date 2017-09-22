using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.UIProcess;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.AgentApplication
{
    public partial class FlowCardCreate : EditPageBase
    {
        public FlowCardCreate()
        {
            ResultMessage = new ResultMessage();
            _systemFlowPacketsService = new SystemFlowPacketsService();
            _flowActiveCardService = new FlowActiveCardService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCompanyFlows();

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ValidateInfo();
            if (ResultMessage.IsOk)
            {
                var info = new FlowActiveCard();
                GetFlowActiveCardInfo(info);
                ResultMessage = _flowActiveCardService.FlowCardBatchCreate(info);
                ResetCurrentInfo();
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script language=javascript>this.parent.parent.window.document.getElementById('topFrame').contentWindow.updateAccount();</script>");
                OperationEnd("卡密", "新增");
            }
        }

        private void GetFlowActiveCardInfo(FlowActiveCard info)
        {
            info.TransNo = txtTransNo.Text.Trim();
            info.Numbers = int.Parse(txtNumbers.Text.Trim());
            if (!string.IsNullOrEmpty(txtOverTime.Text))
            {
                info.OverdueTime = Convert.ToDateTime(txtOverTime.Text);
            }
            info.SystemFlowPacketKey = int.Parse(slt_flows.Value);
            var flow = _systemFlowPacketsService.FindById(int.Parse(slt_flows.Value));
            info.Amount = (int)(flow.Price * int.Parse(txtNumbers.Text.Trim()));
            info.SysUserKey = CurrentUser.SysUserKey;
            info.Status = "KMZC";
        }



        private void BindCompanyFlows()
        {
            lblInt.InnerText = CurrentUser.SystemAccount == null ? "0" : CurrentUser.SystemAccount.LeftAccount.ToString();
            slt_flows.Items.Clear();
            var flows = _systemFlowPacketsService.FindAll(new SystemFlowPackets { SysUserKey = CurrentUser.SysUserKey });
            foreach (var fbCompanyFlowPacketse in flows)
            {
                slt_flows.Items.Add(new ListItem(fbCompanyFlowPacketse.FlowBaseInfo.Name, fbCompanyFlowPacketse.SystemFlowPacketKey.ToString()));
            }
            slt_flows.Items.Insert(0, new ListItem("请选择", "0"));
        }


        private void ValidateInfo()
        {

            try
            {
                Convert.ToInt32(txtNumbers.Text.Trim());
            }
            catch (Exception ex)
            {
                LogMsg.Error(ex.Message);
                ResultMessage.Errors.Add("txtNumbers is Error", "格式不正确");
                return;
            }

            if (slt_flows.Value.Equals("0"))
            {
                LogMsg.Error("流量包未选择");
                ResultMessage.Errors.Add("流量包未选择", "流量包未选择");
                sp_flow_empty.Visible = true;
                return;
            }
            else
            {
                sp_flow_empty.Visible = false;
            }

            if (_flowActiveCardService.FindById(txtTransNo.Text.Trim()) != null)
            {
                LogMsg.Error("批次号已重复");
                ResultMessage.Errors.Add("批次号已重复", "批次号已重复");
                sp_trans_exists.Visible = true;
            }
            else
            {
                sp_trans_exists.Visible = false;
            }
            if (CurrentUser.SystemAccount == null)
            {
                LogMsg.Error("账户余额不足");
                ResultMessage.Errors.Add("账户余额不足", "账户余额不足");
                sp_Account_Error.Visible = true;
            }
            else
            {
                var flow = _systemFlowPacketsService.FindById(int.Parse(slt_flows.Value));
                var Amount = (int)(flow.Price * int.Parse(txtNumbers.Text.Trim()));
                if (Amount > CurrentUser.SystemAccount.LeftAccount)
                {
                    LogMsg.Error("账户余额不足");
                    ResultMessage.Errors.Add("账户余额不足", "账户余额不足");
                    sp_Account_Error.Visible = true;
                }
                else
                {
                    sp_Account_Error.Visible = false;
                }
            }

        }

        private IFlowActiveCardService _flowActiveCardService;
        private ISystemFlowPacketsService _systemFlowPacketsService;
    }
}