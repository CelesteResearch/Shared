using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Content;
using Celeste.Graphics.Effects.SpeedRings;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Scene.Entities;

namespace Celeste.Game.Presentation.Effects.SpeedRings
{
    public class OriginalSpeedRingState : SceneEntityState, ISourceSpeedRing
    {
        private int index;
        private float angle;
        private float lerp;
        private PackedColor color;
        private Vector2 normal;
        private readonly ISourceEngineContext engine;

        public OriginalSpeedRingState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
        }

        public OriginalSpeedRingState Init(Vector2 position, float angle, PackedColor color)
        {
            Position = position;
            this.angle = angle;
            this.color = color;
            lerp = 0f;
            normal = Vector2Geometry.AngleToVector(angle, 1f);
            return this;
        }

        ISourceSpeedRing ISourceSpeedRing.Init(Vector2 position, float angle, PackedColor color)
        {
            return Init(position, angle, color);
        }

        public override void Update()
        {
            lerp += 3f * engine.Frame.DeltaTime;
            Position += normal * 10f * engine.Frame.DeltaTime;
            if (lerp >= 1f) RemoveSelf();
        }

        public override void Render(ISourceRenderContext context)
        {
            var color = this.color * ((ISourceScalarEnvironment)engine).ScalarArithmetic.Lerp(.6f, 0f, lerp);
            if (color.A > 0)
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(
                    ((ISourceSpeedRingBufferResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).SpeedRings
                    .Target,
                    Position + new Vector2(-32f, -32f),
                    new IntRect(index % 4 * 64, index / 4 * 64, 64, 64), color.PackedValue);
        }

        private void DrawRing(ISourceRenderContext context, Vector2 position)
        {
            var maxRadius = ((ISourceScalarEnvironment)engine).ScalarArithmetic.Lerp(4f, 14f, lerp);
            var vector = GetVectorAtAngle(0f, maxRadius);
            for (var i = 1; i <= 8; i++)
            {
                var radians = i * ((float)Math.PI / 8f);
                var vectorAtAngle = GetVectorAtAngle(radians, maxRadius);
                SourcePrimitiveDrawing.Line(context, this, position + vector, position + vectorAtAngle,
                    PackedColor.White, ((ISourceVectorEnvironment)engine).VectorArithmetic);
                SourcePrimitiveDrawing.Line(context, this, position - vector, position - vectorAtAngle,
                    PackedColor.White, ((ISourceVectorEnvironment)engine).VectorArithmetic);
                vector = vectorAtAngle;
            }
        }

        private Vector2 GetVectorAtAngle(float radians, float maxRadius)
        {
            var vector = Vector2Geometry.AngleToVector(radians, 1f);
            var radius = ((ISourceScalarEnvironment)engine).ScalarArithmetic.Lerp(maxRadius, maxRadius * .5f,
                Math.Abs(((ISourceVectorEnvironment)engine).VectorArithmetic.Dot(vector, normal)));
            return vector * radius;
        }

        public static void DrawToBuffer(OriginalLevelSceneRoot level)
        {
            var entities = level.Scheduler.Entities.GetTrackedEntities("Celeste.SpeedRing");
            var number = 0;
            if (entities.Count <= 0) return;
            var engine = level.EngineContext;
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(
                ((ISourceSpeedRingBufferResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).SpeedRings
                .Target);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Transparent);
            ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend, SourceSamplerState.PointClamp, SourceDepthStencilState.None,
                SourceRasterizerState.CullNone);
            foreach (OriginalSpeedRingState ring in entities)
            {
                ring.index = number;
                ring.DrawRing(((ISourceRenderEnvironment)engine).CurrentContext,
                    new(number % 4 * 64 + 32, number / 4 * 64 + 32));
                number++;
            }

            ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
        }

        public static OriginalSpeedRingState Create(ISourceEngineContext engine)
        {
            return engine.EntityPools.Create<OriginalSpeedRingState>();
        }
    }
}
