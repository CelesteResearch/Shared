using System.Numerics;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Content.Tiles
{
    public struct AnimatedTileAnimation
    {
        public int ID;
        public string Name;
        public float Delay;
        public Vector2 Offset;
        public Vector2 Origin;
        public AtlasEntry[] Frames;
    }
}
