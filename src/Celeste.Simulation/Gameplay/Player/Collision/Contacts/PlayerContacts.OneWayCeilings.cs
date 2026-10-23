using System.Numerics;
using System.Runtime.CompilerServices;

namespace Celeste.Simulation.Gameplay.Player.Collision.Contacts
{
    public sealed partial class PlayerContacts
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool FloorJumpThruAt(Vector2 offset)
        {
            return JumpThruAt(offset);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool FloorJumpThruOutsideAt(Vector2 offset)
        {
            return JumpThruOutsideAt(offset);
        }
    }
}
