using System.Numerics;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession : global::Celeste.Core.Components.ISourceScaleState
    {
        Vector2 global::Celeste.Core.Components.ISourceScaleState.Scale
        {
            get => Sprite.Scale;
            set => Sprite.Scale = value;
        }
    }
}
