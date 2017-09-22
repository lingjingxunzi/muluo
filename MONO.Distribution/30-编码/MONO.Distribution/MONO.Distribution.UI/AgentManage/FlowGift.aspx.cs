using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.UI.WebControls;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.AgentManage
{
    public partial class FlowGift : EditPageBase
    {
        public FlowGift()
        {
            successStr = new StringBuilder();
            sbErr = new StringBuilder();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hfAuth.Value = Request.Cookies[FormsAuthentication.FormsCookieName] == null ? string.Empty : Request.Cookies[FormsAuthentication.FormsCookieName].Value;
                this.hfAspSessID.Value = Session.SessionID;
                this.hfExcelAuth.Value = Request.Cookies[FormsAuthentication.FormsCookieName] == null ? string.Empty : Request.Cookies[FormsAuthentication.FormsCookieName].Value;
                this.hfExcelSessid.Value = Session.SessionID;

                BindBaseInfo();
            }
        }


        private void BindBaseInfo()
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var mobileStr = BindGiftMobilePhone();
            if (!string.IsNullOrEmpty(sbErr.ToString())) return;
            var flowKeyStr = AppendFlowKey();

        }

        protected void txtPhone_TextChange(object sender, EventArgs e)
        {
            var arr = txtPhone.Text.Trim().Split(';');
            iTotalPhone.Text = arr.Length.ToString();
        }

        private string BindGiftMobilePhone()
        {
            var sb = new StringBuilder();
            var phoneArr = txtPhone.Text.Trim().TrimEnd(';').Split(';');
            var dReg = new Regex("[0-9]{11,11}");
            var flowCount = 0;
            foreach (var mobile in phoneArr)
            {
                if (dReg.IsMatch(mobile))
                {

                }
                else
                {
                    flowCount++;
                    sbErr.Append(mobile + "格式不正确！");
                }
            }
            if (flowCount == 0) sbErr.Append("流量包未选择！");
            if (string.IsNullOrEmpty(sbErr.ToString()))
            {
                this.div_result.Visible = true;
                dd_Falid.Visible = false;
                dd_Success.Visible = false;
            }
            return sb.ToString().TrimEnd('|');
        }
        private string AppendFlowKey()
        {
            var flowKeyStr = new StringBuilder();
            if (int.Parse(ddlDxFlows.SelectedValue) > 0) flowKeyStr.Append(ddlDxFlows.SelectedValue + ",");
            if (int.Parse(ddlLtFlows.SelectedValue) > 0) flowKeyStr.Append(ddlLtFlows.SelectedValue + ",");
            if (int.Parse(ddlYdFlows.SelectedValue) > 0) flowKeyStr.Append(ddlYdFlows.SelectedValue + ",");
            return flowKeyStr.ToString().TrimEnd(',');
        }
        private string GetDdlSelectValue(string type)
        {
            switch (type.ToUpper())
            {
                case "YD":
                    return ddlYdFlows.SelectedValue;
                    break;
                case "DX":
                    return ddlDxFlows.SelectedValue;
                    break;
                case "LT":
                    return ddlLtFlows.SelectedValue;
                    break;
                default:
                    return "0";
            }
        }











        private StringBuilder successStr;
        private StringBuilder sbErr;
    }
}