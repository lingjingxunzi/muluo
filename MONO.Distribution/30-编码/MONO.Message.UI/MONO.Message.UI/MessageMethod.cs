using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MONO.Message.UI.ServiceReference1;

namespace MONO.Message.UI
{
    public class MessageMethod
    {
        public MessageMethod()
        {
            _semMsgSend = new MsgSendSoapClient();
        }

        public string GetBalance(string account, string pwd)
        {
            return _semMsgSend.GetBalance(account, pwd);
        }

        public string SendMsg(string account, string pwd, string desNo, string content)
        {
            return _semMsgSend.SendMsg(account, pwd, desNo, content, null);
        }

        public string GetReport(string account, string pwd, string batchNumber)
        {
            return _semMsgSend.GetReport(account, pwd, batchNumber);
        }

        public string GetMo(string account, string pwd)
        {
            //return _semMsgSend.GetMo(account, pwd);
            return "";
        }
        
        private readonly MsgSendSoap _semMsgSend;

    }
}