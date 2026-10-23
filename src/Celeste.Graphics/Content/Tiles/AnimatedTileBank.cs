using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Graphics.Content.Tiles
{
    public sealed class AnimatedTileBank
    {
        public Dictionary<string, AnimatedTileAnimation> AnimationsByName =
            new Dictionary<string, AnimatedTileAnimation>();

        public List<AnimatedTileAnimation> Animations = new List<AnimatedTileAnimation>();

        public void Add(string name, float delay, Vector2 offset, Vector2 origin,
            List<global::Celeste.Graphics.Content.Atlas.AtlasEntry> textures)
        {
            var animation = new AnimatedTileAnimation
            {
                Name = name, Delay = delay, Offset = offset, Origin = origin, Frames = textures.ToArray()
            };
            animation.ID = Animations.Count;
            Animations.Add(animation);
            AnimationsByName.Add(name, animation);
        }
    }
}
