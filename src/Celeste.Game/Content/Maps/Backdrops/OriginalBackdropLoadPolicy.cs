using Celeste.Formats.Map.Binary.Source;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Game.Content.Maps.Backdrops
{
    public sealed class OriginalBackdropLoadPolicy : IOriginalBackdropLoadPolicy
    {
        public BackdropPresentation LoadCustomBackdrop(BinaryPackerElement child, BinaryPackerElement above,
            OriginalChapterMapData map)
        {
            return null;
        }
    }
}
