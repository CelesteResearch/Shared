using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Graphics.Display;

namespace Celeste.Simulation.Presentation.Decals.Entities
{
    public sealed class SourceDecalFinalFlagComponent : SourceDecalImageComponentBase
    {
        public float Rotation;

        public SourceDecalFinalFlagComponent() : base(true)
        {
        }

        public override void Render(ISourceRenderContext context)
        {
            var texture = Decal.Textures[(int)Decal.Frame];
            Draw(context, texture, Decal.Position + Vector2.UnitY * (texture.FrameHeight / 2),
                new Vector2(texture.FrameWidth * .5f, texture.FrameHeight), PackedColor.White, Rotation);
        }
    }
}
