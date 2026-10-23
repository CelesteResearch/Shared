namespace Celeste.Game.Execution.ProcessState
{
    public static class CelesteRuntimeState
    {
        // Original Celeste.Celeste.PlayMode is a static field. Keep this as a field too: TargetQuery
        // treats field access as data access even while EnforceLegal blocks property/method execution.
        public static CelestePlayMode PlayMode =
            CelestePlayMode.Normal;

        // Original Engine.Commands.Enabled lives independently after Celeste startup initialises it.
        // SaveAndQuitReenter explicitly sets it false after restoring PlayMode, so changing PlayMode
        // later must not implicitly rewrite this value.
        public static readonly CelesteCommandsRuntimeState Commands = new();

        public static bool DebugPlayMode =>
            PlayMode == CelestePlayMode.Debug;

        public static bool EventPlayMode =>
            PlayMode == CelestePlayMode.Event;
    }
}
