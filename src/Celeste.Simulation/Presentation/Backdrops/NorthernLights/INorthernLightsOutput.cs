using System.Collections.Generic;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Display;
using Celeste.Graphics.Effects.Backdrops.NorthernLights;
using Celeste.Graphics.Effects.Blur;

namespace Celeste.Simulation.Presentation.Backdrops.NorthernLights
{
    public interface INorthernLightsOutput
    {
        void CreateBuffer();
        void SetBuffer();

        void DrawGradient(IReadOnlyList<ColoredVertex> vertices);

        // The original binds the entire Misc texture, not its atlas UV rectangle.
        void DrawStrands(TileRegion noise,
            NorthernLightsVertex[] vertices, int count);

        void BlurBuffer(float fade, bool clear, GaussianBlurSamples samples,
            float sampleScale,
            GaussianBlurDirection direction);

        // One default SpriteBatch.Begin/End: AlphaBlend, LinearClamp, identity.
        void DrawParticles(IEnumerable<ImagePlacement> images);
        void DisposeBuffer();
    }
}
