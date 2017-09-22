using System;

namespace FB_FlowAgent_Test
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
            if (ddlMethod.SelectedValue.Equals("orderpkg"))
            {
                var url = "http://113.207.124.143/FlowAgent.aspx?";
                var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                var order = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                var sigStr = txtSec.Text + "||" + ddlMethod.SelectedValue + "||"+txtPhone.Text+","+txtProductId.Text+","+order+"||" + txtAccount.Text + "||" + timestamp + "||" + txtSec.Text;
                var sigSHA1 = CarrierCharManipulation.SHA1(sigStr);
                var sig = sigSHA1.Substring(4, sigSHA1.Length - 8);
                var param = "name=" + ddlMethod.SelectedValue + "&isactive=1&userkey=" + txtAccount.Text + "&phonecodestr=" + txtPhone.Text + "," + txtProductId.Text + "," + order + "&backurl=http://baidu.com" + "&timestamp=" + timestamp + "&sig=" + sig;
                url = url + param;
                var json = HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                Response.Write(json);
            }
            if (ddlMethod.SelectedValue.Equals("orderbce"))
            {
                var url = "http://localhost:9012/FlowAgent.aspx?";
                var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                var order = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                var sigStr = txtSec.Text + "||" + ddlMethod.SelectedValue + "||" + txtAccount.Text + "||" + timestamp + "||" + txtSec.Text;
                var sigSHA1 = CarrierCharManipulation.SHA1(sigStr);
                var sig = sigSHA1.Substring(4, sigSHA1.Length - 8);
                var param = "name=" + ddlMethod.SelectedValue + "&userkey=" + txtAccount.Text + "&timestamp=" + timestamp + "&sig=" + sig;
                url = url + param;
                var json = HttpWebRequestTools.GetRequestByHttpWeb(url);
                Response.Write(json);
            }

            if (ddlMethod.SelectedValue.Equals("orderquery"))
            {
                var url = "http://localhost:9012/FlowAgent.aspx?";
                var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                var order = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                var sigStr = txtSec.Text + "||" + ddlMethod.SelectedValue + "||" + txtAccount.Text + "||" + txtOrder.Text + "||" + timestamp + "||" + txtSec.Text;
                var sigSHA1 = CarrierCharManipulation.SHA1(sigStr);
                var sig = sigSHA1.Substring(4, sigSHA1.Length - 8);
                var param = "name=" + ddlMethod.SelectedValue + "&userkey=" + txtAccount.Text + "&timestamp=" + timestamp + "&sig=" + sig + "&orderid=" + txtOrder.Text;
                url = url + param;
                var json = HttpWebRequestTools.GetRequestByHttpWeb(url);
                Response.Write(json);
            }
        }
    }
}