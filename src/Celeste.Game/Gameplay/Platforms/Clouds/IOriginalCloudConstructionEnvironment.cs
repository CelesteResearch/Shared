using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Gameplay.Platforms.Clouds
{
    public interface IOriginalCloudConstructionEnvironment
    {
        IOriginalCloudConstructionPolicy CloudConstruction { get; }
    }
}
