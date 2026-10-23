using Celeste.Core.Display;
using Celeste.Graphics.Display;
using Celeste.Core.Components;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Scene.Entities;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Gameplay.Platforms.Cassette
{
    public sealed class CassetteBlockBoxSideState : SceneEntityState
    {
        private CassetteBlockState block;
        private PackedColor color;

        private readonly global::Celeste.Game.Presentation.Platforms.Cassette.ISourceCassetteBlockSidePresentation
            presentation;

        public CassetteBlockBoxSideState(CassetteBlockState block, PackedColor color,
            ISourceEntitySourceDataRegistration sourceData)
            : base(sourceData)
        {
            this.block = block;
            this.color = color;
            presentation =
                block as global::Celeste.Game.Presentation.Platforms.Cassette.ISourceCassetteBlockSidePresentation;
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
