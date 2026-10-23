using Celeste.Core.Display;

namespace Celeste.Game.Entities.LightSources.Torches
{
    public interface IOriginalTorchColors
    {
        PackedColor Color { get; }
        PackedColor StartLitColor { get; }
    }
}
