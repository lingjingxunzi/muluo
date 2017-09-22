using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using MONO.Distribution.BLL.BaseInfo;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.Model.BaseInfoViewModel;

namespace MONO.Distribution.UI.Ashx.Sys
{
    /// <summary>
    /// GetSystemEnableFlowInfo 的摘要说明
    /// </summary>
    public class GetSystemEnableFlowInfo : IHttpHandler
    {
        public GetSystemEnableFlowInfo()
        {
            _flowBaseInfoService = new FlowBaseInfoService();
            _flowCodeService = new FlowCodeService();
        }
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json;charset=UTF-8";
            context.Response.Write(GetJsonData(context));
        }

        private string GetJsonData(HttpContext context)
        {
            var listParent = new List<CarrieroperatorViewModel> { new CarrieroperatorViewModel() { Key = "CM" }, new CarrieroperatorViewModel() { Key = "CT" }, new CarrieroperatorViewModel() { Key = "CU" } };
            var list = _flowBaseInfoService.SelectFlowType(new FlowBaseInfo());
            var result = from m in listParent
                         select new
                         {
                             m.Name,
                             key = m.Key,
                             parentKey = 0,
                             IsCheckBox = 0,
                             IsAddEdit = 0,
                             ISChecked = false,
                             children = from li in list
                                        where li.From == m.Key
                                        select new
                                        {
                                            li.Name,
                                            key = li.Name,
                                            parentKey = m.Key,
                                            IsCheckBox = 0,
                                            IsAddEdit = 1,
                                            ISChecked = false,
                                            children = from lii in GetCarrierFlowInfo(li.Name)
                                                       select new
                                                       {
                                                           Name = lii.Name,
                                                           key = lii.FlowKey,
                                                           parentKey = li.Name,
                                                           IsCheckBox = 1,
                                                           IsAddEdit = 0,
                                                           ISChecked = true,
                                                           children = from liii in GetFlowCodeInfo(lii.FlowKey)
                                                                      select new
                                                                      {
                                                                          Name = liii.EnumCarrier.EnumValue + "(折扣：" + liii.Discounts.Deduction.ToString("N1") + ")",
                                                                          key = liii.FlowCodeKey,
                                                                          parentKey = lii.FlowKey,
                                                                          IsCheckBox = 0,
                                                                          IsAddEdit = 0,
                                                                          ISChecked = true
                                                                      }
                                                       }
                                        }
                         };
            return new JavaScriptSerializer().Serialize(result);
        }

        private IList<FlowCode> GetFlowCodeInfo(int p)
        {
            return _flowCodeService.FindAll(new FlowCode { FlowKey = p });
        }

        private IList<FlowBaseInfo> GetCarrierFlowInfo(string p)
        {
            return _flowBaseInfoService.FindAll(new FlowBaseInfo { Name = p });
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private IFlowBaseInfoService _flowBaseInfoService;
        private IFlowCodeService _flowCodeService;
    }
}