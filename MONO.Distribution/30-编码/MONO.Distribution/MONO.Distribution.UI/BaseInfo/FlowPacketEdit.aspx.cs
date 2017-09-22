using System;
using System.Globalization;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.BaseInfo;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.UIProcess;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.BaseInfo
{
    public partial class FlowPacketEdit : EditPageBase
    {
        public FlowPacketEdit()
        {
            _result = new ResultMessage();
            _enumerationService = new EnumerationService();
            _flowPacketInfosService = new FlowBaseInfoService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IsOpenTabNav = false;
            if (!IsPostBack)
            {
                BindDdlData();
            }
        }
        protected override void SetUpdate()
        {
            base.SetUpdate();
            btnSave.Visible = false;
            SetFlowPacketInfo();
        }



        protected override void SetInsert()
        {
            base.SetInsert();
            btnUpdate.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ValidateInfo();
            if (!ResultMessage.IsOk)
            {
                WriteLog("流量包设置", GetNotice(ResultMessage), "");
                return;
            }
            var info = new FlowBaseInfo();
            GetFlowPacketInfo(info);
            ResultMessage = _flowPacketInfosService.Insert(info);
            OperationEnd();
        }



        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ValidateInfo();
            if (!ResultMessage.IsOk)
            {
                WriteLog("流量包设置", GetNoticeForLog(ResultMessage), "");
                return;
            }
            var info = _flowPacketInfosService.FindById(Id);
            GetFlowPacketInfo(info);
            ResultMessage = _flowPacketInfosService.Update(info);
            OperationEnd();
        }


        private void GetProvierInstance(FlowCode provier, int id)
        {
            provier.Area = ddlRange.SelectedValue;
            provier.FlowKey = id;
            provier.Status = "0";
        }

        private void ValidateInfo()
        {
            var variable = new CheckPageVariable();
            variable.CheckInputValueIsEmpty(ddlFrom.SelectedValue, "运营商未选择")
                .CheckInputValueIsEmpty(ddlRange.SelectedValue, "范围未选择")

                .CheckInputValueIsEmpty(txtSize.Text.Trim(), "大小不能为空")
                .CheckInputValueIsEmpty(txtPrice.Text.Trim(), "价格不能为空")
                .CheckInputValueIsEmpty(ddlStatus.SelectedValue, "状态不能为空")
                .CheckIsNumber(txtSize.Text.Trim(), "大小格式不正确", "大小必须为整数")
                .CheckIsNumber(txtPrice.Text.Trim(), "价格格式不正确", "价格必须为整数")

                ;
            ResultMessage = variable.GetResultMessage();

        }


        private void BindDdlData()
        {
            var fromList = _enumerationService.SelectEnumerationsByTypeName("Froms");
            foreach (var fbEnumeration in fromList)
            {
                ddlFrom.Items.Add(new ListItem(fbEnumeration.EnumValue, fbEnumeration.EnumKey));
            }
            ddlFrom.Items.Insert(0, new ListItem("请选择", ""));
            var rangList = _enumerationService.SelectEnumerationsByTypeName("Ranges");
            foreach (var fbEnumeration in rangList)
            {
                ddlRange.Items.Add(new ListItem(fbEnumeration.EnumValue, fbEnumeration.EnumKey));
            }
            ddlRange.Items.Insert(0, new ListItem("请选择", ""));
            var statusList = _enumerationService.SelectEnumerationsByTypeName("Whether");

        }

        private void GetFlowPacketInfo(FlowBaseInfo flow)
        {
            flow.From = ddlFrom.SelectedValue;
            flow.StandardPrice = string.IsNullOrEmpty(txtPrice.Text.Trim()) ? 0 : Convert.ToInt32((string)txtPrice.Text.Trim());
            flow.Range = ddlRange.SelectedValue;
            flow.Size = string.IsNullOrEmpty(txtSize.Text.Trim()) ? 0 : Convert.ToInt32((string)txtSize.Text.Trim());
            flow.Status = ddlStatus.SelectedValue;
            flow.PlatformCode = txtFlowCode.Text.Trim();
            flow.Name = txtName.Text;
            flow.IsInterParallel = ddlIsParallel.SelectedValue;
            flow.IsRecyle = ddlRecyle.SelectedValue;
            flow.ChannelStatus = ddlChannelStatus.SelectedValue;
        }
        private void SetFlowPacketInfo()
        {
            var flow = _flowPacketInfosService.FindById(Id);
            ddlFrom.SelectedValue = flow.From;
            txtPrice.Text = flow.StandardPrice.ToString(CultureInfo.InvariantCulture);
            ddlRange.SelectedValue = flow.Range;
            txtSize.Text = flow.Size.ToString(CultureInfo.InvariantCulture);
            txtFlowCode.Text = flow.PlatformCode;
            ddlStatus.SelectedValue = flow.Status;
            ddlIsParallel.SelectedValue = flow.IsInterParallel;
            ddlRecyle.SelectedValue = flow.IsRecyle;
            txtName.Text = flow.Name;
            ddlStatus.SelectedValue = flow.Status;
            ddlChannelStatus.SelectedValue = flow.ChannelStatus;
        }

        private ResultMessage _result;
        private readonly IEnumerationService _enumerationService;
        private readonly IFlowBaseInfoService _flowPacketInfosService;



    }
}