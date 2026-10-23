using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Diagnostics.Console
{
    // =============================================================================================
    // The debug console's world contract (CommandsDraft).
    //
    // Faithful reference: Monocle/Commands.cs (the console) + Celeste/Commands.cs (the command
    // table). The original's commands reach the running game through ambient globals - Engine.Scene,
    // SaveData.Instance, Settings.Instance (e.g. Commands.cs:41 `Engine.Scene is Level level`,
    // :660 `SaveData.Instance.CurrentSession.SetFlag(...)`). Those globals are exactly what a pure
    // simulation layer cannot have, so this interface is the explicit replacement: one member per
    // global the ported table touches. Nothing here is Unity-specific.
    //
    // The console itself (DebugConsole.cs) only ever calls through this interface, so the whole
    // registry / parsing / echo / key-handling path is exercised identically by the Unity host and
    // by a probe that supplies its own implementation.
    // =============================================================================================

    // Monocle/Commands.cs:22-39 Line: text plus a colour. Colors.White is the default.
    public readonly struct DebugConsoleLine
    {
        public readonly string Text;
        public readonly Vector4 Color;

        public DebugConsoleLine(string text)
        {
            Text = text;
            Color = global::Celeste.Simulation.Diagnostics.Console.DebugConsoleColors.White;
        }

        public DebugConsoleLine(string text, Vector4 color)
        {
            Text = text;
            Color = color;
        }
    }
}
