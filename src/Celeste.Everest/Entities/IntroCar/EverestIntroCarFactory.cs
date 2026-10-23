using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.IntroCar;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Graphics.Display;

namespace Celeste.Everest.Entities.IntroCar
{
    public sealed class EverestIntroCarFactory : IOriginalIntroCarFactory
    {
        public OriginalIntroCarState Create(ISourceEngineContext engine, ISourceSolidWorldFactory worlds,
            EntityData data, Vector2 offset)
            => new EverestIntroCarState(engine, worlds, data, offset);
    }
}
