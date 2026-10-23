using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Runtime
{
    // Entity/scene adapters supply all collision and interaction queries to the same
    // player state. Other game states can register callbacks on Machine as they are loaded.
    public interface IPlayerMotorWorld : global::Celeste.Simulation.Gameplay.Player.Movement.INormalWorld,
        global::Celeste.Simulation.Gameplay.Player.Movement.IClimbWorld,
        global::Celeste.Simulation.Gameplay.Player.Dash.IDashWorld,
        global::Celeste.Simulation.Gameplay.Player.Movement.ISwimWorld,
        global::Celeste.Simulation.Gameplay.Player.Audio.Frame.IPlayerFrameWorld,
        global::Celeste.Simulation.Gameplay.Player.Collision.Responses.IPlayerCollisionWorld,
        global::Celeste.Simulation.Gameplay.Player.Movement.IPlayerMovementWorld
    {
    }
}
