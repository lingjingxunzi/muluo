

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using log4net;
using MONO.Distribution.Common;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UIProcess
{
    /// <summary>
    /// 编辑页面基类，如：新增、修改、详情等页面须继承改类
    /// </summary>
    public class EditPageBase : PageBase
    {

        #region 构造函数

        public EditPageBase()
            : base()
        {
            this._commandName = this.Context.Request["Command"] == null ? "" : this.Context.Request["Command"];
            Id = GetId();
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        #endregion

        #region 公有、保护方法
        protected override void OnLoad(EventArgs e)
        {
            if (Session["User"] == null)
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script language=javascript>window.parent.parent.location.href = '../Login.aspx';</script>");
                return;
            }
            base.OnLoad(e);
            SetPage();

        }

        /// <summary>
        /// 新增页面设置在此方法进行
        /// </summary>
        protected virtual void SetInsert()
        {

        }
        /// <summary>
        /// 修改页面设置在此方法进行
        /// </summary>
        protected virtual void SetUpdate()
        {
        }
        /// <summary>
        /// 详情页面设置在此方法进行
        /// </summary>
        protected virtual void SetDetail()
        {
        }

        protected void OperationEnd(string module = "", string opername = "")
        {
            if (ResultMessage == null)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), _operationName, _goToUrl, true);
                return;
            }
            if (ResultMessage.IsOk)
            {
                if (!string.IsNullOrEmpty(opername) && !string.IsNullOrEmpty(module))
                    WriteLog(module, opername + "成功", "");
                this.ClientScript.RegisterStartupScript(this.GetType(), _operationName, _goToUrl, true);
            }
            else
            {
                WriteLog(module, opername + "失败;错误原因" + GetNoticeForLog(ResultMessage), "");
                this.ClientScript.RegisterStartupScript(this.GetType(), _operationName, _goToUrl, true);
            }
        }
        #endregion


        protected override void RigisterJavascriptFiles()
        {
            var selectcss = new HtmlGenericControl { TagName = "link" };
            selectcss.Attributes.Add("type", "text/css");
            selectcss.Attributes.Add("rel", "stylesheet");
            selectcss.Attributes.Add("href", ResolveUrl(Page.ResolveClientUrl("/CSS/select.css")));


            var stylecss = new HtmlGenericControl { TagName = "link" };
            stylecss.Attributes.Add("type", "text/css");
            stylecss.Attributes.Add("rel", "stylesheet");
            stylecss.Attributes.Add("href", ResolveUrl(Page.ResolveClientUrl("/CSS/style.css")));

            var jqueryjs = new HtmlGenericControl { TagName = "script" };
            jqueryjs.Attributes.Add("type", "text/javascript");
            jqueryjs.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("/Scripts/js/jquery.js")));

            var navjs = new HtmlGenericControl { TagName = "script" };
            navjs.Attributes.Add("type", "text/javascript");
            navjs.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("/Scripts/nav.init.js")));

            var selectjs = new HtmlGenericControl { TagName = "script" };
            selectjs.Attributes.Add("type", "text/javascript");
            selectjs.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("/Scripts/js/select-ui.min.js")));

            var commonjs = new HtmlGenericControl { TagName = "script" };
            commonjs.Attributes.Add("type", "text/javascript");
            commonjs.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("/Scripts/common.js")));

            this.Page.Header.Controls.AddAt(0, stylecss);
            this.Page.Header.Controls.AddAt(1, selectcss);
            this.Page.Header.Controls.AddAt(2, jqueryjs);
            this.Page.Header.Controls.AddAt(4, selectjs);
            this.Page.Header.Controls.AddAt(5, commonjs);
        }
        #region 属性
        /// <summary>
        /// 操作命令
        /// </summary>
        public string Command { get { return this._commandName; } set { this._commandName = value; } }
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        #endregion

        #region 私有方法
        private int GetId()
        {
            string sId = this.Context.Request["Id"];
            int result;
            int.TryParse(sId, out result);
            return result;
        }
        private void SetPage()
        {
            switch (this.Command.ToUpper())
            {
                case "":
                case "INSERT":
                    {
                        if (IsPostBack)
                            return;
                        SetInsert();
                    }
                    break;
                case "EDIT":
                case "UPDATE":
                    {
                        if (IsPostBack)
                            return;
                        SetUpdate();
                    }
                    break;
                case "DETAIL":
                    {
                        SetDetail();
                        SetController();
                    }
                    break;
            }
        }
        private void SetController()
        {
            IList<string> preNames = ConfigurationManager.AppSettings["ControlPreNames"].Split(',').ToList<String>();
            foreach (var controller in this.Page.Form.Controls)
            {
                Control control = controller as Control;
                if (controller == null || control.ID == null)
                    continue;
                foreach (var preName in preNames)
                {
                    WebControl webControl = controller as WebControl;
                    if (control.ID.ToUpper().StartsWith(preName.ToUpper()) && webControl != null)
                    {
                        webControl.Enabled = false;
                    }
                }
            }
        }
        #endregion

        #region 私有变量
        private string _commandName;
        protected ResultMessage ResultMessage;
        private string _operationName = "editComplete";
        private string _goToUrl = "parent.closeWindow(true);";
        protected string _updateaccount = "this.parent.parent.window.document.getElementById('topFrame').contentWindow.updateAccount();";
        protected ILog LogMsg;

        #endregion
    }

}
