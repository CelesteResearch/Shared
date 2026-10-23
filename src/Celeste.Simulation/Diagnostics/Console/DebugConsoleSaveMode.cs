using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Diagnostics.Console
{
    // Commands.cs:803-821 toggles the three save-file modes; the console only flips the flag, the
    // consumers read it the next time they are built (originally Settings/SaveData singletons).
    public enum DebugConsoleSaveMode
    {
        Assist,
        Variants,
        Cheat
    }
}
