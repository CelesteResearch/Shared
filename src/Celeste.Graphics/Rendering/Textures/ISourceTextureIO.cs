using System;
using Celeste.Graphics.Content.Images;

namespace Celeste.Graphics.Rendering.Textures
{
    public interface ISourceTextureIO : ISourceImageStreamProcessEnvironment
    {
        void SetTextureName(IntPtr texture, string name);
        void AddDisposeTexture(IntPtr texture);
        void CopyTexture2D(IntPtr source, IntPtr destination);
        byte SupportsSRGBRenderTargets();
        byte SupportsDXT1();
        byte SupportsS3TC();
        IntPtr CreateTexture2D(SourceSurfaceFormat format, int width, int height, int levels, byte renderTarget);

        void SetTextureData2D(IntPtr texture, int x, int y, int width, int height, int level, IntPtr data,
            int dataLength);

        void GetTextureData2D(IntPtr texture, int x, int y, int width, int height, int level, IntPtr data,
            int dataLength);

        IntPtr CreateTexture3D(SourceSurfaceFormat format, int width, int height, int depth, int levels);

        void SetTextureData3D(IntPtr texture, int left, int top, int front, int width, int height, int depth, int level,
            IntPtr data, int dataLength);

        void GetTextureData3D(IntPtr texture, int left, int top, int front, int width, int height, int depth, int level,
            IntPtr data, int dataLength);

        IntPtr CreateTextureCube(SourceSurfaceFormat format, int size, int levels, byte renderTarget);

        void SetTextureDataCube(IntPtr texture, int x, int y, int width, int height, SourceCubeMapFace face, int level,
            IntPtr data, int dataLength);

        void GetTextureDataCube(IntPtr texture, int x, int y, int width, int height, SourceCubeMapFace face, int level,
            IntPtr data, int dataLength);

        IntPtr Allocate(int bytes);
        void Free(IntPtr pointer);
        void Image_Free(IntPtr pointer);
        int GetMaxMultiSampleCount(SourceSurfaceFormat format, int preferredCount);
        IntPtr GenColorRenderbuffer(int width, int height, SourceSurfaceFormat format, int sampleCount, IntPtr texture);
        IntPtr GenDepthStencilRenderbuffer(int width, int height, SourceDepthFormat format, int sampleCount);
        void AddDisposeRenderbuffer(IntPtr renderbuffer);
    }
}
