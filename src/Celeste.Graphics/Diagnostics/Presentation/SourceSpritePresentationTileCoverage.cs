using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering.Observation;

namespace Celeste.Graphics.Diagnostics.Presentation
{
    public readonly struct SourceSpritePresentationTileCoverage(
        in SourceRenderObservationScope scope,
        in IntRect tiles,
        Vector2 worldPosition,
        int tileWidth,
        int tileHeight)
    {
        public readonly SourceRenderObservationScope Scope = scope;
        public readonly IntRect Tiles = tiles;
        public readonly Vector2 WorldPosition = worldPosition;
        public readonly int TileWidth = tileWidth;
        public readonly int TileHeight = tileHeight;

        public bool Matches(in SourceSpritePresentationTileCoverage other)
        {
            return Scope.EntityIndex == other.Scope.EntityIndex && Scope.ComponentIndex == other.Scope.ComponentIndex &&
                   Scope.ComponentKind == other.Scope.ComponentKind && Scope.Owner.Matches(in other.Scope.Owner) &&
                   Scope.RenderPhase.Matches(in other.Scope.RenderPhase) && Tiles.X == other.Tiles.X &&
                   Tiles.Y == other.Tiles.Y && Tiles.Width == other.Tiles.Width && Tiles.Height == other.Tiles.Height &&
                   WorldPosition.Equals(other.WorldPosition) && TileWidth == other.TileWidth &&
                   TileHeight == other.TileHeight;
        }
    }
}
