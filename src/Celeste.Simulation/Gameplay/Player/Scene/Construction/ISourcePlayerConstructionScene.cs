using System.Numerics;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;

namespace Celeste.Simulation.Gameplay.Player.Scene.Construction
{
    public interface ISourcePlayerConstructionScene
    {
        RoomPlayerSession CreatePlayer(Vector2 position, PlayerSpriteMode spriteMode);
    }
}
