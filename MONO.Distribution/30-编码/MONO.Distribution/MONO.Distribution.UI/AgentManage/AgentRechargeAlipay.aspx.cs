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

namespace MONO.Distribution.UI.AgentManage
{
    public partial class AgentRechargeAlipay : Page
    {
        public AgentRechargeAlipay()
        {
            _rechargeRecordsService = new RechargeRecordsService();
            _systemUsersService = new SystemUsersService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            if (!IsPostBack)
            {
                var recharge = _rechargeRecordsService.FindById(Request.QueryString["key"]);
                var sysremUser= _systemUsersService.FindById(recharge.SysUserKey);
                var html = AlipayHelper.AlipayOrder(new AlipayParamModels { Amount = recharge.Amount, Describe = "", OrderId = recharge.RechargeKey.ToString(), OrderName = sysremUser.Nick + "充值" });
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.Write(html);
            }
        }


        private IRechargeRecordsService _rechargeRecordsService;
        private ISystemUsersService _systemUsersService;
    }
}