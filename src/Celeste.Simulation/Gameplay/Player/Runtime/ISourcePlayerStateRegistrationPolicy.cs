namespace Celeste.Simulation.Gameplay.Player.Runtime
{
    public interface ISourcePlayerStateRegistrationPolicy
    {
        void RegisterStates(RoomPlayerSession player);
    }
}
