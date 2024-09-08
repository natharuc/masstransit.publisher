using Masstransit.Publisher.Domain.Classes;
using Masstransit.Publisher.Windows.Interfaces;

namespace Masstransit.Publisher.Windows.Forms.UserControls.BrokersSettings
{
    public partial class UserControlAmazonSqsSettings : UserControl, IUserControlBrokerSettings
    {
        public UserControlAmazonSqsSettings()
        {
            InitializeComponent();
        }

        public BrokerSettings GetSettings()
        {
            return new BrokerSettings
            {
                Broker = Domain.Classes.Enumns.Broker.AmazonSqs,
                Host = textBoxHost.Text.Trim(),
                User = textBoxUser.Text.Trim(),
                Password = textBoxPassword.Text.Trim()
            };
        }

        public void SetSettings(BrokerSettings brokerSettings)
        {
            textBoxHost.Text = brokerSettings.Host;
            textBoxUser.Text = brokerSettings.User;
            textBoxPassword.Text = brokerSettings.Password;
        }
    }
}
