using Celeste.Formats.Map.Binary.Source;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Game.Content.Maps.Backdrops
{
    public interface IOriginalBackdropLoadEnvironment
    {
        IOriginalBackdropLoadPolicy BackdropLoadPolicy { get; }
    }
}
