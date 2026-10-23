using System.Numerics;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Gameplay.Hazards.Puffer
{
    public partial class OriginalPufferState
    {
        public static OriginalPufferState Create(OriginalLevelSceneRoot level, OriginalLevelEntityData entity,
            Vector2 offset)
        {
            var data = entity;
            var position = data.Position + offset;
            var faceRight = EntityAttributeReader.Bool(data.Values, "right");
            var engine = level.EngineContext;
            return new(
                new(level.PlatformWorld, position),
                position, faceRight, engine,
                ((ISourcePlatformTargetMotionEnvironment)engine).TargetMotionPolicy);
        }
    }
}
