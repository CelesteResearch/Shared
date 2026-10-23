using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Content;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Color = Celeste.Core.Display.PackedColor;
using MTexture = Celeste.Graphics.Content.Atlas.AtlasEntry;
using Level = Celeste.Game.Execution.Levels.OriginalLevelSceneRoot;

namespace Celeste.Game.Gameplay.Environment.Ridge
{
    public class OriginalLightBeamState : SceneEntityState, ISourceEngineContextEntity
    {
        private readonly ISourceEngineContext engine;
        ISourceEngineContext ISourceEngineContextEntity.EngineContext => engine;


        private readonly MTexture texture;

        protected Color BeamColor { get; set; }

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        protected float BeamAlpha => alpha;
        protected virtual bool FadeWhenNear => true;

        protected virtual bool ShouldEmitGlow(Level level)
        {
            return true;
        }

        protected virtual void EmitGlow(Level level, Vector2 position, float rotation)
        {
            level.Particles.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.LightBeam.P_Glow, position,
                rotation);
        }

        private float alpha;

        public int LightWidth;

        public int LightLength;

        public float Rotation;

        public string Flag;

        private float timer;

        public OriginalLightBeamState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(data, offset, engine,
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["util/lightbeam"],
                new(0.8f, 1f, 1f),
                SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 1000f))
        {
        }

        protected OriginalLightBeamState(EntityData data, Vector2 offset,
            ISourceEngineContext engine, MTexture initialTexture, Color initialColor, float initialTimer)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
            texture = initialTexture;
            BeamColor = initialColor;
            timer = initialTimer;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value;
            Depth = -9998;
            LightWidth = data.Width;
            LightLength = data.Height;
            Flag = EntityAttributeReader.Attr(data.Values, "flag");
            Rotation = EntityAttributeReader.Float(data.Values, "rotation") * ((float)Math.PI / 180f);
        }

        public override void Update()
        {
            timer += engine.DeltaTime;
            var level = Scene as Level;
            var entity =
                ((Level)Scene).Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            if (entity != null && (string.IsNullOrEmpty(Flag) || level.Session.GetFlag(Flag)))
            {
                var vector = Vector2Geometry.AngleToVector(Rotation + (float)Math.PI / 2f, 1f);
                var vector2 =
                    ((ISourceVectorEnvironment)engine).VectorArithmetic.ClosestPointOnLine(Position,
                        Position + vector * 10000f, entity.Center);
                var target = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(1f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(0f,
                        ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(vector2 - Position) - 8f) /
                    LightLength);
                if (((ISourceVectorEnvironment)engine).VectorArithmetic.Length(vector2 - entity.Center) >
                    LightWidth / 2f || !FadeWhenNear)
                    target = 1f;

                if (level.Transitioning) target = 0f;

                alpha = ScalarMath.Approach(BeamAlpha, target, engine.DeltaTime * 4f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }

            if (BeamAlpha >= 0.5f && level.OnInterval(0.8f) && ShouldEmitGlow(level))
            {
                var vector3 = Vector2Geometry.AngleToVector(Rotation + (float)Math.PI / 2f, 1f);
                var position = Position - vector3 * 4f;
                float num = ((ISourceRandomEnvironment)engine).Random.Next(LightWidth - 4) + 2 - LightWidth / 2;
                position += num * Vector2Geometry.Perpendicular(vector3);
                EmitGlow(level, position, Rotation + (float)Math.PI / 2f);
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (BeamAlpha > 0f)
            {
                DrawTexture(context, 0f, LightWidth, LightLength - 4 + (float)Math.Sin(timer * 2f) * 4f, 0.4f);
                for (var i = 0; i < LightWidth; i += 4)
                {
                    var num = timer + i * 0.6f;
                    var num2 = 4f + (float)Math.Sin(num * 0.5f + 1.2f) * 4f;
                    var offset =
                        (float)Math.Sin((num + i * 32) * 0.1f +
                                        Math.Sin(num * 0.05f + i * 0.1f) * 0.25) *
                        (LightWidth / 2f - num2 / 2f);
                    var length = LightLength + (float)Math.Sin(num * 0.25f) * 8f;
                    var a = 0.6f + (float)Math.Sin(num + 0.8f) * 0.3f;
                    DrawTexture(context, offset, num2, length, a);
                }
            }
        }

        private void DrawTexture(ISourceRenderContext context, float offset, float width, float length, float a)
        {
            var rotation = Rotation + (float)Math.PI / 2f;
            if (width >= 1f)
                SourceAtlasDrawing.Draw(context, this, texture,
                    Position + Vector2Geometry.AngleToVector(Rotation, 1f) * offset, new(0f, 0.5f),
                    BeamColor * a * BeamAlpha, new Vector2(1f / texture.FrameWidth * length, width), rotation);
        }
    }
}
