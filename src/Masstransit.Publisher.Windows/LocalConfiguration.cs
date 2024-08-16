
using Masstransit.Publisher.Domain.Classes;
using Newtonsoft.Json;

namespace Masstransit.Publisher.Windows
{
    public class LocalConfiguration
    {
        public LocalConfiguration()
        {
            MockSettings = new();
            SenderSettings = new()
            {
                MessageCount = 1,
            };
            ActivitySettings = new()
            {
                FaultQueue = "fault",
                SuccessQueue = "success",
                Activities = new()
            };
        }

        public const string ConfigFileName = "config.json";
        public DateTime? LastSave { get; set; }
        public string DllFile { get; set; } = string.Empty;
        public Contract? Contract { get; set; } 
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

        public MockSettings MockSettings { get; set; }
        public ActivitySettings ActivitySettings { get; set; }
        public SenderSettings SenderSettings { get; set; }

        public static LocalConfiguration LoadFromJsonFile()
        {
            if (File.Exists(ConfigFileName))
            {
                var json = File.ReadAllText(ConfigFileName);

                var savedConfiguration = JsonConvert.DeserializeObject<LocalConfiguration>(json);

                if(savedConfiguration == null)
                    return new LocalConfiguration();

                return savedConfiguration;
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