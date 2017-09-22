using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using System.Reflection;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.UI.BackupOperate
{
    public partial class UpdateAccountTimer : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var result = _systemAccountService.ExecUpdateCompanyAccount(new SystemAccount());
                if (!result.IsOk)
                {
                    foreach (var item in result.Errors)
                    {
                        LogMsg.Info(item.Value);
                    }                   
                }               
            }
        }



       ILog  LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
       private ISystemAccountService _systemAccountService = new SystemAccountService();
    }
}