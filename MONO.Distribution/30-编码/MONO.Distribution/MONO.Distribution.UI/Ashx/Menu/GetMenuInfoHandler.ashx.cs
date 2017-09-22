using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Model.ViewModel;

namespace MONO.Distribution.UI.Ashx.Menu
{
    /// <summary>
    /// GetMenuInfoHandler 的摘要说明
    /// </summary>
    public class GetMenuInfoHandler : IHttpHandler, IRequiresSessionState
    {
        public GetMenuInfoHandler()
        {
            _menusService = new MenusService();
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json;charset=UTF-8";
            context.Response.CacheControl = "no-cache";
            context.Response.Expires = 0;
            context.Response.Write(GetMenuInfo(context));
        }

        private string GetMenuInfo(HttpContext context)
        {
            var path = context.Request["src"].Replace(ConfigurationSettings.AppSettings["navUrl"], "");
            var menus = _menusService.FindAll(new Menus { Path = path });
            if (menus == null || menus.Count == 0) return new JavaScriptSerializer().Serialize("");
            var parent = _menusService.FindById(menus.First().ParentMenuKey);
            var nav = new MenuNav();
            nav.ParentName = parent != null ? parent.Name : "";
            nav.ParentPath = parent != null ? parent.Path : "";
            nav.CurrentName = menus.First().Name;
            nav.CurrentPath = menus.First().Path;
            nav.HomePath =   "/Content.aspx";
            return new JavaScriptSerializer().Serialize(nav);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private IMenusService _menusService;
    }
}