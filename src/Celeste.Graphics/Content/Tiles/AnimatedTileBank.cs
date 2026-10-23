using System.Collections.Generic;
using System.Numerics;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Content.Tiles
{
    public sealed class AnimatedTileBank
    {
        public Dictionary<string, AnimatedTileAnimation> AnimationsByName = new();

        public List<AnimatedTileAnimation> Animations = [];

        public void Add(string name, float delay, Vector2 offset, Vector2 origin,
            List<AtlasEntry> textures)
        {
            var animation = new AnimatedTileAnimation
            {
                Name = name, Delay = delay, Offset = offset, Origin = origin, Frames = [.. textures],
            };
            animation.ID = Animations.Count;
            Animations.Add(animation);
            AnimationsByName.Add(name, animation);
        }
    }
}
