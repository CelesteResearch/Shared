using Celeste.Simulation.Presentation.Backdrops.Runtime;
using Celeste.Simulation.Presentation.Backdrops.Stars;

namespace Celeste.Game.Content.Maps.Backdrops
{
    internal static class OriginalStarfieldBackdropLayout
    {
        internal static StarfieldBackdropLayout Create(BackdropViewport viewport)
        {
            return new(viewport, 15, 4,
                32f, 16f, 24f, 16f);
        }
    }
}
