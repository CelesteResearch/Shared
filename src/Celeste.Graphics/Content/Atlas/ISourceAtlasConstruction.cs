using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Graphics.Content.Atlas
{
    public interface ISourceAtlasConstruction
    {
        bool UsesInstalledReadPolicy { get; }
        AtlasData CreateAtlas();
        AtlasEntry CreateEntry(VirtualTexture texture, AtlasData atlas);
        AtlasEntry CreateEntry(VirtualTexture texture, Vector2 offset, int width, int height, AtlasData atlas);
        AtlasEntry CreateEntry(AtlasEntry parent, string name, IntRect clip);
        AtlasEntry CreateEntry(AtlasEntry parent, string name, IntRect clip, Vector2 offset, int width, int height);
    }
}
