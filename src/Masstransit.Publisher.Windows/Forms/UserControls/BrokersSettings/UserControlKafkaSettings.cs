using Masstransit.Publisher.Domain.Classes;
using Masstransit.Publisher.Windows.Interfaces;

namespace Masstransit.Publisher.Windows.Forms.UserControls.BrokersSettings
{
    public partial class UserControlKafkaSettings : UserControl, IUserControlBrokerSettings
    {
        public UserControlKafkaSettings()
        {
            InitializeComponent();
        }

        public BrokerSettings GetSettings()
        {
            return new BrokerSettings
            {
                Broker = Domain.Classes.Enumns.Broker.Kafka,
                Port = (int)numericUpDownPort.Value,
                Host = textBoxHost.Text,
            };
        }

        public void SetSettings(BrokerSettings brokerSettings)
        {
            textBoxHost.Text = brokerSettings.Host;
            numericUpDownPort.Value = brokerSettings.Port;
        }
    }
}
