using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Game.Content.Maps.Backdrops
{
    internal static class OriginalGodraysBackdropLayout
    {
        internal static OverscannedBackdropViewport Create(BackdropViewport canvas)
        {
            return new(canvas, 32);
        }
    }
}
