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
    public static partial class ZipMoverDrawing
    {
        public static void Sparks(SceneEntityState owner, ISourceEngineContext engine, Vector2 from, Vector2 to,
            Vector2 sparkAdd, float sparkDirFromA, float sparkDirFromB, float sparkDirToA, float sparkDirToB,
            ParticleTypePresentation particle)
        {
            (owner.Scene as OriginalLevelSceneRoot).ParticlesBG.Emit(
                particle ?? ((IOriginalGameplayProcess)engine).ParticleTypes.ZipMover.P_Sparks,
                SourceVector2Math.Add(SourceVector2Math.Add(from, sparkAdd),
                    SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random,
                        SourceVector2Math.Negate(Vector2.One), Vector2.One)), sparkDirFromA);
            ZipMoverSparkDrawing.Tail(owner, engine, from, to, sparkAdd,
                sparkDirFromB, sparkDirToA, sparkDirToB, particle);
        }
    }
}
