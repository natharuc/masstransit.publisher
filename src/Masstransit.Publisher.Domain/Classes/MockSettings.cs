namespace Masstransit.Publisher.Domain.Classes
{
    public class MockSettings
    {
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string? Type { get; set; }
        public bool Ignore { get; set; }
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
