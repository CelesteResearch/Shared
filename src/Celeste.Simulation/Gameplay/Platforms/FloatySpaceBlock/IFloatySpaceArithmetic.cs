namespace Celeste.Simulation.Gameplay.Platforms.FloatySpaceBlock
{
    public interface IFloatySpaceArithmetic
    {
        float GetSine(float phase);
        float GetTargetY(float originalY, float eased, float sine, float dashY);
    }
}
