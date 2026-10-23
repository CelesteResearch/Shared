using System.Numerics;
using Celeste.Core.Rendering;

namespace Celeste.Simulation.Presentation.Decals.Entities
{
    public sealed class SourceDecalImageComponent : SourceDecalImageComponentBase
    {
        public SourceDecalImageComponent() : base(true)
        {
        }

        public override void Render(ISourceRenderContext context)
        {
            var texture = Decal.Textures[(int)Decal.Frame];
            Draw(context, texture, Decal.Position, new Vector2(texture.FrameWidth, texture.FrameHeight) * .5f,
                Decal.Rotation);
        }
    }
}
