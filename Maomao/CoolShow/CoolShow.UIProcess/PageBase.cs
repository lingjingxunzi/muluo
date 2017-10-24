using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace CoolShow.UIProcess
{
    /// <summary>
    /// 页面基类.提供页面基本功能，所有页面直接或者间接继承该类。
    /// </summary>
    public class PageBase : Page
    {
        #region 构造方法

        #endregion

        #region 事件处理方法
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //if (!IsPostBack)
            // {
            /**
             * binjg 移动至成功登录后记录上下文关系。
             * this.PreLoad += SetContext;
             * **/
            //}
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            SetupControls();
            if (IsOpenTabNav)
            {
                RegisterTabNavScriptBlock();
            }
        }



        //protected virtual void RigisterJavascriptFiles()
        //{
        //    HtmlGenericControl js = new HtmlGenericControl { TagName = "script" };
        //    js.Attributes.Add("type", "text/javascript");
        //    js.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("/Scripts/jquery-1.7.2.min.js")));

        //    HtmlGenericControl js1 = new HtmlGenericControl { TagName = "script" };
        //    js1.Attributes.Add("type", "text/javascript");
        //    js1.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("/Scripts/JQUI/jquery.ui.core.js")));

        //    HtmlGenericControl js2 = new HtmlGenericControl { TagName = "script" };
        //    js2.Attributes.Add("type", "text/javascript");
        //    js2.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("/Scripts/JQUI/jquery.ui.widget.js")));

        //    HtmlGenericControl js3 = new HtmlGenericControl { TagName = "script" };
        //    js3.Attributes.Add("type", "text/javascript");
        //    js3.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("/Scripts/JQUI/jquery.ui.mouse.js")));

        //    HtmlGenericControl js4 = new HtmlGenericControl { TagName = "script" };
        //    js4.Attributes.Add("type", "text/javascript");
        //    js4.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("/Scripts/JQUI/jquery.ui.sortable.js")));

        //    HtmlGenericControl js5 = new HtmlGenericControl { TagName = "script" };
        //    js5.Attributes.Add("type", "text/javascript");
        //    js5.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("/Scripts/Mouse.js")));

        //    HtmlGenericControl js6 = new HtmlGenericControl { TagName = "script" };
        //    js6.Attributes.Add("type", "text/javascript");
        //    js6.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("/Scripts/TabNav.js")));

        //    HtmlGenericControl js7 = new HtmlGenericControl { TagName = "script" };
        //    js7.Attributes.Add("type", "text/javascript");
        //    js7.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("/Scripts/EnterToTab.js")));



        //    HtmlGenericControl js9 = new HtmlGenericControl { TagName = "script" };
        //    js9.Attributes.Add("type", "text/javascript");
        //    js9.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("/CSS/assets/js/vendor-modules/sea.js")));

        //    HtmlGenericControl js10 = new HtmlGenericControl { TagName = "script" };
        //    js10.Attributes.Add("type", "text/javascript");
        //    js10.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("/Scripts/Default/commom.helper.js")));



        //    this.Page.Header.Controls.AddAt(1, js);
        //    this.Page.Header.Controls.AddAt(2, js1);
        //    this.Page.Header.Controls.AddAt(3, js2);
        //    this.Page.Header.Controls.AddAt(4, js3);
        //    this.Page.Header.Controls.AddAt(5, js4);
        //    this.Page.Header.Controls.AddAt(6, js5);
        //    this.Page.Header.Controls.AddAt(7, js6);
        //    this.Page.Header.Controls.AddAt(8, js7);
        //    this.Page.Header.Controls.AddAt(9, js9);
        //    this.Page.Header.Controls.AddAt(10, js10);
        //}

        private void RegisterTabNavScriptBlock()
        {
            //    FB_Menus menu = GetCurrentPageMenu(this.Request.Url);

            //    //tab标签命名格式：#tabs-category-command-menuid-id
            //    string id = string.Format("#tabs-{0}-{1}-{2}-{3}", menu.Code, "", menu.MenuKey, "");
            //    string href = id;

            //    StringBuilder sb = new StringBuilder();
            //    sb.AppendLine("$(function(){setCurrentPageTab(window.parent.document");
            //    sb.Append(string.Format(",'{0}'", id));
            //    if (string.IsNullOrEmpty(menu.Name))
            //    {
            //        sb.Append(string.Format(",window.document.title"));
            //    }
            //    else
            //    {
            //        sb.Append(string.Format(",'{0}'", menu.Name));
            //    }
            //    sb.Append(string.Format(",'{0}'", href));
            //    sb.Append(string.Format(",'{0}'", this.Request.Url));
            //    sb.Append(");});");
            //    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "TabNav", sb.ToString(), true);
        }


        //private Menus GetCurrentPageMenu(Uri uri)
        //{
        //    string pagePathForQuery = uri.AbsolutePath.Substring(1);
        //    IMenusService menuService = new MenusService();
        //    var queryResult1 = menuService.FindAll(new Menus { Path = pagePathForQuery, Status = "0" });
        //    Menus myMenu = new Menus();
        //    foreach (var menu in queryResult1)
        //    {
        //        if (menu.Path.ToLower() == pagePathForQuery.ToLower())
        //        {
        //            myMenu = menu;
        //            break;
        //        }
        //        if (menu.Path.Split('?')[0].ToLower() == pagePathForQuery.ToLower() && "?" + menu.Path.Split('?')[1].ToLower() == uri.Query.ToLower())
        //        {
        //            myMenu = menu;
        //            break;
        //        }
        //    }
        //    return myMenu;
        //}



        #endregion

        #region 属性
        //protected String AppRootPath
        //{
        //    get
        //    {
        //        string absolutePath = Request.Url.AbsolutePath;
        //        string hostUrl = Request.Url.AbsoluteUri.Replace(absolutePath, "");
        //        if (hostUrl.IndexOf('?') != -1)
        //            hostUrl = hostUrl.Remove(hostUrl.IndexOf('?'));
        //        string applicationPath = Request.ApplicationPath;
        //        hostUrl = string.Format("{0}{1}", hostUrl, applicationPath).TrimEnd('/');
        //        return hostUrl;
        //    }
        //}

        /// <summary>
        /// 返回当前用户信息
        /// </summary>
        //public SystemUsers CurrentUser
        //{
        //    get
        //    {
        //        //if (Session["User"] == null)
        //        //{
        //        //    Response.Redirect("http://113.207.124.143");
        //        //    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script language=javascript>window.parent.parent.location.href = '../Login.aspx';</script>");
        //        //}
        //        return HttpContext.Current.Session["USER"] as SystemUsers;
        //    }
        //}

        /// <summary>
        /// 设置是否验证页面权限
        /// </summary>
        protected bool IsCheckPageAuthentication
        {
            get { return isCheckPageAuthentication; }
            set { isCheckPageAuthentication = value; }
        }



        ///// <summary>
        ///// 根据枚举键，获取枚举值集
        ///// </summary>
        ///// <param name="key">枚举键</param>
        ///// <returns>枚举值集</returns>
        //public Enumerations GetEnumerationValuesByKey(string key)
        //{
        //    IList<Enumerations> enumerationCollection = new List<Enumerations>();
        //    IList<Enumerations> enumerations = HttpContext.Current.Application["EnmuMap"] as IList<Enumerations>;
        //    if (enumerations != null)
        //    {
        //        enumerationCollection = (from enu in enumerations
        //                                 where enu.EnumKey == key
        //                                 && enu.Status == "1"
        //                                 select enu).ToList();

        //    }
        //    return enumerationCollection.Count > 0 ? enumerationCollection[0] : null;
        //}
        ///// <summary>
        ///// 根据枚举类型，获取枚举值集
        ///// </summary>
        ///// <param name="type">枚举类型</param>
        ///// <returns>枚举值集</returns>
        //public IList<Enumerations> GetEnumerationValuesByType(string type)
        //{
        //    IList<Enumerations> enumerationCollection = new List<Enumerations>();
        //    IList<Enumerations> enumerations = HttpContext.Current.Application["EnmuMap"] as IList<Enumerations>;
        //    if (enumerations != null)
        //    {
        //        //enumerationCollection = (from enu in enumerations
        //        //                         where enu..Code == type
        //        //                         && enu.Status == "1"
        //        //                         orderby enu.Order
        //        //                         select enu).ToList();

        //    }
        //    return enumerationCollection;
        //}

        private bool _isOpenTabNav = true;
        public bool IsOpenTabNav
        {
            get { return _isOpenTabNav; }
            set { _isOpenTabNav = value; }
        }

        private void SetupControls()
        {
          //  LimitTextBox();
        }

        //private void LimitTextBox()
        //{
        //    foreach (var controls in this.Controls)
        //    {
        //        HtmlForm form = controls as HtmlForm;
        //        if (form == null)
        //            continue;
        //        foreach (var formControls in form.Controls)
        //        {
        //            TextBox text = formControls as TextBox;
        //            if (text != null && text.MaxLength == 0)
        //            {
        //                text.MaxLength = 4000;
        //            }
        //        }
        //    }
        //}

        #endregion

        #region 方法



        //public string IP
        //{
        //    get
        //    {
        //        return IPUtil.GetUserIP();
        //    }
        //}

        //protected void SetContext(object sender, EventArgs e)
        //{
        //    Thread.SetData(Thread.GetNamedDataSlot(MyContext.Instance.USER), this.CurrentUser);
        //    Thread.SetData(Thread.GetNamedDataSlot(MyContext.Instance.USER_ID), this.CurrentUser.SysUserKey);
        //    Thread.SetData(Thread.GetNamedDataSlot(MyContext.Instance.USER_NAME), this.CurrentUser.SysUserInfos.Name);
        //}

        /// <summary>
        /// 服务端返回错误信息后，在页面进行警告提示。
        /// </summary>
        /// <param name="result">服务端返回信息</param>
        /// <returns>HTML包装的警告提示</returns>
        //protected string GetNotice(ResultMessage result)
        //{
        //    string errorContent = "<ul style='list-style-type:square;'>";
        //    foreach (string key in result.Errors.Keys)
        //    {
        //        errorContent += @"<li style='float:none; margin-top:5px'>" + result.Errors[key].Replace("\"", "&quot;").Replace("'", "&#39;") + "</li>";
        //    }
        //    errorContent += "</ul>";
        //    return errorContent;
        //}

        //protected string GetNoticeForLog(ResultMessage result)
        //{
        //    var logs = new StringBuilder();
        //    foreach (string key in result.Errors.Keys)
        //    {
        //        logs.Append(result.Errors[key]);
        //    }
        //    return logs.ToString();
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalPage">数据总数</param>
        /// <param name="rowsCount">数据项开头</param>
        //public void SetPager(int totalPage, int rowsCount)
        //{
        //    PageHelper.SetPageTotal(totalPage);
        //    var recordInfo = (System.Web.UI.HtmlControls.HtmlContainerControl)this.Page.FindControl("recordinfo");
        //    var pageinfo = (System.Web.UI.HtmlControls.HtmlContainerControl)this.Page.FindControl("pageinfo");
        //    if (recordInfo != null && pageinfo != null)
        //    {
        //        PageHelper.SetPageIndex(PageHelper.getPage(totalPage, PageHelper.GetStartIndex()));
        //        recordInfo.InnerHtml = PageHelper.DataRecordTxt(PageHelper.GetPageIndex(), PageHelper.GetPageTotal());
        //        pageinfo.InnerHtml = PageHelper.PageInfo(PageHelper.GetPageIndex(), PageHelper.GetPageTotal());
        //    }
        //}


        #endregion

        #region 私有变量

        private bool isCheckPageAuthentication = true;
        protected IPageHelper PageHelper = new PageHelper();
        #endregion

        //public void WriteLog(string module, string content, string level)
        //{
        //    var log = new SystemLogs
        //    {
        //        SystemLogKey = Guid.NewGuid(),
        //        SysUserKey = CurrentUser == null ? 0 : CurrentUser.SysUserKey,
        //        Module = module,
        //        Content = content,
        //        Level = "1",
        //        IP = GetIPHelper.GetIP()
        //    };
        //    _systemLogsService.Insert(log);
        //}

        //public void ResetCurrentInfo()
        //{
        //    var sysUser = _systemUsersService.SelectByAccount(CurrentUser.Account);
        //    HttpContext.Current.Session["USER"] = sysUser;
        //}

        //protected ISystemUsersService _systemUsersService = new SystemUsersService();
        //protected ISystemLogsService _systemLogsService = new SystemLogsService();
    }
}
