using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Presentation.Particles
{
    public static class OriginalDust
    {
        public static void Burst(ISourceEngineContext engine, Vector2 position, float direction,
            int count = 1, ParticleTypePresentation particleType = null)
        {
            if (particleType == null)
                particleType = ((IOriginalGameplayProcess)engine).ParticleTypes.Dust;
            Vector2 vector = Vector2Geometry.AngleToVector(direction - (float)Math.PI / 2f, 4f);
            vector.X = Math.Abs(vector.X);
            vector.Y = Math.Abs(vector.Y);
            var level = engine.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot;
            for (int i = 0; i < count; i++)
                level.Particles.Emit(particleType,
                    position + SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -vector, vector),
                    direction);
        }

        public static void BurstFG(ISourceEngineContext engine, Vector2 position, float direction,
            int count = 1, float range = 4f, ParticleTypePresentation particleType = null)
        {
            if (particleType == null)
                particleType = ((IOriginalGameplayProcess)engine).ParticleTypes.Dust;
            Vector2 vector = Vector2Geometry.AngleToVector(direction - (float)Math.PI / 2f, range);
            vector.X = Math.Abs(vector.X);
            vector.Y = Math.Abs(vector.Y);
            var level = engine.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot;
            for (int i = 0; i < count; i++)
                level.ParticlesFG.Emit(particleType,
                    position + SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -vector, vector),
                    direction);
        }
    }
}
