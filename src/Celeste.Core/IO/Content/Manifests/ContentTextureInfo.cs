using System;

namespace Celeste.Core.IO.Content.Manifests
{
    public sealed class ContentTextureInfo
    {
        public int Width { get; }
        public int Height { get; }
        public byte AlphaFlag { get; }
        public bool HasAlpha => AlphaFlag == 1;

        public ContentTextureInfo(int width, int height, byte alphaFlag)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentOutOfRangeException(nameof(width), "Physical texture dimensions must be positive.");
            Width = width;
            Height = height;
            AlphaFlag = alphaFlag;
        }
    }
}
