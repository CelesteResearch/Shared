using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Diagnostics.Console
{
    // Monocle/Command.cs:5-15 - the attribute that turns a static method into a command.
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class DebugConsoleCommandAttribute : Attribute
    {
        public readonly string Name;
        public readonly string Help;

        public DebugConsoleCommandAttribute(string name, string help)
        {
            Name = name;
            Help = help;
        }
    }
}
