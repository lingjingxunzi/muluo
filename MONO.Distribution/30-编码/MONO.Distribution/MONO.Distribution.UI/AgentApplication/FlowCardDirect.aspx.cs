using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    public partial class FlowCardDirect : EditPageBase
    {
        public FlowCardDirect()
        {
            _flowActiveCardDetailsService = new FlowActiveCardDetailsService();
            _flowActiveCardService = new FlowActiveCardService();
            _result = new ResultMessage();
            _flowDistributionRecordsService = new FlowDistributionRecordsService();
            _systemSettingDao = new SystemSettingService();
            _mobileAreaService = new MobileAreaService();
            _systemFlowPacketsService = new SystemFlowPacketsService();
            _systemAccountService = new SystemAccountService();
            _flowCodeService = new FlowCodeService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ValidateInfo();
            if (_result.IsOk)
            {
                var details = _flowActiveCardDetailsService.FindById(txtCardId.Text.Trim());
                var parentCard = _flowActiveCardService.FindById(details.TransNo);
                details.MobilePhone = txtMobilePhone.Text.Trim();
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
                    SysUserKey = parentCard.SysUserKey
                };
                var flowCodeInfo = GetFlowCode(parentCard.SystemFlowPacketKey);
                flowDistribution.Carrier = flowCodeInfo.Carrier;
                flowDistribution.Code = flowCodeInfo.ProductCode;
                ResultMessage = _flowDistributionRecordsService.Insert(flowDistribution);
            }
            OperationEnd("卡密", "卡密提取：卡号：" + txtCardId.Text);
        }


        private FlowCode GetFlowCode(int flowId)
        {
            var systemFlow = _systemFlowPacketsService.FindById(flowId);
            var settingInfo = _systemSettingDao.SelectSystemSettingBySysUserKey(systemFlow.SysUserKey);
            var condition = new FlowCode
            {
                AreaStr = new List<string> { "0" },
                FlowKey = systemFlow.FlowPacketKey,
                FromRanges = settingInfo.IsDefaultProvnice.Equals("Y") ? "" : "-1"
            };
            var areas = _mobileAreaService.FindAll(new MobileArea { MobileHead = txtMobilePhone.Text.Trim().Substring(0, 7) });
            if (areas != null && areas.Count > 0 && areas.Any())
            {
                condition.AreaStr.Add(areas.First().AreaKey);
            }
            var flowCodes = _flowCodeService.FindAll(condition).OrderBy(m => m.Priority);
            if (flowCodes.Any()) return flowCodes.First();
            return new FlowCode();
        }

        private void ValidateInfo()
        {
            var flowdetails = _flowActiveCardDetailsService.FindById(txtCardId.Text);
            if (flowdetails == null || flowdetails.FlowActiveCard.SysUserKey != CurrentUser.SysUserKey)
            {
                sp_caridNotExists.Visible = true;
                _result.Errors.Add("CardId not Exists", "CardId not Exists");
                return;
            }
            else
            {
                sp_caridNotExists.Visible = false;
            }
            if (flowdetails.FlowActiveCard.Status.Equals("KMZZ"))
            {
                sp_Parent_eror.Visible = true;
                _result.Errors.Add("FlowActiveCard Status ", "FlowActiveCard Status ");
                return;
            }
            else
            {
                sp_Parent_eror.Visible = false;
            }

            if (!flowdetails.Status.Equals("KMWSY"))
            {
                sp_caridStatus_error.Visible = true;
                _result.Errors.Add("flowdetails Status ", "flowdetails Status ");
                return;
            }
            else
            {
                sp_caridStatus_error.Visible = false;
            }

            if (!flowdetails.Serect.Equals(txtSec.Text.Trim()))
            {
                sp_sec_error.Visible = true;
                _result.Errors.Add("flowdetails Serect ", "flowdetails Serect ");
                return;
            }
            else
            {
                sp_sec_error.Visible = false;
            }

        }

        private IFlowActiveCardDetailsService _flowActiveCardDetailsService;
        private IFlowActiveCardService _flowActiveCardService;
        private IFlowDistributionRecordsService _flowDistributionRecordsService;

        //private MessageSendHanlder _sendMsgHelper;
        private ResultMessage _result;
        private ISystemSettingService _systemSettingDao;
        private ISystemAccountService _systemAccountService;
        private IMobileAreaService _mobileAreaService;
        private ISystemFlowPacketsService _systemFlowPacketsService;
        private IFlowCodeService _flowCodeService;
    }
}