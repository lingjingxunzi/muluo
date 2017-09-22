using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.Utility;

namespace MONO.Distribution.Test
{
    public partial class OrderFlows : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }


        protected void btnTest_OnClick(object sender, EventArgs e)
        {
            var url = "http://localhost:9012/FlowAgent.aspx?";
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var order = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var sigStr = txtSec.Text + "||" + ddlMethod.SelectedValue + "||" + txtPhone.Text + "," + txtProductId.Text + "," +order+ "||" + txtAccount.Text + "||" + timestamp + "||" + txtSec.Text;
            var sigSHA1 = CarrierCharManipulation.SHA1(sigStr);
            var sig = sigSHA1.Substring(4, sigSHA1.Length - 8);
            var param = "name=" + ddlMethod.SelectedValue + "&userkey=" + txtAccount.Text + "&phonecodestr=" + txtPhone.Text + "," + txtProductId.Text + "," + order + "&backurl=http://baidu.com" + "&timestamp=" + timestamp + "&sig=" + sig;
            url = url + param;
            var json= HttpWebRequestTools.GetRequestByHttpWeb(url);
            Response.Write(json);
        }
    }
}