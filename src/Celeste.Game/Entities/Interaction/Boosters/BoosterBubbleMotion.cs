using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;

namespace Celeste.Game.Entities.Interaction.Boosters
{
    public static class BoosterBubbleMotion
    {
        public static bool AdvanceCooldowns(ISourceEngineContext engine, ref float cannotUseTimer,
            ref float respawnTimer)
        {
            if (cannotUseTimer > 0f) cannotUseTimer -= engine.DeltaTime;
            if (respawnTimer > 0f)
            {
                respawnTimer -= engine.DeltaTime;
                return respawnTimer <= 0f;
            }

            return false;
        }

        public static void ApproachSprite(ISourceEngineContext engine, Sprite sprite, Vector2 target)
        {
            sprite.Position = ((ISourceVectorEnvironment)engine).VectorArithmetic.Approach(sprite.Position, target,
                80f * engine.DeltaTime);
        }

        public static Vector2 BeginRender(Sprite sprite, ISourceRenderContext context)
        {
            var position = sprite.Position;
            sprite.Position = new((float)Math.Floor(position.X), (float)Math.Floor(position.Y));
            if (sprite.CurrentAnimationID != "pop" && sprite.Visible) sprite.DrawOutline(context);
            return position;
        }

        public static void EndRender(Sprite sprite, Vector2 position)
        {
            sprite.Position = position;
        }
    }
}
