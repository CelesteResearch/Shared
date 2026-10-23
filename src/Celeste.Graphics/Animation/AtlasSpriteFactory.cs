using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Animation
{
    public static class AtlasSpriteFactory
    {
        private sealed class FrameSource(AtlasData atlas) : IAnimationFrameSource
        {
            private readonly AtlasData atlas = atlas;

            public AtlasEntry Frame(string key, int index)
            {
                return atlas.Frame(key, index);
            }

            public List<AtlasEntry> Frames(string key)
            {
                return atlas.Frames(key);
            }
        }

        private static readonly ConditionalWeakTable<AtlasData, FrameSource> Sources = new();

        public static Sprite Create(ISourceEngineContext engine, AtlasData atlas, string path)
        {
            return new(engine, atlas == null ? null : Sources.GetValue(atlas, value => new(value)), path);
        }
    }
}
