using MassTransit.Serialization.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Masstransit.Publisher.Services.Services
{
    public static class JsonToInterfaceConverter
    {
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            ObjectCreationHandling = ObjectCreationHandling.Auto,
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            ContractResolver = new JsonContractResolver(
                            new ByteArrayConverter(),
                            new CaseInsensitiveDictionaryJsonConverter(),
                            new InternalTypeConverter(),
                            new InterfaceProxyConverter(),
                            new NewtonsoftMessageDataJsonConverter(),
                            new StringDecimalConverter())
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            },
            TypeNameHandling = TypeNameHandling.None,
            DateParseHandling = DateParseHandling.None,
            DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind
        };

        public static T? Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _settings);
        }

        public static object? Deserialize(string json, Type contractType)
        {
            return JsonConvert.DeserializeObject(json, contractType, _settings);
        }

        public static string Serialize(Type contractType)
        {
            return JsonConvert.SerializeObject(new { }, contractType, _settings);
        }

        internal static object Deserialize(object dadosEvento, Type tipo)
        {
            throw new NotImplementedException();
        }
    }
}
