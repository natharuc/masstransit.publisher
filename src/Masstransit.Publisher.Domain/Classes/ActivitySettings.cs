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

        // Custom contract settings for success/fault messages
        public Contract? SuccessContract { get; set; }
        public string? SuccessMessageProperty { get; set; }
        
        public Contract? FaultContract { get; set; }
        public string? FaultMessageProperty { get; set; }
    }
}
