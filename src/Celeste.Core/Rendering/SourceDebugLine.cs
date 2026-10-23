using System.Numerics;

namespace Celeste.Core.Rendering
{
    public readonly struct SourceDebugLine
    {
        public readonly Vector2 Position;
        public readonly float Angle, Length;
        public readonly Vector4 Color;

        public SourceDebugLine(Vector2 position, float angle, float length, Vector4 color)
        {
            Position = position;
            Angle = angle;
            Length = length;
            Color = color;
        }
    }
}
