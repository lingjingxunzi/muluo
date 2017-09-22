namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class CU023Result : VatResultBase
    {
        public string message { get; set; }
        public string orderSeq { get; set; }
        public string smsSeq { get; set; }
        public string code { get; set; }
        public string serialId { get; set; }
        public string detail { get; set; }
        public override string GetResult()
        {
            if (code == "1")
            {
                return "0";
            }
            if (code == "0")
            {
                return "1";
            }
            return code;
        }

        public override string GetOrders()
        {
            return serialId;
        }

        public override string GetTransNo()
        {
            return orderSeq;
        }

        public override string GetMsg()
        {
            return message;
        }
    }
}
