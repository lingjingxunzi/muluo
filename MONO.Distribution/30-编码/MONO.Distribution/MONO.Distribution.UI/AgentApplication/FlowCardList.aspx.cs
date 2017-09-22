using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.AgentApplication
{
    public partial class FlowCardList : ListPageBase
    {
        public FlowCardList()
        {
            _flowActiveCardService = new FlowActiveCardService();
            _systemUsersService = new SystemUsersService();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBaseInfo();
                BindData();
            }
        }
        protected void AspNetPager_PageChanged(object sender, EventArgs e)
        {
            PageHelper.SetPageIndex(int.Parse(hidePage.Value));
            BindData();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
            WriteLog("卡密","卡密查询","");
        }

        protected void gvFlowCardList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                string id = e.CommandArgument.ToString();
                var cards = _flowActiveCardService.FindById(id);
                cards.Status = "KMZZ";
                _flowActiveCardService.Update(cards);
            }
            BindData();
        }

        protected void btnPage_Click(object sender, EventArgs e)
        {
            PageHelper.SetPageIndex(int.Parse(hidePage.Value));
            BindData();
        }




        private void BindData()
        {
            var condition = GetQueryCondition();
            SetPager(condition);
            var data = _flowActiveCardService.FindAll(condition);
            gvFlowCardList.DataSource = data;
            gvFlowCardList.DataBind();
        }

        private void SetPager(FlowActiveCard condition)
        {
            SetPager(_flowActiveCardService.GetCount(condition), 10);
        }

        private FlowActiveCard GetQueryCondition()
        {
            return new FlowActiveCard
            {
                IsStartPager = true,
                StartRecordIndex = PageHelper.GetStartIndex(),
                EndRecordIndex = PageHelper.GetEndIndex() < PageHelper.GetPageTotal()
                        ? PageHelper.GetPageTotal()
                        : PageHelper.GetEndIndex(),
                StartTime = txtStartQueryDateTime.Text,
                EndTime = txtEndQueryDateTime.Text,
                TransNo = txtTransNo.Text.Trim(),
                SysUserKey = CurrentUser.SysUserKey
            };
        }

        private void BindBaseInfo()
        {
            var info = _systemUsersService.FindById(CurrentUser.SysUserKey);
            //spName.InnerText = info.Account;
            //imgLogoPath.ImageUrl = (info.SysUserInfos != null && info.SysUserInfos.CompanyInfo != null) ? (string.IsNullOrEmpty(info.SysUserInfos.CompanyInfo.LogoPath) ? "../Images/36.png" : info.SysUserInfos.CompanyInfo.LogoPath) : "../Images/36.png";
        }


        private IFlowActiveCardService _flowActiveCardService;
        private ISystemUsersService _systemUsersService;


    }
}