using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.UIProcess;
using MONO.Distribution.Utility;
using MONO.Distribution.Utility.NPOI;
using log4net;


namespace MONO.Distribution.UI.CustomerManage
{
    public partial class FlowOrderQueryList : ListPageBase
    {
        public FlowOrderQueryList()
        {
            _enumerationService = new EnumerationService();
            _systemUsersService = new SystemUsersService();
            _flowDistributionRecordsService = new FlowDistributionRecordsService();
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _flowActiveHistoriesService = new FlowActiveHistoriesService();
            _systemAccountService = new SystemAccountService();
            _systemAccountLogService = new SystemAccountLogService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdlData();
                BindData();
            }
        }



        protected void btnPage_Click(object sender, EventArgs e)
        {
            PageHelper.SetPageIndex(int.Parse(hidePage.Value));
            BindData();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            var condtion = GetQueryCondition();
            SetPager(_flowDistributionRecordsService.GetCount(condtion), 10);
            var list = _flowDistributionRecordsService.FindAll(condtion);
            this.gvDisList.DataSource = list;
            this.gvDisList.DataBind();
        }

        private FlowDistributionRecords GetQueryCondition()
        {
            return new FlowDistributionRecords
            {
                IsStartPager = true,
                StartRecordIndex = PageHelper.GetStartIndex(),
                EndRecordIndex = PageHelper.GetEndIndex() < PageHelper.GetPageTotal()
                        ? PageHelper.GetPageTotal()
                        : PageHelper.GetEndIndex(),
                SystemUserList = _systemUsersService.SelectSystemChildrensKey(new SystemUsers { SysUserKey = int.Parse(ddlUsers.SelectedValue) }),
                OrderStatus = ddlorderStatus.SelectedValue,
                MobilePhone = txtPhone.Text,
                StartTime = txtStartQueryDateTime.Text,
                EndTime = txtEndQueryDateTime.Text
            };
        }

        private void BindDdlData()
        {
            var userList = _systemUsersService.FindAll(new SystemUsers());
            this.ddlUsers.DataSource = userList;
            this.ddlUsers.DataTextField = "Account";
            this.ddlUsers.DataValueField = "SysUserKey";
            this.ddlUsers.DataBind();
            this.ddlUsers.Items.Insert(0, new ListItem("请选择", "0"));
            var statusList = _enumerationService.SelectEnumerationsByTypeName("OrderSta");
            this.ddlorderStatus.DataSource = statusList;
            this.ddlorderStatus.DataTextField = "EnumValue";
            this.ddlorderStatus.DataValueField = "EnumKey";
            this.ddlorderStatus.DataBind();
            this.ddlorderStatus.Items.Insert(0, new ListItem("请选择", ""));
        }

        protected void btnLoad_OnClick(object sender, EventArgs e)
        {
            var condtion = GetQueryCondition();
            condtion.IsStartPager = false;
            condtion.StartRecordIndex = 0;
            condtion.EndRecordIndex = 0;
            var data = _flowDistributionRecordsService.FindAll(condtion);
            var dt = new DataTable();
            SetHeaderInfo(dt);
            SetDataTableValue(dt, data);
            ExportExcel.ExportExcelFile(Page.Response, dt, "订购详情-" + DateTime.Now.ToString("yyyyMMddHHmmss"));
        }


        private void SetDataTableValue(DataTable dt, IList<FlowDistributionRecords> data)
        {
            try
            {
                foreach (var con in data)
                {
                    DataRow row = dt.NewRow();
                    row[0] = con.BatchNo;
                    row[1] = con.MobilePhone;
                    row[2] = con.SystemUsers.Account;
                    row[3] = con.SystemFlowPackets.FlowBaseInfo.FlowName;
                    row[4] = con.SystemFlowPackets.Price;
                    row[5] = con.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    row[6] = con.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    row[7] = con.DistributionRecordKey;
                    row[8] = con.EnumStatus.EnumValue;
                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                LogMsg.Error(ex.Message);
            }
        }

        private void SetHeaderInfo(DataTable dt)
        {
            dt.Columns.Add(new DataColumn("批次号"));
            dt.Columns.Add(new DataColumn("电话号码"));
            dt.Columns.Add(new DataColumn("分销用户"));
            dt.Columns.Add(new DataColumn("流量包"));
            dt.Columns.Add(new DataColumn("花销"));
            dt.Columns.Add(new DataColumn("订购日期"));
            dt.Columns.Add(new DataColumn("更新日期"));
            dt.Columns.Add(new DataColumn("订单编号"));
            dt.Columns.Add(new DataColumn("订购状态"));
        }

        protected void gvDisList_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            var oper = e.CommandName.ToString();
            var id = e.CommandArgument.ToString();
            switch (oper)
            {
                case "sendAgain":
                    SendAgainOperation(id);
                    break;
                case "ManualFaild":
                    ManualFaildOperation(id);
                    break;
                case "manu":
                    ManualCommitFaildOperation(id);
                    break;
                case "ManualSuccess":
                    ManualSuccessOperation(id);
                    break;
                case "FlowBack":
                    FlowBackOperation(id);
                    break;
            }
            BindData();
        }

        private void FlowBackOperation(string id)
        {
            try
            {
                LogMsg.Info(DateTime.Now);
                var info = _flowDistributionRecordsService.FindById(id);
                LogMsg.Info(DateTime.Now);
                var inter = _systemAccountLogService.FindAll(new SystemAccountLog { Seq = info.DistributionRecordKey });
                LogMsg.Info(DateTime.Now);
                if (inter.Count == 0) return;
                var account = _systemAccountService.SelectSystemAccountByUserKey(info.SysUserKey);
                LogMsg.Info(DateTime.Now);
                var logTemp = new SystemAccountLog();
                logTemp.AccountLogKey = new Guid(info.DistributionRecordKey);
                logTemp.OperaType = "FlowBack";
                logTemp.Integral = -inter.First().Integral;
                logTemp.OperaDate = DateTime.Now;
                logTemp.CompanyAccountKey = account.CompanyAccountKey;
                logTemp.Seq = info.DistributionRecordKey;
                LogMsg.Info(DateTime.Now);
                info.OrderStatus = "Back";
                _systemAccountLogService.Insert(logTemp);
                LogMsg.Info(DateTime.Now);
                _flowDistributionRecordsService.Update(info);
                LogMsg.Info(DateTime.Now);
            }
            catch (Exception ex)
            {
                LogMsg.Info(ex);
            }
        }

        private void ManualSuccessOperation(string id)
        {
            var info = _flowDistributionRecordsService.FindById(id);
            if (info == null)
            {
                LogMsg.Info("手动成功订单失败，订单编号为：" + info.DistributionRecordKey);
                return;
            }
            var hisInfo = _flowActiveHistoriesService.FindAll(new FlowActiveHistories() { DistributionRecordKey = id });
            if (hisInfo != null && hisInfo.Count > 0)
            {
                var hisKey = hisInfo.First().FlowActiveHistoryKey;
                var url = "http://113.207.124.143/Order/SxdCallBack.aspx?passParm=" + hisKey + "&serialNo=888888" + "&result=0&msg=手动成功";
                try
                {
                    LogMsg.Info("手动成功url：" + url);
                    HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                }
                catch (Exception ex)
                {
                    LogMsg.Info(ex);
                }
            }

        }

        private void ManualCommitFaildOperation(string id)
        {
            var info = _flowDistributionRecordsService.FindById(id);

            if (info == null)
            {
                LogMsg.Info("手动失败订单失败，订单编号为：" + info.DistributionRecordKey);
                return;
            }
            info.OrderStatus = "SB";
            var updateresult = _flowDistributionRecordsService.Update(info);
            if (!updateresult.IsOk)
            {
                return;
            }
            if (string.IsNullOrEmpty(info.BackUrl))
            {
                LogMsg.Info("发送回调地址为空，回调失败！订单编号：" + info.DistributionRecordKey);
                return;
            }
            try
            {
                var url = info.BackUrl;
                if (info.BackUrl.Contains("?"))
                {
                    url = url + "&";
                }
                else
                {
                    url = url + "?";
                }
                url = url + "orderId=" + info.DistributionRecordKey + "&result=" + info.OrderStatus +
                          "&msg=" + info.ResultMsg + "&transNo=" + info.BatchNo;
                LogMsg.Info("回调地址：" + url);
                var result = HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                LogMsg.Info("回调返回：" + result);
            }
            catch (Exception ex)
            {
                LogMsg.Error(ex.Message);
            }
        }

        private void ManualFaildOperation(string id)
        {
            var list = _flowActiveHistoriesService.FindAll(new FlowActiveHistories { DistributionRecordKey = id, FlowStatus = "0001" });
            LogMsg.Info("手动失败订单数量:" + list.Count());
            if (list.Any() && list.Count > 0)
            {
                WriteLog("客服处理", "手动失败处理订单，订单号：" + id, "0");
                var item = list.First();
                var url = ConfigurationSettings.AppSettings["MauFaildUrl"] + "?passParm=" + item.FlowActiveHistoryKey + "&serialNo=&result=1&msg=手动失败";
                var result = HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                // LogMsg.Info("手动失败处理返回：" + result);
            }
            else
            {
                WriteLog("客服处理", "手动失败处理订单失败，未找到指定订单号：" + id, "1");
            }
        }

        private void SendAgainOperation(string id)
        {
            var info = _flowDistributionRecordsService.FindById(id);
            if (info == null)
            {
                LogMsg.Info("再次发送订单为空，订单编号为：" + info.DistributionRecordKey);
                return;
            }
            if (string.IsNullOrEmpty(info.BackUrl))
            {
                LogMsg.Info("再次发送回调地址为空，回调失败！订单编号：" + info.DistributionRecordKey);
                return;
            }
            try
            {
                var url = info.BackUrl;
                if (info.BackUrl.Contains("?"))
                {
                    url = url + "&";
                }
                else
                {
                    url = url + "?";
                }
                url = url + "orderId=" + info.DistributionRecordKey + "&result=" + info.OrderStatus +
                          "&msg=" + info.ResultMsg + "&transNo=" + info.BatchNo;
                LogMsg.Info("再次发送回调地址：" + url);
                var result = HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                LogMsg.Info("再次发送返回信息：" + result);
            }
            catch (Exception ex)
            {
                LogMsg.Error(ex.Message);
            }
        }


        private IEnumerationService _enumerationService;
        private ISystemUsersService _systemUsersService;
        private IFlowDistributionRecordsService _flowDistributionRecordsService;
        private ILog LogMsg;
        private IFlowActiveHistoriesService _flowActiveHistoriesService;
        private ISystemAccountService _systemAccountService;
        private ISystemAccountLogService _systemAccountLogService;
    }
}