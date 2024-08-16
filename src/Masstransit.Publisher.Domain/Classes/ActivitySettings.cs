namespace Masstransit.Publisher.Domain.Classes
{
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
}
