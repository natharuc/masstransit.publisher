using Masstransit.Publisher.Domain.Classes;
using Masstransit.Publisher.Domain.Interfaces;
using System.Collections;
using System.Dynamic;
using System.Reflection;

namespace Masstransit.Publisher.Services.Services
{
    public class MockInterfaceService : IMockInterfaceService
    {
        private readonly Random _random;

        public MockInterfaceService()
        {
            _random = new Random();
        }

        public object? Mock(Type type, MockSettings mockSettings)
        {
            if (!type.IsInterface && !type.IsClass)
                throw new ArgumentException("The type has been a class or inteface.");

            IDictionary<string, object?>? mockObject = Activator.CreateInstance(typeof(ExpandoObject)) as IDictionary<string, object?> ?? throw new InvalidOperationException("The mock object could not be created.");

            foreach (var property in GetAllProperties(type))
            {
                if (Ignore(property, mockSettings)) continue;

                if (ConfigValue(property, mockSettings) != null)
                {
                    mockObject[property.Name] = ConfigValue(property, mockSettings);
                    continue;
                }

                mockObject[property.Name] = GetMockValue(property.PropertyType, mockSettings);
            }

            return mockObject;
        }

        private static bool Ignore(PropertyInfo property, MockSettings mockSettings)
        {
            if (mockSettings == null) return false;

            return mockSettings.CustomProperties
                .Where(x => x.Name == property.Name)
                .Where(x => x.Type == property.PropertyType.Name || x.Type == "Any")
                .Any(x => x.Ignore);
        }

        private static object? ConfigValue(PropertyInfo property, MockSettings mockSettings)
        {
            if (mockSettings == null) return null;

            return mockSettings.CustomProperties
                .Where(x => !x.RegenerateBeforeSending)
                .Where(x => x.Name == property.Name)
                .FirstOrDefault(x => x.Type == property.PropertyType.Name || x.Type == "Any")?
                .Value;
        }

        public object? GetMockValue(Type type, MockSettings mockSettings)
        {
            if (type == typeof(int))
                return _random.Next();
            if (type == typeof(Uri))
                return new Uri($@"https://{Guid.NewGuid()}.com");
            if (type == typeof(long))
                return _random.Next();
            if (type == typeof(Guid))
                return Guid.NewGuid();
            if (type == typeof(string))
                return type.Name + Guid.NewGuid().ToString();
            if (type == typeof(DateTime))
                return DateTime.Now;
            if (type == typeof(bool))
                return _random.Next(0, 1) == 1;
            if (type == typeof(double))
                return _random.NextDouble();
            if (type == typeof(decimal))
                return Convert.ToDecimal(_random.NextDouble());
            if (type.IsEnum)
                return GetRandomEnumPosition(type);
            if (type.IsArray)
                return MockList(type, mockSettings);
            if (typeof(IEnumerable).IsAssignableFrom(type) && type.IsGenericType)
                return MockList(type, mockSettings);
            if (type.IsClass || type.IsInterface)
                return Mock(type, mockSettings);

            var instance = Activator.CreateInstance(type);

            return instance;
        }

        private object? GetRandomEnumPosition(Type propertyType)
        {
            var enumValues = Enum.GetValues(propertyType);

            var randomIndex = _random.Next(0, enumValues.Length);

            var randomEnumValue = enumValues.GetValue(randomIndex);

            return randomEnumValue ?? throw new InvalidOperationException("The random enum value could not be created.");
        }

        private object? MockList(Type listType, MockSettings mockSettings)
        {
            var listInstance = new List<object>();

            var itemType = listType.IsArray ? listType.GetElementType() : listType.GetGenericArguments()[0];

            if (itemType == null)
                return listInstance;

            var count = _random.Next(mockSettings.MinArrayLength, mockSettings.MaxArrayLength);

            for (int i = 0; i < count; i++)
            {
                var mockValue = GetMockValue(itemType, mockSettings);

                if (mockValue == null)
                    continue;

                listInstance.Add(mockValue);
            }

            return listInstance;
        }

        private static IEnumerable<PropertyInfo> GetAllProperties(Type type)
        {
            var propertyInfos = new List<PropertyInfo>();

            if (type.IsInterface)
            {
                var considered = new HashSet<Type>();
                var queue = new Queue<Type>();
                considered.Add(type);
                queue.Enqueue(type);

                while (queue.Count > 0)
                {
                    var subType = queue.Dequeue();
                    foreach (var subInterface in from subInterface in subType.GetInterfaces()
                                                 where considered.Add(subInterface)
                                                 select subInterface)
                    {
                        queue.Enqueue(subInterface);
                    }

                    var typeProperties = subType.GetProperties(
                        BindingFlags.FlattenHierarchy
                        | BindingFlags.Public
                        | BindingFlags.Instance);

                    var newPropertyInfos = typeProperties
                        .Where(x => !propertyInfos.Contains(x));

                    propertyInfos.InsertRange(0, newPropertyInfos);
                }
            }
            else
            {
                var typeProperties = type.GetProperties(
                    BindingFlags.FlattenHierarchy
                    | BindingFlags.Public
                    | BindingFlags.Instance);

                propertyInfos.AddRange(typeProperties);
            }

            return propertyInfos;
        }

    }
}
