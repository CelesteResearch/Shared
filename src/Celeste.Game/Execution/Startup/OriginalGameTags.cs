using Celeste.Scene.Tagging;
using Celeste.Scene.Scheduling.ExecutionTags;

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
            PauseUpdate = new SourceBitTag("pauseUpdate", sameProcess);
            FrozenUpdate = new SourceBitTag("frozenUpdate", sameProcess);
            TransitionUpdate = new SourceBitTag("transitionUpdate", sameProcess);
            HUD = new SourceBitTag("hud", sameProcess);
            Persistent = new SourceBitTag("persistent", sameProcess);
            Global = new SourceBitTag("global", sameProcess);
        }
    }
}
