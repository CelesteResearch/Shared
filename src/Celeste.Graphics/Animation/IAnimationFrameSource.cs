using System.Collections.Generic;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Animation
{
    public interface IAnimationFrameSource
    {
        AtlasEntry Frame(string key, int index);
        List<AtlasEntry> Frames(string key);
    }
}
