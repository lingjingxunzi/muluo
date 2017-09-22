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

namespace MONO.Distribution.UI.AgentManage
{
    public partial class AgentUserList : ListPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _usersService = new SystemUsersService();
            if (!IsPostBack)
            {
                BindUserData();

            }
        }


        #region
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindUserData();
            WriteLog("系统用户管理", "用户查询", "");
        }

        protected void btnPage_Click(object sender, EventArgs e)
        {
            PageHelper.SetPageIndex(int.Parse(hidePage.Value));
            BindUserData();
        }

        protected void gvUserList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (e.CommandName == "del")
            {
                id = Convert.ToInt32(e.CommandArgument);
                Delete(id);
            }
            else if (e.CommandName == "reset")
            {
                id = int.Parse(e.CommandArgument.ToString());
                var info = _usersService.FindById(id);
                if (info != null) info.PWD = "123456";
                var result = _usersService.Update(info);
                WriteLog("用户管理", "用户密码重置" + info.Account + (result.IsOk ? "成功" : "失败"), "");
            }
            BindUserData();
        }

        private void Delete(int id)
        {
            var info = _usersService.FindById(id);
            info.Flag = 1;
            _usersService.Update(info);
        }

        protected void AspNetPager_PageChanged(object src, EventArgs e)
        {
            BindUserData();
        }
        #endregion


        private void BindUserData()
        {
            var user = GetQueryCondition();
            SetPager(user);
            IList<SystemUsers> userList = _usersService.FindAll(user);
            gvUserList.DataSource = userList;
            gvUserList.DataBind();
        }

        private void SetPager(SystemUsers user)
        {

            SetPager(_usersService.GetCount(user), 10);
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
                SysUserKeyList = _usersService.SelectSystemChildrensKey(new SystemUsers { SysUserKey = CurrentUser.SysUserKey })
            };
        }

        private ISystemUsersService _usersService = null;


    }
}