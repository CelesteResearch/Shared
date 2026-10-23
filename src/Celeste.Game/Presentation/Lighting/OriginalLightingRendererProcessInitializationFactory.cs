using Celeste.Core.Threading;

namespace Celeste.Game.Presentation.Lighting
{
    public sealed class
        OriginalLightingRendererProcessInitializationFactory : ISourceTypeInitializationFactory<
        LightingRendererProcessState>
    {
        public LightingRendererProcessState Allocate() => new LightingRendererProcessState();

        public void Initialize(LightingRendererProcessState instance)
        {
        }
    }
}
