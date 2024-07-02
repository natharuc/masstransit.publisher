namespace Masstransit.Publisher.Services.Extensions
{
    public static class ObjectExtensions
    {
        public static void SetPropertyValue(this object obj, string propertyName, object value)
        {
            obj.GetType().GetProperty(propertyName).SetValue(obj, value);
        }
    }
}