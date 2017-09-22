using System;
using System.Web.UI.HtmlControls;

namespace MONO.Distribution.UIProcess
{
    /// <summary>
    /// 列表页面基类
    /// </summary>
    public class ListPageBase : PageBase
    {
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            //RigisterJavascriptFiles();

        }

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

            var pagejs = new HtmlGenericControl { TagName = "script" };
            pagejs.Attributes.Add("type", "text/javascript");
            pagejs.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("/Scripts/page.js")));

            this.Page.Header.Controls.AddAt(0, stylecss);
            this.Page.Header.Controls.AddAt(1, selectcss);
            this.Page.Header.Controls.AddAt(2, jqueryjs);
            this.Page.Header.Controls.AddAt(3, navjs);
            this.Page.Header.Controls.AddAt(4, selectjs);
            this.Page.Header.Controls.AddAt(5, commonjs);
            this.Page.Header.Controls.AddAt(6, pagejs);
        }
        protected override void OnLoad(EventArgs e)
        {
            if (Session["User"] == null)
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script language=javascript>window.parent.location.href = '../Login.aspx';</script>");
                return;
            }
            base.OnLoad(e);
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        public bool CheckIsVisable(object id)
        {
            if (int.Parse(id.ToString()) == CurrentUser.SysUserKey)
                return false;
            return true;
        }

        public bool CheckIsAdmin(object id)
        {
            var sysuser = _systemUsersService.FindById(int.Parse(id.ToString()));
            if (sysuser != null && sysuser.Account.Equals("admin"))
                return false;
            return true;
        }




    }
}
