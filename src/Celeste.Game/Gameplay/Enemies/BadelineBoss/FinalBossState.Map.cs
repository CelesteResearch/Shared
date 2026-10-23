using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Progression;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss
{
    public partial class FinalBossState
    {
        public FinalBossState(EntityData data, Vector2 offset,
            FinalBossProgressionPolicy progression, ISourceEngineContext engine)
            : this(data.Position + offset, data.NodesOffset(offset),
                EntityAttributeReader.Int(data.Values, "patternIndex"), progression, engine,
                EntityAttributeReader.Float(data.Values, "cameraPastY", 120f),
                EntityAttributeReader.Bool(data.Values, "dialog"),
                EntityAttributeReader.Bool(data.Values, "startHit"),
                EntityAttributeReader.Bool(data.Values, "cameraLockY", true))
        {
            progression.ApplyMapAttributes(this, data);
        }
    }
}
