using System;
using Celeste.Everest.Gameplay.Platforms.Construction;
using Celeste.Game.Gameplay.Mechanisms.SwitchGates;
using Celeste.Game.Gameplay.Platforms.Construction;
using Celeste.Game.Gameplay.Platforms.Crumble;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalSwitchGateProcess,
        IOriginalCrumbleProcess, IOriginalCheckpointCloudCrumbleEnvironment
    {
        private IOriginalCheckpointCloudCrumbleFactory sourceCheckpointCloudCrumble;

        public IOriginalCheckpointCloudCrumbleFactory CheckpointCloudCrumbleFactory =>
            sourceCheckpointCloudCrumble ??
            throw new InvalidOperationException("The actual checkpoint/cloud/crumble construction is not constructed.");

        public void ConstructSourceCheckpointCloudCrumbleFactory()
        {
            if (sourceCheckpointCloudCrumble != null)
                throw new InvalidOperationException(
                    "The actual checkpoint/cloud/crumble construction is already constructed.");
            sourceCheckpointCloudCrumble = SourceProfile == GameProfile.Original
                ? new OriginalCheckpointCloudCrumbleFactory()
                : new EverestCheckpointCloudCrumbleFactory();
        }
    }
}
