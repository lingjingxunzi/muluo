namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class SxdCbResult : VatResultBase
    {
        public string code { get; set; }

        public string message { get; set; }

        public SxdTradeModels data { get; set; }

        public override string GetResult()
        {

            return code.Equals("0") ? "0001" : code;
        }

        public override string GetOrders()
        {
            return "";
        }

        public override string GetMsg()
        {
            return message;
        }
    }
}
