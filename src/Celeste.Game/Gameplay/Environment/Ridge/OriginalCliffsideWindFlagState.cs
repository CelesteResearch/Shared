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
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Content;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;
using MTexture = Celeste.Graphics.Content.Atlas.AtlasEntry;
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

        private readonly Segment[] segments;

        private float sine;

        private readonly float random;

        private int sign;

        private float wind => ScalarMath.ClampedMap(Math.Abs((Scene as Level).Wind.X), 0f, 800f);

        public OriginalCliffsideWindFlagState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
            var atlasSubtexturesAt =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.GetAtlasSubtexturesAt(
                    "scenery/cliffside/flag", EntityAttributeReader.Int(data.Values, "index"));
            segments = new Segment[atlasSubtexturesAt.FrameWidth];
            for (var i = 0; i < segments.Length; i++)
            {
                var segment = new Segment
                {
                    Texture = atlasSubtexturesAt.GetSubtexture(i, 0, 1, atlasSubtexturesAt.FrameHeight),
                    Offset = new(i, 0f),
                };
                segments[i] = segment;
            }

            sine = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, (float)Math.PI * 2f);
            random = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random);
            Depth = 8999;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            sign = 1;
            if (wind != 0f) sign = Math.Sign((Scene as Level).Wind.X);

            for (var i = 0; i < segments.Length; i++) SetFlagSegmentPosition(i, true);
        }

        public override void Update()
        {
            base.Update();
            if (wind != 0f) sign = Math.Sign((Scene as Level).Wind.X);

            sine += engine.DeltaTime * (4f + wind * 4f) * (0.8f + random * 0.2f);
            for (var i = 0; i < segments.Length; i++) SetFlagSegmentPosition(i, false);
        }

        private float Sin(float timer)
        {
            return (float)Math.Sin(0f - timer);
        }

        private void SetFlagSegmentPosition(int i, bool snap)
        {
            var segment = segments[i];
            var value = i * sign * (0.2f + wind * 0.8f * (0.8f + random * 0.2f)) * (0.9f + Sin(sine) * 0.1f);
            var num = ScalarMath.LerpClamp(
                Sin(sine * 0.5f - i * 0.1f) * (i / (float)segments.Length) * i * 0.2f, value,
                (float)Math.Ceiling(wind), ((ISourceScalarEnvironment)engine).ScalarArithmetic);
            var num2 = i / (float)segments.Length *
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
            for (var i = 0; i < segments.Length; i++)
            {
                var segment = segments[i];
                var num = i / (float)segments.Length * Sin(-i * 0.1f + sine) * 2f;
                SourceAtlasDrawing.Draw(context, this, segment.Texture,
                    Position + segment.Offset + Vector2.UnitY * num);
            }
        }
    }
}
