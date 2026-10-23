using System.Numerics;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Display.Colors;
using Celeste.Simulation.Presentation.Backdrops.Blackhole;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Game.Content.Maps.Backdrops
{
    public static class OriginalBlackholeBackdropResources
    {
        public static BlackholeBackdropResources Create(AtlasData atlas,
            BackdropViewport viewport)
        {
            var bg = atlas.Entries["objects/temple/portal/portal"];
            var background = new TileRegion(bg, 0, 0, bg.FrameWidth, bg.FrameHeight);
            var entries = atlas.Frames("bgs/10/blackhole/particle");
            var textures = new TileRegion[entries.Count];
            for (var i = 0; i < textures.Length; i++)
            {
                var e = entries[i];
                textures[i] = new(e, 0, 0, e.FrameWidth, e.FrameHeight);
            }

            var mild = (Vector4[])
            [
                ColorMath.Scale(new Vector4(110, 49, 153, 255) / 255f, .8f),
                ColorMath.Scale(new Vector4(133, 31, 145, 255) / 255f, .8f),
                ColorMath.Scale(new Vector4(48, 38, 176, 255) / 255f, .8f),
            ];
            var wild = (Vector4[])
            [
                new Vector4(202, 76, 167, 255) / 255f, new Vector4(177, 76, 202, 255) / 255f,
                new Vector4(202, 76, 167, 255) / 255f,
            ];

            // Preserve the native Sources[0] choice after all constructor RNG and pageSize callbacks.
            string FirstAtlasPage()
            {
                foreach (var entry in atlas.Entries.Values) return entry.Page;
                return null;
            }

            return new(viewport, background, textures, mild, wild,
                new Vector4(81, 42, 139, 255) / 255f,
                new Vector4(189, 33, 146, 255) / 255f,
                "blackhole_strength", FirstAtlasPage);
        }
    }
}
