using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

namespace MONO.Distribution.UI
{
    public partial class Index : Page
    {
        public Index()
        {
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }



        private ILog LogMsg;
    }
}