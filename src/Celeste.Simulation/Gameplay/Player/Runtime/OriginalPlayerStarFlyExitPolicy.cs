namespace Celeste.Simulation.Gameplay.Player.Runtime
{
    public sealed class OriginalPlayerStarFlyExitPolicy : ISourcePlayerStarFlyExitPolicy
    {
        public void OnFailure(RoomPlayerSession actualPlayer)
        {
            throw new("Could not get out of solids when exiting Star Fly State!");
        }
    }
}
