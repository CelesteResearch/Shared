using Celeste.Core.Components;
using Celeste.Graphics.Animation;

namespace Celeste.Game.Presentation.Doors
{
    public interface IDoorPresentationSource : ISourceEntityPosition
    {
        Sprite Sprite { get; }
    }
}
