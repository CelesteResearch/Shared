using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Gameplay.Platforms.IntroCrusher;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Everest.Gameplay.Platforms.IntroCrusher
{
    public sealed class EverestIntroCrusherConstructionPolicy : IOriginalIntroCrusherConstructionPolicy
    {
        public static readonly EverestIntroCrusherConstructionPolicy Instance = new();

        private EverestIntroCrusherConstructionPolicy()
        {
        }

        public OriginalIntroCrusherState Create(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world)
        {
            return new EverestIntroCrusherState(engine, data, offset, world);
        }
    }
}
