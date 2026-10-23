using System.Numerics;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.BounceBlock;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Gameplay.Platforms.BounceBlocks
{
    public sealed class OriginalBounceBlockConstructionPolicy : IOriginalBounceBlockConstructionPolicy
    {
        public BounceBlockState Create(EntityData data, Vector2 offset, ISourceSolidWorldFactory worlds)
        {
            return new(data.Position + offset, data.Width, data.Height,
                worlds.Create(data.Position + offset, false));
        }
    }
}
