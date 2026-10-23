using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles
{
    public static class FinalBossBeamDrawing
    {
        public static void Render<TState>(TState state, ISourceRenderContext ctx)
            where TState : struct, IFinalBossBeamDrawingState
        {
            var beamOrigin = state.BeamOrigin;
            var vector = Vector2Geometry.AngleToVector(state.Angle, state.BeamSprite.Width);
            state.BeamSprite.Rotation = state.Angle;
            state.BeamSprite.Color = PackedColor.White * state.BeamAlpha;
            state.StartSprite.Rotation = state.Angle;
            state.StartSprite.Color = PackedColor.White * state.BeamAlpha;
            if (state.BeamSprite.CurrentAnimationID == "shoot")
                beamOrigin += Vector2Geometry.AngleToVector(state.Angle, 8f);
            for (int i = 0; i < 15; i++)
            {
                state.BeamSprite.RenderPosition = beamOrigin;
                state.BeamSprite.Render(ctx);
                beamOrigin += vector;
            }

            if (state.BeamSprite.CurrentAnimationID == "shoot")
            {
                state.StartSprite.RenderPosition = state.BeamOrigin;
                state.StartSprite.Render(ctx);
            }

            ctx.EndBatch();
            Vector2 vector2 = state.VectorArithmetic.SafeNormalize(vector);
            Vector2 vector3 = new Vector2(0f - vector2.Y, vector2.X);
            PackedColor color = PackedColor.Black * state.SideFadeAlpha * .35f;
            PackedColor transparent = PackedColor.Transparent;
            vector2 *= 4000f;
            vector3 *= 120f;
            int v = 0;
            Quad(state, ref v, beamOrigin, -vector2 + vector3 * 2f, vector2 + vector3 * 2f, vector2 + vector3,
                -vector2 + vector3, color, color);
            Quad(state, ref v, beamOrigin, -vector2 + vector3, vector2 + vector3, vector2, -vector2, color,
                transparent);
            Quad(state, ref v, beamOrigin, -vector2, vector2, vector2 - vector3, -vector2 - vector3, transparent,
                color);
            Quad(state, ref v, beamOrigin, -vector2 - vector3, vector2 - vector3, vector2 - vector3 * 2f,
                -vector2 - vector3 * 2f, color, color);
            Celeste.Graphics.Rendering.Primitives.SourcePrimitiveGraphics.DrawVertices(
                ((Celeste.Graphics.Rendering.Primitives.ISourcePrimitiveGraphicsEnvironment)state.EngineContext)
                .PrimitiveGraphics,
                ((ISourceCameraScene)state.Scene).Camera.Matrix, state.Fade, state.Fade.Length);
            ((global::Celeste.Graphics.Rendering.ISourceGameplayBatchScopeEnvironment)state.EngineContext)
                .GameplayBatchScope.Begin(ctx);
        }

        private static void Quad<TState>(TState state, ref int v, Vector2 offset, Vector2 a, Vector2 b, Vector2 c,
            Vector2 d, PackedColor ab,
            PackedColor cd)
            where TState : struct, IFinalBossBeamDrawingState
        {
            state.Fade[v].Position.X = offset.X + a.X;
            state.Fade[v].Position.Y = offset.Y + a.Y;
            state.Fade[v++].Color = ab;
            state.Fade[v].Position.X = offset.X + b.X;
            state.Fade[v].Position.Y = offset.Y + b.Y;
            state.Fade[v++].Color = ab;
            state.Fade[v].Position.X = offset.X + c.X;
            state.Fade[v].Position.Y = offset.Y + c.Y;
            state.Fade[v++].Color = cd;
            state.Fade[v].Position.X = offset.X + a.X;
            state.Fade[v].Position.Y = offset.Y + a.Y;
            state.Fade[v++].Color = ab;
            state.Fade[v].Position.X = offset.X + c.X;
            state.Fade[v].Position.Y = offset.Y + c.Y;
            state.Fade[v++].Color = cd;
            state.Fade[v].Position.X = offset.X + d.X;
            state.Fade[v].Position.Y = offset.Y + d.Y;
            state.Fade[v++].Color = cd;
        }
    }
}
