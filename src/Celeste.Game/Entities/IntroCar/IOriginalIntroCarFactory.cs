using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Entities.IntroCar
{
    public interface IOriginalIntroCarFactory
    {
        OriginalIntroCarState Create(ISourceEngineContext engine, ISourceSolidWorldFactory worlds,
            EntityData data, Vector2 offset);
    }
}
