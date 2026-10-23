using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Everest.Presentation.Hud
{
    public sealed class SubHudRendererProcessState
    {
        public VirtualRenderTarget Buffer;
        public readonly EverestSubHudRendererEvents Events = new();
    }
}
