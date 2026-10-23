using Celeste.Core.Scheduling;

namespace Celeste.Game.Execution.Levels
{
    public partial class OriginalLevelSceneRoot : global::Celeste.Scene.Lifecycle.ISourceTransitionScene
    {
        internal SimulationCoroutine TransitionCoroutine;
        public float NextTransitionDuration = 0.65f;

        public bool Transitioning => TransitionCoroutine != null;
    }
}
