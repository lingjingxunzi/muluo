namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class VatResultBase
    {

        public string SystemMsg { get; set; }
        public string SystemError { get; set; }
        

        public virtual string GetResult()
        {
            return "";
        }

        public virtual string GetOrders()
        {
            return "";
        }

        public virtual string GetTransNo()
        {
            return "";
        }

        public virtual string GetMsg()
        {
            return "";
        }
    }
}
