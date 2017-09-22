using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.ComPage
{
    public partial class FlowCardExtract : Page
    {
        public FlowCardExtract()
        {
            _flowActiveCardDetailsService = new FlowActiveCardDetailsService();
            _flowActiveCardService = new FlowActiveCardService();
            _result = new ResultMessage();
            _flowDistributionRecordsService = new FlowDistributionRecordsService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Visible = false;
            }
        }

        protected void btnExtract_OnClick(object sender, EventArgs e)
        {
            ValidateInfo();
            if (_result.IsOk)
            {
                var details = _flowActiveCardDetailsService.FindById(txtCard.Value.Trim());
                var parentCard = _flowActiveCardService.FindById(details.TransNo);
                details.MobilePhone = txtPhone.Value.Trim();
                details.RechargeTime = DateTime.Now;
                details.Status = "KMYLQ";
                details.FlowPakegeKey = parentCard.SystemFlowPackets.FlowPacketKey;
                _flowActiveCardDetailsService.Update(details);
                var flowDistribution = new FlowDistributionRecords
                {
                    BatchNo = details.TransNo,
                    CallBackUrl = "",
                    DistributionRecordKey = Guid.NewGuid().ToString(),
                    CompanyFlowPacketKey = parentCard.SystemFlowPacketKey,
                    SysUserKey = parentCard.SysUserKey,
                    DistributionType = "Ticket"
                };
                _flowDistributionRecordsService.Insert(flowDistribution);
            }
        }

        private void ValidateInfo()
        {
            var flowdetails = _flowActiveCardDetailsService.FindById(txtCard.Value);
            if (flowdetails == null)
            {
                lblError.Visible = true;
                lblError.Text = "*卡号不存在";
                _result.Errors.Add("CardId not Exists", "CardId not Exists");
                return;
            }
            if (flowdetails.FlowActiveCard.Status.Equals("KMZZ"))
            {
                lblError.Visible = true;
                lblError.Text = "*该批次的卡密已终止，不能提取";
                _result.Errors.Add("FlowActiveCard Status ", "FlowActiveCard Status ");
                return;
            }


            if (!flowdetails.Status.Equals("KMWSY"))
            {
                lblError.Visible = true;
                lblError.Text = "*卡号状态异常，不能激活，请联系管理员！";
                _result.Errors.Add("flowdetails Status ", "flowdetails Status ");
                return;
            }

            if (!flowdetails.Serect.Equals(txtPwd.Value.Trim()))
            {
                lblError.Visible = true;
                lblError.Text = "*卡号密码不匹配";
                _result.Errors.Add("flowdetails Serect ", "flowdetails Serect ");
                return;
            }
        }

        private IFlowActiveCardDetailsService _flowActiveCardDetailsService;
        private IFlowActiveCardService _flowActiveCardService;
        private IFlowDistributionRecordsService _flowDistributionRecordsService;
        private ResultMessage _result;
    }
}