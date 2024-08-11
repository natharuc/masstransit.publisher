namespace Masstransit.Publisher.Domain.Classes
{
    public class Contract
    {
        public Contract? GenericType { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        
        public bool RequiresGeneric => Type.IsGenericType && GenericType == null;

        public Contract(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        public override string ToString()
        {
            var name = Name;

            if (GenericType != null)
            {
                name += $"<{GenericType}>";
            }

            return name;
        }

        public Type GetFullType()
        {
            if (GenericType != null)
            {
                return Type.MakeGenericType(GenericType.GetFullType());
            }

            return Type;
        }
    }
}
