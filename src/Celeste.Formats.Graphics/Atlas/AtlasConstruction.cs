using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Formats.Graphics.Atlas
{
    public sealed class AtlasConstruction : ISourceAtlasConstruction
    {
        public bool UsesInstalledReadPolicy => false;
        public AtlasData CreateAtlas() => new AtlasData();
        public AtlasEntry CreateEntry(VirtualTexture texture, AtlasData atlas) => new AtlasEntry(texture);

        public AtlasEntry CreateEntry(VirtualTexture texture, Vector2 offset, int width, int height, AtlasData atlas) =>
            new AtlasEntry(texture, offset, width, height);

        public AtlasEntry CreateEntry(AtlasEntry parent, string name, IntRect clip) =>
            new AtlasEntry(parent, name, clip);

        public AtlasEntry
            CreateEntry(AtlasEntry parent, string name, IntRect clip, Vector2 offset, int width, int height) =>
            new AtlasEntry(parent, name, clip, offset, width, height);
    }
}
