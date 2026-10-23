using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Entities.IntroCar
{
    public sealed class OriginalIntroCarFactory : IOriginalIntroCarFactory
    {
        public OriginalIntroCarState Create(ISourceEngineContext engine, ISourceSolidWorldFactory worlds,
            EntityData data, Vector2 offset)
            => new OriginalIntroCarState(engine, worlds, data, offset);
    }
}
