using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using MONO.Distribution.BLL.BaseInfo;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.BaseInfo;

namespace MONO.Distribution.UI.Ashx.ZtreeAsync
{
    /// <summary>
    /// ChannelListHandler 的摘要说明
    /// </summary>
    public class ChannelListHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json;charset=UTF-8";
            context.Response.CacheControl = "no-cache";
            context.Response.Expires = 0;
            context.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
            context.Response.Write(GetData(context));
        }

        private string GetData(HttpContext context)
        {
            var interList = _flowEnumerationService.SelectEnumerationsByTypeName("Carriers");
            var itemList = _flowCodeService.FindAll(new FlowCode());
            var item = from inter in interList
                       orderby inter.EnumKey
                       select new
                       {
                           uid = inter.EnumKey,
                           Name = inter.EnumValue,
                           Code = inter.EnumKey,
                           pid = 0,
                           type = "Org",
                           icon = "../CSS/Ztree/zTreeStyle/img/Org/home.png",
                           children = from child in itemList
                                      where child.Carrier == inter.EnumKey
                                      select new
                                      {
                                          uid = child.FlowCodeKey,
                                          pid = inter.EnumKey,
                                          name = child.FlowBaseInfo.FlowName,
                                          icon = "../CSS/Ztree/zTreeStyle/img/user/user.png",
                                          type = "Chidren"
                                      }
                       };
            return new JavaScriptSerializer().Serialize(item);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private IFlowCodeService _flowCodeService = new FlowCodeService();
        private IEnumerationService _flowEnumerationService = new EnumerationService();
    }
}