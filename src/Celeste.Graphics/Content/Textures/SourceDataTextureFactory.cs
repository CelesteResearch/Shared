using Celeste.Core.Display;
using System.IO;
using Celeste.Graphics.Content.Compiled;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Content.Textures
{
    public sealed class SourceDataTextureFactory : ISourceDataTextureFactory
    {
        private readonly ISourceGraphicsDeviceEnvironment graphics;
        private readonly ISourceContentManagerEnvironment content;

        public SourceDataTextureFactory(ISourceGraphicsDeviceEnvironment graphics,
            ISourceContentManagerEnvironment content)
        {
            this.graphics = graphics;
            this.content = content;
        }

        public SourceTexture2DResource CreateTexture(string name, int width, int height)
            => new SourceTexture2DResource(graphics.GraphicsDevice, width, height);

        public SourceTexture2DResource CreateTexture(string name, int width, int height,
            PackedColor initialColor)
        {
            var texture = new SourceTexture2DResource(graphics.GraphicsDevice, width, height);
            texture.SetData(SourceDataTextureInitialColor.Create(width, height, initialColor));
            return texture;
        }

        public SourceTexture2DResource FromStream(Stream stream)
            => SourceTexture2DResource.FromStream(graphics.GraphicsDevice, stream);

        public SourceTexture2DResource FromStream(Stream stream, bool premultiply)
            => SourceTexture2DResource.FromStream(graphics.GraphicsDevice, stream, premultiply);

        public SourceTexture2DResource LoadContent(string assetName)
            => content.ContentManager.Load<SourceTexture2DResource>(assetName);
    }
}
