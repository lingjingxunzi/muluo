using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.BaseInfo;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.Model.BaseInfoViewModel;

namespace MONO.Distribution.UI.Ashx.Sys
{
    /// <summary>
    /// GetFlowJurisdictionInfoByKey 的摘要说明
    /// </summary>
    public class GetFlowJurisdictionInfoByKey : IHttpHandler
    {
        public GetFlowJurisdictionInfoByKey()
        {
            _flowBaseInfoService = new FlowBaseInfoService();
            _flwoFlowCodeService = new FlowCodeService();
            _systemFlowPacketsService = new SystemFlowPacketsService();
        }
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json;charset=UTF-8";
            context.Response.Write(GetFlowInfo(context));
        }

        private string GetFlowInfo(HttpContext context)
        {
            var systemkey = context.Request["sysuserKey"];
            var systemFLowList = _systemFlowPacketsService.SelectSystemFlowPacketByUser(new SystemFlowPackets { SysUserKey = int.Parse(systemkey) });
            var keyList = (from m in systemFLowList
                           select m.FlowPacketKey).ToList();
            var list = _flowBaseInfoService.SelectFlowType(new FlowBaseInfo { FlowkeyListForQuery = keyList });
            var listParent = (from m in list
                              select new CarrieroperatorViewModel
                             {
                                 Key = m.From
                             }).ToList();
            ISet<CarrieroperatorViewModel> viewModel = new HashSet<CarrieroperatorViewModel>();
            foreach (var item in listParent)
            {
                if (viewModel.Count(m => m.Key == item.Key) > 0)
                    continue;

                viewModel.Add(item);
            }
            var result = from m in viewModel
                         select new
                         {
                             m.Name,
                             key = m.Key,
                             parentKey = 0,
                             lv = 1,
                             children = (from t in list
                                         where m.Key == t.From
                                         select new
                                         {
                                             Name = t.Name,
                                             key = t.Name,
                                             parentKey = m.Key,
                                             lv = 2,
                                             children = from up in GetUpterFlowName(t.Name, keyList)
                                                        from ttt in systemFLowList
                                                        where up.FlowKey == ttt.FlowPacketKey
                                                        select new
                                                        {
                                                            Name = up.Name + "(原价：" + up.StandardPrice.ToString("N1") + " 折扣：" + ttt.Discounts.Deduction.ToString("N1") + " 折后价：" + ttt.Price.ToString("N1") + ")",
                                                            key = up.FlowKey,
                                                            parentKey = t.Name,
                                                            lv = 3,
                                                            children = from code in GetFlowCodeByFlow(up.FlowKey, keyList)
                                                                       select new
                                                                       {
                                                                           Name = "接口商：" + code.EnumCarrier.EnumValue + " 优先级：" + code.Priority,
                                                                           key = code.FlowCodeKey,
                                                                           parentKey = up.FlowKey,
                                                                           lv = 4,
                                                                       }
                                                        }
                                         }).ToList()
                         };

            return new JavaScriptSerializer().Serialize(result);

        }

        private IList<FlowCode> GetFlowCodeByFlow(int p, IList<int> keys)
        {
            return _flwoFlowCodeService.FindAll(new FlowCode { FlowKey = p, FlowKeyListForQuery = keys });

        }

        private IList<FlowBaseInfo> GetUpterFlowName(string name, IList<int> keys)
        {

            return _flowBaseInfoService.FindAll(new FlowBaseInfo { Name = name, FlowkeyListForQuery = keys });
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        private IFlowBaseInfoService _flowBaseInfoService;
        private IFlowCodeService _flwoFlowCodeService;
        private ISystemFlowPacketsService _systemFlowPacketsService;
    }
}