namespace MONO.Distribution.Model.AgentModel
{
    public class QueryResult : AgentResultBase
    {
        public QueryResult()
        {
            Result = "0";
            Msg = "成功";
            OrderId = "";
        }
        public string OrderId { get; set; }
    }
}
