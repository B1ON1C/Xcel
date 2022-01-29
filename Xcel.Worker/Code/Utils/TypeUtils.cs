using System.Reflection;

namespace Xcel.Worker.Code.Utils
{
    internal static class TypeUtils
    {
        public static Type GetBaseType(PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType.IsGenericType &&
                propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return propertyInfo.PropertyType.GetGenericArguments()[0];
            }
            return propertyInfo.PropertyType;
        }
    }
}
