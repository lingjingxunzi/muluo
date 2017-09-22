using System;
using System.Collections.Generic;
using System.Linq;
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
using MONO.Distribution.Model.Sys;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.Sys
{
    public partial class BusinessDiscountEdit : EditPageBase
    {
        public BusinessDiscountEdit()
        {
            _systemFlowPacketsService = new SystemFlowPacketsService();
            _systemUsersService = new SystemUsersService();
            _discountsService = new DiscountsService();
            _flowBaseInfoService = new FlowBaseInfoService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected override void SetInsert()
        {
            this.btnUpdate.Visible = false;
            BindUsers();
            BindFlows();
        }

        private void BindFlows()
        {
            var flowInfo = _flowBaseInfoService.FindAll(new FlowBaseInfo { ChannelStatus = "Y", Status = "Y" });
            foreach (var item in flowInfo)
            {
                DropDownList2.Items.Add(new ListItem(item.Name, item.FlowKey.ToString()));
            }
            DropDownList2.Items.Insert(0, new ListItem("请选择", "0"));
        }

        private void BindUsers()
        {
            var sysusers = _systemUsersService.FindAll(new SystemUsers());
            foreach (var item in sysusers)
            {
                DropDownList1.Items.Add(new ListItem(item.Nick, item.SysUserKey.ToString()));
            }
            DropDownList1.Items.Add(new ListItem("请选择", "0"));
        }

        protected override void SetUpdate()
        {
            this.btnSave.Visible = false;
            BindData();
        }

        private void BindData()
        {
            var key = int.Parse(Request.QueryString["Key"]);
            var info = _systemFlowPacketsService.FindById(key);
            var sysuser = _systemUsersService.FindById(info.SysUserKey);
            this.DropDownList1.Items.Insert(0, new ListItem(sysuser.Nick, sysuser.SysUserKey.ToString()));
            this.DropDownList2.Items.Insert(0, new ListItem(info.FlowBaseInfo.Name, info.FlowBaseInfo.FlowKey.ToString()));
            this.txtNick.Text = info.Discounts.Deduction.ToString("N2");
            this.DropDownList1.Enabled = false;
            this.DropDownList2.Enabled = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var info = new SystemFlowPackets();
            var dection = _discountsService.SelectDiscountsByDeduction(Convert.ToDecimal(txtNick.Text));
            if (dection == null)
            {
                var demon = new Discounts();
                demon.Deduction = Convert.ToDecimal(txtNick.Text);
                demon.Status = "Y";
                dection.DiscountKey = _discountsService.Insert(demon).Id;
                dection.Deduction = Convert.ToDecimal(txtNick.Text);
            }

            var count = _systemFlowPacketsService.GetCount(new SystemFlowPackets { SysUserKey = int.Parse(DropDownList1.SelectedValue), FlowPacketKey = int.Parse(DropDownList2.SelectedValue) });
            if (count > 0)
            {
                info =
                  _systemFlowPacketsService.FindAll(new SystemFlowPackets
                  {
                      SysUserKey = int.Parse(DropDownList1.SelectedValue),
                      FlowPacketKey = int.Parse(DropDownList2.SelectedValue)
                  }).First();
                info.Price = (dection.Deduction * info.FlowBaseInfo.StandardPrice) / 100;
                info.DiscountKey = dection.DiscountKey;
                info.Status = "Y";
                ResultMessage = _systemFlowPacketsService.Update(info);
            }
            else
            {
                var flowInfo = _flowBaseInfoService.FindById(int.Parse(DropDownList2.SelectedValue));
                info.Price = (dection.Deduction * flowInfo.StandardPrice ) / 100;
                info.DiscountKey = dection.DiscountKey;
                info.Status = "Y";
                info.FlowPacketKey = int.Parse(DropDownList2.SelectedValue);
                info.SysUserKey = int.Parse(DropDownList1.SelectedValue);
                ResultMessage = _systemFlowPacketsService.Insert(info);
            }
            OperationEnd();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var key = int.Parse(Request.QueryString["Key"]);
            var info = _systemFlowPacketsService.FindById(key);
            var dection = _discountsService.SelectDiscountsByDeduction(Convert.ToDecimal(txtNick.Text));
            if (dection == null)
            {
                var demon = new Discounts();
                demon.Deduction = Convert.ToDecimal(txtNick.Text);
                demon.Status = "Y";
                dection.DiscountKey = _discountsService.Insert(demon).Id;
                dection.Deduction = Convert.ToDecimal(txtNick.Text);
            }
            info.Price = (dection.Deduction * info.FlowBaseInfo.StandardPrice) / 100;
            info.DiscountKey = dection.DiscountKey;
            ResultMessage = _systemFlowPacketsService.Update(info);
            OperationEnd();
        }

        private ISystemFlowPacketsService _systemFlowPacketsService;
        private ISystemUsersService _systemUsersService;
        private IDiscountsService _discountsService;
        private IFlowBaseInfoService _flowBaseInfoService;
    }
}