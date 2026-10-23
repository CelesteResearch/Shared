using Celeste.Core.Display;

namespace Celeste.Game.Gameplay.Environment.Ridge
{
    public interface IOriginalRidgeClothResources
    {
        PackedColor[] Colors { get; }
        PackedColor LineColor { get; }
        PackedColor PinColor { get; }
    }
}
