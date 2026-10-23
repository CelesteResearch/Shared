using System.Numerics;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.Gameplay.Player.Scene.Particles;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourcePlayerStarFlyScene
    {
        void ISourcePlayerStarFlyScene.EmitStarFlyParticles(bool boost, int count, Vector2 position, Vector2 range,
            float direction)
        {
            var types = ((IOriginalGameplayProcess)EngineContext).ParticleTypes.FlyFeather;
            Particles.Emit(boost ? types.P_Boost : types.P_Flying, count, position, range, direction);
        }

        void ISourcePlayerStarFlyScene.AddStarFlyBurst(Vector2 position)
        {
            Displacement.AddBurst(position, .25f, 8f, 32f);
        }
    }
}
