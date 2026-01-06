using Masstransit.Publisher.Domain.Classes;
using Masstransit.Publisher.Domain.Classes.Enumns;
using Masstransit.Publisher.Domain.Classes.Statics;
using Masstransit.Publisher.Domain.Interfaces;
using Masstransit.Publisher.Services.Services;
using Masstransit.Publisher.Windows.Forms;
using Masstransit.Publisher.Windows.Forms.UserControls.BrokersSettings;
using Masstransit.Publisher.Windows.Interfaces;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace Masstransit.Publisher.Windows
{
    public partial class FormPublisher : Form
    {
        public List<Contract> Contracts { get; private set; } = new List<Contract>();
        private Contract? SelectedContract { get; set; }

        private readonly IMockInterfaceService _mockService;
        private readonly IPublisherService _publisherService;
        private readonly IBusControlFactory _busControlFactory;
        private readonly ILogService _logService;
        private bool _genericTypeSelecting;

        private BrokerSettings _brokerSettings;
        private FaultQueueListenerService? _faultQueueListener;

        // WebView2 initialization flag
        private bool _isWebViewInitialized = false;
        // Pending JSON to set after initialization
        private string? _pendingJson = null;

        private LocalConfiguration _localConfiguration { get; set; }
        private LocalConfiguration LocalConfiguration
        {
            get
            {
                return _localConfiguration;
            }
            set
            {
                ApplyConfiguration(value);

                _localConfiguration = value;
            }
        }

        private void ApplyConfiguration(LocalConfiguration value)
        {
            buttonExecuteActivity.Text = $"Execute ({value.SenderSettings.MessageCount})";
            buttonPublish.Text = $"Publish ({value.SenderSettings.MessageCount})";
            buttonSend.Text = $"Send ({value.SenderSettings.MessageCount})";
        }


        private IUserControlBrokerSettings _userControlSettings;

        public FormPublisher(IMockInterfaceService mockInterfaceService, IPublisherService publisherService, ILogService logService, IBusControlFactory busControlFactory)
        {
            InitializeComponent();
            _userControlSettings = new UserControlServiceBusSettings();
            LocalConfiguration = new LocalConfiguration();
            _brokerSettings = new BrokerSettings();
            _mockService = mockInterfaceService;
            _publisherService = publisherService;
            _logService = logService;

            _logService.Subscribe(this.Name, Queues.Log, Log);
            _busControlFactory = busControlFactory;
        }

        private async void FormPublicador_Load(object sender, EventArgs e)
        {
            PopulateBrokers();

            // Initialize WebView2 before loading configuration
            await InitializeWebView2();

            LoadLastConfiguration();

            dataGridViewAutoComplete.Hide();
        }

        /// <summary>
        /// Initializes the WebView2 control and loads the Monaco Editor HTML
        /// </summary>
        private async Task InitializeWebView2()
        {
            try
            {
                // Ensure WebView2 runtime is available
                await webView2Json.EnsureCoreWebView2Async(null);

                // Get the HTML file path (expects MonacoEditor.html in the application directory)
                string htmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MonacoEditor.html");

                // Navigate to the HTML file
                webView2Json.CoreWebView2.Navigate(htmlPath);

                // Wait for navigation to complete
                webView2Json.CoreWebView2.NavigationCompleted += WebView2Json_NavigationCompleted;
            }
            catch (Exception ex)
            {
                await _logService.Send(Queues.Log, $"Failed to initialize Monaco Editor: {ex.Message}");
                MessageBox.Show($"Failed to initialize Monaco Editor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler for WebView2 navigation completed
        /// </summary>
        private void WebView2Json_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            _isWebViewInitialized = true;

            // If there was pending JSON to set, set it now
            if (!string.IsNullOrEmpty(_pendingJson))
            {
                SetJson(_pendingJson);
                _pendingJson = null;
            }
        }

        /// <summary>
        /// Sets JSON content in the Monaco Editor
        /// </summary>
        /// <param name="json">JSON string to display in the editor</param>
        private async void SetJson(string json)
        {
            if (!_isWebViewInitialized)
            {
                // Store the JSON to set after initialization
                _pendingJson = json;
                return;
            }

            try
            {
                // Escape the JSON string for JavaScript
                string escapedJson = json.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r", "\\r").Replace("\n", "\\n");

                // Call JavaScript function to set the JSON
                await webView2Json.CoreWebView2.ExecuteScriptAsync($"setJson(\"{escapedJson}\");");
            }
            catch (Exception ex)
            {
                await _logService.Send(Queues.Log, $"Failed to set JSON in editor: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets JSON content from the Monaco Editor
        /// </summary>
        /// <returns>JSON string from the editor</returns>
        private async Task<string> GetJson()
        {
            if (!_isWebViewInitialized)
            {
                return string.Empty;
            }

            try
            {
                // Call JavaScript function to get the JSON
                string result = await webView2Json.CoreWebView2.ExecuteScriptAsync("getJson();");

                // Remove the quotes added by ExecuteScriptAsync
                if (result.StartsWith("\"") && result.EndsWith("\""))
                {
                    result = result.Substring(1, result.Length - 2);
                }

                // Unescape the JSON string
                result = result.Replace("\\r", "\r").Replace("\\n", "\n").Replace("\\\"", "\"").Replace("\\\\", "\\");

                return result;
            }
            catch (Exception ex)
            {
                await _logService.Send(Queues.Log, $"Failed to get JSON from editor: {ex.Message}");
                return string.Empty;
            }
        }

        private async void ButtonSend_Click(object sender, EventArgs e)
        {
            FillBrokerSettings();

            await ValidateConfiguration();

            tabControl.SelectedTab = tabPageLog;

            await _logService.Send(Queues.Log, "Sending events");

            await SaveLastConfiguration();

            if (SelectedContract == null)
            {
                Alert.Show("Select a contract", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContract.Focus();
                return;
            }

            var messages = await GetMessagesToSend();

            ConfigurePublisher();

            await _publisherService.Send(messages, LocalConfiguration.SenderSettings.Queue);

            await _logService.Send(Queues.Log, $"{messages.Count} events has been sent to {SelectedContract}");
        }

        private void PopulateBrokers()
        {
            var brokers = Enum.GetValues(typeof(Broker)).Cast<Broker>().ToList();

            foreach (var broker in brokers)
            {
                var buttonImage = Properties.Resources.ResourceManager.GetObject($"iconButton{broker}");

                var button = new Button()
                {
                    Image = buttonImage == null ? null : (Image)buttonImage,
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

        private async Task<List<ContractMessage>> GetMessagesToSend()
        {
            var messages = new List<ContractMessage>();

            var initialJson = (await GetJson()).Trim();

            for (int i = 0; i < LocalConfiguration.SenderSettings.MessageCount; i++)
            {
                messages.Add(GetContractMessage(initialJson));
            }

            var lastMessage = messages.LastOrDefault();

            if (lastMessage != null)
            {
                SetJson(lastMessage.Body);
            }

            return messages;
        }

        private ContractMessage GetContractMessage(string initialJson)
        {
            if (SelectedContract == null)
                throw new InvalidOperationException("Contract is required");

            return new ContractMessage()
            {
                Contract = SelectedContract,
                Body = RegenerateJson(initialJson)
            };
        }

        private string RegenerateJson(string initialJson)
        {
            if (LocalConfiguration.MockSettings.CustomProperties.Exists(n => n.RegenerateBeforeSending))
            {
                var currentObject = JsonConvert.DeserializeObject<JObject>(initialJson) ?? throw new InvalidOperationException("Json is invalid");

                var regenerateProperties = LocalConfiguration.MockSettings.CustomProperties.FindAll(n => n.RegenerateBeforeSending);

                if (regenerateProperties.Any())
                {
                    foreach (var regenerateProperty in regenerateProperties)
                    {
                        var type = Type.GetType($"System.{regenerateProperty.Type}") ?? throw new InvalidOperationException($"Type {regenerateProperty.Type} not found");

                        var newValue = _mockService.GetMockValue(type, LocalConfiguration.MockSettings) ?? throw new InvalidOperationException("New value not found");

                        //select token with ignore case
                        JToken token = currentObject.Descendants()
                            .OfType<JProperty>()
                            .FirstOrDefault(p => string.Equals(p.Name, regenerateProperty.Name, StringComparison.OrdinalIgnoreCase)) ?? throw new InvalidOperationException($"Property {regenerateProperty.Name} not found in json");

                        //atualizar valor do token
                        token.Replace(new JProperty(token.Path, JToken.FromObject(newValue)));
                    }
                }

                return currentObject.ToString();
            }

            return initialJson;
        }

        private async Task SaveLastConfiguration()
        {
            var newConfiguration = new LocalConfiguration()
            {
                Contract = SelectedContract,
                Json = (await GetJson()).Trim(),
                BrokerSettings = FillBrokerSettings(),
                DllFile = linkLabelSelectDll.Tag?.ToString() ?? string.Empty,
                MockSettings = LocalConfiguration.MockSettings,
                ActivitySettings = LocalConfiguration.ActivitySettings,
                SenderSettings = LocalConfiguration.SenderSettings,
            };

            LocalConfiguration.SaveToJsonFile(newConfiguration);
        }

        private BrokerSettings FillBrokerSettings()
        {
            _brokerSettings = _userControlSettings.GetSettings();

            return _brokerSettings;
        }

        private async Task LoadLastConfiguration()
        {
            LocalConfiguration = LocalConfiguration.LoadFromJsonFile();

            if (LocalConfiguration.HasConfiguration)
            {
                LoadContractFromDllFile(LocalConfiguration.DllFile);

                if (Contracts.Any())
                {
                    SelectedContract = LocalConfiguration.Contract;

                    if (SelectedContract != null)
                    {
                        SelectedContract.FillTypes(Contracts);

                        labelSelectedContract.Text = SelectedContract.ToString();
                    }

                    LocalConfiguration.ActivitySettings.FaultContract?.FillTypes(Contracts);
                    LocalConfiguration.ActivitySettings.SuccessContract?.FillTypes(Contracts);
                }

                SetJson(LocalConfiguration.Json);

                _brokerSettings = LocalConfiguration.BrokerSettings ?? new BrokerSettings();

                SelectBroker(_brokerSettings.Broker);
            }
        }

        private async Task ValidateConfiguration(bool isPublish = false)
        {
            if (SelectedContract == null)
                throw new InvalidOperationException("Contract is required");

            var json = await GetJson();

            if (string.IsNullOrWhiteSpace(json))
                throw new InvalidOperationException("Json is required");

            if (!isPublish && string.IsNullOrWhiteSpace(LocalConfiguration.SenderSettings.Queue))
                throw new InvalidOperationException("Queue is required");

            if (!string.IsNullOrEmpty(_brokerSettings.ErrorMessage))
                throw new InvalidOperationException(_brokerSettings.ErrorMessage);

            if (SelectedContract.RequiresGeneric && SelectedContract.GenericContract == null)
                throw new InvalidOperationException("Select a type for the generic type");
        }

        private void ConfigurePublisher()
        {
            var buscontrol = _busControlFactory.Create(_brokerSettings);

            _publisherService.Setup(buscontrol);
        }

        private async void ButtonPublish_Click(object sender, EventArgs e)
        {
            ValidateConfiguration(true);

            tabControl.SelectedTab = tabPageLog;

            await _logService.Send(Queues.Log, "Publishing events");

            SaveLastConfiguration();

            var messages = await GetMessagesToSend();

            ConfigurePublisher();

            await _publisherService.Publish(messages);

            await _logService.Send(Queues.Log, $"{messages.Count} events has been published to {SelectedContract}");
        }

        private void ButtonMockJson_Click(object sender, EventArgs e)
        {
            if (SelectedContract == null)
            {
                Alert.Show("Select a contract", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContract.Focus();
                return;
            }

            if (SelectedContract.RequiresGeneric && SelectedContract.GenericContract == null)
            {
                Alert.Show("Select a type for the generic type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContract.Focus();
                return;
            }

            var tipo = SelectedContract.GetFullType();

            var mockObject = _mockService.Mock(tipo, LocalConfiguration.MockSettings);

            var json = JsonConvert.SerializeObject(mockObject, Formatting.Indented);

            labelJson.Text = $"Json ({json.Length} characters)";

            SetJson(json);
        }

        private void TextBoxContract_TextChanged(object sender, EventArgs e)
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

        private void TextBoxContract_KeyDown(object sender, KeyEventArgs e)
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

        private void DataGridViewAutoComplete_KeyDown(object sender, KeyEventArgs e)
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

            if (_genericTypeSelecting && SelectedContract != null)
            {
                if (contract.RequiresGeneric)
                {
                    Alert.Show("You cannot select a contract that requires a generic type as a generic type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SelectedContract.GenericContract = contract;
                _genericTypeSelecting = false;
            }
            else
            {


                SelectedContract = contract;

                SetJson(string.Empty);

                textBoxContract.Text = contract.Name;

                if (contract.RequiresGeneric)
                {
                    Alert.Show("This contract requires a generic type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    _genericTypeSelecting = true;

                    textBoxContract.Focus();
                }

            }

            dataGridViewAutoComplete.Hide();

            labelSelectedContract.Text = SelectedContract.ToString();
        }

        private void DataGridViewAutoComplete_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectFocuseGridContract();
        }

        private void LinkLabelSelectDll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string fileName = string.Empty;

            using (var selectFile = new OpenFileDialog())
            {
                selectFile.Filter = "Dll files (*.dll)|*.dll";

                if (selectFile.ShowDialog() == DialogResult.OK)
                {
                    fileName = selectFile.FileName;

                    LoadContractFromDllFile(fileName);

                    SaveLastConfiguration();

                    Alert.Show("Dll success loaded", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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

        private void ButtonConfigMock_Click(object sender, EventArgs e)
        {
            using var form = new FormMockSettings(_mockService, LocalConfiguration ?? new LocalConfiguration());

            form.ShowDialog();

            LocalConfiguration = form.LocalConfiguration;

            SaveLastConfiguration();
        }

        private async void ButtonActivitySettings_Click(object sender, EventArgs e)
        {
            using var form = new FormActivitySettings(LocalConfiguration.ActivitySettings, Contracts);

            form.ShowDialog();

            LocalConfiguration.ActivitySettings = form.ActivitySettings;

            await SaveLastConfiguration();
        }

        private async void ButtonExecuteActivity_Click(object sender, EventArgs e)
        {
            await _logService.Send(Queues.Log, "Executing activity");

            tabControl.SelectedTab = tabPageLog;

            var conctractMessage = await GetMessagesToSend();

            ConfigurePublisher();

            // Start fault queue listener if enabled
            if (LocalConfiguration.ActivitySettings.ListenToFaultQueue &&
                _brokerSettings.Broker == Broker.AzureServiceBus &&
                !string.IsNullOrEmpty(_brokerSettings.ConnectionString) &&
                !string.IsNullOrEmpty(LocalConfiguration.ActivitySettings.FaultQueue))
            {
                try
                {
                    // Stop existing listener if any
                    if (_faultQueueListener != null)
                    {
                        await _faultQueueListener.StopListeningAsync();
                        await _faultQueueListener.DisposeAsync();
                    }

                    _faultQueueListener = new FaultQueueListenerService(_logService);
                    await _faultQueueListener.StartListeningAsync(
                        _brokerSettings.ConnectionString,
                        LocalConfiguration.ActivitySettings.FaultQueue);
                }
                catch (Exception ex)
                {
                    await _logService.Send(Queues.Log, $"Failed to start fault queue listener: {ex.Message}");
                }
            }

            await _publisherService.ExecuteActivity(conctractMessage, LocalConfiguration.ActivitySettings);

            await SaveLastConfiguration();

            await _logService.Send(Queues.Log, $"{conctractMessage.Count} events has been executed as activity");
        }

        private void ButtonSenderSettings_Click(object sender, EventArgs e)
        {
            using var form = new FormSenderSettings(LocalConfiguration.SenderSettings);

            form.ShowDialog();

            LocalConfiguration.SenderSettings = form.SenderSettings;

            ApplyConfiguration(LocalConfiguration);

            SaveLastConfiguration();
        }

        private void Log(LogMessage message)
        {
            this.BeginInvoke(new Action(() =>
            {
                var date = DateTime.Now.ToString("HH:mm:ss");

                listBoxLog.Items.Add(message);

                listBoxLog.SelectedIndex = listBoxLog.Items.Count - 1;
            }));
        }

        private void SelectBroker(Broker broker)
        {
            foreach (var button in panelBrokers.Controls.OfType<Button>())
            {
                button.FlatAppearance.BorderSize = 1;
            }

            if (panelBrokers.Controls.Find($"buttonBroker{broker}", false).FirstOrDefault() is Button buttonBroker)
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
                    userControlSettings = new UserControlKafkaSettings();
                    break;
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

        private void listBoxLog_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selctedItem = listBoxLog.SelectedItem as LogMessage;

            if (selctedItem != null)
            {
                using var form = new FormLogDetails(selctedItem);
                form.ShowDialog();
            }
        }
    }
}