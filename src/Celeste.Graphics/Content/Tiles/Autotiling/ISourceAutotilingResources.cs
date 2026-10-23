namespace Celeste.Graphics.Content.Tiles.Autotiling
{
    public interface ISourceAutotilingResources : IAnimatedTileBankEnvironment
    {
        Autotiler BackgroundAutotiler { get; }
        Autotiler ForegroundAutotiler { get; }
    }
}
