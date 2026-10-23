using System.Numerics;
using Celeste.Simulation.Presentation.Backdrops.Formation;

namespace Celeste.Simulation.Gameplay.Player.CassetteFly
{
    public interface ISourcePlayerCassetteScene
    {
        bool CanRetry { get; set; }
        FormationBackdropPresentation FormationBackdrop { get; }
        void EmitCassetteFlyParticles(Vector2 position, int count, Vector2 range);
    }
}
