namespace Celeste.Core.Reflection
{
    public sealed class SourceCommandParameter(string name, string parameterTypeIdentity, object defaultValue)
    {
        public string Name { get; }
            = name;

        public string ParameterTypeIdentity { get; }
            = parameterTypeIdentity;

        public object DefaultValue { get; }
            = defaultValue;
    }
}
