using System;
using Celeste.Game.Entities;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Profiles;
using Celeste.Scene.Scheduling;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalScenePolicyBirthEnvironment,
        ISourceSceneUpdatePolicyEnvironment
    {
        private SceneUpdatePolicy sourcePlainScenePolicy;
        private SceneUpdatePolicy sourceLevelScenePolicy;

        public SceneUpdatePolicy PlainScenePolicy => sourcePlainScenePolicy ??
                                                     throw new InvalidOperationException(
                                                         "The actual plain scene policy is not constructed.");

        public SceneUpdatePolicy LevelScenePolicy => sourceLevelScenePolicy ??
                                                     throw new InvalidOperationException(
                                                         "The actual level scene policy is not constructed.");

        internal void ConstructSourcePlainScenePolicy()
        {
            if (sourcePlainScenePolicy != null)
                throw new InvalidOperationException("The actual plain scene policy is already constructed.");
            sourcePlainScenePolicy =
                OriginalScenePolicy.CreatePlain(SourceProfile ==
                                                GameProfile.InstalledEverest);
        }

        public void ConstructSourceScenePolicies()
        {
            if (sourceLevelScenePolicy != null)
                throw new InvalidOperationException("The actual scene policies are already constructed.");
            if (sourcePlainScenePolicy == null)
                ConstructSourcePlainScenePolicy();
            sourceLevelScenePolicy = OriginalScenePolicy.CreateLevel(Tags,
                SourceProfile == GameProfile.InstalledEverest);
        }
    }
}
