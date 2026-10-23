namespace Celeste.Simulation.Gameplay.Player.Launch
{
    public interface ILaunchWorld
    {
        void MoveTowardsX(float target, float maximumMove);
        bool TryPickup();
    }
}
