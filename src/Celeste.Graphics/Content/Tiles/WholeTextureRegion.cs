namespace Celeste.Graphics.Content.Tiles
{
    public static class WholeTextureRegion
    {
        public static TileRegion Create(string name, string page, int width, int height)
        {
            return new(
                new()
                {
                    Name = name, Page = page, Width = width, Height = height,
                    FrameWidth = width, FrameHeight = height,
                }, 0, 0, width, height);
        }
    }
}
