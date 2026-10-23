namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public bool Frozen;

        public bool FrozenOrPaused => !Frozen ? Paused : true;
    }
}
