using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.Alipay;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.AlipayViewModel;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.AgentManage
{
    public partial class AgentRecharge : EditPageBase
    {
        public AgentRecharge()
        {
            _systemAccountService = new SystemAccountService();
            _rechargeRecordsService = new RechargeRecordsService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected override void SetUpdate()
        {
            BindBaseInfo();
        }



        private void BindBaseInfo()
        {
            var accountInfo = _systemAccountService.SelectSystemAccountByUserKey(int.Parse(Request.QueryString["UserKey"]));
            this.txtName.Text = accountInfo.SystemUsers.Account;
            this.txtLeft.Text = accountInfo.LeftAccount.ToString();
            this.txtTotal.Text = accountInfo.TotalAccount.ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var recharge = new RechargeRecords();
            recharge.Amount = int.Parse(txtTurnIn.Text) / 100;
            recharge.SysUserKey = CurrentUser.SysUserKey;
            recharge.RechargeKey = Guid.NewGuid();
            recharge.Status = "DCL";
            recharge.RechargeTo = int.Parse(Request.QueryString["UserKey"]);
            ResultMessage = _rechargeRecordsService.Insert(recharge);
            if (ResultMessage.IsOk)
            {
                WriteLog("账户管理", "充入操作，金额为：" + recharge.Amount, "");
                var url = "AgentRechargeAlipay.aspx?key=" + recharge.RechargeKey;
                var html = AlipayHelper.AlipayOrder(new AlipayParamModels { Amount = recharge.Amount, Describe = "", OrderId = recharge.RechargeKey.ToString(), OrderName = "recharge" });

                Response.Write(html);
                //Response.ContentEncoding = System.Text.Encoding.UTF8;
                //Response.Write("<script language='javascript'>window.open('" + url + "');</script>");
            }
        }

        private ISystemAccountService _systemAccountService;
        private string name;
        private IRechargeRecordsService _rechargeRecordsService;
    }
}