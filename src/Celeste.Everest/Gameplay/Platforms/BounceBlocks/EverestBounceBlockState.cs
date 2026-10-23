using System.Numerics;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.BounceBlock;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Everest.Gameplay.Platforms.BounceBlocks
{
    public sealed class EverestBounceBlockState : BounceBlockState
    {
        private readonly bool notCoreMode;

        public EverestBounceBlockState(EntityData data, Vector2 offset, ISourceSolidWorldFactory worlds)
            : base(data.Position + offset, data.Width, data.Height, worlds.Create(data.Position + offset, false))
        {
            notCoreMode = EntityAttributeReader.Bool(data.Values, "notCoreMode");
        }

        protected override bool InitialIceMode => base.InitialIceMode || notCoreMode;
    }
}
