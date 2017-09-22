using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.InformationViews
{
    public partial class UserInfoList : ListPageBase
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            var user = GetQueryCondition();
            SetPager(user);
            IList<SystemUsers> userList = _systemUsersService.FindAll(user);
            gvUserList.DataSource = userList;
            gvUserList.DataBind();

        }

        private SystemUsers GetQueryCondition()
        {
            return new SystemUsers
            {
                IsStartPager = true,
                StartRecordIndex = PageHelper.GetStartIndex(),
                EndRecordIndex = PageHelper.GetEndIndex() < PageHelper.GetPageTotal()
                        ? PageHelper.GetPageTotal()
                        : PageHelper.GetEndIndex(),
                Account = this.txtName.Text.Trim(),
                Status = this.ddlStatus.SelectedValue,
                SysUserKeyList = _systemUsersService.SelectSystemChildrensKey(new SystemUsers { SysUserKey = CurrentUser.SysUserKey })
            };
        }

        protected void btnPage_Click(object sender, EventArgs e)
        {
            PageHelper.SetPageIndex(int.Parse(hidePage.Value));
            BindData();
        }

        

        private void SetPager(SystemUsers user)
        {
            SetPager(_systemUsersService.GetCount(user), 10);
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        
    }
}