using System;
using Celeste.Graphics.Content.Textures;

namespace Celeste.Graphics.Rendering.Textures
{
    public partial class SourceTexture2DResource : ISourceDataTextureResource
    {
        bool ISourceDataTextureResource.IsGraphicsDeviceDisposed => GraphicsDevice.IsDisposed;

        void ISourceDataTextureResource.GetData(byte[] rgba, int startIndex, int byteCount)
        {
            GetData(rgba, startIndex, byteCount);
        }

        void ISourceDataTextureResource.SetData(byte[] rgba)
        {
            SetData(rgba);
        }

        void ISourceDataTextureResource.SetData(byte[] rgba, int startIndex, int byteCount)
        {
            SetData(rgba, startIndex, byteCount);
        }

        void ISourceDataTextureResource.SetData(IntPtr rgba, int byteCount)
        {
            SetDataPointerEXT(0, null, rgba, byteCount);
        }
    }
}
