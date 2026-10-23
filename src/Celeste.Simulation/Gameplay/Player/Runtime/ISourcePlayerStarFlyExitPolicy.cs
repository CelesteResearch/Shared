namespace Celeste.Simulation.Gameplay.Player.Runtime
{
    public interface ISourcePlayerStarFlyExitPolicy
    {
        void OnFailure(RoomPlayerSession actualPlayer);
    }
}
