using System.Numerics;

namespace Celeste.Core.Input
{
    public interface ISourceVirtualJoystick
    {
        Vector2 Value { get; set; }
        Vector2 PreviousValue { get; }
        bool InvertedX { get; set; }
        bool InvertedY { get; set; }
    }
}
