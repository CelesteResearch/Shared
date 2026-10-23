using System.Numerics;

namespace Celeste.Simulation.Gameplay.Player.Collision.Contacts
{
    public sealed partial class PlayerContacts
    {
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public bool FloorJumpThruAt(Vector2 offset) => JumpThruAt(offset);

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public bool FloorJumpThruOutsideAt(Vector2 offset) => JumpThruOutsideAt(offset);
    }
}
