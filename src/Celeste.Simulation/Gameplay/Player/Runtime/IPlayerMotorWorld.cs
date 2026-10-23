using Celeste.Simulation.Gameplay.Player.Audio.Frame;
using Celeste.Simulation.Gameplay.Player.Collision.Responses;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Gameplay.Player.Movement;

namespace Celeste.Simulation.Gameplay.Player.Runtime
{
    // Entity/scene adapters supply all collision and interaction queries to the same
    // player state. Other game states can register callbacks on Machine as they are loaded.
    public interface IPlayerMotorWorld : INormalWorld,
        IClimbWorld,
        IDashWorld,
        ISwimWorld,
        IPlayerFrameWorld,
        IPlayerCollisionWorld,
        IPlayerMovementWorld;
}
