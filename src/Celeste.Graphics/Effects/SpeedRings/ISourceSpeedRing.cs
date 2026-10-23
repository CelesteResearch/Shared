using Celeste.Core.Display;
using System.Numerics;
using Celeste.Graphics.Display;

namespace Celeste.Graphics.Effects.SpeedRings
{
    public interface ISourceSpeedRing
    {
        ISourceSpeedRing Init(Vector2 position, float angle, PackedColor color);
    }
}
