using System.Numerics;

namespace Celeste.Core.Rendering
{
    public readonly struct SourceDebugLine(Vector2 position, float angle, float length, Vector4 color)
    {
        public readonly Vector2 Position = position;
        public readonly float Angle = angle, Length = length;
        public readonly Vector4 Color = color;
    }
}
