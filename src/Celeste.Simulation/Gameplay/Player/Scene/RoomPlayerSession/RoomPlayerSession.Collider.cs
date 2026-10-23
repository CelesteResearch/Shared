namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession : global::Celeste.Physics.Collision.ISourceEntityCollider
    {
        public global::Celeste.Physics.Collision.Shapes.ColliderGeometry Hurtbox
        {
            get => World.Contacts.Hurtbox;
            set => World.Contacts.Hurtbox = value;
        }
    }
}
