using Masstransit.Publisher.Domain.Classes;
using Masstransit.Publisher.Domain.Classes.Enumns;
using MassTransit;

namespace Masstransit.Publisher.Domain.Interfaces
{
    public interface IBusControlFactory
    {
        IBusControl Create(BrokerSettings brokerSettings);
        bool IsBrokerSupported(Broker broker);
    }
}
