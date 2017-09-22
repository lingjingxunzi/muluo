using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Web.UI;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.BaseInfo;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.Model.FlowAgentViewModels;
using log4net;
namespace MONO.Distribution.UI.Order
{
    public partial class GetOrderResultCallBack : Page
    {
        public GetOrderResultCallBack()
        {
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _flowDistributionRecordsService = new FlowDistributionRecordsService();
            _flowActiveHistoriesService = new FlowActiveHistoriesService();
            _flowCodeService = new FlowCodeService();
            _cu023YtkCommitViewModel = new YtkCommitReuslt();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LogMsg.Info(Request.Url);
                if (GetQueryString() != "200")
                {
                    Response.Write("403");
                    return;
                }
                Response.Write(UpdateStatus());
            }
        }

        private string UpdateStatus()
        {
            var historiesInfo = _flowActiveHistoriesService.FindById(historiesKey);
            if (historiesInfo == null)
                return "200";
            if (!historiesInfo.FlowStatus.Equals("0001"))
                return "200";
            var result = GetResult(historiesInfo.Carrier);
            LogMsg.Info(result);
            historiesInfo.UpdateTime = DateTime.Now;
            historiesInfo.FlowStatus = result;
            historiesInfo.Orders = GetTransNo(historiesInfo.Carrier);
            historiesInfo.Results = result;
            LogMsg.Info(historiesInfo.Results);
            if (!result.Equals("0001"))
            {
                _flowActiveHistoriesService.Update(historiesInfo);
            }
            else
            {
                _flowActiveHistoriesService.UpdateHistoryStatus(historiesInfo);
                var disInfo = _flowDistributionRecordsService.FindById(historiesInfo.DistributionRecordKey);
                if (disInfo != null)
                {
                    disInfo.OrderStatus = "WaitCallBack";
                    _flowDistributionRecordsService.Update(disInfo);
                }
            }
            return "200";
        }

        private string GetResultMsg(string carrier)
        {
            switch (carrier)
            {
                case "YTK":
                    return ytkResult.GetMsg();
                    break;
                case "CU023":
                    return cu023Result.result.GetMsg();
                    break;
                case "SXD":
                    return sxdCbResult.GetMsg();
                    break;
                case "JT":
                    return jtResult.GetMsg();
                    break;
                case "CM025":
                    return xmCm025CommitModels.GetMsg();
                    break;
                case "CU0531":
                    return cu0531CommitModels.GetMsg();
                    break;
                case "CMWhole":
                    return wholeCmCommit.GetMsg();
                    break;
                case "CU0591":
                    return wholeCmCommit.GetMsg();
                    break;
                case "CM023":
                    return cm023ResultModel.GetMsg();
                    break;
                case "CM023_02":
                    return cm023ResultModel.GetMsg();
                    break;
                case "CM023_03":
                    return cm023ResultModel.GetMsg();
                    break;
                case "CM023_04":
                    return cm023ResultModel.GetMsg();
                    break;
                case "CT023_A":
                    return CT023_AModels.GetMsg();
                    break;
                case "CT023_P":
                    return CT023_PModels.GetMsg();
                    break;
                case "CM023New":
                    return CM023Models.GetMsg();
                case "XZ":
                    return xzCommitViewModel.GetMsg();
                case "FJJH":
                    return aggregationCommitViewModel.GetMsg();
                case "CU023YTK":
                    return _cu023YtkCommitViewModel.GetMsg();
                case "YS":
                    return ysCommitViewModel.GetMsg();
                case "JN":
                    return jnCommitModesl.GetMsg();
                case "CM028":
                    return CM028result.GetMsg();
                default:
                    return "";
            }
        }

        private string GetTransNo(string carrier)
        {
            switch (carrier)
            {
                case "YTK":
                    return ytkResult.GetOrders();
                    break;
                case "CU023":
                    return cu023Result.result.GetOrders();
                    break;
                case "SXD":
                    return sxdCbResult.GetOrders();
                    break;
                case "JT":
                    return jtResult.GetOrders();
                    break;
                case "XYP":
                    return xyProResult.GetOrders();
                    break;
                case "XYA":
                    return xyAllResult.GetOrders();
                    break;
                case "CM025":
                    return xmCm025CommitModels.GetOrders();
                    break;
                case "CU0531":
                    return cu0531CommitModels.GetOrders();
                    break;
                case "CMWhole":
                    return wholeCmCommit.GetOrders();
                    break;
                case "CU0591":
                    return cu0591ResultModel.GetOrders();
                case "CM023":
                    return cm023ResultModel.GetOrders();
                case "CM023_02":
                    return cm023ResultModel.GetOrders();
                case "CM023_03":
                    return cm023ResultModel.GetOrders();
                case "CM023_04":
                    return cm023ResultModel.GetOrders();
                case "CT023_A":
                    return CT023_AModels.GetOrders();
                case "CT023_P":
                    return CT023_PModels.GetOrders();
                case "CM023New":
                    return CM023Models.GetOrders();
                case "XZ":
                    return xzCommitViewModel.GetOrders();
                case "FJJH":
                    return aggregationCommitViewModel.GetOrders();
                case "CU023YTK":
                    return _cu023YtkCommitViewModel.GetOrders();
                case "YS":
                    return ysCommitViewModel.GetOrders();
                case "JN":
                    return jnCommitModesl.GetOrders();
                case "CM028":
                    return CM028result.GetOrders();
                default:
                    return "";
            }
        }

        private string GetResult(string carrier)
        {
            switch (carrier)
            {
                case "YTK":
                    return ytkResult.GetResult();
                    break;
                case "CU023":
                    return cu023Result.result.GetResult();
                    break;
                case "SXD":
                    return sxdCbResult.GetResult();
                    break;
                case "JT":
                    return jtResult.GetResult();
                    break;
                case "XYP":
                    return xyProResult.GetResult();
                    break;
                case "XYA":
                    return xyAllResult.GetResult();
                    break;
                case "CM025":
                    return xmCm025CommitModels.GetResult();
                    break;
                case "CU0531":
                    return cu0531CommitModels.GetResult();
                    break;
                case "CMWhole":
                    return wholeCmCommit.GetResult();
                    break;
                case "CU0591":
                    return cu0591ResultModel.GetResult();
                    break;
                case "CM023":
                    return cm023ResultModel.GetResult();
                    break;
                case "CM023_02":
                    return cm023ResultModel.GetResult();
                    break;
                case "CM023_03":
                    return cm023ResultModel.GetResult();
                    break;
                case "CM023_04":
                    return cm023ResultModel.GetResult();
                case "CT023_A":
                    return CT023_AModels.GetResult();
                case "CT023_P":
                    return CT023_PModels.GetResult();
                case "CM023New":
                    return CM023Models.GetResult();
                case "XZ":
                    return xzCommitViewModel.GetResult();
                case "FJJH":
                    return aggregationCommitViewModel.GetResult();
                case "CU023YTK":
                    return _cu023YtkCommitViewModel.GetResult();
                case "YS":
                    return ysCommitViewModel.GetResult();
                case "JN":
                    return jnCommitModesl.GetResult();
                case "CM028":
                    return CM028result.GetResult();
                default:
                    return "";
            }
        }



        private string GetQueryString()
        {
            LogMsg.Info(Request.Params["data"]);
            historiesKey = Request.Params["TransKey"];
            var historiesInfo = _flowActiveHistoriesService.FindById(historiesKey);
            if (historiesInfo == null)
            {
                LogMsg.Info("未找到该订单编号的订购信息，订单编号为：" + Request.Params["TransKey"]);
                return "403";
            }
            LogMsg.Info(historiesInfo.Carrier);
            try
            {
                switch (historiesInfo.Carrier)
                {
                    case "YTK":
                        ytkResult = new JavaScriptSerializer().Deserialize<YtkResult>(Request.Params["data"]);
                        break;
                    case "CU023":
                        cu023Result = new JavaScriptSerializer().Deserialize<CU023PreOrderResult>(Request.Params["data"]);
                        break;
                    case "XYP":
                        xyProResult = GetXYDeseriaInfo();
                        break;
                    case "XYA":
                        xyAllResult = GetXYDeseriaInfo();
                        break;
                    case "SXD":
                        sxdCbResult = new JavaScriptSerializer().Deserialize<SxdCbResult>(Request.Params["data"]);
                        break;
                    case "JT":
                        jtResult = new JavaScriptSerializer().Deserialize<JTResult>(Request.Params["data"]);
                        break;
                    case "CM025":
                        xmCm025CommitModels = new JavaScriptSerializer().Deserialize<CM025CommitModels>(Request.Params["data"]);
                        break;
                    case "CU0531":
                        cu0531CommitModels = new JavaScriptSerializer().Deserialize<CU0531CommitModels>(Request.Params["data"].Replace("=", ":"));
                        break;
                    case "CMWhole":
                        wholeCmCommit = new JavaScriptSerializer().Deserialize<WholeCMCommit>(Request.Params["data"]);
                        break;
                    case "CU0591":
                        cu0591ResultModel = new JavaScriptSerializer().Deserialize<CU0591ResultModel>(Request.Params["data"]);
                        break;
                    case "CM023":
                        cm023ResultModel = new JavaScriptSerializer().Deserialize<CM023ResultModel>(Request.Params["data"]);
                        break;
                    case "CM023_02": cm023ResultModel = new JavaScriptSerializer().Deserialize<CM023ResultModel>(Request.Params["data"]);
                        break;
                    case "CM023_03": cm023ResultModel = new JavaScriptSerializer().Deserialize<CM023ResultModel>(Request.Params["data"]);
                        break;
                    case "CM023_04": cm023ResultModel = new JavaScriptSerializer().Deserialize<CM023ResultModel>(Request.Params["data"]);
                        break;
                    case "CT023_A":
                        CT023_AModels = new JavaScriptSerializer().Deserialize<CT023ResultModels>(Request.Params["data"]);
                        break;
                    case "CT023_P":
                        CT023_PModels = new JavaScriptSerializer().Deserialize<CT023BDResultModels>(Request.Params["data"]);
                        break;
                    case "CM023New":
                        CM023Models = new JavaScriptSerializer().Deserialize<CM023NewResultViewModel>(Request.Params["data"]);
                        break;
                    case "XZ":
                        xzCommitViewModel =
                            new JavaScriptSerializer().Deserialize<XZCommitViewModel>(Request.Params["data"]);
                        break;
                    case "FJJH":
                        aggregationCommitViewModel =
                            new JavaScriptSerializer().Deserialize<AggregationCommitViewModel>(Request.Params["data"]);
                        break;
                    case "CU023YTK":
                        _cu023YtkCommitViewModel = new JavaScriptSerializer().Deserialize<YtkCommitReuslt>(Request.Params["data"]);
                        break;
                    case "YS":
                        ysCommitViewModel = new JavaScriptSerializer().Deserialize<YSCommitViewModel>(Request.Params["data"]);
                        break;
                    case "JN":
                        jnCommitModesl = new JavaScriptSerializer().Deserialize<JnCommitModesl>(Request.Params["data"]);
                        break;
                    case "CM028":
                        CM028result = new JavaScriptSerializer().Deserialize<CM023NewResultViewModel>(Request.Params["data"]);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogMsg.Error(ex.Message + "字符串：" + Request.Params["data"]);
            }
            return "200";

        }

        private XYCommitResultModels GetXYDeseriaInfo()
        {
            try
            {
                return new JavaScriptSerializer().Deserialize<XYCommitResultModels>(Request.Params["data"]);
            }
            catch (Exception ex)
            {
                try
                {

                    return new JavaScriptSerializer().Deserialize<XYCommitResultModels>(Request.Params["data"].Replace(",\"data\":[]", ""));

                }
                catch (Exception e)
                {
                    LogMsg.Info(e.Message);
                    return new XYCommitResultModels { err_code = "1000", err_msg = "失败" };

                }
            }
        }

        private VatResultBase _vatResultBase = new VatResultBase();
        private IFlowActiveHistoriesService _flowActiveHistoriesService;
        private IFlowDistributionRecordsService _flowDistributionRecordsService;
        private IFlowCodeService _flowCodeService;
        private ILog LogMsg;
        private string historiesKey;
        private CU023PreOrderResult cu023Result;
        private SxdCbResult sxdCbResult;
        private YtkResult ytkResult;
        private JTResult jtResult;
        private XYCommitResultModels xyProResult;
        private XYCommitResultModels xyAllResult;
        private CM025CommitModels xmCm025CommitModels;
        private CU0531CommitModels cu0531CommitModels;
        private WholeCMCommit wholeCmCommit;
        private CU0591ResultModel cu0591ResultModel;
        private CM023ResultModel cm023ResultModel;
        private CT023ResultModels CT023_AModels;
        private CT023BDResultModels CT023_PModels;
        private CM023NewResultViewModel CM023Models;
        private XZCommitViewModel xzCommitViewModel;
        private AggregationCommitViewModel aggregationCommitViewModel;
        private YtkCommitReuslt _cu023YtkCommitViewModel;
        private YSCommitViewModel ysCommitViewModel;
        private JnCommitModesl jnCommitModesl;
        private CM023NewResultViewModel CM028result;
    }
}