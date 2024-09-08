using Masstransit.Publisher.Domain.Classes;
using Masstransit.Publisher.Domain.Classes.Enumns;
using Masstransit.Publisher.Domain.Interfaces;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Masstransit.Publisher.Services.Services
{
    public class BusControlFactory : IBusControlFactory
    {
        public IBusControl Create(BrokerSettings brokerSettings)
        {
            return brokerSettings.Broker switch
            {
                Broker.AzureServiceBus => GetBusControlAzureServiceBus(brokerSettings),
                Broker.RabbitMq => GetBusControlAzureRabbitMq(brokerSettings),
                Broker.AmazonSqs => GetBusControlAmazonSqs(brokerSettings),
                Broker.ActiveMq => GetBusControlActiveMq(brokerSettings),
                _ => throw new System.NotImplementedException()
            };
        }

        private IBusControl GetBusControlAzureRabbitMq(BrokerSettings brokerSettings)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddMassTransit((masstransit) =>
            {
                masstransit.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(brokerSettings.Host, brokerSettings.VirtualHost, h =>
                    {
                        h.Username(brokerSettings.User);
                        h.Password(brokerSettings.Password);
                    });
                });
            });

            var provider = serviceCollection.BuildServiceProvider();

            var buscontrol = provider.GetRequiredService<IBusControl>();

            return buscontrol;
        }

        private IBusControl GetBusControlAzureServiceBus(BrokerSettings brokerSettings)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddMassTransit((masstransit) =>
            {
                masstransit.UsingAzureServiceBus((context, configuration) =>
                {
                    configuration.Host(brokerSettings.ConnectionString);

                    configuration.UseNewtonsoftJsonDeserializer();
                    configuration.UseNewtonsoftJsonDeserializer();
                });
            });

            var provider = serviceCollection.BuildServiceProvider();

            var buscontrol = provider.GetRequiredService<IBusControl>();

            return buscontrol;
        }

        private IBusControl GetBusControlAmazonSqs(BrokerSettings brokerSettings)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddMassTransit((masstransit) =>
            {
                masstransit.UsingAmazonSqs((context, cfg) =>
                {
                    cfg.Host(brokerSettings.Host, h =>
                    {
                        h.AccessKey(brokerSettings.User);
                        h.SecretKey(brokerSettings.Password);
                    });
                });
            });

            var provider = serviceCollection.BuildServiceProvider();

            var buscontrol = provider.GetRequiredService<IBusControl>();

            return buscontrol;
        }

        private IBusControl GetBusControlActiveMq(BrokerSettings brokerSettings)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddMassTransit((masstransit) =>
            {
                masstransit.UsingActiveMq((context, cfg) =>
                {
                    cfg.Host(brokerSettings.Host, h =>
                    {
                        h.UseSsl();

                        h.Username(brokerSettings.User);
                        h.Password(brokerSettings.Password);
                    });
                });
            });

            var provider = serviceCollection.BuildServiceProvider();

            var buscontrol = provider.GetRequiredService<IBusControl>();

            return buscontrol;
        }

        public bool IsBrokerSupported(Broker broker)
        {
            return broker switch
            {
                Broker.AzureServiceBus => true,
                Broker.RabbitMq => true,
                Broker.AmazonSqs => true,
                Broker.ActiveMq => true,
                _ => false
            };
        }
    }
}
