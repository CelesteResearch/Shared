namespace Celeste.Simulation.Gameplay.Player.Dash
{
    public interface IPlayerBoostWorld : IDashWorld
    {
        bool RefillDash();
        void Drop();
        void SyncCollider();
        void RedDashDust(float direction, int count);
        void RedDashDisplacement();
        void RedDashCorrectJumpThrus();
    }
}
