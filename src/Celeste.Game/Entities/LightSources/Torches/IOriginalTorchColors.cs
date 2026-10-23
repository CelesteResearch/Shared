using Celeste.Core.Display;
using Celeste.Graphics.Display;

namespace Celeste.Game.Entities.LightSources.Torches
{
    public interface IOriginalTorchColors
    {
        PackedColor Color { get; }
        PackedColor StartLitColor { get; }
    }
}
