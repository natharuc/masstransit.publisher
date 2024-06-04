using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace Publicador.Services
{
    public static class FictObject
    {
        private static Dictionary<Type, object> _instances = new Dictionary<Type, object>();

        public static object GenerateMockObject(Type interfaceType)
        {
            if (!interfaceType.IsInterface && !interfaceType.IsClass)
                throw new ArgumentException("The type has been a class or inteface.");

            if (_instances.ContainsKey(interfaceType))
            {
                return _instances[interfaceType];
            }

            var mockObject = Activator.CreateInstance(typeof(ExpandoObject)) as IDictionary<string, object>;
            _instances[interfaceType] = mockObject;

            foreach (var property in GetAllProperties(interfaceType))
            {
                mockObject[property.Name] = GetMockValue(property.PropertyType);
            }

            return mockObject;
        }

        public static object GetMockValue(Type propertyType)
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
                return GenerateMockObject(propertyType);


            return Activator.CreateInstance(propertyType);
        }

        public static object CreateList(Type listType)
        {
            var itemType = listType.GetGenericArguments()[0];
            var listInstance = Activator.CreateInstance(typeof(List<>).MakeGenericType(itemType)) as IList;

            if (listInstance != null)
            {
                listInstance.Add(GetMockValue(itemType));
            }

            return listInstance;
        }

        public static IEnumerable<PropertyInfo> GetAllProperties(Type type)
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
