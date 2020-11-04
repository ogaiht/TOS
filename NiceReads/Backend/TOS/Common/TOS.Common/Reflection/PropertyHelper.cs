using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TOS.Common.Reflection
{
    public class PropertyHelper<T>
    {
        private readonly Dictionary<string, PropertyInfo> _properties;

        public PropertyHelper()
        {
            _properties = typeof(T).GetProperties().ToDictionary(p => p.Name, p => p);
        }

        public void SetValue(T instance, string propertyName, object value)
        {
            _properties[propertyName].SetValue(instance, value);
        }
    }
}
