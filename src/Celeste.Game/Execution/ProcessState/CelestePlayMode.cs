namespace Celeste.Game.Execution.ProcessState
{
    // Process-wide state which the original keeps on Celeste.Celeste / Monocle.Engine, not in SaveData.
    //
    // This distinction is observable. CelesteTAS SaveAndQuitReenter temporarily sets
    // Celeste.PlayMode=Debug to expose the ~DEBUG~ main-menu entry when no save slot is active, then
    // restores the old play mode. Writing ChapterProgress.DebugMode here would permanently mutate the
    // save/profile model and is therefore not equivalent.
    public enum CelestePlayMode
    {
        Normal,
        Debug,
        Event,
        Demo
    }
}
