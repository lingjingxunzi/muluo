using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoolShow.UI
{
    public partial class BusinessTaskEdit : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void ddlTaskStyleChanged(object sender, EventArgs e)
        {
            switch (ddlTaskStyle.SelectedValue)
            {
                case "":
                    break;
                    
            }
        }
    }
}