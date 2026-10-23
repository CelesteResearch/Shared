using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Scene.Tagging;

namespace Celeste.Game.Execution.Startup
{
    public class OriginalGameTags : ISourceGlobalFrozenExecutionTags, ISourcePersistentTransitionExecutionTags
    {
        public SourceBitTag PauseUpdate;
        public SourceBitTag FrozenUpdate;
        public SourceBitTag TransitionUpdate;
        public SourceBitTag HUD;
        public SourceBitTag Persistent;
        public SourceBitTag Global;

        SourceBitTag ISourceGlobalFrozenExecutionTags.Global => Global;
        SourceBitTag ISourceGlobalFrozenExecutionTags.FrozenUpdate => FrozenUpdate;
        SourceBitTag ISourcePersistentTransitionExecutionTags.Persistent => Persistent;
        SourceBitTag ISourcePersistentTransitionExecutionTags.TransitionUpdate => TransitionUpdate;

        public void Initialize(SourceBitTagProcessState sameProcess)
        {
            PauseUpdate = new("pauseUpdate", sameProcess);
            FrozenUpdate = new("frozenUpdate", sameProcess);
            TransitionUpdate = new("transitionUpdate", sameProcess);
            HUD = new("hud", sameProcess);
            Persistent = new("persistent", sameProcess);
            Global = new("global", sameProcess);
        }
    }
}
