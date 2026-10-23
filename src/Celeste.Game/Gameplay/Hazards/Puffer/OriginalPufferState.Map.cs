using Celeste.Physics.Collision;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using System.Numerics;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Gameplay.Hazards.Puffer
{
    public partial class OriginalPufferState
    {
        public static OriginalPufferState Create(OriginalLevelSceneRoot level, OriginalLevelEntityData entity,
            Vector2 offset)
        {
            var data = entity;
            Vector2 position = data.Position + offset;
            bool faceRight = EntityAttributeReader.Bool(data.Values, "right");
            var engine = level.EngineContext;
            return new OriginalPufferState(
                new PixelActor(((ISourcePlatformCollisionScene)level).PlatformWorld, position),
                position, faceRight, engine,
                ((ISourcePlatformTargetMotionEnvironment)engine).TargetMotionPolicy);
        }
    }
}
