using Masstransit.Publisher.Domain.Classes;
using Masstransit.Publisher.Domain.Classes.Enumns;
using Masstransit.Publisher.Domain.Classes.Statics;
using Masstransit.Publisher.Domain.Interfaces;
using Masstransit.Publisher.Windows.Forms;
using Masstransit.Publisher.Windows.Forms.UserControls.BrokersSettings;
using Masstransit.Publisher.Windows.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace Masstransit.Publisher.Windows
{
    public partial class FormPublisher : Form
    {
        public List<Contract> Contracts { get; private set; } = new List<Contract>();
        private Contract? _selectedContract { get; set; }

        private IMockInterfaceService _mockService;
        private IPublisherService _publisherService;
        private IBusControlFactory _busControlFactory;
        private ILogService _logService;
        private bool _genericTypeSelecting;
        private LocalConfiguration _localConfiguration;
        private BrokerSettings _brokerSettings;
        private IUserControlBrokerSettings? _userControlSettings;

        public FormPublisher(IMockInterfaceService mockInterfaceService, IPublisherService publisherService, ILogService logService, IBusControlFactory busControlFactory)
        {
            InitializeComponent();
            _localConfiguration = new LocalConfiguration();
            _brokerSettings = new BrokerSettings();
            _mockService = mockInterfaceService;
            _publisherService = publisherService;
            _logService = logService;

            _logService.Subscribe(this.Name, Queues.Log, Log);
            _busControlFactory = busControlFactory;
        }

        private void FormPublicador_Load(object sender, EventArgs e)
        {
            PopulateBrokers();

            LoadLastConfiguration();

            dataGridViewAutoComplete.Hide();
        }

        private async void buttonSend_Click(object sender, EventArgs e)
        {
            FillBrokerSettings();

            Validate();

            tabControl.SelectedTab = tabPageLog;

            await _logService.Send(Queues.Log, "Sending events");

            SaveLastConfiguration();

            if (_selectedContract == null)
            {
                MessageBox.Show("Select a contract", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContract.Focus();
                return;
            }

            var messages = GetMessagesToSend();

            ConfigurePublisher();

            await _publisherService.Send(messages, _localConfiguration.SenderSettings.Queue);

            await _logService.Send(Queues.Log, $"{messages.Count} events has been sent to {_selectedContract}");
        }

        private void PopulateBrokers()
        {
            var brokers = Enum.GetValues(typeof(Broker)).Cast<Broker>().ToList();

            foreach (var broker in brokers)
            {
                var buttonImage = (Image)Properties.Resources.ResourceManager.GetObject($"iconButton{broker}");

                var button = new Button()
                {
                    Image = buttonImage,
                    ImageAlign = ContentAlignment.MiddleLeft,
                    Name = $"buttonBroker{broker}",
                    Text = broker.ToString(),
                    Tag = broker,
                    Enabled = _busControlFactory.IsBrokerSupported(broker),
                    Height = 40,
                    Width = 120,
                    TextAlign = ContentAlignment.MiddleRight,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = {

                        BorderSize = 1
                    },
                };

                button.Click += (ss, ee) => SelectBroker(broker);

                panelBrokers.Controls.Add(button);
            }
        }

        private List<ContractMessage> GetMessagesToSend()
        {
            var messages = new List<ContractMessage>();

            var initialJson = richTextBoxJson.Text.Trim();

            for (int i = 0; i < _localConfiguration.SenderSettings.MessageCount; i++)
            {
                messages.Add(GetContractMessage(initialJson));
            }

            var lastMessage = messages.LastOrDefault();

            richTextBoxJson.Text = lastMessage?.Body;

            return messages;
        }

        private ContractMessage GetContractMessage(string initialJson)
        {
            if (_selectedContract == null)
                throw new InvalidOperationException("Contract is required");

            return new ContractMessage()
            {
                Contract = _selectedContract,
                Body = RegenerateJson(initialJson)
            };
        }

        private string RegenerateJson(string initialJson)
        {
            if (_localConfiguration.MockSettings.CustomProperties.Exists(n => n.RegenerateBeforeSending))
            {
                var currentObject = JsonConvert.DeserializeObject<JObject>(initialJson);

                if (currentObject == null)
                    throw new InvalidOperationException("Json is invalid");

                var regenerateProperties = _localConfiguration.MockSettings.CustomProperties.FindAll(n => n.RegenerateBeforeSending);



                if (regenerateProperties.Any())
                {
                    foreach (var regenerateProperty in regenerateProperties)
                    {
                        var type = Type.GetType($"System.{regenerateProperty.Type}");

                        var newValue = _mockService.GetMockValue(type, _localConfiguration.MockSettings);

                        var token = currentObject.SelectToken(regenerateProperty.Name);

                        if (token == null)
                            throw new InvalidOperationException($"Property {regenerateProperty.Name} not found in json");

                        token.Replace(JToken.FromObject(newValue));
                    }
                }

                return currentObject.ToString();
            }

            return initialJson;
        }

        private void SaveLastConfiguration()
        {
            var newConfiguration = new LocalConfiguration()
            {
                Contract = _selectedContract,
                Json = richTextBoxJson.Text.Trim(),
                BrokerSettings = FillBrokerSettings(),
                DllFile = linkLabelSelectDll.Tag?.ToString(),
                MockSettings = _localConfiguration.MockSettings,
                ActivitySettings = _localConfiguration.ActivitySettings,
                SenderSettings = _localConfiguration.SenderSettings,
            };

            LocalConfiguration.SaveToJsonFile(newConfiguration);
        }

        private BrokerSettings FillBrokerSettings()
        {
            _brokerSettings = _userControlSettings.GetSettings();

            return _brokerSettings;
        }

        private void LoadLastConfiguration()
        {
            _localConfiguration = LocalConfiguration.LoadFromJsonFile();

            if (_localConfiguration.HasConfiguration)
            {
                LoadContractFromDllFile(_localConfiguration.DllFile);

                if (Contracts.Any())
                {
                    _selectedContract = _localConfiguration.Contract;

                    if (_selectedContract != null)
                    {
                        _selectedContract.FillTypes(Contracts);

                        labelSelectedContract.Text = _selectedContract.ToString();
                    }
                }

                richTextBoxJson.Text = _localConfiguration.Json;

                _brokerSettings = _localConfiguration.BrokerSettings ?? new BrokerSettings();

                SelectBroker(_brokerSettings.Broker);
            }
        }

        private void Validate(bool isPublish = false)
        {
            if (_selectedContract == null)
                throw new InvalidOperationException("Contract is required");

            if (string.IsNullOrWhiteSpace(richTextBoxJson.Text))
                throw new InvalidOperationException("Json is required");

            if (!isPublish && string.IsNullOrWhiteSpace(_localConfiguration.SenderSettings.Queue))
                throw new InvalidOperationException("Queue is required");

            if (!string.IsNullOrEmpty(_brokerSettings.ErrorMessage))
                throw new InvalidOperationException(_brokerSettings.ErrorMessage);

            if (_selectedContract != null && _selectedContract.RequiresGeneric && _selectedContract.GenericContract == null)
                throw new InvalidOperationException("Select a type for the generic type");
        }

        private void ConfigurePublisher()
        {
            var buscontrol = _busControlFactory.Create(_brokerSettings);

            _publisherService.Setup(buscontrol);
        }

        private async void buttonPublish_Click(object sender, EventArgs e)
        {
            Validate(true);

            tabControl.SelectedTab = tabPageLog;

            await _logService.Send(Queues.Log, "Publishing events");

            SaveLastConfiguration();

            var messages = GetMessagesToSend();

            ConfigurePublisher();

            await _publisherService.Publish(messages);

            await _logService.Send(Queues.Log, $"{messages.Count} events has been published to {_selectedContract}");
        }

        private void buttonMockJson_Click(object sender, EventArgs e)
        {
            if (_selectedContract == null)
            {
                MessageBox.Show("Select a contract", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContract.Focus();
                return;
            }

            if (_selectedContract.RequiresGeneric && _selectedContract.GenericContract == null)
            {
                MessageBox.Show("Select a type for the generic type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContract.Focus();
                return;
            }

            var tipo = _selectedContract.GetFullType();

            var mockObject = _mockService.Mock(tipo, _localConfiguration.MockSettings);

            var json = JsonConvert.SerializeObject(mockObject, Formatting.Indented);

            labelJson.Text = $"Json ({json.Length} characters)";

            richTextBoxJson.Text = json;
        }

        private void textBoxContract_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxContract.Text.Trim()))
            {
                dataGridViewAutoComplete.Hide();
            }
            else
            {
                if (Contracts.Any())
                {
                    var contracts = Contracts.FindAll(c => c.Name.ToLower().Contains(textBoxContract.Text.Trim().ToLower()));

                    if (contracts.Any())
                    {
                        dataGridViewAutoComplete.DataSource = null;

                        dataGridViewAutoComplete.DataSource = contracts;

                        dataGridViewAutoComplete.Columns[nameof(Contract.Name)].Visible = true;
                        dataGridViewAutoComplete.Columns[nameof(Contract.RequiresGeneric)].Visible = false;
                        dataGridViewAutoComplete.Columns[nameof(Contract.GenericContract)].Visible = false;

                        dataGridViewAutoComplete.Show();

                        dataGridViewAutoComplete.BringToFront();
                    }
                    else
                    {
                        dataGridViewAutoComplete.Hide();
                    }
                }
            }
        }

        private void textBoxContract_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SelectFocuseGridContract();
                    break;
                case Keys.Down:
                    dataGridViewAutoComplete.Focus();
                    break;

            }
        }

        private void dataGridViewAutoComplete_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SelectFocuseGridContract();
                    break;
            }
        }

        private void SelectFocuseGridContract()
        {
            if (!dataGridViewAutoComplete.Visible) return;

            var contract = (Contract)dataGridViewAutoComplete.CurrentRow.DataBoundItem;

            if (_genericTypeSelecting)
            {
                if (contract.RequiresGeneric)
                {
                    MessageBox.Show("You cannot select a contract that requires a generic type as a generic type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _selectedContract.GenericContract = contract;
                _genericTypeSelecting = false;
            }
            else
            {


                _selectedContract = contract;

                richTextBoxJson.Text = string.Empty;

                textBoxContract.Text = contract.Name;

                if (contract.RequiresGeneric)
                {
                    MessageBox.Show("This contract requires a generic type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    _genericTypeSelecting = true;

                    textBoxContract.Focus();
                }

            }

            dataGridViewAutoComplete.Hide();

            labelSelectedContract.Text = _selectedContract.ToString();
        }

        private void dataGridViewAutoComplete_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectFocuseGridContract();
        }

        private void linkLabelSelectDll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string fileName = string.Empty;

            using (var selectFile = new OpenFileDialog())
            {
                selectFile.Filter = "Dll files (*.dll)|*.dll";

                if (selectFile.ShowDialog() == DialogResult.OK)
                {
                    fileName = selectFile.FileName;
                }
            }

            LoadContractFromDllFile(fileName);

            SaveLastConfiguration();

            MessageBox.Show("Dll success loaded", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadContractFromDllFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return;

            byte[] fileBytes = File.ReadAllBytes(fileName);

            // Carrega o assembly a partir do array de bytes
            using (var ms = new MemoryStream(fileBytes))
            {
                var assembly = Assembly.Load(ms.ToArray());

                var contracts = assembly.GetTypes()
                    .Select(t => new Contract(t))
                    .ToList();

                Contracts.Clear();
                Contracts.AddRange(contracts);
            }

            linkLabelSelectDll.Text = Path.GetFileName(fileName);
            linkLabelSelectDll.Tag = fileName;
        }

        private void buttonConfigMock_Click(object sender, EventArgs e)
        {
            using (var form = new FormMockSettings(_mockService, _localConfiguration ?? new LocalConfiguration()))
            {
                form.ShowDialog();

                _localConfiguration = form.LocalConfiguration;

                SaveLastConfiguration();
            }
        }

        private void buttonActivitySettings_Click(object sender, EventArgs e)
        {
            using (var form = new FormActivitySettings(_localConfiguration.ActivitySettings))
            {
                form.ShowDialog();

                _localConfiguration.ActivitySettings = form.ActivitySettings;

                SaveLastConfiguration();
            }
        }

        private async void buttonExecuteActivity_Click(object sender, EventArgs e)
        {
            await _logService.Send(Queues.Log, "Executing activity");

            tabControl.SelectedTab = tabPageLog;

            var conctractMessage = GetMessagesToSend();

            ConfigurePublisher();

            await _publisherService.ExecuteActivity(conctractMessage, _localConfiguration.ActivitySettings);

            SaveLastConfiguration();

            await _logService.Send(Queues.Log, $"{conctractMessage.Count} events has been executed as activity");
        }

        private void buttonSenderSettings_Click(object sender, EventArgs e)
        {
            using (var form = new FormSenderSettings(_localConfiguration.SenderSettings))
            {
                form.ShowDialog();

                _localConfiguration.SenderSettings = form.SenderSettings;

                SaveLastConfiguration();
            }
        }

        private void Log(string log)
        {
            var date = DateTime.Now.ToString("HH:mm:ss");

            log = $"[{date}] {log}";

            listBoxLog.Items.Add(log);

            listBoxLog.SelectedIndex = listBoxLog.Items.Count - 1;
        }

        private void SelectBroker(Broker broker)
        {
            foreach (var button in panelBrokers.Controls.OfType<Button>())
            {
                button.FlatAppearance.BorderSize = 1;
            }

            var buttonBroker = panelBrokers.Controls.Find($"buttonBroker{broker}", false).FirstOrDefault() as Button;

            if (buttonBroker != null)
                buttonBroker.FlatAppearance.BorderSize = 2;

            UserControl? userControlSettings = null;

            switch (broker)
            {
                case Broker.AzureServiceBus:
                    userControlSettings = new UserControlServiceBusSettings();
                    break;
                case Broker.RabbitMq:
                    userControlSettings = new UserControlRabbitMqSettings();
                    break;
                case Broker.Kafka:
                    throw new InvalidOperationException("Kafka not implemented yet");
                case Broker.AmazonSqs:
                    userControlSettings = new UserControlAmazonSqsSettings();
                    break;
                case Broker.ActiveMq:
                    userControlSettings = new UserControlActiveMqSettings();
                    break;
            }

            if (userControlSettings == null)
                throw new InvalidOperationException("User control not found");

            _userControlSettings = (IUserControlBrokerSettings)userControlSettings;
            _userControlSettings.SetSettings(_brokerSettings);
            panelBrokerSettings.Controls.Clear();
            userControlSettings.Dock = DockStyle.Fill;
            panelBrokerSettings.Controls.Add(userControlSettings);
        }
    }
}