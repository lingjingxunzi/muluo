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
    public partial class FlowCodeEdit : EditPageBase
    {
        public FlowCodeEdit()
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
                this.ddlFlows.SelectedValue = Request.QueryString["FlowKey"];
                this.ddlFlows.Enabled = false;
            }
        }



        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                var item = _flowCodeService.FindById(int.Parse(ddlFlowCode.SelectedValue));
                if (item == null) return;
                item.Area = ddlProvice.SelectedValue;
                item.Carrier = ddlCarries.SelectedValue;
                item.DiscountKey = int.Parse(ddlDiscounts.SelectedValue);
                item.Priority = int.Parse(txtProtify.Text.Trim());
                item.PurchasePrice =(item.PurchasePrice/(  item.Discounts.Deduction /100))*(Convert.ToDecimal(ddlDiscounts.SelectedItem.Text) /100);
                item.Status = ddlStatus.SelectedValue;
                item.Name = txtName.Text;
                ResultMessage = _flowCodeService.Update(item);
                OperationEnd("流量设置","修改"+ddlFlows.SelectedItem.Text+"接口信息");
            }
            catch (Exception ex)
            {


            }
        }

        protected void ddlFlowCode_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(ddlFlowCode.SelectedValue);
                if (id > 0)
                {
                    var flowcode = _flowCodeService.FindById(id);
                    this.ddlDiscounts.SelectedValue = flowcode.DiscountKey.ToString();
                    this.ddlProvice.SelectedValue = flowcode.Area;
                    this.txtInterfaceCode.Text = flowcode.ProductCode;
                    this.txtProtify.Text = flowcode.Priority.ToString();
                    ddlStatus.SelectedValue = flowcode.Status;
                    this.ddlCarries.SelectedValue = flowcode.Carrier;
                    txtName.Text = flowcode.Name;
                }
            }
            catch (Exception ex)
            {

            }
        }


        private void BindDdlData()
        {
            var list = _flowCodeService.FindAll(new FlowCode { FlowKey = int.Parse(Request.QueryString["FlowKey"]), AreaStr = null, FromRanges = "" });
            this.ddlFlowCode.DataSource = list;
            this.ddlFlowCode.DataTextField = "Name";
            this.ddlFlowCode.DataValueField = "FlowCodeKey";
            this.ddlFlowCode.DataBind();
            this.ddlFlowCode.Items.Insert(0, new ListItem("请选择", "0"));
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
            foreach (var items in carrList)
            {
                ddlCarries.Items.Add(new ListItem(items.EnumValue + "(" + items.EnumKey + ")", items.EnumKey));
            }
            ddlCarries.Items.Insert(0, new ListItem("请选择", ""));

        }

        private IAreaService _areaService;
        private IFlowBaseInfoService _flowBaseInfoService;
        private IDiscountsService _discountsService;
        private IEnumerationService _enumerationService;
        private IFlowCodeService _flowCodeService;


    }
}