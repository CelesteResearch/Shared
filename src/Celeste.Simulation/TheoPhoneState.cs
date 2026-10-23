using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation
{
    public sealed class TheoPhoneState
    {
        public static readonly Vector4 LawnGreen = new Vector4(124 / 255f, 252 / 255f, 0f, 1f);
        public readonly ITheoPhoneEntityWorld World;
        public readonly global::Celeste.Graphics.Content.Atlas.AtlasEntry Image;
        public readonly EntityLightVisual Light;
        public Vector2 Position;
        public bool Visible = true, Active = true;
        public bool LightVisible = true;
        public int Depth = 0;
        public bool Removed { get; private set; }

        public TheoPhoneState(ITheoPhoneEntityWorld world, global::Celeste.Graphics.Content.Atlas.AtlasEntry image,
            Vector2 position)
        {
            World = world;
            Image = image;
            Position = position;
            Light = new EntityLightVisual
                { Position = Vector2.Zero, Color = LawnGreen, Alpha = 1f, StartRadius = 8, EndRadius = 16 };
        }

        public void Added()
        {
            Removed = false;
        }

        public void Update(float dt, float raw)
        {
            if (World.OnInterval(0.5f)) LightVisible = !LightVisible;
        }

        public void OnRemoved()
        {
            Removed = true;
            Visible = Active = false;
        }

        public void SceneEnd()
        {
            Removed = true;
        }

        public IReadOnlyList<global::Celeste.Graphics.Display.ImagePlacement> Images()
        {
            if (!Visible || Removed) return Array.Empty<global::Celeste.Graphics.Display.ImagePlacement>();
            return new[]
            {
                new global::Celeste.Graphics.Display.ImagePlacement(
                    new global::Celeste.Graphics.Content.Tiles.TileRegion(Image, 0, 0, Image.FrameWidth,
                        Image.FrameHeight),
                    Position.X, Position.Y, Depth, originX: Image.FrameWidth * 0.5f, originY: Image.FrameHeight,
                    color: Vector4.One)
            };
        }
    }
}
