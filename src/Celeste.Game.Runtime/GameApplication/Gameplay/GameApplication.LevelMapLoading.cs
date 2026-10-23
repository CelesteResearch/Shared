using System;
using Celeste.Everest.Runtime.Levels.Loading.Entities;
using Celeste.Game.Execution.Levels.Loading.Entities;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalLevelMapLoadEnvironment
    {
        private IOriginalLevelMapLoadPolicy sourceLevelMapLoadPolicy;

        public IOriginalLevelMapLoadPolicy LevelMapLoadPolicy => sourceLevelMapLoadPolicy
                                                                 ?? throw new InvalidOperationException(
                                                                     "The actual source map loading policy is not constructed.");

        private void ConstructSourceLevelMapLoading()
        {
            if (sourceLevelMapLoadPolicy != null)
                throw new InvalidOperationException("The actual source map loading policy is already constructed.");
            if (SourceProfile == GameProfile.InstalledEverest)
                ConstructSourceCustomEntityLoading();
            sourceLevelMapLoadPolicy = SourceProfile == GameProfile.InstalledEverest
                ? new EverestLevelMapLoadPolicy(this)
                : new OriginalLevelMapLoadPolicy();
        }
    }
}
