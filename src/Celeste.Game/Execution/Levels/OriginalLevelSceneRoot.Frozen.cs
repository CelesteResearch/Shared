namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public bool Frozen;

        public bool FrozenOrPaused
        {
            get
            {
                if (!Frozen)
                    return Paused;
                return true;
            }
        }
    }
}
