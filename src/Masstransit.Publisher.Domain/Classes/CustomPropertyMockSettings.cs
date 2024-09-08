namespace Masstransit.Publisher.Domain.Classes
{
    public class CustomPropertyMockSettings
    {
        public string Name { get; set; } = string.Empty;
        public string? Value { get; set; }
        public string? Type { get; set; }
        public bool Ignore { get; set; }
        public bool RegenerateBeforeSending { get; set; }
        public bool Invalid
        {
            get
            {
                return !string.IsNullOrEmpty(InvalidMessage);
            }
        }

        public string InvalidMessage
        {
            get
            {
                if (string.IsNullOrEmpty(Name))
                {
                    return "The name could not be null ";
                }

                if (RegenerateBeforeSending && (string.IsNullOrEmpty(Type) || Type == "Any"))
                {
                    return "The type could not be null or empty in Property: \"" + Name + "\".";
                }

                return string.Empty;
            }
        }

    }

    public class SenderSettings
    {
        public int MessageCount { get; set; }
        public int Interval { get; set; }
        public string Queue { get; set; } = string.Empty;
    }
}
