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
    public class OriginalCliffsideWindFlagState : SceneEntityState, ISourceEngineContextEntity
    {
        private readonly ISourceEngineContext engine;
        ISourceEngineContext ISourceEngineContextEntity.EngineContext => engine;

        private class Segment
        {
            public MTexture Texture;

            public Vector2 Offset;
        }

        private Segment[] segments;

        private float sine;

        private float random;

        private int sign;

        private float wind => ScalarMath.ClampedMap(Math.Abs((base.Scene as Level).Wind.X), 0f, 800f);

        public OriginalCliffsideWindFlagState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
            MTexture atlasSubtexturesAt =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.GetAtlasSubtexturesAt(
                    "scenery/cliffside/flag", EntityAttributeReader.Int(data.Values, "index"));
            segments = new Segment[atlasSubtexturesAt.FrameWidth];
            for (int i = 0; i < segments.Length; i++)
            {
                Segment segment = new Segment
                {
                    Texture = atlasSubtexturesAt.GetSubtexture(i, 0, 1, atlasSubtexturesAt.FrameHeight),
                    Offset = new Vector2(i, 0f)
                };
                segments[i] = segment;
            }

            sine = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, (float)Math.PI * 2f);
            random = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random);
            base.Depth = 8999;
            base.Tags = ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            sign = 1;
            if (wind != 0f)
            {
                sign = Math.Sign((base.Scene as Level).Wind.X);
            }

            for (int i = 0; i < segments.Length; i++)
            {
                SetFlagSegmentPosition(i, snap: true);
            }
        }

        public override void Update()
        {
            base.Update();
            if (wind != 0f)
            {
                sign = Math.Sign((base.Scene as Level).Wind.X);
            }

            sine += engine.DeltaTime * (4f + wind * 4f) * (0.8f + random * 0.2f);
            for (int i = 0; i < segments.Length; i++)
            {
                SetFlagSegmentPosition(i, snap: false);
            }
        }

        private float Sin(float timer)
        {
            return (float)Math.Sin(0f - timer);
        }

        private void SetFlagSegmentPosition(int i, bool snap)
        {
            Segment segment = segments[i];
            float value = (float)(i * sign) * (0.2f + wind * 0.8f * (0.8f + random * 0.2f)) * (0.9f + Sin(sine) * 0.1f);
            float num = ScalarMath.LerpClamp(
                Sin(sine * 0.5f - (float)i * 0.1f) * ((float)i / (float)segments.Length) * (float)i * 0.2f, value,
                (float)Math.Ceiling(wind), ((ISourceScalarEnvironment)engine).ScalarArithmetic);
            float num2 = (float)i / (float)segments.Length *
                         ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(0.1f, 1f - wind) * 16f;
            if (!snap)
            {
                segment.Offset.X = ScalarMath.Approach(segment.Offset.X, num, engine.DeltaTime * 40f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                segment.Offset.Y = ScalarMath.Approach(segment.Offset.Y, num2, engine.DeltaTime * 40f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }
            else
            {
                segment.Offset.X = num;
                segment.Offset.Y = num2;
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            base.Render(context);
            for (int i = 0; i < segments.Length; i++)
            {
                Segment segment = segments[i];
                float num = (float)i / (float)segments.Length * Sin((float)(-i) * 0.1f + sine) * 2f;
                SourceAtlasDrawing.Draw(context, this, segment.Texture,
                    Position + segment.Offset + Vector2.UnitY * num);
            }
        }
    }
}
