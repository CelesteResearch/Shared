using Celeste.Simulation.Presentation.Backdrops.Runtime;
using Celeste.Simulation.Presentation.Backdrops.Stars;

namespace Celeste.Game.Content.Maps.Backdrops
{
    internal static class OriginalStarfieldBackdropLayout
    {
        internal static StarfieldBackdropLayout Create(BackdropViewport viewport) =>
            new StarfieldBackdropLayout(viewport, nodeCount: 15, closingNodeCount: 4,
                nodeSpacing: 32f, nodeDriftMinimum: 16f, nodeDriftRange: 24f, verticalMargin: 16f);
    }
}
