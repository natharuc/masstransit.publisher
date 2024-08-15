namespace Masstransit.Publisher.Domain.Classes
{
    public class ContractMessage
    {
        public Contract Contract { get; set; }
        public string Body { get; set; }
        public bool HasContractType
        {
            get
            {
                return Contract?.GetFullType() != null;
            }
        }
    }
}
