using System.Numerics;

namespace Celeste.Graphics.Display
{
    public struct ColoredVertex(Vector2 position, Vector4 color)
    {
        public Vector3 Position = new(position, 0);
        public Vector4 Color = color;
    }
}
