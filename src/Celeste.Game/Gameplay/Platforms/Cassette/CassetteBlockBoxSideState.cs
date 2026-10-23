using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Game.Presentation.Platforms.Cassette;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;

namespace Celeste.Game.Gameplay.Platforms.Cassette
{
    public sealed class CassetteBlockBoxSideState : SceneEntityState
    {
        private readonly CassetteBlockState block;
        private readonly PackedColor color;

        private readonly ISourceCassetteBlockSidePresentation
            presentation;

        public CassetteBlockBoxSideState(CassetteBlockState block, PackedColor color,
            ISourceEntitySourceDataRegistration sourceData)
            : base(sourceData)
        {
            this.block = block;
            this.color = color;
            presentation =
                block as ISourceCassetteBlockSidePresentation;
        }

        public override void Render(ISourceRenderContext context)
        {
            if (presentation != null)
            {
                presentation.RenderBoxSide(context, this, color);
                return;
            }

            SourcePrimitiveDrawing.Rect(context, this, block.X, block.Y + block.Height - 8f,
                block.Width, 8 + block.blockHeight, color);
        }
    }
}
