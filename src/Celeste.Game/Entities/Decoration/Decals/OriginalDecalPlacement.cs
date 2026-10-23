using System.Numerics;

namespace Celeste.Game.Entities.Decoration.Decals
{
    public sealed class OriginalDecalPlacement
    {
        public string Texture;
        public Vector2 Position;
        public Vector2 Scale;
        public float Rotation;
        public string ColorHex = string.Empty;
        public int? Depth;
        public float? Parallax;
    }
}
