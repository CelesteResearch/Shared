using Celeste.Graphics.Animation;

namespace Celeste.Simulation.Gameplay.Collectibles.Refills
{
    public interface IRefillTargetState
    {
        Sprite RefillSprite { get; }
        float RefillRespawnTimer { get; set; }
        bool RefillOneUse { get; set; }
        void RespawnRefill();
    }
}
