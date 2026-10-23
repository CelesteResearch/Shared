using System.Numerics;
using Celeste.Simulation.Gameplay.Player.Movement;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerWorld
    {
        bool IPlayerMovementWorld.JumpThruAt(
            Vector2 offset)
        {
            return Contacts.FloorJumpThruAt(offset);
        }

        bool IPlayerMovementWorld.JumpThruOutsideAt(
            Vector2 offset)
        {
            return Contacts.FloorJumpThruOutsideAt(offset);
        }
    }
}
