using System;
using Celeste.Everest.Presentation.Effects.Trails;
using Celeste.Game.Profiles;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceTrailConstructionEnvironment
    {
        private ISourceTrailConstruction sourceTrailConstruction;

        public ISourceTrailConstruction TrailConstruction => sourceTrailConstruction ??
                                                             throw new InvalidOperationException(
                                                                 "The actual trail construction policy has not been constructed.");

        internal void ConstructSourceTrailConstructionPolicy()
        {
            if (sourceTrailConstruction != null)
                throw new InvalidOperationException("The actual trail construction policy is already constructed.");
            sourceTrailConstruction = SourceProfile switch
            {
                GameProfile.Original => new OriginalTrailConstruction(),
                GameProfile.InstalledEverest => new EverestTrailConstruction(),
                _ => throw new InvalidOperationException("A supported source profile is required.")
            };
        }
    }
}
