using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Simulation.Presentation.Decals.Entities
{
    public sealed class SourceDecalFlagSwapComponent : SourceDecalImageComponentBase
    {
        private readonly string flag;
        private readonly List<AtlasEntry> off, on;
        private readonly int loopCount;
        private float frame;
        private List<AtlasEntry> ActiveTextures => ((ISourceDecalFlagScene)Scene).GetFlag(flag) ? on : off;

        public SourceDecalFlagSwapComponent(string flag, List<AtlasEntry> off, List<AtlasEntry> on) : base(true)
        {
            this.flag = flag;
            this.off = off;
            this.on = on;
            loopCount = Math.Max(off.Count, 1) * Math.Max(on.Count, 1);
        }

        public override void Update()
        {
            float deltaTime = Decal.EngineContext.DeltaTime;
            frame = (frame + Decal.AnimationSpeed * deltaTime) % loopCount;
        }

        public override void Render(ISourceRenderContext context)
        {
            if (ActiveTextures.Count > 0)
            {
                var texture = ActiveTextures[(int)frame % ActiveTextures.Count];
                Draw(context, texture, Decal.Position,
                    new Vector2(texture.FrameWidth, texture.FrameHeight) * .5f, Decal.Rotation);
            }
        }
    }
}
