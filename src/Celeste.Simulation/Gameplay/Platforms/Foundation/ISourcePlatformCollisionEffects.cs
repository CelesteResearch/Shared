namespace Celeste.Simulation.Gameplay.Platforms.Foundation
{
    public interface ISourcePlatformCollisionEffects
    {
        bool ShouldMovePlayerUp(RoomPlayerSession actualPlayer, int move);
        void AfterBreakingWall(SourcePlatformEntityState movingPlatform);
    }
}
