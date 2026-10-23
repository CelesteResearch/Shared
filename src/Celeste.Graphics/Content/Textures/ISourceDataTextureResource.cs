using System;

namespace Celeste.Graphics.Content.Textures
{
    public interface ISourceDataTextureResource : IDisposable
    {
        int Width { get; }
        int Height { get; }
        bool IsDisposed { get; }
        bool IsGraphicsDeviceDisposed { get; }
        void GetData(byte[] rgba, int startIndex, int byteCount);
        void SetData(byte[] rgba);
        void SetData(IntPtr rgba, int byteCount);
        void SetData(byte[] rgba, int startIndex, int byteCount);
    }
}
