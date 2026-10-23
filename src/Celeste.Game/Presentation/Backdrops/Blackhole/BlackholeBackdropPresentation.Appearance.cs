using Celeste.Core.Display;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Game.Presentation.Backdrops.Blackhole
{
    public partial class BlackholeBackdropPresentation
    {
        public void ApplyColors(BlackholeBackdropPalette palette)
        {
            colorsMild = palette.MildColors;
            colorsWild = palette.WildColors;
            bgColorInner = palette.InnerColor;
            bgColorOuterMild = palette.OuterMildColor;
            bgColorOuterWild = palette.OuterWildColor;
        }

        public void SetBackgroundTexture(AtlasEntry texture) => bgTexture = texture;

        protected virtual PackedColor ForegroundBlack => PackedColor.Black;
        protected virtual PackedColor BackgroundClearColor => bgColorInner;
        protected virtual int BackgroundFirstLayer => 0;
        protected virtual int BackgroundLayerStep => 1;
        protected virtual int BackgroundLayerIndex(int layer) => layer;
        protected virtual SourceTexture2DResource ResolvePrimitiveTexture(SourceTexture2DResource texture) => texture;
    }
}
