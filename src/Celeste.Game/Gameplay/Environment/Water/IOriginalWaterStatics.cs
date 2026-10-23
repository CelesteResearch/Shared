using System.Numerics;
using Celeste.Core.Display;

namespace Celeste.Game.Gameplay.Environment.Water
{
    public interface IOriginalWaterStatics
    {
        PackedColor FillColor { get; }
        PackedColor SurfaceColor { get; }
        PackedColor RayTopColor { get; }
        Vector2 RayAngle { get; }
    }
}
