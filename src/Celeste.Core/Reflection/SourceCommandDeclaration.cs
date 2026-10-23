using System;

namespace Celeste.Core.Reflection
{
    public sealed class SourceCommandDeclaration
    {
        public string Name { get; }
        public string Help { get; }

        public SourceCommandDeclaration(string name, string help)
        {
            Name = name;
            Help = help;
        }
    }
}
