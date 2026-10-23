using System.Numerics;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.Rendering;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : IPlayerDashAssistScene
    {
        void IPlayerDashAssistScene.AddDashAssist(PlayerDashAssistPresentation entity)
        {
            Scheduler.QueueSourceEntity(entity);
        }

        void IPlayerDashAssistScene.PauseGameplaySfx(bool paused)
        {
            sourceAudioSession.PauseGameplaySfx = paused;
        }

        void IPlayerDashAssistScene.PlayDashAssistAim(Vector2 at, int direction)
        {
            sourceAudioSession.Play("event:/game/general/assist_dash_aim", at,
                ((IOriginalGameplayProcess)EngineContext).SaveContext, "dash_direction", direction);
        }
    }
}
