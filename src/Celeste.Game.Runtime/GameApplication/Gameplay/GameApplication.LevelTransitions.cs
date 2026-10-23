using System;
using Celeste.Everest.Runtime.Levels.Transitions;
using Celeste.Game.Execution.Levels.Transitions;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalLevelTransitionEnvironment, IEverestLevelTransitionSettings
    {
        private IOriginalLevelTransitionPolicy sourceLevelTransitionPolicy;

        public IOriginalLevelTransitionPolicy LevelTransitionPolicy => sourceLevelTransitionPolicy
                                                                       ?? throw new InvalidOperationException(
                                                                           "The source Level transition policy is not constructed.");

        bool IEverestLevelTransitionSettings.DisableAntiSoftlock => CurrentCoreSettings.DisableAntiSoftlock;

        private void ConstructSourceLevelTransitionPolicy()
        {
            if (sourceLevelTransitionPolicy != null)
                throw new InvalidOperationException("The source Level transition policy is already constructed.");
            sourceLevelTransitionPolicy = SourceProfile == GameProfile.InstalledEverest
                ? new EverestLevelTransitionPolicy(LevelUpdateEvents, this, LevelLoaders)
                : new OriginalLevelTransitionPolicy();
        }
    }
}
