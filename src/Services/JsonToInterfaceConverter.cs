using MassTransit.Serialization.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Globalization;

namespace Publicador.Services
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
                            new StringDecimalConverter(),
                            new MultiFormatDateConverter())
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            },
            TypeNameHandling = TypeNameHandling.None,
            DateParseHandling = DateParseHandling.None,
            DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind
        };

        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _settings);
        }

        public static object Deserialize(string json, Type contractType)
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

    class MultiFormatDateConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string dateString = reader.Value as string;

            if (dateString == null)
            {
                if (objectType == typeof(DateTime?))
                    return null;

                throw new JsonException("Unable to parse null as a date.");
            }

            DateTime date;

            if (DateTime.TryParse(dateString, out date))
                return date;

            if (DateTime.TryParseExact(dateString, "M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;


            throw new JsonException("Unable to parse \"" + dateString + "\" as a date.");
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
