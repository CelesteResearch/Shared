using System;
using System.Reflection;

namespace Celeste.Savestates.Reflection
{
    public sealed class ObjectSettingsSnapshot
    {
        private readonly object copy;
        private readonly bool properties;
        private readonly Predicate<FieldInfo> includeField;
        private readonly Predicate<PropertyInfo> includeProperty;

        private static readonly MethodInfo shallowClone =
            typeof(object).GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);

        public ObjectSettingsSnapshot(object value, bool includeProperties, Func<object, object> deepClone = null,
            Predicate<FieldInfo> includeField = null, Predicate<PropertyInfo> includeProperty = null)
        {
            properties = includeProperties;
            this.includeField = includeField;
            this.includeProperty = includeProperty;
            try
            {
                copy = deepClone?.Invoke(value) ?? shallowClone.Invoke(value, null);
            }
            catch
            {
                copy = shallowClone.Invoke(value, null);
            }
        }

        public void Restore(object target)
        {
            if (target.GetType() != copy.GetType())
                throw new ArgumentException("Settings type changed during playback.");
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic |
                                       BindingFlags.DeclaredOnly;
            if (properties)
                for (var type = target.GetType(); type != null; type = type.BaseType)
                    foreach (var property in type.GetProperties(flags))
                        if ((includeProperty == null || includeProperty(property)) &&
                            property.GetIndexParameters().Length == 0 &&
                            property.GetGetMethod(true) != null && property.GetSetMethod(true) != null)
                        {
                            var value = property.GetValue(copy);
                            if (!ReferenceEquals(value, property.GetValue(target))) property.SetValue(target, value);
                        }

            for (var type = target.GetType(); type != null; type = type.BaseType)
                foreach (var field in type.GetFields(flags))
                {
                    if (includeField != null && !includeField(field)) continue;
                    var value = field.GetValue(copy);
                    if (!properties || !ReferenceEquals(value, field.GetValue(target))) field.SetValue(target, value);
                }
        }
    }
}
