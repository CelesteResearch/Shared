using System.Numerics;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Gameplay.Platforms.FallingBlocks
{
    public partial class OriginalFallingBlockState
    {
        public static OriginalFallingBlockState Create(OriginalLevelSceneRoot level, OriginalLevelEntityData entity,
            Vector2 offset)
        {
            var data = entity;
            var position = data.Position + offset;
            return new(position, EntityAttributeReader.Char(data.Values, "tiletype", '3'),
                data.Width, data.Height, false, EntityAttributeReader.Bool(data.Values, "behind"),
                EntityAttributeReader.Bool(data.Values, "climbFall", true),
                level.SolidWorldFactory.Create(position, false), level.EngineContext);
        }

        public static OriginalFallingBlockState CreateFinalBossBlock(OriginalLevelSceneRoot level,
            OriginalLevelEntityData entity, Vector2 offset)
        {
            var data = entity;
            var position = data.Position + offset;
            return new(position, 'g', data.Width, data.Height, true, false, false,
                level.SolidWorldFactory.Create(position, false), level.EngineContext);
        }
    }
}
