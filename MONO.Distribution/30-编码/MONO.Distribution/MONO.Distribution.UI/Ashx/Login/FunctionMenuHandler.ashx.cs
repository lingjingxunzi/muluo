using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Common.Consts;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.UI.Ashx.Login
{
    /// <summary>
    /// FunctionMenuHandler 的摘要说明
    /// </summary>
    public class FunctionMenuHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            user = context.Session["USER"] as SystemUsers;
            if (user == null) return;

            userAccount = user.Account;
            userService = new SystemUsersService();
            _menuService = new MenusService();
            user = userService.SelectByAccount(userAccount);
            menuId = context.Request.QueryString["menuId"];
            context.Response.ContentType = "text/plain";
            context.Response.Write(GetMenuHtml());
        }



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private string GetMenuHtml()
        {
            try
            {
                _menus = _menuService.SelectMenuByUserKey(user.SysUserKey);
                var sb = new StringBuilder();
                foreach (var parentMenus in _menus.Where(m => m.ParentMenuKey == 0).OrderBy(m => m.Order))
                {
                    sb.Append("<dd><div class='title'><span><img src='/Images/leftico01.png' /> </span>" + parentMenus.Name + "</div>");
                    sb.Append("<ul class='menuson'>");
                    var child = from m in _menus
                                where m.ParentMenuKey == parentMenus.MenuKey
                                select m;
                    foreach (var fbMenuse in child)
                    {
                        sb.Append("<li><cite></cite><a href='" + fbMenuse.Path + "' target='rightFrame'>" + fbMenuse.Name + "</a><i></i></li>");
                    }

                    sb.Append("</ul></dd>");
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                return "<li class='border-top'></li>";
            }
        }

        private string BuildFirstLevelMenu(IEnumerable<Menus> menus)
        {
            var firstLevelMenus = new StringBuilder();
            firstLevelMenus.AppendLine("<li class=\"border-top\">");
            foreach (var menu in menus)
            {
                firstLevelMenus.AppendFormat("{0}", menu.Name);
            }


            firstLevelMenus.AppendLine("</li>");
            return firstLevelMenus.ToString();
        }

        private string BuildSecondFunctionMenuHtml(IEnumerable<Menus> menus)
        {
            StringBuilder secondLevelMenu = new StringBuilder();
            foreach (Menus menu2 in menus)
            {
                secondLevelMenu.AppendLine("<div class=\"group\">");
                secondLevelMenu.AppendLine("<h3 class='group-header'>");
                secondLevelMenu.AppendFormat("<a href=\"#\">{0}</a>", menu2.Name);
                secondLevelMenu.AppendLine("</h3>");
                secondLevelMenu.AppendLine("<div class='functions-div'>");
                secondLevelMenu.AppendLine("<table class='items'>");
                var threeLevelMenus = from Menus m3 in _menus
                                      where m3.ParentMenuKey == menu2.MenuKey && m3.Status == "0"
                                      select m3;
                foreach (Menus menu3 in threeLevelMenus)
                {
                    switch (menu3.Target)
                    {
                        case WindowTarget.POPUP_WINDOW:
                            secondLevelMenu.AppendFormat("<tr><td > <a href='javascript:void(0)' onclick=\"javascript:showModalDialog('{1}','{0}','dialogWidth:600px;');\" >{0}</a></></td></tr>", menu3.Name, menu3.Path, menu3.Target, menu3.MenuKey);
                            break;
                        case WindowTarget.NEW_TAG_PAGE:
                            secondLevelMenu.AppendFormat("<tr><td > <a href=\"javascript:void(0);addTab(\'{3}\',\'{1}\',\'{0}\');\" >{0}</a></></td></tr>", menu3.Name, menu3.Path, menu3.Target, menu3.MenuKey);
                            break;
                        default:
                            secondLevelMenu.AppendFormat("<tr><td > <a href=\"javascript:void(0);addTab(\'{3}\',\'{1}\',\'{0}\');\" >{0}</a></></td></tr>", menu3.Name, menu3.Path, menu3.Target, menu3.MenuKey);
                            break;
                    }
                }
                secondLevelMenu.AppendLine("</table>");
                secondLevelMenu.AppendLine("</div></div>");
            }
            return secondLevelMenu.ToString();
        }


        private SystemUsers user = null;
        private string userAccount = null;
        private string menuId = null;
        private ISystemUsersService userService = null;
        private IMenusService _menuService = null;
        private IList<Menus> _menus;
    }
}