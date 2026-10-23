namespace Celeste.Simulation.Gameplay.Platforms.FinalBossMovingBlock
{
    public interface IFinalBossMovingBlock
    {
        float X { get; }
        int BossNodeIndex { get; }
        void StartMoving(float delay);
        void Destroy(float delay);
    }
}
