using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Display;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;

namespace Celeste.Simulation.Gameplay.Platforms.Bridge
{
    // Port of Celeste.BridgeFixed (Artifacts/Reference/Original/Celeste/BridgeFixed.cs).
    // An indestructible Solid, 8 pixels tall, tiled with scenery/bridge_fixed at y = -8. There is
    // no Update and no collision logic of its own.
    public sealed class BridgeFixedState : ISceneEntityAssociation,
        ISceneEntityDepth
    {
        public object Scene { get; private set; }

        object ISceneEntityAssociation.Scene
        {
            get => Scene;
            set => Scene = value;
        }

        public const float Height = 8f;
        public const string AtlasPath = "scenery/bridge_fixed";
        public const bool Safe = true;

        private readonly TileRegion texture;

        private readonly List<(float X, TileRegion Region)> images = [];

        public Vector2 Position;
        public Bounds Collider;
        public int Width;

        public SceneEntityDepthState DepthState { get; } = new(-9000);

        public int Depth
        {
            get => DepthState.RawDepth;
            set => DepthState.SetDepth(value, Scene, this);
        }

        public bool Active = true, Visible = true, Collidable = true;
        public SceneTagSet Tags = default;
        public bool Removed { get; private set; }

        public BridgeFixedState(AtlasData atlas, Vector2 position, int width)
        {
            Position = position;
            Width = width;
            Collider = new(0f, 0f, width, Height);
            var entry = atlas.Entries[AtlasPath];
            texture = new(entry, 0, 0, entry.FrameWidth,
                entry.FrameHeight);
            // BridgeFixed.cs:11-23. The truncated last rectangle is computed and then discarded;
            // Image never receives it, so every slice draws at its full width.
            for (var i = 0; (float)i < width; i += texture.Width)
                images.Add((i,
                    new(texture.Atlas, 0, 0, texture.Width,
                        texture.Height)));
        }

        public void RemoveSelf()
        {
            if (Removed) return;
            Removed = true;
            Active = Visible = Collidable = false;
        }

        public IEnumerable<ImagePlacement> Images()
        {
            if (!Visible) yield break;
            foreach (var (x, region) in images)
                yield return new(region, Position.X + x,
                    Position.Y - Height, Depth,
                    originX: region.Atlas.OffsetX, originY: region.Atlas.OffsetY);
        }
    }
}
