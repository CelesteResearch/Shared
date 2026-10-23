using System.Numerics;
using Celeste.Core.Components;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession : ISourceScaleState
    {
        Vector2 ISourceScaleState.Scale
        {
            get => Sprite.Scale;
            set => Sprite.Scale = value;
        }
    }
}
