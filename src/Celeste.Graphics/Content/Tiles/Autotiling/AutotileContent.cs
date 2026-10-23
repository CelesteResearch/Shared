using System.Collections.Generic;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Content.Tiles.Autotiling
{
    public sealed class AutotileContent(
        AutotileRules background,
        AutotileRules foreground,
        IReadOnlyDictionary<string, AnimatedTileDefinition> animated)
    {
        public readonly AutotileRules Background = background, Foreground = foreground;
        public readonly IReadOnlyDictionary<string, AnimatedTileDefinition> Animated = animated;

        public AnimatedTileBank CreateAnimationBank()
        {
            var output = new AnimatedTileBank();
            foreach (var item in Animated)
            {
                var source = item.Value;
                var frames = new List<AtlasEntry>(source.Frames.Count);
                foreach (var frame in source.Frames)
                    frames.Add(frame);
                output.Add(source.Name, source.Delay, new(source.OffsetX, source.OffsetY),
                    new(source.OriginX, source.OriginY), frames);
            }

            return output;
        }
    }
}
