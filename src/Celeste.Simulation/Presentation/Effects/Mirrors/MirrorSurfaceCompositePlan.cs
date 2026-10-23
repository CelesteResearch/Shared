using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Simulation.Presentation.Effects.Mirrors
{
    // Celeste.MirrorSurfaces.BeforeRender and Render. Both capture targets include a
    // 32-pixel camera border; FxMirrors crops that border into a 320x180 result.
    // The host supplies the tracked MirrorReflection and MirrorSurface images.
    public sealed class MirrorSurfaceCompositePlan
    {
        public const int Border = 32;
        public const int SourceWidth = 384;
        public const int SourceHeight = 244;
        public const int OutputWidth = 320;
        public const int OutputHeight = 180;
        public const int Depth = 9490;
        public const float Opacity = 0.5f;

        public readonly List<ImagePlacement> Sources = [];

        public readonly List<ImagePlacement> Masks = [];

        public Vector2 CaptureOffset { get; private set; }
        public Vector2 WorldPosition { get; private set; }
        public bool Active { get; private set; }

        public void Update(Vector2 camera,
            MirrorRenderCollection components)
        {
            if (components == null) throw new ArgumentNullException(nameof(components));
            Update(camera, components.SourceImages(), components.MaskImages(),
                components.Reflections.Count > 0, components.Surfaces.Count > 0);
        }

        public void Update(Vector2 camera, IEnumerable<ImagePlacement> sources,
            IEnumerable<ImagePlacement> masks, bool hasReflectionComponents,
            bool hasSurfaceComponents)
        {
            if (sources == null) throw new ArgumentNullException(nameof(sources));
            if (masks == null) throw new ArgumentNullException(nameof(masks));
            Sources.Clear();
            Masks.Clear();
            Active = hasReflectionComponents && hasSurfaceComponents;
            if (!Active) return;
            // Original source/mask SpriteBatch transform is T(32,32)*Camera.Matrix.
            // Render uses the floored camera for its final world placement.
            CaptureOffset = new(Border - camera.X, Border - camera.Y);
            WorldPosition = new((float)Math.Floor(camera.X),
                (float)Math.Floor(camera.Y));
            Sources.AddRange(sources);
            Masks.AddRange(masks);
        }

        public ImagePlacement Output(
            TileRegion target)
        {
            return Output(target, WorldPosition);
        }

        // Unity builds its room mesh before BeforeRender captures the current
        // frame. Let that host place the result from the current render view.
        public static ImagePlacement Output(
            TileRegion target, Vector2 camera)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            return new(target, (float)Math.Floor(camera.X),
                (float)Math.Floor(camera.Y), Depth,
                color: ColorMath.Scale(Vector4.One, Opacity));
        }
    }
}
