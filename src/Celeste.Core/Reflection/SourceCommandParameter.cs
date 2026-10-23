using System;

namespace Celeste.Core.Reflection
{
    public sealed class SourceCommandParameter
    {
        public string Name { get; }
        public string ParameterTypeIdentity { get; }
        public object DefaultValue { get; }

        public SourceCommandParameter(string name, string parameterTypeIdentity, object defaultValue)
        {
            Name = name;
            ParameterTypeIdentity = parameterTypeIdentity;
            DefaultValue = defaultValue;
        }
    }
}
