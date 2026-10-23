using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Bounds = Celeste.Core.Geometry.Bounds;
using Celeste.Core.Collections;

namespace Celeste.Physics.Collision
{
// Proposed pure geometry owner. Celeste's CollisionPlatform would inherit this,
// keeping audio, room-source, switch, gate and attachment metadata in Simulation.
    public class PixelPlatform
    {
        private Vector2 position;

        public Vector2 Position
        {
            get => SourceEntityOwner == null ? position : SourceEntityOwner.Position;
            set
            {
                if (SourceEntityOwner == null) position = value;
                else ((Celeste.Core.Components.ISourceMutableEntityState)SourceEntityOwner).Position = value;
            }
        }

        public Vector2 LiftSpeed { get; set; }
        private bool collidable = true;

        public bool Collidable
        {
            get => SourceEntityOwner == null ? collidable : SourceEntityOwner.Collidable;
            set
            {
                if (SourceEntityOwner == null) collidable = value;
                else ((Celeste.Core.Components.ISourceMutableEntityState)SourceEntityOwner).Collidable = value;
            }
        }

        public bool IsJumpThru { get; }

        // When a source Entity owns this platform, all collision reads use its one
        // current Collider, including raw TAS reassignment of Collider.Entity.
        public ISourceEntityCollider SourceEntityOwner { get; set; }

        public VirtualMap<char> TileGrid { get; set; }

        // Grid geometry belongs to the caller; the Celeste adapter selects 8x8 and '0'.
        private int tileWidth = 1, tileHeight = 1;
        private bool eightPixelCells;

        public int TileWidth
        {
            get => tileWidth;
            set
            {
                tileWidth = value;
                eightPixelCells = tileWidth == 8 && tileHeight == 8;
            }
        }

        public int TileHeight
        {
            get => tileHeight;
            set
            {
                tileHeight = value;
                eightPixelCells = tileWidth == 8 && tileHeight == 8;
            }
        }

        public char EmptyTile { get; set; }
        public List<Bounds> Regions { get; } = new();
        public Bounds BoundingBox => BoundsAt(Position);

        public PixelPlatform(Vector2 position, bool isJumpThru = false)
        {
            Position = position;
            IsJumpThru = isJumpThru;
        }

        public Bounds BoundsAt(Vector2 position)
        {
            if (SourceEntityOwner != null)
            {
                var shape = SourceEntityOwner.Collider;
                if (shape == null) return new Bounds(position.X, position.Y, 0, 0);
                // Entity movement affects its Collider only while it remains that
                // geometry's actual owner. A raw reparent must not be overwritten.
                var offset = object.ReferenceEquals(shape.Entity, SourceEntityOwner)
                    ? position - Position
                    : Vector2.Zero;
                return new Bounds(shape.AbsoluteLeft + offset.X, shape.AbsoluteTop + offset.Y,
                    shape.Width, shape.Height);
            }

            if (TileGrid != null)
            {
                if (eightPixelCells)
                    return new Bounds(position.X, position.Y, TileGrid.Columns * 8, TileGrid.Rows * 8);
                return new Bounds(position.X, position.Y, TileGrid.Columns * TileWidth, TileGrid.Rows * TileHeight);
            }

            if (Regions.Count == 0) return new Bounds(position.X, position.Y, 0, 0);
            if (Regions.Count == 1) return Regions[0].At(position);
            float left = float.MaxValue, top = float.MaxValue, right = float.MinValue, bottom = float.MinValue;
            foreach (Bounds region in Regions)
            {
                left = Math.Min(left, region.X);
                top = Math.Min(top, region.Y);
                right = Math.Max(right, region.Right);
                bottom = Math.Max(bottom, region.Bottom);
            }

            return Bounds.FromEdges(left, top, right, bottom).At(position);
        }

        public Bounds WorldBounds(Bounds region) => region.At(Position);

        public bool Intersects(Bounds bounds)
        {
            if (!Collidable) return false;
            if (SourceEntityOwner != null)
                return SourceEntityOwner.Collider != null && SourceEntityOwner.Collider.CollideHitbox(bounds);
            if (TileGrid != null)
            {
                if (!eightPixelCells) return IntersectsConfiguredGrid(bounds);
                bounds = new Bounds((int)bounds.X, (int)bounds.Y, (int)bounds.Width, (int)bounds.Height);
                Bounds gridBounds = new((int)Position.X, (int)Position.Y, TileGrid.Columns * 8, TileGrid.Rows * 8);
                if (!gridBounds.Intersects(bounds)) return false;
                int left = (int)((bounds.X - Position.X) / 8), top = (int)((bounds.Y - Position.Y) / 8);
                int right = (int)((bounds.Right - Position.X - 1) / 8),
                    bottom = (int)((bounds.Bottom - Position.Y - 1) / 8);
                for (int x = Math.Max(0, left); x <= right && x < TileGrid.Columns; x++)
                for (int y = Math.Max(0, top); y <= bottom && y < TileGrid.Rows; y++)
                    if (TileGrid[x, y] != EmptyTile)
                        return true;
                return false;
            }

            if (Regions.Count == 1) return WorldBounds(Regions[0]).Intersects(bounds);
            foreach (Bounds region in Regions)
                if (WorldBounds(region).Intersects(bounds))
                    return true;
            return false;
        }

        // The original point query is inlined by the runtime. Preserve that behavior
        // after adding the uncommon configurable-layout fallback.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(Vector2 point)
        {
            if (!Collidable) return false;
            if (SourceEntityOwner != null)
                return SourceEntityOwner.Collider != null && SourceEntityOwner.Collider.Collide(point);
            if (TileGrid != null)
            {
                if (!eightPixelCells) return ContainsConfiguredGrid(point);
                return new Bounds(Position.X, Position.Y, TileGrid.Columns * 8, TileGrid.Rows * 8).Contains(point) &&
                       TileGrid[(int)((point.X - Position.X) / 8), (int)((point.Y - Position.Y) / 8)] != EmptyTile;
            }

            foreach (Bounds region in Regions)
                if (WorldBounds(region).Contains(point))
                    return true;
            return false;
        }

        private bool IntersectsConfiguredGrid(Bounds bounds)
        {
            bounds = new Bounds((int)bounds.X, (int)bounds.Y, (int)bounds.Width, (int)bounds.Height);
            Bounds gridBounds = new((int)Position.X, (int)Position.Y, TileGrid.Columns * TileWidth,
                TileGrid.Rows * TileHeight);
            if (!gridBounds.Intersects(bounds)) return false;
            int left = (int)((bounds.X - Position.X) / TileWidth), top = (int)((bounds.Y - Position.Y) / TileHeight);
            int right = (int)((bounds.Right - Position.X - 1) / TileWidth),
                bottom = (int)((bounds.Bottom - Position.Y - 1) / TileHeight);
            for (int x = Math.Max(0, left); x <= right && x < TileGrid.Columns; x++)
            for (int y = Math.Max(0, top); y <= bottom && y < TileGrid.Rows; y++)
                if (TileGrid[x, y] != EmptyTile)
                    return true;
            return false;
        }

        private bool ContainsConfiguredGrid(Vector2 point) => BoundingBox.Contains(point) &&
                                                              TileGrid[(int)((point.X - Position.X) / TileWidth),
                                                                  (int)((point.Y - Position.Y) / TileHeight)] !=
                                                              EmptyTile;
    }
}
