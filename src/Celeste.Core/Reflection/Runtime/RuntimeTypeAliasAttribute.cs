using System;

namespace Celeste.Core.Reflection.Runtime
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface |
                    AttributeTargets.Enum | AttributeTargets.Delegate, AllowMultiple = true, Inherited = false)]
    public sealed class RuntimeTypeAliasAttribute : Attribute
    {
        public string Name { get; }

        public RuntimeTypeAliasAttribute(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("A type alias is required.", nameof(name));
            Name = name;
        }
    }
}
