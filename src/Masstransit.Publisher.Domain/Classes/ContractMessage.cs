namespace Masstransit.Publisher.Domain.Classes
{
    public class ContractMessage
    {
        public Contract Contract { get; set; } = new();
        public string Body { get; set; } = string.Empty;
        public bool HasContractType
        {
            get
            {
                return Contract?.GetFullType() != null;
            }
        }
    }
}
