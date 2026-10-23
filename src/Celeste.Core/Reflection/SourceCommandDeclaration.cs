namespace Celeste.Core.Reflection
{
    public sealed class SourceCommandDeclaration(string name, string help)
    {
        public string Name { get; }
            = name;

        public string Help { get; }
            = help;
    }
}
