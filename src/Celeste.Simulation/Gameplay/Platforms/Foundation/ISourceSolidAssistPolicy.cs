namespace Celeste.Simulation.Gameplay.Platforms.Foundation
{
// Original-game invincibility flow is supplied by its composition policy.
    public interface ISourceSolidAssistPolicy
    {
        void AfterMovement(SourceSolidEntityState solid);
    }
}
