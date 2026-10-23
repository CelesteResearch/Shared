using System;
using System.Numerics;
using Celeste.Graphics.Content.Tiles;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Simulation.Presentation.Backdrops.Blackhole
{
    public sealed class BlackholeBackdropResources
    {
        public BackdropViewport Viewport { get; }
        public TileRegion Background { get; }
        public TileRegion[] StreamTextures { get; }
        public Vector4[] MildColors { get; }
        public Vector4[] WildColors { get; }
        public Vector4 OuterMild { get; }
        public Vector4 OuterWild { get; }
        public string CounterKey { get; }
        public Func<string> ResolveAtlasPage { get; }

        public BlackholeBackdropResources(
            BackdropViewport viewport, TileRegion background,
            TileRegion[] streamTextures,
            Vector4[] mildColors, Vector4[] wildColors, Vector4 outerMild, Vector4 outerWild,
            string counterKey, Func<string> resolveAtlasPage)
        {
            if (viewport.Width <= 0 || viewport.Height <= 0) throw new ArgumentOutOfRangeException(nameof(viewport));
            Viewport = viewport;
            Background = background;
            StreamTextures = streamTextures ?? throw new ArgumentNullException(nameof(streamTextures));
            MildColors = mildColors ?? throw new ArgumentNullException(nameof(mildColors));
            WildColors = wildColors ?? throw new ArgumentNullException(nameof(wildColors));
            OuterMild = outerMild;
            OuterWild = outerWild;
            CounterKey = counterKey ?? throw new ArgumentNullException(nameof(counterKey));
            ResolveAtlasPage = resolveAtlasPage ?? throw new ArgumentNullException(nameof(resolveAtlasPage));
        }
    }
}
