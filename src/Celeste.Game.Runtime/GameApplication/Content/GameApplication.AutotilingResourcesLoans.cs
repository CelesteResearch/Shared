using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Content.Tiles.Autotiling;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceAutotilingResources
    {
        Autotiler ISourceAutotilingResources.BackgroundAutotiler => GraphicsResources.BackgroundAutotiler;
        Autotiler ISourceAutotilingResources.ForegroundAutotiler => GraphicsResources.ForegroundAutotiler;
        AnimatedTileBank IAnimatedTileBankEnvironment.AnimatedTilesBank => GraphicsResources.AnimatedTilesBank;
    }
}
