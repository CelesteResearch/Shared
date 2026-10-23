using System;

namespace Celeste.Framework.Diagnostics.Commands
{
    public class SourceCommandAttribute : Attribute
    {
        public string Name;
        public string Help;

        public SourceCommandAttribute(string name, string help)
        {
            Name = name;
            Help = help;
        }
    }
}
