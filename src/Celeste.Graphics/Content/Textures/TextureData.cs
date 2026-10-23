namespace Celeste.Graphics.Content.Textures
{
    public sealed class TextureData
    {
        public int Width { get; }
        public int Height { get; }
        public byte[] Rgba { get; }

        public TextureData(int width, int height)
        {
            Width = width;
            Height = height;
            Rgba = new byte[checked(width * height * 4)];
        }
    }
}
