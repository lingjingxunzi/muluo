namespace MONO.Distribution.Model.AgentModel
{
    public class AgentBlanceResult : AgentResultBase
    {
        public AgentBlanceResult()
        {
            Result = "0";
            Msg = "成功";
            Balance = "";
        }
        public string Balance { get; set; }
    }
}
