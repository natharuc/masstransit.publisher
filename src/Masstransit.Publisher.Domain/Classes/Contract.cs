namespace Masstransit.Publisher.Domain.Classes
{
    public class Contract
    {
        public Contract() { }

        public Contract? GenericContract { get; set; }
        public string Name { get; set; }

        private Type _type { get; set; }

        public Type GetFullType()
        {
            if (GenericContract != null)
            {
                return _type.MakeGenericType(GenericContract.GetFullType());
            }

            return _type;
        }

        public bool RequiresGeneric => GetFullType().IsGenericType && GenericContract == null;

        public Contract(Type type)
        {
            FillName(type);
            _type = type;
        }

        private void FillName(Type type)
        {
            Name = type?.FullName ?? throw new ArgumentNullException(nameof(type));
        }

        public override string ToString()
        {
            var name = Name;

            if (GenericContract != null)
            {
                name += $"<{GenericContract}>";
            }

            return name;
        }

        public void FillTypes(List<Contract> contracts)
        {
            var contract = contracts.FirstOrDefault(c => c.Name == Name);

            if (contract != null)
            {
                _type = contract.GetFullType();
                FillName(_type);
            }

            if (GenericContract != null)
            {
                GenericContract.FillTypes(contracts);
            }
        }
    }
}
