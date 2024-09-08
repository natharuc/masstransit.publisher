using Masstransit.Publisher.Domain.Classes;

namespace Masstransit.Publisher.Windows.Interfaces
{
    public interface IUserControlBrokerSettings
    {
        BrokerSettings GetSettings();
        void SetSettings(BrokerSettings brokerSettings);
    }
}
