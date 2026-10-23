using System.Numerics;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.BounceBlock;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Gameplay.Platforms.BounceBlocks
{
    public interface IOriginalBounceBlockConstructionPolicy
    {
        BounceBlockState Create(EntityData data, Vector2 offset, ISourceSolidWorldFactory worlds);
    }
}
