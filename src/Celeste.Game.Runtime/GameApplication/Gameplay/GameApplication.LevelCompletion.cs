using System;
using Celeste.Game.Execution.Levels.Completion;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalLevelCompletionPolicyEnvironment
    {
        private IOriginalLevelCompletionPolicy sourceLevelCompletion;

        public IOriginalLevelCompletionPolicy LevelCompletion => sourceLevelCompletion
                                                                 ?? throw new InvalidOperationException(
                                                                     "The actual source Level completion policy is not constructed.");

        private void ConstructSourceLevelCompletion()
        {
            if (sourceLevelCompletion != null)
                throw new InvalidOperationException(
                    "The actual source Level completion policy is already constructed.");
            sourceLevelCompletion = SourceProfile == GameProfile.InstalledEverest
                ? new global::Celeste.Everest.Runtime.Levels.Completion.EverestLevelCompletionPolicy()
                : new OriginalLevelCompletionPolicy();
        }
    }
}
