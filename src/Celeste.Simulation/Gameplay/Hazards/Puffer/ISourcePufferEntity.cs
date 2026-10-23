using Celeste.Physics.Collision;
using Celeste.Simulation.Gameplay.Interaction.Springs;

namespace Celeste.Simulation.Gameplay.Hazards.Puffer
{
    public interface ISourcePufferEntity : ISourceEntityCollider
    {
        bool HitSpring(ISourceSpringEntity spring);
    }
}
