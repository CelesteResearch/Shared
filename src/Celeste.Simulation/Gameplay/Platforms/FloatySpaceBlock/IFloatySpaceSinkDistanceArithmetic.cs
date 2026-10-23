namespace Celeste.Simulation.Gameplay.Platforms.FloatySpaceBlock
{
    public interface IFloatySpaceSinkDistanceArithmetic : IFloatySpaceArithmetic
    {
        float GetTargetY(float originalY, float eased, float sine, float dashY, float sinkDistance);
    }
}
