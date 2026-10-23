using System;
using Celeste.Core.Settings.Lightning;
using Celeste.Everest.Gameplay.Hazards.Lightning;
using Celeste.Game.Gameplay.Hazards.Lightning;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceLightningFlashEnvironment
    {
        private ISourceLightningFlashPolicy sourceLightningFlashPolicy;

        public ISourceLightningFlashPolicy LightningFlashPolicy => sourceLightningFlashPolicy ??
                                                                   throw new InvalidOperationException(
                                                                       "The source Lightning flash policy is not selected.");

        public void ConstructSourceLightningFlashPolicy()
        {
            if (sourceLightningFlashPolicy != null)
                throw new InvalidOperationException("The source Lightning flash policy is already selected.");
            if (SourceProfile == GameProfile.Original)
                sourceLightningFlashPolicy = new OriginalLightningFlashPolicy(engine);
            else if (SourceProfile == GameProfile.InstalledEverest)
                sourceLightningFlashPolicy = new EverestLightningFlashPolicy(engine);
            else throw new InvalidOperationException("A supported source profile is required.");
        }
    }
}
