namespace Celeste.Simulation.Gameplay.Player.Presentation.Sprites
{
    public interface ISourcePlayerSpriteEnvironment
    {
        PlayerFramesMetadata PlayerMetadata { get; }
        PlayerSprite CreatePlayerSprite(PlayerSpriteMode mode);
    }
}
