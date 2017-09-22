using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MONO.Distribution.UI.StatisticsManager
{
    public partial class MonthlySaleCharts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtStartQueryDateTime.Text = DateTime.Now.ToString("yyyy-MM");
        }
    }
}