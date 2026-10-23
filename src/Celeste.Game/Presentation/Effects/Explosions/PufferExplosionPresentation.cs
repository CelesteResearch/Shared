using System;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.Gameplay.Actors.Foundation;

namespace Celeste.Game.Presentation.Effects.Explosions
{
    public static class PufferExplosionPresentation
    {
        public static void Emit(OriginalLevelSceneRoot level, ISourceEngineContext engine,
            SourceActorEntityState entity)
        {
            level.Displacement.AddBurst(entity.Position, .4f, 12f, 36f, .5f);
            level.Displacement.AddBurst(entity.Position, .4f, 24f, 48f, .5f);
            level.Displacement.AddBurst(entity.Position, .4f, 36f, 60f, .5f);
            for (var a = 0f; a < (float)Math.PI * 2f; a += .17453292f)
            {
                var at = entity.Center + Vector2Geometry.AngleToVector(
                    a + SourceRandomMath.Range(
                        ((ISourceRandomEnvironment)engine).Random,
                        -(float)Math.PI / 90f,
                        (float)Math.PI / 90f),
                    SourceRandomMath.Range(
                        ((ISourceRandomEnvironment)engine).Random, 12, 18));
                level.Particles.Emit(
                    ((IOriginalGameplayProcess)engine)
                    .ParticleTypes.Seeker.P_Regen, at, a);
            }
        }
    }
}
