using System;
using System.Collections.Generic;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
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
        public readonly List<List<AtlasEntry>> Segments = [];

        public SourceDecalBannerComponent(ISourceRandom random) : base(true)
        {
            sineTimer = (float)random.NextDouble();
        }

        public override void Update()
        {
            var deltaTime = Decal.EngineContext.DeltaTime;
            if (OnlyIfWindy)
            {
                var x = ((ISourceDecalEnvironment)Scene).WindX;
                var extrema = ((ISourceExtremaEnvironment)Decal.EngineContext)
                    .ExtremaArithmetic;
                var target = extrema.Min(3f, Math.Abs(x) * .004f);
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
            for (var i = 0; i < segments.Count; i++)
            {
                var factor = (EaseDown ? (float)i / segments.Count : 1f - (float)i / segments.Count) * WindMultiplier;
                var x = (float)(Math.Sin(sineTimer * WaveSpeed + i * SliceSinIncrement) * factor * WaveAmplitude +
                                factor * Offset);
                Draw(context, segments[i],
                    Decal.Position +
                    ((ISourceVectorEnvironment)Decal.EngineContext).VectorArithmetic.Rotate(
                        new(x, 0f), Decal.Rotation),
                    new(texture.FrameWidth / 2, texture.FrameHeight / 2 - i * SliceSize), Decal.Rotation);
            }
        }
    }
}
