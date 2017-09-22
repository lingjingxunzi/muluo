using MONO.Distribution.Message.MessageService;

namespace MONO.Distribution.Message
{
    public class SendMessageHandler
    {
        public static string SendMsg(string desNo, string content)
        {
            return _semMsgSend.SendMsg(appKey, appSec, desNo, content, null);
        }

        public static string GetReport(string batchNumber)
        {
            return _semMsgSend.GetReport(appKey, appSec, batchNumber);
        }
        private readonly static MsgSendSoap _semMsgSend = new MsgSendSoapClient();
        private static SendMessageHandler _sendMessageInstacne = null;
        private static string appKey = "cqliuba";
        private static string appSec = "cqliuba678";
    }
}
