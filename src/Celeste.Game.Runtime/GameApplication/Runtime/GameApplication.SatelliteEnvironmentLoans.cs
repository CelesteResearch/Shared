using System;
using Celeste.Core.Threading;
using Celeste.Game.Entities.Puzzles.ForsakenSatellite;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalSatelliteEnvironment
    {
        private SourceTypeInitialization<OriginalSatelliteProcessState> sourceSatelliteProcess;

        public OriginalSatelliteProcessState SatelliteProcess => (sourceSatelliteProcess ??
                                                                  throw new InvalidOperationException(
                                                                      "The actual Satellite type initialization descriptor has not been constructed."))
            .Value;

        internal void ConstructSourceSatelliteTypeInitialization()
        {
            if (sourceSatelliteProcess != null)
                throw new InvalidOperationException(
                    "The actual Satellite type initialization descriptor is already constructed.");
            sourceSatelliteProcess = new(
                "Celeste.ForsakenCitySatellite", new SatelliteSourceTypeInitialization(SourceProfile));
        }

        private sealed class
            SatelliteSourceTypeInitialization : ISourceTypeInitializationFactory<OriginalSatelliteProcessState>
        {
            private readonly GameProfile profile;

            public SatelliteSourceTypeInitialization(GameProfile profile)
            {
                this.profile = profile;
            }

            public OriginalSatelliteProcessState Allocate()
            {
                return profile switch
                {
                    GameProfile.Original => new(),
                    GameProfile.InstalledEverest => new(),
                    _ => throw new InvalidOperationException("A supported source profile is required."),
                };
            }

            // Complete field initializers execute in the existing constructor; no later initializer body.
            public void Initialize(OriginalSatelliteProcessState instance)
            {
            }
        }
    }
}
