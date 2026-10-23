using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Components.Oscillation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Display.Colors;
using Color = Celeste.Core.Display.PackedColor;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Environment.Water;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Physics.Collision.Shapes;
using Celeste.Simulation.Audio.Sources;
using Image = Celeste.Graphics.Animation.SpriteImage;
using MTexture = Celeste.Graphics.Content.Atlas.AtlasEntry;
using SineWave = Celeste.Scene.Components.Oscillation.SineWaveState;
using BloomPoint = Celeste.Simulation.Presentation.PostProcessing.Bloom.BloomPointState;
using VertexLight = Celeste.Simulation.Presentation.Lighting.VertexLightState;
using Hitbox = Celeste.Physics.Collision.Shapes.HitboxColliderGeometry;
using SoundSource = Celeste.Simulation.Audio.Sources.SoundSourceComponentState;
using Player = Celeste.Simulation.RoomPlayerSession;
using Level = Celeste.Game.Execution.Levels.OriginalLevelSceneRoot;

namespace Celeste.Game.Gameplay.Environment.Ridge
{
    public class OriginalLightBeamState : SceneEntityState, ISourceEngineContextEntity
    {
        private readonly ISourceEngineContext engine;
        ISourceEngineContext ISourceEngineContextEntity.EngineContext => engine;


        private MTexture texture;

        private Color color;

        protected Color BeamColor
        {
            get => color;
            set => color = value;
        }

        protected float BeamAlpha => alpha;

        protected virtual bool FadeWhenNear => true;

        protected virtual bool ShouldEmitGlow(Level level) => true;

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
                new Color(0.8f, 1f, 1f),
                SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 1000f))
        {
        }

        protected OriginalLightBeamState(EntityData data, Vector2 offset,
            ISourceEngineContext engine, MTexture initialTexture, Color initialColor, float initialTimer)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
            texture = initialTexture;
            color = initialColor;
            timer = initialTimer;
            base.Tags = ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value;
            base.Depth = -9998;
            LightWidth = data.Width;
            LightLength = data.Height;
            Flag = EntityAttributeReader.Attr(data.Values, "flag");
            Rotation = EntityAttributeReader.Float(data.Values, "rotation") * ((float)Math.PI / 180f);
        }

        public override void Update()
        {
            timer += engine.DeltaTime;
            Level level = base.Scene as Level;
            global::Celeste.Simulation.RoomPlayerSession entity =
                ((Level)Scene).Scheduler.Entities.GetTrackedEntity<global::Celeste.Simulation.RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            if (entity != null && (string.IsNullOrEmpty(Flag) || level.Session.GetFlag(Flag)))
            {
                Vector2 vector = Vector2Geometry.AngleToVector(Rotation + (float)Math.PI / 2f, 1f);
                Vector2 vector2 =
                    ((ISourceVectorEnvironment)engine).VectorArithmetic.ClosestPointOnLine(Position,
                        Position + vector * 10000f, entity.Center);
                float target = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(1f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(0f,
                        ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(vector2 - Position) - 8f) /
                    (float)LightLength);
                if (((ISourceVectorEnvironment)engine).VectorArithmetic.Length(vector2 - entity.Center) >
                    (float)LightWidth / 2f || !FadeWhenNear)
                {
                    target = 1f;
                }

                if (level.Transitioning)
                {
                    target = 0f;
                }

                alpha = ScalarMath.Approach(alpha, target, engine.DeltaTime * 4f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }

            if (alpha >= 0.5f && level.OnInterval(0.8f) && ShouldEmitGlow(level))
            {
                Vector2 vector3 = Vector2Geometry.AngleToVector(Rotation + (float)Math.PI / 2f, 1f);
                Vector2 position = Position - vector3 * 4f;
                float num = ((ISourceRandomEnvironment)engine).Random.Next(LightWidth - 4) + 2 - LightWidth / 2;
                position += num * Vector2Geometry.Perpendicular(vector3);
                EmitGlow(level, position, Rotation + (float)Math.PI / 2f);
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (alpha > 0f)
            {
                DrawTexture(context, 0f, LightWidth, (float)(LightLength - 4) + (float)Math.Sin(timer * 2f) * 4f, 0.4f);
                for (int i = 0; i < LightWidth; i += 4)
                {
                    float num = timer + (float)i * 0.6f;
                    float num2 = 4f + (float)Math.Sin(num * 0.5f + 1.2f) * 4f;
                    float offset =
                        (float)Math.Sin((double)((num + (float)(i * 32)) * 0.1f) +
                                        Math.Sin(num * 0.05f + (float)i * 0.1f) * 0.25) *
                        ((float)LightWidth / 2f - num2 / 2f);
                    float length = (float)LightLength + (float)Math.Sin(num * 0.25f) * 8f;
                    float a = 0.6f + (float)Math.Sin(num + 0.8f) * 0.3f;
                    DrawTexture(context, offset, num2, length, a);
                }
            }
        }

        private void DrawTexture(ISourceRenderContext context, float offset, float width, float length, float a)
        {
            float rotation = Rotation + (float)Math.PI / 2f;
            if (width >= 1f)
            {
                SourceAtlasDrawing.Draw(context, this, texture,
                    Position + Vector2Geometry.AngleToVector(Rotation, 1f) * offset, new Vector2(0f, 0.5f),
                    color * a * alpha, new Vector2(1f / (float)texture.FrameWidth * length, width), rotation);
            }
        }
    }
}
