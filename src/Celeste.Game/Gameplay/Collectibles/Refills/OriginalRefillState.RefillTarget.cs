using Celeste.Graphics.Animation;
using Celeste.Simulation.Gameplay.Collectibles.Refills;

namespace Celeste.Game.Gameplay.Collectibles.Refills
{
    public partial class OriginalRefillState : IRefillTargetState
    {
        public Sprite RefillSprite => sprite;

        public float RefillRespawnTimer
        {
            get => respawnTimer;
            set => respawnTimer = value;
        }

        public bool RefillOneUse
        {
            get => OneUse;
            set => oneUse = value;
        }

        public void RespawnRefill()
        {
            Respawn();
        }
    }
}
