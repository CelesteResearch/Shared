using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Game.Gameplay.Platforms.IntroCrusher;

namespace Celeste.Game.Gameplay.Platforms.IntroCrusher
{
    public sealed class OriginalIntroCrusherConstructionPolicy : IOriginalIntroCrusherConstructionPolicy
    {
        public static readonly OriginalIntroCrusherConstructionPolicy Instance = new();

        private OriginalIntroCrusherConstructionPolicy()
        {
        }

        public OriginalIntroCrusherState Create(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world)
            => new OriginalIntroCrusherState(engine, data, offset, world);
    }
}
