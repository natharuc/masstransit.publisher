using Masstransit.Publisher.Domain.Interfaces;
using System.Collections;
using System.Dynamic;
using System.Reflection;

namespace Masstransit.Publisher.Services.Services
{
    public class MockInterfaceService : IMockInterfaceService
    {
        public object Generate(Type interfaceType)
        {
            if (!interfaceType.IsInterface && !interfaceType.IsClass)
                throw new ArgumentException("The type has been a class or inteface.");

            var mockObject = Activator.CreateInstance(typeof(ExpandoObject)) as IDictionary<string, object>;
            
            foreach (var property in GetAllProperties(interfaceType))
            {
                mockObject[property.Name] = GetMockValue(property.PropertyType);
            }

            return mockObject;
        }

        private object GetMockValue(Type propertyType)
        {
            if (propertyType == typeof(int))
                return 123;
            if (propertyType == typeof(string))
                return "Sample String";
            if (propertyType == typeof(DateTime))
                return DateTime.Now;
            if (propertyType == typeof(bool))
                return true;
            if (propertyType == typeof(double))
                return 123.45;
            if (propertyType.IsEnum)
                return Enum.GetValues(propertyType).GetValue(0);
            if (propertyType.IsArray)
                return Array.CreateInstance(propertyType.GetElementType(), 1);
            if (typeof(IEnumerable).IsAssignableFrom(propertyType) && propertyType.IsGenericType)
                return CreateList(propertyType);
            if (propertyType.IsClass || propertyType.IsInterface)
                return Generate(propertyType);


            return Activator.CreateInstance(propertyType);
        }

        private object CreateList(Type listType)
        {
            var itemType = listType.GetGenericArguments()[0];
            var listInstance = new List<object>();

            if (listInstance != null)
            {
                listInstance.Add(GetMockValue(itemType));
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
                    foreach (var subInterface in subType.GetInterfaces())
                    {
                        if (considered.Add(subInterface))
                        {
                            queue.Enqueue(subInterface);
                        }
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
