using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MONO.Message.UI
{
    public partial class Index :  Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var msgSend = new MessageMethod();
                //var result = msgSend.GetBalance("123", "123456");
            }
        }
    }
}