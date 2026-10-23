using Celeste.Framework.Diagnostics.Commands;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Execution.Engine.Commands
{
    public static class OriginalEngineCommandsBuiltins
    {
        [SourceCommand("clear", "Clears the terminal")]
        public static void Clear() =>
            SourceCommandsBuiltinScope.Clear((ISourceCommandsBuiltinProcess)EngineRuntime.Instance.Process);

        [SourceCommand("exit", "Exits the game")]
        private static void Exit() =>
            SourceCommandsBuiltinScope.Exit((ISourceCommandsBuiltinProcess)EngineRuntime.Instance.Process);

        [SourceCommand("vsync", "Enables or disables vertical sync")]
        private static void Vsync(bool enabled = true) =>
            SourceCommandsBuiltinScope.Vsync((ISourceCommandsBuiltinProcess)EngineRuntime.Instance.Process,
                enabled);

        [SourceCommand("count",
            "Logs amount of Entities in the Scene. Pass a tagIndex to count only Entities with that tag")]
        private static void Count(int tagIndex = -1) =>
            SourceCommandsBuiltinScope.Count((ISourceCommandsBuiltinProcess)EngineRuntime.Instance.Process,
                tagIndex);

        [SourceCommand("tracker",
            "Logs all tracked objects in the scene. Set mode to 'e' for just entities, or 'c' for just components")]
        private static void Tracker(string mode) =>
            SourceCommandsBuiltinScope.Tracker((ISourceCommandsBuiltinProcess)EngineRuntime.Instance.Process, mode);

        [SourceCommand("pooler", "Logs the pooled Entity counts")]
        private static void Pooler() =>
            SourceCommandsBuiltinScope.Pooler((ISourceCommandsBuiltinProcess)EngineRuntime.Instance.Process);

        [SourceCommand("fullscreen", "Switches to fullscreen mode")]
        private static void Fullscreen() =>
            SourceCommandsBuiltinScope.Fullscreen((ISourceCommandsBuiltinProcess)EngineRuntime.Instance.Process);

        [SourceCommand("window", "Switches to window mode")]
        private static void Window(int scale = 1) =>
            SourceCommandsBuiltinScope.Window((ISourceCommandsBuiltinProcess)EngineRuntime.Instance.Process, scale);

        [SourceCommand("help", "Shows usage help for a given command")]
        private static void Help(string command) =>
            SourceCommandsBuiltinScope.Help((ISourceCommandsBuiltinProcess)EngineRuntime.Instance.Process, command);
    }
}
