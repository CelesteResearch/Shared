using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Game.Gameplay.Platforms.IntroCrusher;

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
            => new EverestIntroCrusherState(engine, data, offset, world);
    }
}
