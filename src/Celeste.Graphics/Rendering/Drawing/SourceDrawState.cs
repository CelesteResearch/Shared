using Celeste.Core.Display;
using Celeste.Core.Rendering.Renderers;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Core.Geometry;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering.Batches;
using Celeste.Graphics.Text.Fonts;

namespace Celeste.Graphics.Rendering.Drawing
{
    public sealed class SourceDrawState
    {
        public AtlasEntry Pixel;
        public AtlasEntry Particle;
        internal IntRect Rectangle;

        public ISceneRenderer Renderer;
        public SourceSpriteBatch SpriteBatch;
        public SourceSpriteFont DefaultFont;

        public void HollowRect(float x, float y, float width, float height, PackedColor color)
        {
            var draw = this;
            draw.Rectangle.X = (int)x;
            draw.Rectangle.Y = (int)y;
            draw.Rectangle.Width = (int)width;
            draw.Rectangle.Height = 1;
            draw.SpriteBatch.Draw((SourceTexture2DResource)draw.Pixel.Texture.TextureSafe,
                draw.Rectangle, draw.Pixel.ClipRect, color.PackedValue);
            draw.Rectangle.Y = unchecked(draw.Rectangle.Y + (int)height - 1);
            draw.SpriteBatch.Draw((SourceTexture2DResource)draw.Pixel.Texture.TextureSafe,
                draw.Rectangle, draw.Pixel.ClipRect, color.PackedValue);
            draw.Rectangle.Y = unchecked(draw.Rectangle.Y - ((int)height - 1));
            draw.Rectangle.Width = 1;
            draw.Rectangle.Height = (int)height;
            draw.SpriteBatch.Draw((SourceTexture2DResource)draw.Pixel.Texture.TextureSafe,
                draw.Rectangle, draw.Pixel.ClipRect, color.PackedValue);
            draw.Rectangle.X = unchecked(draw.Rectangle.X + (int)width - 1);
            draw.SpriteBatch.Draw((SourceTexture2DResource)draw.Pixel.Texture.TextureSafe,
                draw.Rectangle, draw.Pixel.ClipRect, color.PackedValue);
        }
    }
}
