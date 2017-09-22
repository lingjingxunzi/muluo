using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.BaseInfo;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.BaseInfo
{
    public partial class FlowCarrierEdit : EditPageBase
    {
        public FlowCarrierEdit()
        {
            _discountsService = new DiscountsService();
            _flowBaseInfoService = new FlowBaseInfoService();
            _areaService = new AreasService();
            _enumerationService = new EnumerationService();
            _flowCodeService = new FlowCodeService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdlData();
                BindData();
            }
        }

        protected override void SetInsert()
        {
            base.SetInsert();
            btnUpdate.Visible = false;
        }

        protected override void SetUpdate()
        {
            base.SetUpdate();
            btnSave.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ValidateInfo();
            var flowCode = new FlowCode();
            GetCarrierInfo(flowCode);
            ResultMessage = _flowCodeService.Insert(flowCode);
            OperationEnd("接口商代码", "接口商插入" + flowCode.From + "." + flowCode.Carrier + "." + flowCode.Area + "." + flowCode.ProductCode);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ValidateInfo();
            if (!ResultMessage.IsOk) return;
            var flowcode = _flowCodeService.FindById(int.Parse(Request.QueryString["id"]));
            GetCarrierInfo(flowcode);
            ResultMessage = _flowCodeService.Update(flowcode);
            OperationEnd("接口商代码", "接口商修改" + flowcode.From + "." + flowcode.Carrier + "." + flowcode.Area + "." + flowcode.ProductCode);
        }


        private void ValidateInfo()
        {

        }


        private void GetCarrierInfo(FlowCode flowCode)
        {
            var flow = _flowBaseInfoService.FindById(int.Parse(ddlFlows.SelectedValue));
            flowCode.Area = ddlProvice.SelectedValue;
            flowCode.Carrier = ddlCarries.SelectedValue;
            flowCode.DiscountKey = int.Parse(ddlDiscounts.SelectedValue);
            flowCode.FlowKey = int.Parse(ddlFlows.SelectedValue);
            flowCode.From = flow.From;
            flowCode.PurchasePrice = (flow.StandardPrice * int.Parse(ddlDiscounts.SelectedItem.Text)) / 100;
            flowCode.ProductCode = txtInterfaceCode.Text.Trim();
            flowCode.Priority = int.Parse(txtProtify.Text.Trim());
            flowCode.FromRanges = ddlRoamType.SelectedValue;
            flowCode.Status = "Y";
            flowCode.Name = txtName.Text;
        }


        private void BindDdlData()
        {
            var areaList = _areaService.FindAll(new Areas { ParentKey = "0" });
            this.ddlProvice.DataSource = areaList;
            this.ddlProvice.DataTextField = "Name";
            this.ddlProvice.DataValueField = "AreaKey";
            this.ddlProvice.DataBind();
            ddlProvice.Items.Insert(0, new ListItem("全国", "0"));

            var flowList = _flowBaseInfoService.FindAll(new FlowBaseInfo());
            this.ddlFlows.DataSource = flowList;
            this.ddlFlows.DataTextField = "FlowNameWithPrice";
            this.ddlFlows.DataValueField = "FlowKey";
            this.ddlFlows.DataBind();
            var disList = _discountsService.FindAll(new Discounts());
            this.ddlDiscounts.DataSource = disList;
            this.ddlDiscounts.DataTextField = "Deduction";
            this.ddlDiscounts.DataValueField = "DiscountKey";
            this.ddlDiscounts.DataBind();
            var carrList = _enumerationService.SelectEnumerationsByTypeName("Carriers");
            this.ddlCarries.DataSource = carrList;
            this.ddlCarries.DataTextField = "EnumValue";
            this.ddlCarries.DataValueField = "EnumKey";
            this.ddlCarries.DataBind();


            var rangeList = _enumerationService.SelectEnumerationsByTypeName("RoamType");
            this.ddlRoamType.DataSource = rangeList;
            this.ddlRoamType.DataTextField = "EnumValue";
            this.ddlRoamType.DataValueField = "EnumKey";
            this.ddlRoamType.DataBind();
        }


        private void BindData()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["FlowKey"]))
            {
                var key = Request.QueryString["FlowKey"];
                ddlFlows.SelectedValue = key;
                ddlFlows.Enabled = false;
            }
        }

        private IAreaService _areaService;
        private IFlowBaseInfoService _flowBaseInfoService;
        private IDiscountsService _discountsService;
        private IEnumerationService _enumerationService;
        private IFlowCodeService _flowCodeService;
    }
}