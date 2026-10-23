using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Animation
{
    public static class AtlasSpriteFactory
    {
        private sealed class FrameSource : IAnimationFrameSource
        {
            private readonly AtlasData atlas;
            public FrameSource(AtlasData atlas) => this.atlas = atlas;
            public AtlasEntry Frame(string key, int index) => atlas.Frame(key, index);
            public List<AtlasEntry> Frames(string key) => atlas.Frames(key);
        }

        private static readonly ConditionalWeakTable<AtlasData, FrameSource> Sources =
            new ConditionalWeakTable<AtlasData, FrameSource>();

        public static Sprite Create(global::Celeste.Core.Scheduling.ISourceEngineContext engine, AtlasData atlas,
            string path)
            => new Sprite(engine, atlas == null ? null : Sources.GetValue(atlas, value => new FrameSource(value)),
                path);
    }
}
