using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Graphics.Display;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession : global::Celeste.Core.Components.ISourceEntityRender,
        global::Celeste.Core.Components.ISourceEntityVisibility
    {
        bool global::Celeste.Core.Components.ISourceEntityVisibility.Visible => Visible;

        public readonly global::Celeste.Simulation.Presentation.Effects.Mirrors.MirrorReflectionState Reflection =
            new global::Celeste.Simulation.Presentation.Effects.Mirrors.MirrorReflectionState();

        public override void Render(ISourceRenderContext ctx)
        {
            if (InvisibleMotionActive) return;
            Vector2 renderPosition = Sprite.RenderPosition;
            Sprite.RenderPosition = global::Celeste.Core.Mathematics.Vector2Geometry.Floor(Sprite.RenderPosition);
            if (Machine.State == 14)
            {
                global::Celeste.Simulation.Presentation.Player.Death.DeathEffect.Draw(ctx, Center + Respawn.DeadOffset,
                    Hair.Color, Respawn.IntroEase, this, engineContext);
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
                if (Sweat.LastAnimationID == "idle") Sweat.Scale = Sprite.Scale;
                else
                {
                    Sweat.Scale.Y = Sprite.Scale.Y;
                    Sweat.Scale.X = Math.Abs(Sprite.Scale.X) * Math.Sign(Sweat.Scale.X);
                }

                base.Render(ctx);
                if (Sprite.CurrentAnimationID == "startStarFly")
                {
                    float fade = (float)Sprite.CurrentAnimationFrame / Sprite.CurrentAnimationTotalFrames;
                    var texture = ((global::Celeste.Graphics.Rendering.ISourceGameAtlasRenderContext)ctx).GameAtlas
                        .GetAtlasSubtexturesAt("characters/player/startStarFlyWhite", Sprite.CurrentAnimationFrame);
                    PackedColor color = starFlyColor * fade;
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
