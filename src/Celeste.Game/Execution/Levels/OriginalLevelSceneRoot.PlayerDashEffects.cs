using System.Numerics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Game.Gameplay.Effects.Slashes;
using Celeste.Game.Presentation.Particles;
using Celeste.Simulation.Gameplay.Player.Scene.Effects;
using Celeste.Simulation.Gameplay.Player.Scene.Particles;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourcePlayerDashEffectsScene
    {
        void ISourcePlayerDashEffectsScene.AddPlayerDashBurst(Vector2 center, float duration, float radiusFrom,
            float radiusTo, float alpha)
        {
            Displacement.AddBurst(center, duration, radiusFrom, radiusTo, alpha,
                ((ISourceEasingEnvironment)EngineContext).EasingArithmetic.QuadOut,
                ((ISourceEasingEnvironment)EngineContext).EasingArithmetic.QuadOut);
        }

        void ISourcePlayerDashEffectsScene.CreatePlayerDashSlash(Vector2 position, float direction)
        {
            OriginalSlashFxState.Burst(EngineContext, position, direction);
        }

        void ISourcePlayerDashEffectsScene.EmitPlayerBirdDashParticle(Vector2 center, Vector2 range, float direction)
        {
            ParticlesFG.Emit(((ISourcePlayerDashParticleEnvironment)EngineContext).DashA,
                center + SourceRandomMath.Range(((ISourceRandomEnvironment)EngineContext).Random, -range, range),
                direction);
        }

        void ISourcePlayerDashEffectsScene.BurstPlayerDashDust(Vector2 position, float direction, int count)
        {
            OriginalDust.Burst(EngineContext, position, direction, count);
        }
    }
}
