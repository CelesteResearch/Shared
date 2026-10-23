using Celeste.Core.Display;
using Celeste.Graphics.Display;

namespace Celeste.Graphics.Content.Textures
{
    public static class SourceDataTextureInitialColor
    {
        public static byte[] Create(int width, int height, PackedColor color)
        {
            int count = width * height;
            var rgba = new byte[count * 4];
            for (int index = 0; index < count; index++)
            {
                int offset = index * 4;
                rgba[offset] = color.R;
                rgba[offset + 1] = color.G;
                rgba[offset + 2] = color.B;
                rgba[offset + 3] = color.A;
            }

            return rgba;
        }
    }
}
