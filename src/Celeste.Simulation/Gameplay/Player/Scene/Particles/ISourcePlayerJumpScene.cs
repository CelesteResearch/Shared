using System.Numerics;

namespace Celeste.Simulation.Gameplay.Player.Scene.Particles
{
    public interface ISourcePlayerJumpScene
    {
        void BurstPlayerDust(Vector2 position, float direction, int count, int surfaceIndex);
        void BurstPlayerWallSlideDust(RoomPlayerSession actualPlayer, int direction, int surfaceIndex);
        void RecordPlayerJump();
        void RecordPlayerWallJump();
    }
}
