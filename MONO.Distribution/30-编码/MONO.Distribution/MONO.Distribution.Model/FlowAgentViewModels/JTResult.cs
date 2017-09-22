namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class JTResult : VatResultBase
    {
        public string Type { get; set; }
        public string Msg { get; set; }
        public string Code { get; set; }
        public string Data { get; set; }

        public override string GetMsg()
        {
            return Msg;
        }

        public override string GetOrders()
        {
            return "";
        }

        public override string GetResult()
        {
            return Msg.Equals("开始充值") ? "0001" : Code;
        }

        public override string GetTransNo()
        {
            return "";
        }
    }
}
