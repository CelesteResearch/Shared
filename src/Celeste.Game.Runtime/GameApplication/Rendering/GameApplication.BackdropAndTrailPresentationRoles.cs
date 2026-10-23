using System;
using Celeste.Core.Threading;
using Celeste.Game.Presentation.Backdrops.Rendering;
using Celeste.Game.Presentation.Effects.Trails;
using Celeste.Game.Profiles;
using Celeste.Simulation.Presentation.Backdrops.Rendering;
using Celeste.Graphics.Rendering.Trails;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceBackdropBeforeRenderEnvironment, ISourceTrailBlendEnvironment
    {
        private ISourceBackdropBeforeRenderPolicy sourceBackdropBeforeRender;
        private SourceTypeInitialization<TrailBlendProcessState> sourceTrailBlendInitialization;

        public ISourceBackdropBeforeRenderPolicy BackdropBeforeRender => sourceBackdropBeforeRender ??
                                                                         throw new InvalidOperationException(
                                                                             "The actual backdrop rendering policy has not been constructed.");

        public ISourceTrailBlendResources TrailBlends => (sourceTrailBlendInitialization ??
                                                          throw new InvalidOperationException(
                                                              "The actual trail blend type initialization has not been constructed."))
            .Value;

        internal void ConstructSourceBackdropAndTrailPresentationRoles()
        {
            if (sourceBackdropBeforeRender != null || sourceTrailBlendInitialization != null)
                throw new InvalidOperationException(
                    "The actual backdrop and trail presentation roles are already constructed.");
            sourceBackdropBeforeRender = SourceProfile switch
            {
                GameProfile.Original => new OriginalBackdropBeforeRenderPolicy(),
                GameProfile.InstalledEverest => new InstalledBackdropBeforeRenderPolicy(),
                _ => throw new InvalidOperationException("A supported source profile is required.")
            };
            sourceTrailBlendInitialization = new SourceTypeInitialization<TrailBlendProcessState>(
                "Celeste.TrailManager", new TrailBlendSourceTypeInitialization(this));
        }

        private sealed class TrailBlendSourceTypeInitialization(GameApplication process)
            : ISourceTypeInitializationFactory<TrailBlendProcessState>
        {
            public TrailBlendProcessState Allocate() => new(process);

            // MaxBlendState is fully initialized by the existing source field initializer.
            public void Initialize(TrailBlendProcessState instance)
            {
            }
        }
    }
}
