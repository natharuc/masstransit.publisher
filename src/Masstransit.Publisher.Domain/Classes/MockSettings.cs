using Masstransit.Publisher.Domain.Classes.Enumns;

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

    public class BrokerSettings
    {
        public Broker Broker { get; set; }

        public string ConnectionString { get; set; } = string.Empty;

        public string Host { get; set; } = string.Empty;
        public string VirtualHost { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string ErrorMessage
        {
            get
            {
                switch (Broker)
                {
                    case Broker.AzureServiceBus:
                        return AzureServiceBusValidation();
                    case Broker.RabbitMq:
                        return RabbitMqBusValidation();
                    case Broker.Kafka:
                        break;
                    case Broker.AmazonSqs:
                        break;
                    case Broker.ActiveMq:
                        break;
                }

                throw new NotImplementedException();
            }
        }


        private string AzureServiceBusValidation()
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                return "ConnectionString is required for Azure Service Bus";
            }

            return string.Empty;
        }

        private string RabbitMqBusValidation()
        {
            if (string.IsNullOrEmpty(Host))
            {
                return "Host is required for RabbitMq";
            }

            if (string.IsNullOrEmpty(User))
            {
                return "User is required for RabbitMq";
            }

            if (string.IsNullOrEmpty(Password))
            {
                return "Password is required for RabbitMq";
            }

            if (string.IsNullOrEmpty(VirtualHost))
            {
                return "VirtualHost is required for RabbitMq";
            }

            return string.Empty;
        }
    }
}
