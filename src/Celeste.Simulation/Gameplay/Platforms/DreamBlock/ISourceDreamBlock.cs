using Celeste.Physics.Collision;

namespace Celeste.Simulation.Gameplay.Platforms.DreamBlock
{
    public interface ISourceDreamBlock : ISourceEntityCollider, ISourceDreamBlockRipple
    {
        void OnPlayerExit(RoomPlayerSession actualPlayer);
    }
}
