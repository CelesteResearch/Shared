using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Entities.Doors.Ridge
{
    public interface IOriginalRidgeGateConstructionEnvironment
    {
        IOriginalRidgeGateConstructionPolicy RidgeGateConstruction { get; }
    }
}
