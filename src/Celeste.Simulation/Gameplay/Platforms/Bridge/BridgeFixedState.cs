using Celeste.Scene.Scheduling;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Gameplay.Platforms.Bridge
{
    // Port of Celeste.BridgeFixed (Artifacts/Reference/Original/Celeste/BridgeFixed.cs).
    // An indestructible Solid, 8 pixels tall, tiled with scenery/bridge_fixed at y = -8. There is
    // no Update and no collision logic of its own.
    public sealed class BridgeFixedState : global::Celeste.Scene.Tracking.ISceneEntityAssociation,
        global::Celeste.Scene.Tracking.ISceneEntityDepth
    {
        public object Scene { get; private set; }

        object global::Celeste.Scene.Tracking.ISceneEntityAssociation.Scene
        {
            get => Scene;
            set => Scene = value;
        }

        public const float Height = 8f;
        public const string AtlasPath = "scenery/bridge_fixed";
        public const bool Safe = true;

        private readonly global::Celeste.Graphics.Content.Tiles.TileRegion texture;

        private readonly List<(float X, global::Celeste.Graphics.Content.Tiles.TileRegion Region)> images =
            new List<(float, global::Celeste.Graphics.Content.Tiles.TileRegion)>();

        public Vector2 Position;
        public global::Celeste.Core.Geometry.Bounds Collider;
        public int Width;

        public global::Celeste.Scene.Tracking.SceneEntityDepthState DepthState { get; } =
            new global::Celeste.Scene.Tracking.SceneEntityDepthState(-9000);

        public int Depth
        {
            get => DepthState.RawDepth;
            set => DepthState.SetDepth(value, Scene, this);
        }

        public bool Active = true, Visible = true, Collidable = true;
        public SceneTagSet Tags = default;
        public bool Removed { get; private set; }

        public BridgeFixedState(global::Celeste.Graphics.Content.Atlas.AtlasData atlas, Vector2 position, int width)
        {
            Position = position;
            Width = width;
            Collider = new global::Celeste.Core.Geometry.Bounds(0f, 0f, width, Height);
            var entry = atlas.Entries[AtlasPath];
            texture = new global::Celeste.Graphics.Content.Tiles.TileRegion(entry, 0, 0, entry.FrameWidth,
                entry.FrameHeight);
            // BridgeFixed.cs:11-23. The truncated last rectangle is computed and then discarded;
            // Image never receives it, so every slice draws at its full width.
            for (int i = 0; (float)i < width; i += texture.Width)
            {
                images.Add((i,
                    new global::Celeste.Graphics.Content.Tiles.TileRegion(texture.Atlas, 0, 0, texture.Width,
                        texture.Height)));
            }
        }

        public void RemoveSelf()
        {
            if (Removed) return;
            Removed = true;
            Active = Visible = Collidable = false;
        }

        public IEnumerable<global::Celeste.Graphics.Display.ImagePlacement> Images()
        {
            if (!Visible) yield break;
            foreach (var (x, region) in images)
                yield return new global::Celeste.Graphics.Display.ImagePlacement(region, Position.X + x,
                    Position.Y - Height, Depth,
                    originX: region.Atlas.OffsetX, originY: region.Atlas.OffsetY);
        }
    }
}
