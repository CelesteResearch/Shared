namespace Celeste.Simulation.Gameplay.Platforms.FloatySpaceBlock
{
    public interface IFloatyPlatformTarget
    {
        float GetTargetY(float origin, float sine, float dashY);
    }
}
