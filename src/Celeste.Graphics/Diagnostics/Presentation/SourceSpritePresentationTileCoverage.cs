using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering.Observation;

namespace Celeste.Graphics.Diagnostics.Presentation
{
    public readonly struct SourceSpritePresentationTileCoverage
    {
        public readonly SourceRenderObservationScope Scope;
        public readonly IntRect Tiles;
        public readonly Vector2 WorldPosition;
        public readonly int TileWidth;
        public readonly int TileHeight;

        public SourceSpritePresentationTileCoverage(in SourceRenderObservationScope scope, in IntRect tiles,
            Vector2 worldPosition, int tileWidth, int tileHeight)
        {
            Scope = scope;
            Tiles = tiles;
            WorldPosition = worldPosition;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
        }

        public bool Matches(in SourceSpritePresentationTileCoverage other)
            => Scope.EntityIndex == other.Scope.EntityIndex && Scope.ComponentIndex == other.Scope.ComponentIndex
                                                            && Scope.ComponentKind == other.Scope.ComponentKind &&
                                                            Scope.Owner.Matches(in other.Scope.Owner) &&
                                                            Scope.RenderPhase.Matches(in other.Scope.RenderPhase) &&
                                                            Tiles.X == other.Tiles.X && Tiles.Y == other.Tiles.Y
                                                            && Tiles.Width == other.Tiles.Width &&
                                                            Tiles.Height == other.Tiles.Height
                                                            && WorldPosition.Equals(other.WorldPosition) &&
                                                            TileWidth == other.TileWidth &&
                                                            TileHeight == other.TileHeight;
    }
}
