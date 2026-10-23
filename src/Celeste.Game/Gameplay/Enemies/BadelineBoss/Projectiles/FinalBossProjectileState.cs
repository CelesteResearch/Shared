using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Scene.Entities;
using Celeste.Graphics.Content;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles
{
    public abstract class FinalBossProjectileState : SceneEntityState
    {
        protected readonly ISourceEngineContext EngineContext;
        protected OriginalLevelSceneRoot CurrentLevel => (OriginalLevelSceneRoot)Scene;

        protected ISourceVectorArithmetic VectorArithmetic =>
            ((ISourceVectorEnvironment)EngineContext).VectorArithmetic;

        protected ISourceExtremaArithmetic ExtremaArithmetic =>
            ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic;

        protected IOriginalGameplayProcess Process => (IOriginalGameplayProcess)EngineContext;
        protected ISourceRandom ProcessRandom => ((ISourceRandomEnvironment)EngineContext).Random;

        protected FinalBossProjectileState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            EngineContext = engine;
        }
    }
}
