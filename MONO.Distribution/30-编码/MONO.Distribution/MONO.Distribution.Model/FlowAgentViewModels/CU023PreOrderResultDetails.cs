namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class CU023PreOrderResultDetails
    {
        public string message { get; set; }
        public string orderSeq { get; set; }
        public string smsSeq { get; set; }
        public string code { get; set; }
        public string serialId { get; set; }
        public string detail { get; set; }


        public bool GetResult()
        {
            if (code.Equals("1"))
                return true;
            return false;
        }

        public string GetOrderMd5Str()
        {
            return orderSeq + smsSeq + "112";
        }

        public string GetOrderUrl(string sign)
        {
            return "productOrderSure/s/" + orderSeq + "/c/" + smsSeq + "/m/" + sign;
        }
    }
}
