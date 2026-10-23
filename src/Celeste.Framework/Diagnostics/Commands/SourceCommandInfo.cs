using System;

namespace Celeste.Framework.Diagnostics.Commands
{
    public struct SourceCommandInfo
    {
        public Action<string[]> Action;
        public string Help;
        public string Usage;
    }
}
