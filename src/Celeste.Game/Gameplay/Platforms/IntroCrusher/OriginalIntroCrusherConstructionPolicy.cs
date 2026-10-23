using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

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
        {
            return new(engine, data, offset, world);
        }
    }
}
