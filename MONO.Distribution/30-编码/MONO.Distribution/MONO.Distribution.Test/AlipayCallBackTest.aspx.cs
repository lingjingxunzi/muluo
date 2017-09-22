using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;

namespace MONO.Distribution.Test
{
    public partial class AlipayCallBackTest : System.Web.UI.Page
    {
        public AlipayCallBackTest()
        {
            _recordsService = new RechargeRecordsService();
            _systemAccountService = new SystemAccountService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var out_trade_no = Request.QueryString["out_trade_no"];
                var records = _recordsService.FindById(out_trade_no);

                if (records != null && records.Status.Equals("DCL"))
                {
                    var result = _systemAccountService.SystemAccountChange(records.SysUserKey, out_trade_no, Convert.ToInt32(records.Amount * 100), "CR");
                    if (result.IsOk)
                    {
                        result = _systemAccountService.SystemAccountChange(records.RechargeTo, out_trade_no, Convert.ToInt32(records.Amount * 100), "CR");
                        if (result.IsOk)
                        {
                            _systemAccountService.SystemAccountChange(records.SysUserKey, out_trade_no, -Convert.ToInt32(records.Amount * 100), "CR");
                        }
                    }
                    records.Status = "YCL";
                    _recordsService.Update(records);
                }
            }
        }

        private IRechargeRecordsService _recordsService;
        private ISystemAccountService _systemAccountService;
        private ISystemUsersService _systemUsersService = new SystemUsersService();
    }
}