using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Web;
using System.Web.UI;
using MONO.Distribution.Alipay;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Sys;
using log4net;


namespace MONO.Distribution.UI.AlipayCallBack
{
    public partial class RechargeNotifyUrl : Page
    {
        ILog LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public RechargeNotifyUrl()
        {
            _recordsService = new RechargeRecordsService();
            _systemAccountService = new SystemAccountService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LogMsg.Info(Request.Url);
                SortedDictionary<string, string> sPara = GetRequestPost();
                
                LogMsg.Info("sPara.Count:" + sPara.Count);
                if (sPara.Count > 0)//判断是否有带返回参数
                {
                    LogMsg.Info("验证之前：");
                    var aliNotify = new Notify();
                    bool verifyResult = aliNotify.Verify(sPara, Request.Form["notify_id"], Request.Form["sign"]);

                    if (verifyResult)//验证成功
                    {
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //请在这里加上商户的业务逻辑程序代码
                        LogMsg.Info("验证成功：");

                        //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                        //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表

                        //商户订单号

                        string out_trade_no = Request.Form["out_trade_no"];
                        LogMsg.Info(Request.Form["out_trade_no"]);
                        //支付宝交易号

                        string trade_no = Request.Form["trade_no"];
                        LogMsg.Info(Request.Form["trade_no"]);
                        //交易状态
                        string trade_status = Request.Form["trade_status"];
                        if (Request.Form["trade_status"] == "TRADE_FINISHED")
                        {
                            //判断该笔订单是否在商户网站中已经做过处理
                            //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                            //如果有做过处理，不执行商户的业务程序

                            //注意：
                            //退款日期超过可退款期限后（如三个月可退款），支付宝系统发送该交易状态通知
                        }
                        else if (Request.Form["trade_status"] == "TRADE_SUCCESS")
                        {
                            //判断该笔订单是否在商户网站中已经做过处理
                            //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                            //如果有做过处理，不执行商户的业务程序
                            var records = _recordsService.FindById(out_trade_no);

                            if (records != null && records.Status.Equals("DCL"))
                            {
                                var result = _systemAccountService.SystemAccountChange(records.SysUserKey, out_trade_no, Convert.ToInt32(records.Amount * 100), "CR");
                                if (result.IsOk)
                                {
                                    result = _systemAccountService.SystemAccountChange(records.RechargeTo, out_trade_no, Convert.ToInt32(records.Amount * 100), "CR");
                                    if (result.IsOk)
                                    {
                                        _systemAccountService.SystemAccountChange(records.SysUserKey, out_trade_no, -Convert.ToInt32(records.Amount * 100), "CR");
                                    }
                                }
                                records.Status = "YCL";
                                _recordsService.Update(records);
                                ResetCurrentInfo(records);

                            }
                            //注意：
                            //付款完成后，支付宝系统发送该交易状态通知
                        }
                        else
                        {
                        }
                        //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                        Response.Write("success");  //请不要修改或删除

                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    }
                    else//验证失败
                    {
                        Response.Write("requesturl:" + Request.Url + "Request.Form:" + Request.Form.Count + "fail");
                    }
                }
                else
                {
                    Response.Write("requesturl:" + Request.Url + "Request.Form:" + Request.Form.Count + "notify无通知参数");
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void ResetCurrentInfo(RechargeRecords records)
        {
            var sysUser = _systemUsersService.FindById(records.SysUserKey);
            HttpContext.Current.Session["USER"] = sysUser;
        }

        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestPost()
        {
            int i = 0;
            var sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            coll = Request.Form;
            String[] requestItem = coll.AllKeys;
            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }
            return sArray;
        }

        private IRechargeRecordsService _recordsService;
        private ISystemAccountService _systemAccountService;
        private ISystemUsersService _systemUsersService = new SystemUsersService();
    }
}