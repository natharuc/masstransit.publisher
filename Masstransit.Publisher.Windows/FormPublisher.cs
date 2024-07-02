using Masstransit.Publisher.Domain.Classes;
using Masstransit.Publisher.Domain.Interfaces;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Masstransit.Publisher.Windows
{
    public partial class FormPublisher : Form
    {
        public List<Contract> Contratos { get; private set; } = new List<Contract>();
        private Contract _selectedContract { get; set; }

        private const string ConfigFileName = "config.json";
        private IMockInterfaceService _mockInterfaceService;
        private IPublisherService _publisherService;

        public FormPublisher(IMockInterfaceService mockInterfaceService,IPublisherService publisherService)
        {
            InitializeComponent();
            _mockInterfaceService = mockInterfaceService;
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

            var contractMessage = new ContractMessage()
            {
                Contract = _selectedContract,
                Body = richTextBoxJson.Text.Trim(),
            };

            ConfigurePublisher();

            await _publisherService.Send(contractMessage, textBoxQueue.Text);

            MessageBox.Show("Event sent successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void SaveLastConfiguration()
        {
            var configuracao = new LocalConfiguration()
            {
                Contract = textBoxContract.Text.Trim(),
                Json = richTextBoxJson.Text.Trim(),
                Queue = textBoxQueue.Text.Trim(),
                ConnectionString = richTextBoxConnectionString.Text.Trim(),
                DllFile = linkLabelSelectDll.Tag?.ToString()
            };

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(configuracao);

            System.IO.File.WriteAllText(ConfigFileName, json);
        }

        private void LoadLastConfiguration()
        {
            if (System.IO.File.Exists(ConfigFileName))
            {
                var json = System.IO.File.ReadAllText(ConfigFileName);

                var configuracao = Newtonsoft.Json.JsonConvert.DeserializeObject<LocalConfiguration>(json);

                LoadContractFromDllFile(configuracao.DllFile);
                if (Contratos.Any())
                {
                    textBoxContract.Text = configuracao.Contract;
                    _selectedContract = Contratos.FirstOrDefault(c => c.Name == configuracao.Contract);
                }

                richTextBoxJson.Text = configuracao.Json;
                textBoxQueue.Text = configuracao.Queue;
                richTextBoxConnectionString.Text = configuracao.ConnectionString;
            }
        }

        private void Validate(bool isPublish = false)
        {
            if (string.IsNullOrWhiteSpace(textBoxContract.Text))
                throw new InvalidOperationException("Contract is required");

            if (string.IsNullOrWhiteSpace(richTextBoxJson.Text))
                throw new InvalidOperationException("Json is required");

            if (!isPublish && string.IsNullOrWhiteSpace(textBoxQueue.Text))
                throw new InvalidOperationException("Queue is required");

            if (string.IsNullOrWhiteSpace(richTextBoxConnectionString.Text))
                throw new InvalidOperationException("Connection string is required");
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

            var provider  = serviceCollection.BuildServiceProvider();

            var buscontrol = provider.GetRequiredService<IBusControl>();

            return buscontrol;
        }

        private async void buttonPublish_Click(object sender, EventArgs e)
        {
            Validate(true);

            SaveLastConfiguration();

            var evento = new ContractMessage()
            {
                Contract = _selectedContract,
                Body = richTextBoxJson.Text.Trim(),
            };

            ConfigurePublisher();

            await _publisherService.Publish(evento);

            MessageBox.Show("Event published successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonGenerateJson_Click(object sender, EventArgs e)
        {
            if (_selectedContract == null)
            {
                MessageBox.Show("Select a contract", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContract.Focus();
                return;
            }

            var tipo = _selectedContract.Type;

            var mockObject = _mockInterfaceService.Generate(tipo);

            var json = JsonConvert.SerializeObject(mockObject, Formatting.Indented);

            richTextBoxJson.Text = json;
        }

        private void textBoxContrato_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxContract.Text.Trim()))
            {
                dataGridViewAutoComplete.Hide();
            }
            else
            {
                if (Contratos.Any())
                {

                    var contratos = Contratos.FindAll(c => c.Name.ToLower().Contains(textBoxContract.Text.Trim().ToLower()));

                    if (contratos.Any())
                    {
                        dataGridViewAutoComplete.DataSource = null;

                        dataGridViewAutoComplete.DataSource = contratos;

                        dataGridViewAutoComplete.Columns["Name"].Visible = false;

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

        private void textBoxContrato_KeyDown(object sender, KeyEventArgs e)
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

            _selectedContract = contract;

            textBoxContract.Text = contract.Name;

            dataGridViewAutoComplete.Hide();
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

            var contratos = assembly.GetTypes()
                .Select(t => new Contract(t.FullName, t))
                .ToList();

            Contratos.Clear();
            Contratos.AddRange(contratos);

            linkLabelSelectDll.Text = file.Name;
            linkLabelSelectDll.Tag = file.FullName;
        }
    }
}
