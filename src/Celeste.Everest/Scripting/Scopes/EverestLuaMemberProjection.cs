using System;
using System.Collections.Generic;
using System.Reflection;
using Celeste.Core.Reflection.Members;

namespace Celeste.Everest.Scripting.Scopes
{
    public sealed class EverestLuaMemberProjection
    {
        private readonly SourceMemberCatalog members;

        private readonly Dictionary<(Type Type, string Name), SourcePhysicalMemberBinding> cache = new();

        public EverestLuaMemberProjection(SourceMemberCatalog members)
        {
            this.members = members ?? throw new ArgumentNullException(nameof(members));
        }

        private SourcePhysicalMemberBinding Find(object instance, string name)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            if (name == null) throw new ArgumentNullException(nameof(name));
            var key = (instance.GetType(), name);
            if (cache.TryGetValue(key, out var binding)) return binding;
            var sourceScope = key.Item1;
            while (sourceScope != null && !members.ContainsSourceType(sourceScope)) sourceScope = sourceScope.BaseType;
            if (sourceScope == null) return null;
            const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            binding = members.GetFieldInfo(sourceScope, name, flags) ??
                      members.GetPropertyInfo(sourceScope, name, flags);
            cache.Add(key, binding);
            return binding;
        }

        public bool HasMember(object instance, string name)
        {
            return Find(instance, name) != null;
        }

        public object Read(object instance, string name)
        {
            return (Find(instance, name) ?? throw new MissingMemberException(instance.GetType().FullName, name))
                .Read(instance);
        }

        public void Write(object instance, string name, object value)
        {
            var binding = Find(instance, name) ?? throw new MissingMemberException(instance.GetType().FullName, name);
            var targetType = binding.PhysicalLeafValueType;
            if (value != null && targetType.IsValueType && value.GetType() != targetType)
                value = targetType.IsEnum ? Enum.ToObject(targetType, value) : Convert.ChangeType(value, targetType);
            binding.Write(instance, value);
        }
    }
}
