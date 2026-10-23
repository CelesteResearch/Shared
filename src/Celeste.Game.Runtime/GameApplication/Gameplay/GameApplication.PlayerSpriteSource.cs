using Celeste.Simulation.Gameplay.Player.Presentation;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourcePlayerSpriteEnvironment
    {
        public PlayerFramesMetadata PlayerMetadata => GraphicsResources.PlayerMetadata;

        public PlayerSprite CreatePlayerSprite(PlayerSpriteMode mode)
        {
            return new(this, mode);
        }
    }
}
