using Celeste.Core.Scheduling;
using Celeste.Scene.Lifecycle;

namespace Celeste.Game.Execution.Levels
{
    public partial class OriginalLevelSceneRoot : ISourceTransitionScene
    {
        internal SimulationCoroutine TransitionCoroutine;
        public float NextTransitionDuration = 0.65f;

        public bool Transitioning => TransitionCoroutine != null;
    }
}
