using Masstransit.Publisher.Domain.Classes;
using Masstransit.Publisher.Domain.Interfaces;
using System.Collections;
using System.Dynamic;
using System.Reflection;

namespace Masstransit.Publisher.Services.Services
{
    public class MockInterfaceService : IMockInterfaceService
    {
        private Random _random;

        public MockInterfaceService()
        {
            _random = new Random();
        }

        public object Mock(Type interfaceType, List<MockSettings>? mockSettings)
        {
            if (!interfaceType.IsInterface && !interfaceType.IsClass)
                throw new ArgumentException("The type has been a class or inteface.");

            var mockObject = Activator.CreateInstance(typeof(ExpandoObject)) as IDictionary<string, object?>;

            if (mockObject == null)
                throw new InvalidOperationException("The mock object could not be created.");

            foreach (var property in GetAllProperties(interfaceType))
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

        private bool Ignore(PropertyInfo property, List<MockSettings>? mockSettings)
        {
            if (mockSettings == null) return false;

            return mockSettings
                .Where(x => x.Name == property.Name)
                .Where(x => x.Type == property.PropertyType.Name || x.Type == "Any")
                .Any(x => x.Ignore);
        }

        private object? ConfigValue(PropertyInfo property, List<MockSettings>? mockSettings)
        {
            if (mockSettings == null) return null;

            return mockSettings
                .Where(x => x.Name == property.Name)
                .Where(x => x.Type == property.PropertyType.Name || x.Type == "Any")
                .FirstOrDefault()?.Value;
        }

        private object? GetMockValue(Type propertyType, List<MockSettings>? mockSettings)
        {
            if (propertyType == typeof(int))
                return _random.Next();
            if (propertyType == typeof(Uri))
                return new Uri($@"https://{Guid.NewGuid()}.com");
            if (propertyType == typeof(long))
                return _random.Next();
            if (propertyType == typeof(Guid))
                return Guid.NewGuid();
            if (propertyType == typeof(string))
                return propertyType.Name + Guid.NewGuid().ToString();
            if (propertyType == typeof(DateTime))
                return DateTime.Now;
            if (propertyType == typeof(bool))
                return _random.Next(0, 1) == 1;
            if (propertyType == typeof(double))
                return _random.NextDouble();
            if (propertyType == typeof(decimal))
                return Convert.ToDecimal(_random.NextDouble());
            if (propertyType.IsEnum)
                return GetRandomEnumPosition(propertyType);
            if (propertyType.IsArray)
                return MockList(propertyType, mockSettings);
            if (typeof(IEnumerable).IsAssignableFrom(propertyType) && propertyType.IsGenericType)
                return MockList(propertyType, mockSettings);
            if (propertyType.IsClass || propertyType.IsInterface)
                return Mock(propertyType, mockSettings);

            var instance = Activator.CreateInstance(propertyType);

            return instance;
        }

        private object GetRandomEnumPosition(Type propertyType)
        {
            var enumValues = Enum.GetValues(propertyType);

            var randomIndex = _random.Next(0, enumValues.Length);

            var randomEnumValue = enumValues.GetValue(randomIndex);

            if (randomEnumValue == null)
                throw new InvalidOperationException("The random enum value could not be created.");

            return randomEnumValue;

        }

        private object MockList(Type listType, List<MockSettings>? mockSettings)
        {
            var itemType = listType.IsArray ? listType.GetElementType() : listType.GetGenericArguments().First();
            var listInstance = new List<object>();

            var count = _random.Next(1, 10);

            for (int i = 0; i < count; i++)
            {
                listInstance.Add(GetMockValue(itemType, mockSettings));
            }

            return listInstance;
        }

        private IEnumerable<PropertyInfo> GetAllProperties(Type type)
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

        public List<string> GetMockTypes()
        {
            return new List<string>()
            {
                "Any",
                typeof(int).Name,
                typeof(Uri).Name,
                typeof(long).Name,
                typeof(Guid).Name,
                typeof(string).Name,
                typeof(DateTime).Name,
                typeof(bool).Name,
                typeof(double).Name,
                typeof(decimal).Name,
                "Enum",
                "Array",
                "List",
                "Object"
            };
        }
    }
}
