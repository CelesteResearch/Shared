namespace Celeste.Simulation.Gameplay.Player.Scene
{
    public interface ISourcePlayerCreationExtension
    {
        RoomPlayerSession AfterPlayerCreatedBeforeIntro(RoomPlayerSession player);
    }
}
