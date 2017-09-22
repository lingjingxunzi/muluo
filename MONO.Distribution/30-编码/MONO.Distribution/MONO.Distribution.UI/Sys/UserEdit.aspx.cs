using System;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.UIProcess;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.Sys
{
    public partial class UserEdit : EditPageBase
    {
        public UserEdit()
        {
            _systemUsersService = new SystemUsersService();
            _enumerationService = new EnumerationService();
            _sysUserGroupsService = new SysUserGroupsService();
            ResultMessage = new ResultMessage();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IsOpenTabNav = false;
            if (!IsPostBack)
            {
                BindDdlData();
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
            var info = _systemUsersService.FindById(int.Parse(Request.QueryString["UserKey"]));
            SetInstance(info);
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            ValidateInfo();
            if (!ResultMessage.IsOk)
            {
                //MessageBox(Page, GetNotice(ResultMessage));
                return;
            }
            var info = new SystemUsers();
            GetInstance(info);
            //ResultMessage = _systemUsersService.Insert(info);
            OperationEnd();
            WriteLog("系统用户管理", "新增用户-" + info.Account, "");
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ValidateInfo();
            if (!ResultMessage.IsOk)
            {
                //MessageBox(Page, GetNotice(ResultMessage));
                return;
            }
            var info = _systemUsersService.FindById(int.Parse(Request.QueryString["UserKey"]));
            GetInstance(info);
            _systemUsersService.Update(info);
            OperationEnd();
            WriteLog("系统用户管理", "用户编辑-" + info.Account, "");
        }

        private void ValidateInfo()
        {
            var variable = new CheckPageVariable();
            variable.CheckInputValueIsEmpty(txtName.Text.Trim())
                .CheckInputValueIsEmpty(txtScrect.Text.Trim())
                .CheckInputValue(txtName.Text.Trim(), 20, "txtNameLenth", "用户账号长度不能超过20个字符！")
                .CheckInputValue(txtScrect.Text.Trim(), 20, "txtScrectLength", "密码长度不能超过20个字符！");
            if (this.CurrentUser == null)
                variable.AddErrorMsg("CurrentUserIsNUll" + Guid.NewGuid(), "CurrentUserIsNUll");
            ResultMessage = variable.GetResultMessage();
        }

        private void GetInstance(SystemUsers info)
        {
            if (info == null) return;
            info.Account = txtName.Text;
            info.PWD = txtScrect.Text;
            info.Status = ddlStatus.SelectedValue;
            info.GroupKey = int.Parse(ddlGroup.SelectedValue);
            info.CurrentUserId = this.CurrentUser == null ? 0 : this.CurrentUser.SysUserKey;
            info.Nick = txtNick.Text;
        }

        private void SetInstance(SystemUsers info)
        {
            txtName.Text = info.Account;
            txtScrect.Text = info.PWD;
            ddlStatus.SelectedValue = info.Status;
            ddlGroup.SelectedValue = info.GroupKey.ToString();
            txtNick.Text = info.Nick;
        }

        private void BindDdlData()
        {
            var groups = _sysUserGroupsService.FindAll(new SysUserGroups() { IsJurisdiction = "Y", Levels = CurrentUser.SysUserGroups.Levels });
            ddlGroup.DataTextField = "Name";
            ddlGroup.DataValueField = "GroupKey";
            ddlGroup.DataSource = groups;
            ddlGroup.DataBind();
            ddlGroup.Items.Insert(0, new ListItem("请选择", "0"));
        }

        private readonly ISysUserGroupsService _sysUserGroupsService;
        private readonly IEnumerationService _enumerationService;
        private readonly ISystemUsersService _systemUsersService;

    }
}