using System.Collections.Generic;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Everest.Content.Maps.Backdrops
{
    public sealed class EverestBackdropLoaders
    {
        public delegate BackdropPresentation BackdropLoader(BinaryPackerElement data);

        public readonly Dictionary<string, BackdropLoader> BackdropLoaders = new Dictionary<string, BackdropLoader>();
    }
}
