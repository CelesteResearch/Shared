using System;
using Celeste.Core.Threading;
using Celeste.Game.Presentation.Lighting;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalLightingRendererEnvironment
    {
        private SourceTypeInitialization<LightingRendererProcessState> sourceLightingRendererProcess;

        LightingRendererProcessState IOriginalLightingRendererEnvironment.LightingRendererProcess =>
            (sourceLightingRendererProcess
             ?? throw new InvalidOperationException(
                 "The actual original lighting renderer type initialization is not bound.")).Value;

        internal void ConstructSourceLightingRendererProcessInitialization()
        {
            if (sourceLightingRendererProcess != null)
                throw new InvalidOperationException(
                    "The actual original lighting renderer type initialization is already bound.");
            sourceLightingRendererProcess = new SourceTypeInitialization<LightingRendererProcessState>(
                "Celeste.LightingRenderer", new OriginalLightingRendererProcessInitializationFactory());
        }
    }
}
