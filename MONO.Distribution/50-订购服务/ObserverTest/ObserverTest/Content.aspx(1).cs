using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ObserverBLL;

namespace ObserverTest
{
    public partial class Content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void btn_OnClick(object sender, EventArgs e)
        {
            var test = new AccountChangeTest();
            test.AccountChange();
        }
    }
}