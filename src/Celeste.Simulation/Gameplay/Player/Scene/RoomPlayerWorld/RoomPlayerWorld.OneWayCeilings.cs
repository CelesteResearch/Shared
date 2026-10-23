namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerWorld
    {
        bool global::Celeste.Simulation.Gameplay.Player.Movement.IPlayerMovementWorld.JumpThruAt(
            System.Numerics.Vector2 offset)
            => Contacts.FloorJumpThruAt(offset);

        bool global::Celeste.Simulation.Gameplay.Player.Movement.IPlayerMovementWorld.JumpThruOutsideAt(
            System.Numerics.Vector2 offset)
            => Contacts.FloorJumpThruOutsideAt(offset);
    }
}
