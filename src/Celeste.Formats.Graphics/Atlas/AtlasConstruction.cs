using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Formats.Graphics.Atlas
{
    public sealed class AtlasConstruction : ISourceAtlasConstruction
    {
        public bool UsesInstalledReadPolicy => false;

        public AtlasData CreateAtlas()
        {
            return new();
        }

        public AtlasEntry CreateEntry(VirtualTexture texture, AtlasData atlas)
        {
            return new(texture);
        }

        public AtlasEntry CreateEntry(VirtualTexture texture, Vector2 offset, int width, int height, AtlasData atlas)
        {
            return new(texture, offset, width, height);
        }

        public AtlasEntry CreateEntry(AtlasEntry parent, string name, IntRect clip)
        {
            return new(parent, name, clip);
        }

        public AtlasEntry
            CreateEntry(AtlasEntry parent, string name, IntRect clip, Vector2 offset, int width, int height)
        {
            return new(parent, name, clip, offset, width, height);
        }
    }
}
