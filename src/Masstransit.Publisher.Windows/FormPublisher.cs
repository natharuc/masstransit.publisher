using Masstransit.Publisher.Domain.Classes;
using Masstransit.Publisher.Domain.Interfaces;
using Masstransit.Publisher.Windows.Forms;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Masstransit.Publisher.Windows
{
    public partial class FormPublisher : Form
    {
        public List<Contract> Contracts { get; private set; } = new List<Contract>();
        private Contract? _selectedContract { get; set; }


        private IMockInterfaceService _mockService;
        private IPublisherService _publisherService;
        private bool _genericTypeSelecting;
        private LocalConfiguration _localConfiguration;

        public FormPublisher(IMockInterfaceService mockInterfaceService, IPublisherService publisherService)
        {
            InitializeComponent();
            _localConfiguration = new LocalConfiguration();
            _mockService = mockInterfaceService;
            _publisherService = publisherService;
        }

        private void FormPublicador_Load(object sender, EventArgs e)
        {
            LoadLastConfiguration();

            dataGridViewAutoComplete.Hide();
        }

        private async void buttonSend_Click(object sender, EventArgs e)
        {
            Validate();

            SaveLastConfiguration();

            if (_selectedContract == null)
            {
                MessageBox.Show("Select a contract", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContract.Focus();
                return;
            }

            var contractMessage = GetContractMessage();

            ConfigurePublisher();

            await _publisherService.Send(contractMessage, textBoxQueue.Text.Trim());

            MessageBox.Show("Event sent successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private ContractMessage GetContractMessage()
        {
            RegenerateJson();

            return new ContractMessage()
            {
                Contract = _selectedContract,
                Body = richTextBoxJson.Text.Trim(),
            };
        }

        private void RegenerateJson()
        {
            if (_localConfiguration.MockSettings.CustomProperties.Exists(n => n.RegenerateBeforeSending))
            {
                var currentObject = JsonConvert.DeserializeObject<JObject>(richTextBoxJson.Text);

                var regenerateProperties = _localConfiguration.MockSettings.CustomProperties.FindAll(n => n.RegenerateBeforeSending);

                if (regenerateProperties.Any())
                {
                    foreach (var property in regenerateProperties)
                    {
                        var objectProperty = currentObject[property.Name];

                        var type = Type.GetType("System." + property.Type);

                        var newValue = _mockService.GetMockValue(type, _localConfiguration.MockSettings);

                        currentObject[property.Name] = JToken.FromObject(newValue);
                    }

                    richTextBoxJson.Text = JsonConvert.SerializeObject(currentObject, Formatting.Indented);
                }
            }
        }

        private void SaveLastConfiguration()
        {
            var newConfiguration = new LocalConfiguration()
            {
                Contract = _selectedContract,
                Json = richTextBoxJson.Text.Trim(),
                Queue = textBoxQueue.Text.Trim(),
                ConnectionString = richTextBoxConnectionString.Text.Trim(),
                DllFile = linkLabelSelectDll.Tag?.ToString(),
                MockSettings = _localConfiguration?.MockSettings,
                ActivitySettings = _localConfiguration?.ActivitySettings
            };

            LocalConfiguration.SaveToJsonFile(newConfiguration);
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
                textBoxQueue.Text = _localConfiguration.Queue;
                richTextBoxConnectionString.Text = _localConfiguration.ConnectionString;

            }
        }

        private void Validate(bool isPublish = false)
        {
            if (_selectedContract == null)
                throw new InvalidOperationException("Contract is required");

            if (string.IsNullOrWhiteSpace(richTextBoxJson.Text))
                throw new InvalidOperationException("Json is required");

            if (!isPublish && string.IsNullOrWhiteSpace(textBoxQueue.Text))
                throw new InvalidOperationException("Queue is required");

            if (string.IsNullOrWhiteSpace(richTextBoxConnectionString.Text))
                throw new InvalidOperationException("Connection string is required");

            if (_selectedContract != null && _selectedContract.RequiresGeneric && _selectedContract.GenericContract == null)
                throw new InvalidOperationException("Select a type for the generic type");
        }

        private void ConfigurePublisher()
        {
            var buscontrol = GetBusControl();

            _publisherService.Setup(buscontrol);
        }

        private IBusControl GetBusControl()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddMassTransit((masstransit) =>
            {
                masstransit.UsingAzureServiceBus((bus, cfg) =>
                {
                    cfg.Host(richTextBoxConnectionString.Text);

                    cfg.UseNewtonsoftJsonDeserializer();
                    cfg.UseNewtonsoftJsonDeserializer();
                    cfg.ConfigureNewtonsoftJsonDeserializer(s => SerializerPadrao(s));
                    cfg.ConfigureNewtonsoftJsonSerializer(s => SerializerPadrao(s));
                });
            });

            JsonSerializerSettings SerializerPadrao(JsonSerializerSettings settings)
            {
                settings.Converters.Add(new StringEnumConverter());
                settings.NullValueHandling = NullValueHandling.Ignore;
                settings.DefaultValueHandling = DefaultValueHandling.Ignore;
                settings.DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind;
                settings.DateParseHandling = DateParseHandling.None;
                settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;

                return settings;
            }

            var provider = serviceCollection.BuildServiceProvider();

            var buscontrol = provider.GetRequiredService<IBusControl>();

            return buscontrol;
        }

        private async void buttonPublish_Click(object sender, EventArgs e)
        {
            Validate(true);

            SaveLastConfiguration();

            var message = GetContractMessage();

            ConfigurePublisher();

            await _publisherService.Publish(message);

            MessageBox.Show("Event published successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            using (var selectFile = new OpenFileDialog())
            {
                selectFile.Filter = "Dll files (*.dll)|*.dll";

                if (selectFile.ShowDialog() == DialogResult.OK)
                {
                    var fileName = selectFile.FileName;

                    LoadContractFromDllFile(fileName);

                    SaveLastConfiguration();

                    MessageBox.Show("Dll success loaded", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void LoadContractFromDllFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return;

            var file = new System.IO.FileInfo(fileName);

            var assembly = System.Reflection.Assembly.LoadFrom(fileName);

            var contracts = assembly.GetTypes()
                .Select(t => new Contract(t))
                .ToList();

            Contracts.Clear();
            Contracts.AddRange(contracts);

            linkLabelSelectDll.Text = file.Name;
            linkLabelSelectDll.Tag = file.FullName;
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
            var conctractMessage = GetContractMessage();

            ConfigurePublisher();

            await _publisherService.ExecuteActivity(conctractMessage, _localConfiguration.ActivitySettings);

            SaveLastConfiguration();

            MessageBox.Show("Activity executed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonSenderSettings_Click(object sender, EventArgs e)
        {

        }
    }
}