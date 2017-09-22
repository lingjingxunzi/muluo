using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace MONO.Message.UI
{
    public partial class MessageSend : Page
    {
        public MessageSend()
        {
            _result = new MessageResult();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var method = Request.Params["method"];

                switch (method)
                {
                    case "Send":
                        SendMessages();
                        break;
                    case "GetNum":
                        GetNum();
                        break;
                    default:
                        SendMessages(); break;
                }
                Response.Expires = -1;
                Response.Clear();
                Response.ContentEncoding = Encoding.UTF8;
                Response.ContentType = "application/json";
                Response.Write(Request["jsoncallback"] + new JavaScriptSerializer().Serialize(_result));

                Response.End();

            }
        }

        private void GetNum()
        {
            if (string.IsNullOrEmpty(Request["userCode"]))
            {
                _result.code = "2";
                _result.msg = "参数错误";
                _result.num = "-10";
                return;
            }
            if (string.IsNullOrEmpty(Request["userPass"]))
            {
                _result.code = "2";
                _result.msg = "参数错误";
                _result.num = "-11";
                return;
            }
            var result = _messageMethod.GetBalance(Request["userCode"], Request["userPass"]);
            _result.code = "1";
            _result.msg = "成功";
            _result.num = result;
        }

        private void SendMessages()
        {
            if (string.IsNullOrEmpty(Request["userCode"]))
            {
                _result.code = "2";
                _result.msg = "参数错误";
                _result.num = "-10";
                return;
            }
            if (string.IsNullOrEmpty(Request["userPass"]))
            {
                _result.code = "2";
                _result.msg = "参数错误";
                _result.num = "-11";
                return;
            }
            if (string.IsNullOrEmpty(Request["DesNo"]))
            {
                _result.code = "2";
                _result.msg = "参数错误";
                _result.num = "-12";
                return;
            }
            if (string.IsNullOrEmpty(Request["Msg"]))
            {
                _result.code = "2";
                _result.msg = "参数错误";
                _result.num = "-13";
                return;
            }
            var result = _messageMethod.SendMsg(Request["userCode"], Request["userPass"], Request["DesNo"],
                Request["Msg"]);
            if (result.Length == 2)
            {
                _result.code = "2";
                _result.msg = GetError(result);
                _result.num = result;
            }
            else
            {
                _result.code = "1";
                _result.msg = "成功";
                _result.num = result;
            }
        }

        private string GetError(string result)
        {
            switch (result)
            {
                case "-1":
                    return "提交接口错误";
                    break;
                case "-3":
                    return "用户名或密码错误";
                    break;
                case "-4":
                    return "短信内容和备案的模板不一样";
                    break;
                case "-5":
                    return "签名不正确";
                    break;
                case "-7":
                    return "余额不足";
                    break;
                case "-8":
                    return "通道错误";
                    break;
                case "-9":
                    return "无效号码";
                    break;
                default:
                    return "其他原因";
            }
        }
        private MessageMethod _messageMethod = new MessageMethod();
        private MessageResult _result;
    }
}