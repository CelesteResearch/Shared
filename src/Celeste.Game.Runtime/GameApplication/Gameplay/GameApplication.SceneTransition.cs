using System;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceEngineSceneTransition,
        IOriginalEngineSceneTransitionEnvironment
    {
        public event Action<ISourceSceneExecution, ISourceSceneExecution> SourceSceneTransitioned;

        void ISourceEngineSceneTransition.OnSceneTransition(ISourceSceneExecution previous, ISourceSceneExecution next)
        {
            ActualGame.DispatchSourceSceneTransition(previous, next);
            SourceSceneTransitioned?.Invoke(previous, next);
        }

        void IOriginalEngineSceneTransitionEnvironment.AfterSourceSceneTransition(ISourceSceneExecution previous,
            ISourceSceneExecution next)
        {
            if (SourceProfile == GameProfile.InstalledEverest)
                GameEvents.SceneTransition(previous, next);
        }
    }
}
