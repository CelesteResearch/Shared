using System.Numerics;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.Gameplay.Hazards.Lightning;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourceLightningScene
    {
        bool ISourceLightningScene.Invincible =>
            ((IOriginalGameplayProcess)EngineContext).SaveContext.CurrentSave.Assists.Invincible;

        void ISourceLightningScene.EmitLightningShatter(Vector2 position, Vector2 range)
        {
            ParticlesFG.Emit(((IOriginalGameplayProcess)EngineContext).ParticleTypes.Lightning.P_Shatter,
                1, position, range);
        }
    }
}
