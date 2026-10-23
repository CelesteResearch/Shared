using System;
using System.Collections.Generic;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Content.Tiles.Autotiling
{
    public sealed class AutotileContent
    {
        public readonly AutotileRules Background, Foreground;
        public readonly IReadOnlyDictionary<string, AnimatedTileDefinition> Animated;

        public AutotileContent(AutotileRules background, AutotileRules foreground,
            IReadOnlyDictionary<string, AnimatedTileDefinition> animated)
        {
            Background = background;
            Foreground = foreground;
            Animated = animated;
        }

        public AnimatedTileBank CreateAnimationBank()
        {
            var output = new AnimatedTileBank();
            foreach (var item in Animated)
            {
                var source = item.Value;
                var frames = new List<AtlasEntry>(source.Frames.Count);
                foreach (var frame in source.Frames)
                    frames.Add(frame);
                output.Add(source.Name, source.Delay,
                    new System.Numerics.Vector2(source.OffsetX, source.OffsetY),
                    new System.Numerics.Vector2(source.OriginX, source.OriginY), frames);
            }

            return output;
        }
    }
}
