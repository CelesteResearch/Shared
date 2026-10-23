using Celeste.Core.Randomness;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Simulation.Presentation.Decals.Entities
{
    public sealed class SourceDecalBannerComponent : SourceDecalImageComponentBase
    {
        public float WaveSpeed, WaveAmplitude, SliceSinIncrement, Offset;
        public int SliceSize;
        public bool EaseDown, OnlyIfWindy;
        public float WindMultiplier = 1f;
        private float sineTimer;
        public readonly List<List<AtlasEntry>> Segments = new List<List<AtlasEntry>>();
        public SourceDecalBannerComponent(ISourceRandom random) : base(true) => sineTimer = (float)random.NextDouble();

        public override void Update()
        {
            float deltaTime = Decal.EngineContext.DeltaTime;
            if (OnlyIfWindy)
            {
                float x = ((ISourceDecalEnvironment)Scene).WindX;
                var extrema = ((Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)Decal.EngineContext)
                    .ExtremaArithmetic;
                float target = extrema.Min(3f, Math.Abs(x) * .004f);
                WindMultiplier = ScalarMath.Approach(WindMultiplier, target, deltaTime * 4f, extrema);
                if (x != 0f) Offset = Math.Sign(x) * Math.Abs(Offset);
            }

            sineTimer += deltaTime * WindMultiplier;
            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            var texture = Decal.Textures[(int)Decal.Frame];
            var segments = Segments[(int)Decal.Frame];
            for (int i = 0; i < segments.Count; i++)
            {
                float factor = (EaseDown ? (float)i / segments.Count : 1f - (float)i / segments.Count) * WindMultiplier;
                float x = (float)(Math.Sin(sineTimer * WaveSpeed + i * SliceSinIncrement) * factor * WaveAmplitude +
                                  factor * Offset);
                Draw(context, segments[i],
                    Decal.Position +
                    ((Celeste.Core.Mathematics.ISourceVectorEnvironment)Decal.EngineContext).VectorArithmetic.Rotate(
                        new Vector2(x, 0f), Decal.Rotation),
                    new Vector2(texture.FrameWidth / 2, texture.FrameHeight / 2 - i * SliceSize), Decal.Rotation);
            }
        }
    }
}
