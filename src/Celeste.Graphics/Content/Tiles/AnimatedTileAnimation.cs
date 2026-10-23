using System.Numerics;

namespace Celeste.Graphics.Content.Tiles
{
    public struct AnimatedTileAnimation
    {
        public int ID;
        public string Name;
        public float Delay;
        public Vector2 Offset;
        public Vector2 Origin;
        public global::Celeste.Graphics.Content.Atlas.AtlasEntry[] Frames;
    }
}
