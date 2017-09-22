namespace MONO.Distribution.Model.AgentModel
{
    public class AgentParamBase
    {
        public string name { get; set; }
        public string userkey { get; set; }
        public string sig { get; set; }
        public string timestamp { get; set; }

        public virtual string GetOrderId()
        {
            return "";
        }

        public virtual string GetPhonecodestr()
        {
            return "";
        }

        public virtual string GetIsActive()
        {
            return "";
        }

        public virtual string GetUrl()
        {
            return "";
        }
        
    }
}