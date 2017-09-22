using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.UI
{
    public partial class Test : System.Web.UI.Page
    {
        ILog LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IPushResultRecordService _pushResultRecordService = new PushResultRecordService();
               var result = _pushResultRecordService.Insert(new PushResultRecords()
                {
                    Msg = "1",
                    OrderKey ="2",
                    PushResultRecordTempKey = "3",
                    PushUrl = "4",
                    Result ="5",
                    BatchNo = "6"
                });

                foreach (var item in result.Errors)
                {
                    LogMsg.Info(item.Value);
                }
            }
        }
    }
}