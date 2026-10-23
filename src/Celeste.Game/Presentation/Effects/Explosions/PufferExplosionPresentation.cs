using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using System;

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
            for (float a = 0f; a < (float)Math.PI * 2f; a += .17453292f)
            {
                var at = entity.Center + global::Celeste.Core.Mathematics.Vector2Geometry.AngleToVector(
                    a + global::Celeste.Core.Randomness.SourceRandomMath.Range(
                        ((global::Celeste.Core.Randomness.ISourceRandomEnvironment)engine).Random,
                        -(float)Math.PI / 90f,
                        (float)Math.PI / 90f),
                    global::Celeste.Core.Randomness.SourceRandomMath.Range(
                        ((global::Celeste.Core.Randomness.ISourceRandomEnvironment)engine).Random, 12, 18));
                level.Particles.Emit(
                    ((global::Celeste.Game.Execution.Processes.IOriginalGameplayProcess)engine)
                    .ParticleTypes.Seeker.P_Regen, at, a);
            }
        }
    }
}
