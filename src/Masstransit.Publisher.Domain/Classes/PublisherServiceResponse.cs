namespace Masstransit.Publisher.Domain.Classes
{
    public class PublisherServiceResponse
    {
        public Contract Contract { get; set; }
        public int SendedEvents { get; set; }
        public string Message { get; set; }
    }

}
