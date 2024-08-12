
using Masstransit.Publisher.Domain.Classes;
using Newtonsoft.Json;

namespace Masstransit.Publisher.Windows
{
    public class LocalConfiguration
    {
        public LocalConfiguration()
        {
            MockSettings = new List<MockSettings>();
        }

        public const string ConfigFileName = "config.json";
        public DateTime? LastSave { get; set; }
        public string DllFile { get; set; } = string.Empty;
        public string Contract { get; set; } = string.Empty;
        public string Json { get; set; } = string.Empty;
        public string Queue { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public bool HasConfiguration
        {
            get
            {
                return LastSave.HasValue;
            }
        }

        public List<MockSettings> MockSettings { get;  set; }

        public static LocalConfiguration LoadFromJsonFile()
        {
            if (File.Exists(ConfigFileName))
            {
                var json = File.ReadAllText(ConfigFileName);

                return JsonConvert.DeserializeObject<LocalConfiguration>(json) ?? new LocalConfiguration();
            }

            return new LocalConfiguration();
        }

        public static void SaveToJsonFile(LocalConfiguration newConfiguration)
        {
            newConfiguration.LastSave = DateTime.Now;

            var json = JsonConvert.SerializeObject(newConfiguration);

            File.WriteAllText(ConfigFileName, json);
        }
    }
}