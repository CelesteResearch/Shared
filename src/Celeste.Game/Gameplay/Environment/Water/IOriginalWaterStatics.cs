using Celeste.Core.Display;
using System.Numerics;
using Celeste.Graphics.Display;

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
