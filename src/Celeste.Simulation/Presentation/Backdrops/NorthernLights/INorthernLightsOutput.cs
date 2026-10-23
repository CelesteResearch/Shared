using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Presentation.Backdrops.NorthernLights
{
    public interface INorthernLightsOutput
    {
        void CreateBuffer();
        void SetBuffer();

        void DrawGradient(IReadOnlyList<global::Celeste.Graphics.Display.ColoredVertex> vertices);

        // The original binds the entire Misc texture, not its atlas UV rectangle.
        void DrawStrands(global::Celeste.Graphics.Content.Tiles.TileRegion noise,
            global::Celeste.Graphics.Effects.Backdrops.NorthernLights.NorthernLightsVertex[] vertices, int count);

        void BlurBuffer(float fade, bool clear, global::Celeste.Graphics.Effects.Blur.GaussianBlurSamples samples,
            float sampleScale,
            global::Celeste.Graphics.Effects.Blur.GaussianBlurDirection direction);

        // One default SpriteBatch.Begin/End: AlphaBlend, LinearClamp, identity.
        void DrawParticles(IEnumerable<global::Celeste.Graphics.Display.ImagePlacement> images);
        void DisposeBuffer();
    }
}
