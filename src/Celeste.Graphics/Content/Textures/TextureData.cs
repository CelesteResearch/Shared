namespace Celeste.Graphics.Content.Textures
{
    public sealed class TextureData(int width, int height)
    {
        public int Width { get; } = width;
        public int Height { get; } = height;
        public byte[] Rgba { get; } = new byte[checked(width * height * 4)];
    }
}
