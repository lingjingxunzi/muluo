using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.UI.Ashx.Agent
{
    /// <summary>
    /// GetCompanyInfoHandler 的摘要说明
    /// </summary>
    public class GetCompanyInfoHandler : IHttpHandler, IRequiresSessionState
    {
        public GetCompanyInfoHandler()
        {
            _companyFlowPacketsService = new  SystemFlowPacketsService();

        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json;charset=UTF-8";
            user = GetUser(context);
            _flowId = string.IsNullOrEmpty(context.Request["FlowId"]) ? 0 : int.Parse(context.Request["FlowId"]);

            context.Response.Write(GetCompanyInfo(context));
        }

        private string GetCompanyInfo(HttpContext context)
        {
            var flow = _companyFlowPacketsService.FindById(_flowId);
            if (flow != null)
            {
                return new JavaScriptSerializer().Serialize(flow);
            }
            return new JavaScriptSerializer().Serialize(new SystemFlowPackets());
        }


        //获取当前登录人
        private SystemUsers GetUser(HttpContext context)
        {
            var user = (SystemUsers)context.Session["User"];
            return user;
        }

        private int _flowId;
        private SystemUsers user;
        private ISystemFlowPacketsService _companyFlowPacketsService;

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}