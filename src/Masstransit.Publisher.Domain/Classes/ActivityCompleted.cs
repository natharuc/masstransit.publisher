namespace Masstransit.Publisher.Domain.Classes
{
    public class ActivityCompleted
    {
        public Guid TrackingNumber { get; set; }

        public object? Message { get; set; }
    }

    public class ActivityFaulted
    {
        public Guid TrackingNumber { get; set; }

        public object? Message { get; set; }
    }
}
