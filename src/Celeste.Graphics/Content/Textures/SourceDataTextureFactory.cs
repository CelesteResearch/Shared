using System.IO;
using Celeste.Core.Display;
using Celeste.Graphics.Content.Compiled;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Content.Textures
{
    public sealed class SourceDataTextureFactory(
        ISourceGraphicsDeviceEnvironment graphics,
        ISourceContentManagerEnvironment content) : ISourceDataTextureFactory
    {
        private readonly ISourceGraphicsDeviceEnvironment graphics = graphics;
        private readonly ISourceContentManagerEnvironment content = content;

        public SourceTexture2DResource CreateTexture(string name, int width, int height)
        {
            return new(graphics.GraphicsDevice, width, height);
        }

        public SourceTexture2DResource CreateTexture(string name, int width, int height, PackedColor initialColor)
        {
            var texture = new SourceTexture2DResource(graphics.GraphicsDevice, width, height);
            texture.SetData(SourceDataTextureInitialColor.Create(width, height, initialColor));
            return texture;
        }

        public SourceTexture2DResource FromStream(Stream stream)
        {
            return SourceTexture2DResource.FromStream(graphics.GraphicsDevice, stream);
        }

        public SourceTexture2DResource FromStream(Stream stream, bool premultiply)
        {
            return SourceTexture2DResource.FromStream(graphics.GraphicsDevice, stream, premultiply);
        }

        public SourceTexture2DResource LoadContent(string assetName)
        {
            return content.ContentManager.Load<SourceTexture2DResource>(assetName);
        }
    }
}
