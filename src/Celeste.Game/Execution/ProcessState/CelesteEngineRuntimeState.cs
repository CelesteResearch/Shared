namespace Celeste.Game.Execution.ProcessState
{
    // Query alias root for "Engine.Commands.Enabled". It deliberately exposes only the original
    // Engine-shaped process state instead of making every CelesteRuntimeState member reachable through
    // both root names.
    public static class CelesteEngineRuntimeState
    {
        public static readonly global::Celeste.Game.Execution.ProcessState.CelesteCommandsRuntimeState Commands =
            global::Celeste.Game.Execution.ProcessState.CelesteRuntimeState.Commands;
    }
}
