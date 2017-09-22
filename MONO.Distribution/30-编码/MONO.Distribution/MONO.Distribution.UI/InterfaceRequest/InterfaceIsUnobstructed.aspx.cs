using System;
using MONO.Distribution.UIProcess;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.InterfaceRequest
{
    public partial class InterfaceIsUnobstructed : EditPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTestCM023New_OnClick(object sender, EventArgs e)
        {
            try
            {
                var App = "d848ecf03b1a46d497e3ebaa4bf82058";
                var AppSec = "553feb8704ba4492bedba5b42045eced";
                var time = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fff") + "+08:00";
                var authUrl = "http://cqdata.4ggogo.com/web-in/auth.html";
                var sign = CarrierCharManipulation.SHA256(App + time + AppSec);
                var paramStr = "<Request>"
                    + "<Datetime>" + time + "</Datetime>"
                    + "<Authorization><AppKey>" + App + "</AppKey>"
                    + "<Sign>" + sign + "</Sign>"
                    + "</Authorization></Request>";
                var authJson = HttpWebRequestTools.CM023NewAuthHttpPost(authUrl, paramStr);
                txtCM023TestResult.Text = authJson;
            }
            catch (Exception ex)
            {
                txtCM023TestResult.Text = ex.Message;
            }
        }
    }
}