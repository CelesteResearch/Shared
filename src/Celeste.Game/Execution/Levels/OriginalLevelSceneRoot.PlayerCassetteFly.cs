using System.Numerics;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.Gameplay.Player.CassetteFly;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourcePlayerCassetteScene
    {
        bool ISourcePlayerCassetteScene.CanRetry
        {
            get => CanRetry;
            set => CanRetry = value;
        }

        void ISourcePlayerCassetteScene.EmitCassetteFlyParticles(Vector2 position, int count, Vector2 range)
            => Particles.Emit(((IOriginalGameplayProcess)EngineContext).ParticleTypes.Player.P_CassetteFly,
                count, position, range);
    }
}
