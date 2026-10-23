using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession : ISourceEntityCollider
    {
        public ColliderGeometry Hurtbox
        {
            get => World.Contacts.Hurtbox;
            set => World.Contacts.Hurtbox = value;
        }
    }
}
