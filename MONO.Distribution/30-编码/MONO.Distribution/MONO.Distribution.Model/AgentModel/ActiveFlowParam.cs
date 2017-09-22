namespace MONO.Distribution.Model.AgentModel
{
    public class ActiveFlowParam:AgentParamBase
    {
        public string phonecodestr { get; set; }
        /// <summary>
        /// 是否立即激活
        /// </summary>
        public string isactive { get; set; }

        public string CallBackUrl { get; set; }
        public string ActiveChannel { get; set; }

        public override string GetUrl()
        {
            return CallBackUrl;
        }
        
    }
}