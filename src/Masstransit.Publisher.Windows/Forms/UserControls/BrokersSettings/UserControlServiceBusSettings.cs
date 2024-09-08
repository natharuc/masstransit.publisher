using Masstransit.Publisher.Domain.Classes;
using Masstransit.Publisher.Windows.Interfaces;

namespace Masstransit.Publisher.Windows.Forms.UserControls.BrokersSettings
{
    public partial class UserControlServiceBusSettings : UserControl, IUserControlBrokerSettings
    {
        public UserControlServiceBusSettings()
        {
            InitializeComponent();
        }

        public BrokerSettings GetSettings()
        {
            return new BrokerSettings
            {
                Broker = Domain.Classes.Enumns.Broker.AzureServiceBus,
                ConnectionString = richTextBoxConnectionString.Text.Trim()
            };
        }

        public void SetSettings(BrokerSettings brokerSettings)
        {
            richTextBoxConnectionString.Text = brokerSettings.ConnectionString;
        }
    }
}
