using System.Numerics;

namespace Celeste.Graphics.Content.Tiles.Autotiling
{
    public interface IGroupedOverlayTileRegion
    {
        Vector2 Position { get; }
        float Width { get; }
        float Height { get; }
        char FillTile { get; }
        void SetGeneratedOverlay(AutotileGeneration generation);
    }
}
