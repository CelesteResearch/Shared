using System.Numerics;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.Gameplay.Environment.Water;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourceWaterInteractionParticleScene
    {
        void ISourceWaterInteractionParticleScene.EmitWaterDrip(Vector2 position)
        {
            ParticlesFG.Emit(((IOriginalGameplayProcess)EngineContext).ParticleTypes.WaterInteraction.P_Drip,
                position);
        }
    }
}
