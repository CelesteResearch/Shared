using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.Platforms.Dream;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Everest.Gameplay.Platforms.Dream
{
    public class EverestDreamBlockState : OriginalDreamBlockState
    {
#pragma warning disable CS0169 // Preserve the actual Installed PE field; its CPU never reads or writes it.
        // ReSharper disable once UnusedMember.Local
        private int randomSeed;
#pragma warning restore CS0169

        internal Vector2 movementCounter { get; }

        public EverestDreamBlockState(ISourceEngineContext engine, Vector2 position, float width, float height,
            Vector2? node, bool fastMoving, bool oneUse, bool below, ISourceSolidWorldFactory worlds)
            : base(engine, position, width, height, node, fastMoving, oneUse, below, worlds)
        {
        }

        public EverestDreamBlockState(ISourceEngineContext engine, Vector2 position, float width, float height,
            Vector2? node, bool fastMoving, bool oneUse, ISourceSolidWorldFactory worlds)
            : this(engine, position, width, height, node, fastMoving, oneUse, false, worlds)
        {
        }

        public new static EverestDreamBlockState CreateFromMapData(EntityData data, Vector2 offset,
            OriginalLevelSceneRoot level)
            => new(level.EngineContext, data.Position + offset, data.Width, data.Height,
                data.FirstNodeNullable(offset), EntityAttributeReader.Bool(data.Values, "fastMoving"),
                EntityAttributeReader.Bool(data.Values, "oneUse"),
                EntityAttributeReader.Bool(data.Values, "below"), level.SolidWorldFactory);
    }
}
