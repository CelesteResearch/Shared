using System;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Simulation.Presentation.Player.Death;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession : ISourceEntityRender,
        ISourceEntityVisibility
    {
        bool ISourceEntityVisibility.Visible => Visible;

        public readonly MirrorReflectionState Reflection = new();

        public override void Render(ISourceRenderContext ctx)
        {
            if (InvisibleMotionActive) return;
            var renderPosition = Sprite.RenderPosition;
            Sprite.RenderPosition = Vector2Geometry.Floor(Sprite.RenderPosition);
            if (Machine.State == 14)
            {
                DeathEffect.Draw(ctx, Center + Respawn.DeadOffset,
                    Hair.Color, Respawn.IntroEase, this, EngineContext);
            }
            else
            {
                if (Machine.State != 19) Sprite.Color = Data.IsTired && Flash ? PackedColor.Red : PackedColor.White;
                if (Reflection.IsRendering && FlipInReflection)
                {
                    Data.Facing = -Data.Facing;
                    Hair.Facing = Data.Facing;
                }

                Sprite.Scale.X *= Data.Facing;
                if (Sweat.LastAnimationID == "idle")
                {
                    Sweat.Scale = Sprite.Scale;
                }
                else
                {
                    Sweat.Scale.Y = Sprite.Scale.Y;
                    Sweat.Scale.X = Math.Abs(Sprite.Scale.X) * Math.Sign(Sweat.Scale.X);
                }

                base.Render(ctx);
                if (Sprite.CurrentAnimationID == "startStarFly")
                {
                    var fade = (float)Sprite.CurrentAnimationFrame / Sprite.CurrentAnimationTotalFrames;
                    var texture = ((ISourceGameAtlasRenderContext)ctx).GameAtlas
                        .GetAtlasSubtexturesAt("characters/player/startStarFlyWhite", Sprite.CurrentAnimationFrame);
                    var color = starFlyColor * fade;
                    var draw = new AtlasTextureDraw(texture, Sprite.RenderPosition, Sprite.Origin,
                        color, Sprite.Scale, Sprite.Rotation);
                    ((ISourceRenderCommandSink<AtlasTextureDraw>)ctx).Draw(in draw, this);
                }

                Sprite.Scale.X *= Data.Facing;
                if (Reflection.IsRendering && FlipInReflection)
                {
                    Data.Facing = -Data.Facing;
                    Hair.Facing = Data.Facing;
                }
            }

            Sprite.RenderPosition = renderPosition;
        }
    }
}
