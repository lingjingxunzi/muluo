using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] == null)
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script language=javascript>window.parent.location.href = '../Login.aspx';</script>");
                    return;
                }
            }
        }


    }
}