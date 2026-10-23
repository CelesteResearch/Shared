using System.Numerics;
using Celeste.Simulation.Gameplay.Player.Scene.Effects;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        internal void CreateDashSlash(Vector2 position, float direction)
            => ((ISourcePlayerDashEffectsScene)Level).CreatePlayerDashSlash(position, direction);
    }
}
