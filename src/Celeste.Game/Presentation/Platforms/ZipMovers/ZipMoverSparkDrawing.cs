using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Randomness;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Scene.Entities;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Presentation.Platforms.ZipMovers
{
    public static class ZipMoverSparkDrawing
    {
        public static void Tail(SceneEntityState owner, ISourceEngineContext engine, Vector2 from, Vector2 to,
            Vector2 sparkAdd, float sparkDirFromB, float sparkDirToA, float sparkDirToB,
            ParticleTypePresentation particle = null)
        {
            (owner.Scene as OriginalLevelSceneRoot).ParticlesBG.Emit(
                particle ?? ((IOriginalGameplayProcess)engine).ParticleTypes.ZipMover.P_Sparks,
                SourceVector2Math.Add(SourceVector2Math.Subtract(from, sparkAdd),
                    SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random,
                        SourceVector2Math.Negate(Vector2.One), Vector2.One)), sparkDirFromB);
            (owner.Scene as OriginalLevelSceneRoot).ParticlesBG.Emit(
                particle ?? ((IOriginalGameplayProcess)engine).ParticleTypes.ZipMover.P_Sparks,
                SourceVector2Math.Add(SourceVector2Math.Add(to, sparkAdd),
                    SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random,
                        SourceVector2Math.Negate(Vector2.One), Vector2.One)), sparkDirToA);
            (owner.Scene as OriginalLevelSceneRoot).ParticlesBG.Emit(
                particle ?? ((IOriginalGameplayProcess)engine).ParticleTypes.ZipMover.P_Sparks,
                SourceVector2Math.Add(SourceVector2Math.Subtract(to, sparkAdd),
                    SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random,
                        SourceVector2Math.Negate(Vector2.One), Vector2.One)), sparkDirToB);
        }
    }
}
