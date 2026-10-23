using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.IntroCar;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Everest.Entities.IntroCar
{
    public sealed class EverestIntroCarFactory : IOriginalIntroCarFactory
    {
        public OriginalIntroCarState Create(ISourceEngineContext engine, ISourceSolidWorldFactory worlds,
            EntityData data, Vector2 offset)
        {
            return new EverestIntroCarState(engine, worlds, data, offset);
        }
    }
}
