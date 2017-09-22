using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.BaseInfo;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.Model.ViewModel;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.AgentManage
{
    public partial class AgentFlowAssigned : EditPageBase
    {
        public AgentFlowAssigned()
        {
            _flowBaseInfoService = new FlowBaseInfoService();
            _systemFlowPacketsService = new SystemFlowPacketsService();
            _discountsService = new DiscountsService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFlowInfo();
            }
        }

        private void BindFlowInfo()
        {
            var list = new List<FlowAssignedViewModel>();
            var flowList = _systemFlowPacketsService.FindAll(new SystemFlowPackets { SysUserKey = CurrentUser.SysUserKey });
            foreach (var flowBaseInfo in flowList)
            {
                if (flowBaseInfo.FlowBaseInfo == null) continue;
                var flowAssignedViewModel = new FlowAssignedViewModel();
                var systemflow = _systemFlowPacketsService.SelectSystemFlowPacketBySystemKey(new SystemFlowPackets
                {
                    SysUserKey = int.Parse(Request.QueryString["UserKey"]),
                    FlowPacketKey = flowBaseInfo.FlowBaseInfo.FlowKey
                });
                flowAssignedViewModel.FlowKey = flowBaseInfo.FlowBaseInfo.FlowKey;
                flowAssignedViewModel.FlowName = flowBaseInfo.FlowBaseInfo.Name;
                flowAssignedViewModel.RangeName = flowBaseInfo.FlowBaseInfo.EnumRange != null ? flowBaseInfo.FlowBaseInfo.EnumRange.EnumValue : "";
                flowAssignedViewModel.StandardPrice = flowBaseInfo.FlowBaseInfo.StandardPrice;
                flowAssignedViewModel.MyDis = flowBaseInfo.Discounts.Deduction;
                if (systemflow != null)
                {
                    flowAssignedViewModel.IsExists = true;
                    flowAssignedViewModel.SettingPrice = systemflow.Price.ToString();
                    flowAssignedViewModel.DiscountValue = systemflow.Discounts.Deduction.ToString();
                    flowAssignedViewModel.SystemFlowPacketKey = systemflow.SystemFlowPacketKey;
                }
                else
                {
                    flowAssignedViewModel.IsExists = false;
                }
                list.Add(flowAssignedViewModel);
            }
            repFlowList.DataSource = list;
            repFlowList.DataBind();
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            var infos = GetSomeFlowSetting();
            foreach (var item in infos)
            {
                if (item.SystemFlowPacketKey > 0)
                {
                    ResultMessage = _systemFlowPacketsService.Update(item);
                }
                else
                {
                    ResultMessage = _systemFlowPacketsService.Insert(item);
                }
            }
            OperationEnd("用户管理", "流量包权限更改");
        }



        private List<SystemFlowPackets> GetSomeFlowSetting()
        {
            var systemFlowPacketses = new List<SystemFlowPackets>();
            var flowIdStr = flowSomeId.Value;
            var flowStrArr = flowIdStr.Split('|');
            foreach (var s in flowStrArr)
            {
                var sArr = s.Split('_');
                if (sArr.Length == 4)
                {
                    var flowInfo = _flowBaseInfoService.FindById(int.Parse(sArr[1]));

                    var disInfo = _discountsService.SelectDiscountsByDeduction(int.Parse(sArr[3]));
                    var systemFlowPackets = new SystemFlowPackets
                    {
                        FlowPacketKey = int.Parse(sArr[1]),
                        DiscountKey = disInfo.DiscountKey,
                        Price = (disInfo.Deduction * flowInfo.StandardPrice) / 100,
                        Status = "Y",
                        SystemFlowPacketKey = int.Parse(sArr[2]),
                        SysUserKey = int.Parse(Request.QueryString["UserKey"])
                    };
                    systemFlowPacketses.Add(systemFlowPackets);
                }
            }
            return systemFlowPacketses;
        }

        private IFlowBaseInfoService _flowBaseInfoService;
        private ISystemFlowPacketsService _systemFlowPacketsService;
        private IDiscountsService _discountsService;


    }
}