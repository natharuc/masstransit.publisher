namespace Masstransit.Publisher.Domain.Classes
{
    public class MockSettings
    {
        public int MaxArrayLength { get; set; }
        public int MinArrayLength { get; set; }

        public List<CustomPropertyMockSettings> CustomProperties { get; set; }

        public MockSettings()
        {
            CustomProperties = new List<CustomPropertyMockSettings>();
        }

    }
    public class CustomPropertyMockSettings
    {
        public string? Name { get; set; }
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

    public class ActivitySettings
    {
        public ActivitySettings()
        {
            Activities = new List<Activity>();
        }

        public string? TrackingNumberProperty { get; set; }
        public string? SuccessQueue { get; set; }
        public string? FaultQueue { get; set; }
        public List<Activity> Activities { get; set; }

    }

    public class Activity
    {
        public string? Name { get; set; }
        public string? Queue { get; set; }
    }
}
