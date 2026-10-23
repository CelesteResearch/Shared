using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Simulation.Presentation.Decals.Entities
{
    public sealed class SourceDecalCoreSwapComponent : SourceDecalImageComponentBase
    {
        private readonly AtlasEntry hot, cold;

        public SourceDecalCoreSwapComponent(AtlasEntry hot, AtlasEntry cold) : base(false)
        {
            this.hot = hot;
            this.cold = cold;
        }

        public override void Render(ISourceRenderContext context)
        {
            var texture = ((ISourceDecalEnvironment)Scene).CoreCold ? cold : hot;
            Draw(context, texture, Decal.Position, new Vector2(texture.FrameWidth, texture.FrameHeight) * .5f,
                Decal.Rotation);
        }
    }
}
