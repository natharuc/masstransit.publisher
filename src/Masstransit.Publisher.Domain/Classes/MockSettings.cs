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
}
