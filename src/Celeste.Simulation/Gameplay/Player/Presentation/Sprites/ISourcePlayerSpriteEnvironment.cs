namespace Celeste.Simulation.Gameplay.Player.Presentation.Sprites
{
    public interface ISourcePlayerSpriteEnvironment
    {
        global::Celeste.Simulation.Gameplay.Player.Presentation.PlayerFramesMetadata PlayerMetadata { get; }
        PlayerSprite CreatePlayerSprite(PlayerSpriteMode mode);
    }
}
