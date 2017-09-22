using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MONO.Distribution.UI.ComPage
{
    public partial class EnterMobilePhone : Page
    {
        public EnterMobilePhone()
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { }
        }

        protected void btnEnterPhone_OnClick(object sender, EventArgs e)
        {
            var phone = txtPhone.Value;
            Response.Redirect("FaildToOperator.aspx?Phone=" + phone);
        }
    }
}