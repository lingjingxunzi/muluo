using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.Sys
{
    public partial class UserRemarkEdit : EditPageBase
    {
        public UserRemarkEdit()
        {
            _systemUsersService = new SystemUsersService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInfo();
            }
        }

        private void BindInfo()
        {
            var key = int.Parse(Request.QueryString["UserKey"]);
            var baseInfo = _systemUsersService.FindById(key);
            this.txtRemark.Text = baseInfo.Remark;

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var key = int.Parse(Request.QueryString["UserKey"]);
            var baseInfo = _systemUsersService.FindById(key);
            baseInfo.Remark = txtRemark.Text;
            ResultMessage = _systemUsersService.Update(baseInfo);
            OperationEnd("系统管理-查看用户","修改用户备注信息");
        }

        private ISystemUsersService _systemUsersService;


        
    }
}