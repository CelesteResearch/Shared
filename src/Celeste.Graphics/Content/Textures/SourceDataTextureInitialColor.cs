using Celeste.Core.Display;

namespace Celeste.Graphics.Content.Textures
{
    public static class SourceDataTextureInitialColor
    {
        public static byte[] Create(int width, int height, PackedColor color)
        {
            var count = width * height;
            var rgba = new byte[count * 4];
            for (var index = 0; index < count; index++)
            {
                var offset = index * 4;
                rgba[offset] = color.R;
                rgba[offset + 1] = color.G;
                rgba[offset + 2] = color.B;
                rgba[offset + 3] = color.A;
            }

            return rgba;
        }
    }
}
