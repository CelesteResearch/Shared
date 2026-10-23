using Celeste.Core.Display;
using Celeste.Graphics.Display;
using System.Numerics;
using Celeste.Core.Scheduling;

namespace Celeste.Game.Gameplay.Environment.Ridge
{
    public interface IOriginalRidgeClothResources
    {
        PackedColor[] Colors { get; }
        PackedColor LineColor { get; }
        PackedColor PinColor { get; }
    }
}
