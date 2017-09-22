using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Customers;
using MONO.Distribution.BLL.Interface.Customers;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Customers;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.CustomerManage
{
    public partial class CompanyAccountApplyList : ListPageBase
    {
        public CompanyAccountApplyList()
        {
            _companyAccountAddApplysService = new CompanyAccountAddApplysService();
            _enumerationService = new EnumerationService();
            _systemUsersService = new SystemUsersService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdlData();
                BindData();
            }
        }

        private void BindDdlData()
        {
            var list = _enumerationService.SelectEnumerationsByTypeName("AccApplyStatus");
            foreach (var item in list)
            {
                ddlorderStatus.Items.Add(new ListItem(item.EnumValue, item.EnumKey));
            }
            ddlorderStatus.Items.Insert(0, new ListItem("请选择", ""));
            var companyList = _systemUsersService.FindAll(new SystemUsers());
            foreach (var items in companyList)
            {
                ddlCompany.Items.Add(new ListItem(items.Account, items.SysUserKey.ToString()));
            }
            ddlCompany.Items.Insert(0, new ListItem("请选择", "0"));
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }
        protected void btnPage_Click(object sender, EventArgs e)
        {
            PageHelper.SetPageIndex(int.Parse(hidePage.Value));
            BindData();
        }


        private void BindData()
        {
            var condtiion = GetQueryCondition();
            SetPager(_companyAccountAddApplysService.GetCount(condtiion), 10);
            var data = _companyAccountAddApplysService.FindAll(condtiion);
            gvDisList.DataSource = data;
            gvDisList.DataBind();
        }

        private CompanyAccountAddApplys GetQueryCondition()
        {
            return new CompanyAccountAddApplys
            {
                IsStartPager = true,
                StartRecordIndex = PageHelper.GetStartIndex(),
                EndRecordIndex = PageHelper.GetEndIndex() < PageHelper.GetPageTotal()
                        ? PageHelper.GetPageTotal()
                        : PageHelper.GetEndIndex(),
                ApplyStatus = ddlorderStatus.SelectedValue
            };
        }

        private ICompanyAccountAddApplysService _companyAccountAddApplysService;
        private ISystemUsersService _systemUsersService;
        private IEnumerationService _enumerationService;
    }
}