namespace MONO.Distribution.Model.AgentModel
{
    public class QueryOrderParam : ActiveFlowParam
    {
        public string OrderId { get; set; }

        public override string GetOrderId()
        {
            return OrderId;
        }
    }
}
