namespace OrderService.Models.CallBackModels
{
    public class SxdCbResult
    {
        public string partnerId { get; set; }
        public string tradeId { get; set; }
        public string tradeCode { get; set; }
        public string partnerOrderId { get; set; }
        public string unixTime { get; set; }
        public string nonce { get; set; }
        public string sign { get; set; }
    }
}
