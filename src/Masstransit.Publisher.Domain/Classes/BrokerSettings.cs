using Masstransit.Publisher.Domain.Classes.Enumns;

namespace Masstransit.Publisher.Domain.Classes
{
    public class BrokerSettings
    {
        public Broker Broker { get; set; }

        public string ConnectionString { get; set; } = string.Empty;

        public string Host { get; set; } = string.Empty;
        public string VirtualHost { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Port { get; set; }
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
                        return KafkaValidation();
                    case Broker.AmazonSqs:
                        return HostUserPasswordValidation();
                    case Broker.ActiveMq:
                        return HostUserPasswordValidation();
                }

                throw new NotImplementedException();
            }
        }

        private string KafkaValidation()
        {
            if (string.IsNullOrEmpty(Host))
            {
                return "Host is required for Kafka";
            }

            if (Port == 0)
            {
                return "Port is required for Kafka";
            }

            return string.Empty;
        }

        private string HostUserPasswordValidation()
        {
            if (string.IsNullOrEmpty(Host))
                return "Host is required for RabbitMq";

            if (string.IsNullOrEmpty(User))
            {
                return "User is required for RabbitMq";
            }

            if (string.IsNullOrEmpty(Password))
            {
                return "Password is required for RabbitMq";
            }

            return string.Empty;
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
