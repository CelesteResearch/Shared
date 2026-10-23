using System.Numerics;
using Celeste.Game.Gameplay.Platforms.BounceBlocks;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.BounceBlock;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Everest.Gameplay.Platforms.BounceBlocks
{
    public sealed class EverestBounceBlockConstructionPolicy : IOriginalBounceBlockConstructionPolicy
    {
        public BounceBlockState Create(EntityData data, Vector2 offset, ISourceSolidWorldFactory worlds)
            => new EverestBounceBlockState(data, offset, worlds);
    }
}
